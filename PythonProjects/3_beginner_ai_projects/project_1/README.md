#  LangGraph ReAct Agent with Ollama

A local AI assistant built with **LangGraph** and **Ollama** that can hold conversations and perform tool-based actions using the ReAct (Reasoning + Acting) agent pattern.

---

## How It Works

This project uses the **ReAct agent** architecture, where the model alternates between:

1. **Reasoning** — the model thinks about what to do next
2. **Acting** — the model calls a tool if needed
3. **Observing** — the model reads the tool's output and decides the next step

The agent is powered by a **local LLM** (`llama3.2`) running via [Ollama](https://ollama.com), so no API keys or cloud services are required. LangGraph orchestrates the agent loop, and LangChain tools provide the callable functions.

### Components

| Component | Role |
|---|---|
| `ChatOllama` | Runs the LLM locally via Ollama |
| `create_react_agent` | Builds the ReAct agent loop with LangGraph |
| `@tool` (calculator) | A tool the agent can call to add two numbers |
| `agent_executor.stream()` | Streams the agent's response token by token |

### Flow

```
User input
    ↓
ReAct Agent
    ↓
Does it need a tool? ──Yes──→ Call calculator(a, b) → Get result
    ↓ No                                                    ↓
Respond directly ←──────────────────────────────── Use result in response
```

---

## Requirements

- Python 3.9+
- [Ollama](https://ollama.com) installed and running locally
- `llama3.2` model pulled in Ollama

### Install dependencies

```bash
pip install langchain langchain-ollama langgraph python-dotenv
```

### Pull the model

```bash
ollama pull llama3.2
```

---

## Setup

1. Clone or copy the project files.
2. Create a `.env` file in the root directory (can be empty, or add custom vars):
   ```
   # .env
   ```
3. Make sure Ollama is running:
   ```bash
   ollama serve
   ```

---

## Usage

Run the assistant:

```bash
python main.py
```

You'll see:

```
Welcome! I'm your AI assistant. Type 'quit' to exit.
You can ask me to perform calculations or chat with me.
You: 
```

### Example interactions

**Triggering the calculator tool:**
```
You: What is 42 + 58?
Assistant: The result of 42.0 + 58.0 is 100.0.
```

**Regular conversation:**
```
You: What is the capital of France?
Assistant: The capital of France is Paris.
```

**Exit:**
```
You: quit
```

---

## Project Structure

```
.
├── main.py       # Entry point — agent setup and chat loop
├── .env          # Environment variables (optional)
└── README.md     # This file
```

---

## Notes

- The `calculator` tool only supports **addition**. You can extend it to support other operations.
- The model runs entirely **offline** — no data is sent to external servers.
- Temperature is set to `0` for deterministic, consistent responses.
- To use a different model, change `model="llama3.2"` in `main.py` to any model available in your Ollama instance.
