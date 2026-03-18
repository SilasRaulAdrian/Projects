"use client";

import { Image } from "@imagekit/next";
import { Video } from "@/types/video";
import Link from "next/link";
import "@/styles/library.css";

interface Props {
  videos: Video[];
}

export default function VideoLibrary({ videos }: Props) {
  const urlEndpoint = process.env.NEXT_PUBLIC_IMAGEKIT_URL_ENDPOINT || "";

  if (videos.length === 0) {
    return (
      <div className="library-empty">
        <p className="library-empty-text">No videos yet</p>
        <Link href="/upload" className="library-upload-button">
          Upload Video
        </Link>
      </div>
    );
  }

  return (
    <div className="library-grid">
      {videos.map((video) => (
        <Link key={video.id} href={`/watch/${video.id}`}>
          <div className="thumbnail-card">
            <Image
              urlEndpoint={urlEndpoint}
              src={video.thumbnailPath || `${video.filePath}/ik-thumbnail.jpg`}
              alt={video.title}
              width={320}
              height={180}
              className="thumbnail-image"
              transformation={[{ width: 320, height: 180 }]}
            />
          </div>
          <div className="thumbnail-info">
            <h3 className="thumbnail-title">{video.title}</h3>
            <p className="thumbnail-date">
              {new Date(video.createdAt).toISOString().split("T")[0]}
            </p>
          </div>
        </Link>
      ))}
    </div>
  );
}
