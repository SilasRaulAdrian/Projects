# 🛠️ Developer Tools Research Agent

An AI agent that researches, scrapes, and compares developer tools based on your query — powered by Firecrawl, LangGraph, and a local Ollama model.

---

## How It Works

The agent runs a 3-step LangGraph pipeline:

1. **Extract Tools** — searches the web for articles related to your query and uses the LLM to extract relevant tool names
2. **Research** — scrapes each tool's official website via Firecrawl and runs structured LLM analysis
3. **Analyze** — generates a concise developer recommendation based on all gathered data

```
Query → Extract Tools → Research each tool → Generate Recommendation
               ↑                ↑
          Firecrawl          Firecrawl
          (search)           (scrape)
```

---

## Project Structure

```
.
├── main.py                  # Entry point / CLI loop
├── src/
│   ├── workflow.py          # LangGraph pipeline (3 nodes)
│   ├── firecrawl.py         # Firecrawl search & scrape wrapper
│   ├── models.py            # Pydantic models (CompanyInfo, ResearchState, etc.)
│   └── prompts.py           # All LLM prompts
└── .env
```

---

## Setup

### Prerequisites
- Python 3.10+, Ollama with `llama3.2` pulled

```bash
ollama pull llama3.2
pip install langgraph langchain-ollama langchain-core firecrawl-py pydantic python-dotenv
```

### Environment variables

```env
FIRECRAWL_API_KEY=your_firecrawl_api_key_here
```

> Get your key at [firecrawl.dev](https://firecrawl.dev)

---

## Usage

```bash
python main.py
```

```
🔍 Developer Tools Query: best open source database for SaaS apps

📊 Results for: best open source database for SaaS apps
============================================================

1. 🏢 Supabase
   🌐 Website: https://supabase.com
   💰 Pricing: Freemium
   📖 Open Source: True
   🛠️  Tech Stack: PostgreSQL, REST, GraphQL
   💻 Language Support: JavaScript, Python, Go
   🔌 API: ✅ Available
   🔗 Integrations: GitHub, Vercel, Docker
   📝 Description: Open source Firebase alternative built on PostgreSQL

Developer Recommendations:
----------------------------------------
Supabase is the strongest pick for SaaS apps...
```

Type `quit` or `exit` to stop.

---

## What Each Tool Does

| Component | Role |
|---|---|
| `FirecrawlService` | Web search + URL scraping |
| `Workflow` | Orchestrates the 3-node LangGraph pipeline |
| `CompanyAnalysis` | Structured LLM output (pricing, stack, APIs, etc.) |
| `DeveloperToolsPrompts` | Prompt templates for extraction, analysis, recommendations |
