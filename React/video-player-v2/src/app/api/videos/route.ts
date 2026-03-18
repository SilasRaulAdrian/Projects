import { NextRequest, NextResponse } from "next/server";
import { getAllVideos, saveVideo } from "@/lib/video-storage";
import {Video} from "@/types/video"
import {v4 as uuidv4} from "uuid";

export async function GET() {
    try {
        return NextResponse.json({videos: getAllVideos()})
    } catch (err) {
        return NextResponse.json({error: "failed to fetch videos"}, {status: 500})
    }
}

export async function POST(request: NextRequest) {
    try {
        const body = await request.json();
        const video: Video = {
            id: uuidv4(),
            title: body.title || "Untitled Video",
            description: body.description || "",
            filePath: body.filePath,
            fileName: body.fileName,
            thumbnailPath: body.thumbnailPath || "",
            duration: body.duration,
            createdAt: new Date().toISOString(),
            watermark: body.watermark
        }
        return NextResponse.json({video: saveVideo(video)}, {status: 201})
    } catch (err) {
        return NextResponse.json({error: "Failed to create video"}, {status: 500})
    }
}