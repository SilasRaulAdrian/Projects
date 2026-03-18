import { notFound } from "next/navigation";
import { getVideoById } from "@/lib/video-storage";
import SimplePlayer from "@/components/video/player/SimplePlayer";
import Link from "next/link";
import "@/styles/watch.css";

interface Props {
  params: Promise<{ id: string }>;
}

export const dynamic = "force-dynamic";

export default async function WatchPage({ params }: Props) {
  const { id } = await params;
  const video = getVideoById(id);

  if (!video) notFound();

  return (
    <div>
      <Link href="/" className="back-link">
        Back to Library
      </Link>
      <div className="video-container">
        <SimplePlayer
          video={video}
          urlEndpoint={process.env.NEXT_PUBLIC_IMAGEKIT_URL_ENDPOINT!}
        />
      </div>
      <h1 className="video-title">{video.title}</h1>
      {video.description && (
        <p className="video-description">{video.description}</p>
      )}
    </div>
  );
}
