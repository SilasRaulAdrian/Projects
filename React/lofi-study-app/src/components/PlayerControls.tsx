import React, { useEffect, useRef, useState } from "react";
import type { Song } from "../types/types";
import prev from "../assets/icons/icon--next.png";
import play from "../assets/icons/icon--play.png";
import pause from "../assets/icons/icon--pause.png";
import next from "../assets/icons/icon--next.png";
import musicCategories from "../data/musicCategories";
import VolumeControl from "./VolumeControl";

interface Props {
  activeMusicCategory: number;
  currentTrack: Song | null;
  songIndex: number;
  setSongIndex: React.Dispatch<React.SetStateAction<number>>;
  setCurrentTrack: React.Dispatch<React.SetStateAction<Song | null>>;
}

function PlayerControls({
  activeMusicCategory,
  currentTrack,
  songIndex,
  setSongIndex,
  setCurrentTrack,
}: Props) {
  const audioRef = useRef<HTMLAudioElement>(null);
  const [isPlaying, setIsPlaying] = useState<boolean>(false);
  const [volume, setVolume] = useState<number>(20);
  const [isMuted, setIsMuted] = useState<boolean>(false);

  useEffect(() => {
    if (isPlaying) {
      audioRef.current?.play();
    } else {
      audioRef.current?.pause();
    }
  }, [isPlaying, currentTrack]);

  // keep current track in sync with song index and active music category
  useEffect(() => {
    setCurrentTrack(musicCategories[activeMusicCategory].music[songIndex]);
  }, [songIndex, activeMusicCategory]);

  useEffect(() => {
    const audio = audioRef.current;

    if (!audio) return;

    const handleEnded = () => {
      // next song
      nextSong();
    };

    audio.addEventListener("ended", handleEnded);
    return () => {
      audio.removeEventListener("ended", handleEnded);
    };
  }, [activeMusicCategory]);

  useEffect(() => {
    if (!audioRef.current) return;
    audioRef.current.volume = isMuted ? 0 : volume / 100;
  }, [volume, isMuted]);

  const nextSong = () => {
    setSongIndex((prevIndex) => {
      const nextIndex =
        prevIndex < musicCategories[activeMusicCategory].music.length - 1
          ? prevIndex + 1
          : 0;

      return nextIndex;
    });
    setIsPlaying(true);
  };

  const prevSong = () => {
    setSongIndex((prevIndex) =>
      prevIndex > 1
        ? prevIndex - 1
        : musicCategories[activeMusicCategory].music.length - 1,
    );
  };

  return (
    <div className="flex items-center justify-center gap-4 sm:gap-8 flex-wrap">
      <button
        className="rotate-180 w-10 sm:w-11.5 cursor-pointer hover:scale-105 transition-transform ease-in-out duration-200"
        onClick={prevSong}
      >
        <img src={prev} alt="Previous" className="invert" />
      </button>

      <button
        className="cursor-pointer w-12 sm:w-15 hover:scale-105 transition-transform ease-in-out duration-200"
        onClick={() => setIsPlaying(!isPlaying)}
      >
        <img
          src={isPlaying ? pause : play}
          className="invert"
          alt={isPlaying ? "Pause" : "Play"}
        />
      </button>

      <button
        className="w-10 sm:w-11.5 cursor-pointer hover:scale-105 transition-transform ease-in-out duration-200"
        onClick={nextSong}
      >
        <img src={next} className="invert" alt="Next" />
      </button>

      <VolumeControl
        volume={volume}
        isMuted={isMuted}
        onVolumeChange={setVolume}
        onToggleMute={() => setIsMuted((prev) => !prev)}
      />

      <audio ref={audioRef} src={currentTrack?.src || ""} autoPlay />
    </div>
  );
}

export default PlayerControls;
