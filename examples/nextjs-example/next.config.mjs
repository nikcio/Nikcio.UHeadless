// UHeadless runs with a self-signed certificate in development.
// Allow Node's fetch to accept it when running the dev server.
if (process.env.NODE_ENV === 'development') {
    process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';
}

/** @type {import('next').NextConfig} */
const nextConfig = {};

export default nextConfig;
