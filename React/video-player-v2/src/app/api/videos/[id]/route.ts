import { NextResponse } from "next/server";
import { getVideoById } from "@/lib/video-storage";

export async function GET(_request: Request, {params} : {params: Promise<{id: string}>}) {
    try {
        const video = getVideoById((await params).id);
        if (!video) return NextResponse.json({error: "video not found"}, {status: 404})
        return NextResponse.json({video})
    } catch (err) {
        return NextResponse.json({error: "Failed to fetch video"}, {status: 500})
    }
}