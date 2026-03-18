"use client";

import { useState } from "react";
import { upload } from "@imagekit/next";
import { useRouter } from "next/navigation";
import "@/styles/upload.css";

export default function VideoUpload() {
  const router = useRouter();
  const [form, setForm] = useState({ title: "", description: "" });
  const [files, setFiles] = useState<Record<string, File | null>>({
    video: null,
    thumbnail: null,
    watermark: null,
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const uploadFile = async (file: File, folder: string) => {
    const auth = await fetch("/api/upload-auth").then((r) => r.json());
    return upload({ file, fileName: file.name, folder, ...auth });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!files.video) return;

    setLoading(true);
    setError("");

    try {
      const [videoRes, thumbRes, wmRes] = await Promise.all([
        uploadFile(files.video, "/videos"),
        files.thumbnail ? uploadFile(files.thumbnail, "/thumbnails") : null,
        files.watermark ? uploadFile(files.watermark, "/watermarks") : null,
      ]);

      const res = await fetch("/api/videos", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          title: form.title,
          description: form.description,
          filePath: videoRes.filePath || "",
          fileName: videoRes.name || files.video.name,
          thumbnailPath: thumbRes?.filePath || "",
          watermark: wmRes
            ? {
                imagePath: wmRes.filePath || "",
                position: "bottom_right",
                opacity: 0.7,
                width: 120,
              }
            : undefined,
        }),
      });

      if (!res.ok) throw new Error("Failed to save");
      const { video } = await res.json();
      router.push(`/videos/${video.id}`);
    } catch (err) {
      setError(err instanceof Error ? err.message : "Upload failed");
      setLoading(false);
    }
  };

  const setFile = (key: string) => (e: React.ChangeEvent<HTMLInputElement>) => {
    setFiles((f) => ({ ...f, [key]: e.target.files?.[0] || null }));
  };

  return (
    <form onSubmit={handleSubmit} className="upload-form">
      {error && <div className="upload-error">{error}</div>}

      <div className="form-group">
        <label className="form-label">Title</label>
        <input
          type="text"
          value={form.title}
          onChange={(e) => setForm((f) => ({ ...f, title: e.target.value }))}
          className="form-input"
          placeholder="Video Title"
        />
      </div>

      <div className="form-group">
        <label className="form-label">Description</label>
        <input
          type="text"
          value={form.description}
          onChange={(e) =>
            setForm((f) => ({ ...f, description: e.target.value }))
          }
          className="form-input"
          placeholder="Video description"
        />
      </div>

      <div className="form-group">
        <label className="form-label">Video File *</label>
        <input type="file" accept="video/*" onChange={setFile("video")} />
      </div>

      <div className="form-group">
        <label className="form-label">Thumbnail File (optional)</label>
        <input type="file" accept="image/*" onChange={setFile("thumbnail")} />
      </div>

      <div className="form-group">
        <label className="form-label">Watermark File (optional)</label>
        <input type="file" accept="image/*" onChange={setFile("watermark")} />
      </div>

      <button
        type="submit"
        disabled={loading || !files.video}
        className="submit-button"
      >
        {loading ? "Uploading" : "Upload"}
      </button>
    </form>
  );
}
