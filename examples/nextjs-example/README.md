# UHeadless Next.js Example

A minimal [Next.js](https://nextjs.org/) (App Router) example showing how to connect to a
[UHeadless](https://github.com/Nikcio/Nikcio.UHeadless) GraphQL API and fetch content by route.

## What this demonstrates

- Building an authenticated [`@urql/core`](https://github.com/urql-graphql/urql) GraphQL client that:
  - mints a short-lived scoped token using the UHeadless API key
  - attaches the token to every request
  - refreshes the token on authentication errors
- Querying the `contentByRoute` field from a catch-all route (`app/[[...slug]]/page.tsx`)
  and rendering the page name, its children, and the raw response.

## What was added on top of a barebones `create-next-app`

A barebones Next.js install (TypeScript template, no styling/ESLint/Tailwind extras) only
ships the framework. On top of that, this example adds only what is needed to talk to the
GraphQL API:

| Addition | Why |
| --- | --- |
| `@urql/core` | The GraphQL client used to query the UHeadless endpoint. |
| `@urql/exchange-auth` | Adds the authentication exchange that mints and refreshes scoped tokens. |
| `lib/uheadless/client.ts` | `createClient(scopes)` helper that wires the API key, token minting and the auth exchange together. |
| `app/[[...slug]]/page.tsx` | A server component that builds the route from the URL, queries `contentByRoute` and renders the result. |
| `next.config.mjs` | Disables TLS certificate verification in development so the self-signed Umbraco dev cert is accepted. |

Everything else (layout, `globals.css`, `tsconfig.json`, `next.config.mjs`, `.gitignore`)
is the default Next.js TypeScript template content, trimmed down.

## Backend

This example expects a running UHeadless GraphQL endpoint. Use the
[`starter-example`](../starter-example) project — a minimal Umbraco + UHeadless setup that
enables API-key authentication and exposes the `contentByRoute` query this example calls.

Run it, then update `GRAPHQL_ENDPOINT` and `API_KEY` below to match your instance.

## Configuration

Edit `lib/uheadless/client.ts`:

- `GRAPHQL_ENDPOINT` — the URL of your Umbraco UHeadless GraphQL endpoint.
- `API_KEY` — the API key configured in UHeadless on the Umbraco side.

## Getting started

### 1. Start the backend (Umbraco + UHeadless)

```bash
dotnet run --project examples/starter-example
```

This launches Umbraco with the UHeadless GraphQL endpoint at `https://localhost:44368/graphql/`
(the default URL used by this example).

### 2. Start the frontend (Next.js)

```bash
cd examples/nextjs-example
pnpm install
pnpm dev
```

Open [http://localhost:3000](http://localhost:3000). Navigating to any path (e.g.
`/about`) queries the UHeadless API for the content at that route.

> The API key in `lib/uheadless/client.ts` matches the one in the starter-example's
> `appsettings.json`. Update both locations if you change it.
