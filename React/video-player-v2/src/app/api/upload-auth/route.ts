import { getUploadAuthParams } from "@imagekit/next/server";
import { NextResponse } from "next/server";

export async function GET() {
    try {
        const privateKey = process.env.IMAGEKIT_PRIVATE_KEY
        const publicKey = process.env.IMAGEKIT_PUBLIC_KEY
        if (!privateKey || !publicKey) {
            return NextResponse.json({error: "ImageKit keys not configured"})
        }
        return NextResponse.json({
            ...getUploadAuthParams({
                privateKey,
                publicKey,
            }),
            publicKey
        })
    } catch (err) {
        console.error("Upload auth error:", err)
        return NextResponse.json({error: "Failed to generate credntials"})
    }
}