import { Client, fetchExchange, gql } from '@urql/core';
import { authExchange } from '@urql/exchange-auth';

// The UHeadless GraphQL endpoint exposed by your Umbraco site.
const GRAPHQL_ENDPOINT = 'https://localhost:44368/graphql/';

// API key configured in the UHeadless settings on the Umbraco side.
const API_KEY = 'qLV$6eo5*2OBX9yGGz*BiQVnGlr778nDmy!GX60A@JwL1Ql&AFQRkru!#zW9XVTqF2zzc1O7Q4XIcwuMZDUDNrsfdy3gw5Ey7P@';

// Scopes granted to the short-lived token. Add the scopes your queries need.
type UHeadlessScope = 'content.by.route.query' | 'global.content.read';

type Token = {
    createToken: { expires: number; header: string; prefix: string; token: string };
};

const createTokenMutation = gql`
    mutation createToken($scope: Any) {
        createToken(claims: [{ name: "headless-scope", value: $scope }]) {
            expires
            header
            prefix
            token
        }
    }
`;

const isTokenExpired = (token: Token) => Date.now() > token.createToken.expires * 1000;

// Unauthenticated client used only to mint scoped tokens via the API key.
const tokenClient = new Client({
    url: GRAPHQL_ENDPOINT,
    exchanges: [fetchExchange],
    fetchOptions: {
        headers: { 'X-UHeadless-Api-Key': API_KEY },
        cache: 'no-cache',
    },
    requestPolicy: 'network-only',
});

const tokenCache = new Map<string, Token>();

async function createToken(scopes: UHeadlessScope[]): Promise<Token> {
    const key = scopes.join(',');
    const cached = tokenCache.get(key);
    if (cached && !isTokenExpired(cached)) {
        return cached;
    }

    const { data, error } = await tokenClient.mutation(createTokenMutation, { scope: scopes });

    if (error || !data) {
        throw new Error(`Failed to create token: ${error?.message ?? 'no data'}`);
    }

    tokenCache.set(key, data);
    return data;
}

// Creates an authenticated GraphQL client that mints a scoped token with the
// API key and attaches it to every request, refreshing it on auth errors.
export function createClient(scopes: UHeadlessScope[]): Client {
    return new Client({
        url: GRAPHQL_ENDPOINT,
        exchanges: [
            authExchange(async (utils) => {
                let token = await createToken(scopes);

                return {
                    addAuthToOperation(operation) {
                        return utils.appendHeaders(operation, {
                            [token.createToken.header]: token.createToken.prefix + token.createToken.token,
                        });
                    },
                    willAuthError() {
                        return isTokenExpired(token);
                    },
                    didAuthError(error) {
                        return error.graphQLErrors.some((e) => e.extensions?.code === 'AUTH_NOT_AUTHORIZED');
                    },
                    async refreshAuth() {
                        token = await createToken(scopes);
                    },
                };
            }),
            fetchExchange,
        ],
        fetchOptions: { next: { revalidate: 60 } },
    });
}
