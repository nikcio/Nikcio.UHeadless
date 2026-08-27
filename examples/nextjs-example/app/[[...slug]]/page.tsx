import { gql } from '@urql/core';
import { createClient } from '@/lib/uheadless/client';
import Link from 'next/link';

type ContentChild = { name: string; url: string };
type ContentByRoute = { name: string; url: string; children: (ContentChild | null)[] } | null;

const contentByRouteQuery = gql`
    query contentByRoute($route: String!, $culture: String, $includePreview: Boolean) {
        contentByRoute(
            route: $route
            inContext: { culture: $culture, includePreview: $includePreview }
        ) {
            name
            url(urlMode: ABSOLUTE)
            children {
                name
                url(urlMode: RELATIVE)
            }
        }
    }
`;

export default async function Page({ params }: { params: Promise<{ slug?: string[] }> }) {
    const { slug } = await params;
    const route = '/' + (slug?.join('/') ?? '');

    const client = createClient(['content.by.route.query']);

    const { data, error } = await client.query(contentByRouteQuery, {
        route,
        culture: null,
        includePreview: false,
    });

    if (error) {
        return (
            <main>
                <h1>Error</h1>
                <pre>{JSON.stringify(error, null, 2)}</pre>
            </main>
        );
    }

    const content: ContentByRoute = data?.contentByRoute ?? null;

    return (
        <main>
            <h1>{content?.name ?? 'Not found'}</h1>
            <p>Route: {route}</p>

            {content?.children?.length ? (
            <nav>
                <h2>Children</h2>
                <ul>
                    {content.children
                        .filter((child): child is { name: string; url: string } => child != null)
                        .map((child) => (
                            <li key={child.url}>
                                <Link href={child.url}>{child.name}</Link>
                            </li>
                        ))}
                </ul>
            </nav>
            ) : null}

            <h2>Raw response</h2>
            <pre>{JSON.stringify(data, null, 2)}</pre>
        </main>
    );
}
