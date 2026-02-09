"use client";
import React, { useState, useRef, useEffect } from "react";
import CodeEditor from "@/components/CodeEditor";
import { backgrounds, languages, themes } from "@/utils/utilities";
import LanguageSelector from "@/components/LanguageSelector";
import ThemeSelector from "@/components/ThemeSelector";
import BackgroundSelector from "@/components/BackgroundSelector";
import PaddingSelector from "@/components/PaddingSelector";
import { Download } from "lucide-react";
import Footer from "@/components/Footer";
import { toPng } from "html-to-image";

export default function Home() {
  const editorRef = useRef(null);

  const [language, setLanguage] = useState(languages[0].name);
  const [theme, setTheme] = useState(themes[0]);
  const [background, setBackground] = useState(backgrounds[0]);
  const [activeIcon, setActiveIcon] = useState(languages[0].icon);
  const [paddings, setPaddings] = useState(["1rem", "2rem", "3rem", "4rem"]);
  const [currentPadding, setCurrentPadding] = useState(paddings[2]);

  const exportPng = async () => {
    const editorElem = editorRef.current;

    if (!editorElem) {
      console.error("Elementul editorRef nu este disponibil.");
      return;
    }

    // Ascundem temporar elementele de UI care nu vrem să apară în export
    const handleElems = document.querySelectorAll(".handle");
    const cursorElem = document.querySelector(".ace_cursor");
    const codetitle = document.querySelector(".code-title");
    const codeEditor = document.querySelector(".ace_editor");

    handleElems.forEach(
      (elem) => ((elem as HTMLElement).style.display = "none")
    );
    if (cursorElem) (cursorElem as HTMLElement).style.display = "none";
    if (codetitle) (codetitle as HTMLElement).style.boxShadow = "none";
    if (codeEditor) (codeEditor as HTMLElement).style.boxShadow = "none";

    try {
      const dataUrl = await toPng(editorElem, { cacheBust: true });

      const link = document.createElement("a");
      link.download = "code.png";
      link.href = dataUrl;

      // Asta e important: link-ul trebuie adăugat în DOM pentru unele browsere
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
    } catch (err) {
      console.error("Eroare la export:", err);
    }

    // Reafișăm elementele ascunse
    handleElems.forEach(
      (elem) => ((elem as HTMLElement).style.display = "block")
    );
    if (cursorElem) (cursorElem as HTMLElement).style.display = "block";
    if (codetitle)
      (codetitle as HTMLElement).style.boxShadow =
        "0 3px 10px rgba(0, 0, 0, 0.2)";
    if (codeEditor)
      (codeEditor as HTMLElement).style.boxShadow =
        "2px 3px 10px rgba(0, 0, 0, 0.2)";
  };

  return (
    <main className="h-[100vh] flex flex-col items-center justify-between">
      <header className="mt-6 flex gap-6 w-[940px] p-5 fixed top-0 left-1/2 translate-x-[-50%] z-10 bg-[#191919] rounded border border-[#3C3C3C] shadow-md">
        <LanguageSelector
          language={language}
          setLanguage={setLanguage}
          setActiveIcon={setActiveIcon}
        />
        <ThemeSelector theme={theme} setTheme={setTheme} />
        <BackgroundSelector
          background={background}
          setBackground={setBackground}
        />
        <PaddingSelector
          paddings={paddings}
          currentPadding={currentPadding}
          setCurrentPadding={setCurrentPadding}
        />
        <div className="export-btn self-center ml-auto">
          <button
            className="flex items-center gap-3 py-2 px-3 bg-blue-600 rounded-md text-sm text-white font-medium hover:bg-blue-700 ease-in-out transition-all duration-300"
            onClick={exportPng}
          >
            <Download />
            Export PNG
          </button>
        </div>
      </header>

      <div className="code-editor-ref mt-[14rem]">
        <CodeEditor
          ref={editorRef}
          language={language}
          theme={theme}
          background={background}
          icon={activeIcon}
          currentPadding={currentPadding}
        />
      </div>

      <Footer />
    </main>
  );
}
