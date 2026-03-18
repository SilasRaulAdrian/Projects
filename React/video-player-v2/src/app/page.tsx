import VideoLibrary from "@/components/video/VideoLibrary";
import { getAllVideos } from "@/lib/video-storage";

export default function Home() {
  const videos = getAllVideos();

  return (
    <div>
      <h1 className="page-title">Video Library</h1>
      <VideoLibrary videos={videos} />
    </div>
  );
}
