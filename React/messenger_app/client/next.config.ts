import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  images: {
    domains: [
      "localhost",
      "avatars.githubusercontent.com",
      "xsgames.co",
      "files.edgestore.dev",
    ],
  },
};

export default nextConfig;
