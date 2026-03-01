# AI Projects Portfolio

A collection of hands-on AI projects built with Python, exploring local LLMs, computer vision, and intelligent agents. Each project is self-contained, runs entirely offline (where applicable), and demonstrates a different area of applied AI development.

---

## Projects

### 1. ReAct Agent with LangGraph & Ollama

An AI assistant built on the **ReAct (Reasoning + Acting)** architecture using LangGraph and a local LLM. The agent can hold natural conversations and autonomously decide when to call tools to assist with tasks.

**Key concepts:** Agent loops, tool use, LangGraph, local LLMs, streaming responses

**Tech stack:**
- `LangGraph` — orchestrates the ReAct agent loop
- `LangChain` — tool definition and message handling
- `Ollama` + `llama3.2` — local language model (no API key needed)

**How it works:**
The agent receives user input, reasons about whether a tool is needed, calls it if so, observes the result, and then formulates a final response. This loop continues until the agent is confident in its answer.

**Features:**
- Interactive CLI chat interface
- Built-in calculator tool (extensible to any function)
- Fully local — no data sent to external servers
- Streamed token-by-token output

---

### 2. AI Resume Critiquer

A **Streamlit** web app that analyzes your resume and provides structured, AI-powered feedback tailored to a specific job role. Upload a PDF or TXT file and get actionable suggestions in seconds.

**Key concepts:** Document processing, prompt engineering, local LLMs, Streamlit UI

**Tech stack:**
- `Streamlit` — interactive web interface
- `PyPDF2` — PDF text extraction
- `Ollama` + `llama3.2` via OpenAI-compatible endpoint — local LLM inference

**How it works:**
The app extracts text from the uploaded resume, builds a detailed prompt that instructs the model to act as an expert HR recruiter, and streams the structured feedback directly into the UI.

**Features:**
- Supports `.pdf` and `.txt` resume formats
- Optional job role targeting for tailored feedback
- Reviews clarity, skills presentation, experience descriptions, and role-fit
- Fully local — your resume never leaves your machine

---

### 3. AI Image Classifier

A **Streamlit** web app that uses a pre-trained **MobileNetV2** neural network to identify the contents of any uploaded image, returning the top 3 predictions with confidence scores.

**Key concepts:** Computer vision, transfer learning, image preprocessing, CNN inference

**Tech stack:**
- `Streamlit` — interactive web interface
- `TensorFlow / Keras` — MobileNetV2 model and ImageNet weights
- `OpenCV` + `Pillow` — image loading and preprocessing

**How it works:**
The uploaded image is resized to 224×224 pixels and normalized to match MobileNetV2's expected input format. The model runs inference and the top 3 matching ImageNet categories are decoded and displayed with their confidence percentages.

**Features:**
- Supports `.jpg`, `.jpeg`, and `.png` images
- Recognizes 1000 ImageNet object categories
- Model cached after first load for fast repeated use
- No GPU required — runs efficiently on CPU

---

## Shared Prerequisites

All projects require:

- **Python 3.9+**
- **Ollama** (for projects 1 & 2) — [ollama.com](https://ollama.com)
- **llama3.2** model pulled locally:
  ```bash
  ollama pull llama3.2
  ```

### Install all dependencies at once

```bash
pip install langchain langchain-ollama langgraph streamlit PyPDF2 openai \
            tensorflow opencv-python pillow numpy python-dotenv
```

---

## Running the Projects

| Project | Command |
|---|---|
| ReAct Agent | `python main.py` |
| Resume Critiquer | `streamlit run resume_app.py` |
| Image Classifier | `streamlit run image_app.py` |

---

## Repository Structure

```
.
├── react-agent/
│   ├── main.py
│   └── README.md
├── resume-critiquer/
│   ├── app.py
│   └── README.md
├── image-classifier/
│   ├── app.py
│   └── README.md
└── README.md          ← You are here
```

---

## What I Learned

These projects collectively cover a wide range of modern AI engineering skills:

- **Agentic AI** — building systems where the model decides when and how to use tools
- **Prompt engineering** — crafting prompts that produce structured, reliable outputs
- **Local LLM deployment** — running open-source models privately with Ollama
- **Computer vision** — leveraging pre-trained CNNs for real-world image classification
- **Full-stack AI apps** — combining ML models with interactive web UIs using Streamlit

---

## Author

Built with curiosity and a lot of `pip install`. Feel free to explore, fork, and extend any of these projects.
