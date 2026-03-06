# Firecrawl MCP Agent

A conversational AI agent that scrapes websites, crawls pages, and extracts web data — powered by Firecrawl, LangGraph, and a local Ollama model via MCP.

---

## How It Works

1. **Ollama** runs `llama3.2` locally as the reasoning engine
2. **LangGraph ReAct agent** decides step-by-step which tool to call
3. **MCP client** connects to the Firecrawl MCP server via stdio
4. **Firecrawl** handles the actual scraping and crawling
5. Full **conversation history** is preserved across turns

---

## Setup

### Prerequisites
- Python 3.10+, Node.js 18+, Ollama with `llama3.2` pulled

```bash
ollama pull llama3.2
pip install mcp langchain-mcp-adapters langgraph langchain-ollama python-dotenv
```

### Environment variables

Create a `.env` file:

```env
FIRECRAWL_API_KEY=your_firecrawl_api_key_here
```

> Get your API key at [firecrawl.dev](https://firecrawl.dev)

---

## Usage

```bash
python main.py
```

```
Available Tools - firecrawl_scrape firecrawl_crawl firecrawl_extract ...
------------------------------------------------------------

You: Scrape the content from https://example.com
Agent: Here's what I found...

You: quit
```

### Example queries
- `"Scrape https://news.ycombinator.com and list the top 5 stories"`
- `"Extract the pricing table from https://someproduct.com/pricing"`
- `"Crawl https://docs.example.com and find all pages about authentication"`

---

## Notes
- Runs **fully locally** except for Firecrawl API calls
- `temperature=0` for consistent, deterministic tool-use behavior
- Input capped at 175,000 characters per message

