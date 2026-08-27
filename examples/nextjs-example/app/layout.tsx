import type { Metadata } from 'next';
import './globals.css';

export const metadata: Metadata = {
    title: 'UHeadless Next.js Example',
    description: 'Minimal example fetching content from a UHeadless GraphQL API',
};

export default function RootLayout({
    children,
}: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <html lang="en">
            <body>{children}</body>
        </html>
    );
}
