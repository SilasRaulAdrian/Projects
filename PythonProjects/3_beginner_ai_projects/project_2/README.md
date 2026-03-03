# AI Resume Critiquer

A **Streamlit** web app that lets you upload your resume and receive AI-powered feedback — all running locally with **Ollama**, no cloud API required.

---

## How It Works

The app extracts text from your uploaded resume (PDF or TXT), then sends it to a local LLM (`llama3.2` via Ollama) along with a structured prompt. The model acts as an expert HR recruiter and returns detailed, actionable feedback on your resume.

### Flow

```
User uploads resume (PDF / TXT)
        ↓
Text is extracted from the file
        ↓
Prompt is built (resume text + optional job role)
        ↓
Sent to llama3.2 via Ollama (OpenAI-compatible endpoint)
        ↓
Structured feedback is displayed in the browser
```

### What the AI Reviews

1. **Content clarity and impact** — is your resume easy to read and compelling?
2. **Skills presentation** — are your skills highlighted effectively?
3. **Experience descriptions** — are your roles described with impact?
4. **Role-specific improvements** — tailored tips for a specific job role (if provided)

---

## Requirements

- Python 3.9+
- [Ollama](https://ollama.com) installed and running locally
- `llama3.2` model pulled in Ollama

### Install dependencies

```bash
pip install streamlit PyPDF2 openai python-dotenv
```

### Pull the model

```bash
ollama pull llama3.2
```

---

## Setup

1. Clone or copy the project files.
2. Create a `.env` file in the root (can be empty or hold custom vars):
   ```
   # .env
   ```
3. Make sure Ollama is running:
   ```bash
   ollama serve
   ```

---

## Usage

Start the Streamlit app:

```bash
streamlit run app.py
```

Your browser will open automatically at `http://localhost:8501`.

### Steps in the UI

1. **Upload your resume** — supports `.pdf` and `.txt` files
2. **Enter a target job role** *(optional)* — e.g. `"Senior Backend Engineer"` for tailored feedback
3. Click **Analyze Resume**
4. Read the structured AI feedback below

---

## Project Structure

```
.
├── app.py        # Main Streamlit application
├── .env          # Environment variables (optional)
└── README.md     # This file
```

---

## Notes

- The app runs **entirely offline** — no data leaves your machine.
- The LLM is accessed through Ollama's **OpenAI-compatible endpoint** (`/v1`), using `api_key="ollama"` as a placeholder (no real key needed).
- `temperature=0.7` gives slightly varied but coherent responses each time.
- To use a different model, change `model="llama3.2"` in `app.py` to any model available in your Ollama instance.
- Max response length is capped at **1000 tokens** — increase `max_tokens` for longer feedback.
