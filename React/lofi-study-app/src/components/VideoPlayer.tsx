import { useEffect, useRef, useState } from "react";

interface Props {
  video: string | null;
}

function VideoPlayer({ video }: Props) {
  const videoRef = useRef<HTMLVideoElement>(null);
  const [currentVideo, setCurrentVideo] = useState<string | null>(video);
  const [fade, setFade] = useState<boolean>(false);

  // handle video change
  useEffect(() => {
    if (!video) return;

    if (videoRef.current) {
      // fade out
      setFade(true);

      // wait for the fade-out transition to complete before changing the video
      const timeout = setTimeout(() => {
        setCurrentVideo(video);
        setFade(false);
        videoRef.current?.play();
      }, 100);

      return () => clearTimeout(timeout);
    }
  }, [video]);
  return (
    <div className="fixed inset-0">
      <video
        ref={videoRef}
        loop
        src={currentVideo || undefined}
        autoPlay
        muted
        className={`object-cover w-full h-full transition-opacity duration-200 ${
          fade ? "opacity-0" : "opacity-100"
        }`}
      />
    </div>
  );
}

export default VideoPlayer;
