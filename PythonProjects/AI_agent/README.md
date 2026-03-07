# Firecrawl AI Agents

A collection of two AI agents that use [Firecrawl](https://firecrawl.dev) for web scraping and crawling, powered by local LLMs via Ollama.

---

## Projects

### 1. MCP Chat Agent (`/simple_agent`)
A conversational agent that lets you scrape, crawl, and extract web data through natural language. Uses the **Model Context Protocol (MCP)** to connect directly to Firecrawl's toolset.

**Best for:** Ad-hoc scraping, one-off extractions, interactive web research.

### 2. Developer Tools Research Agent (`/advanced_agent`)
An automated research pipeline that takes a developer tools query, finds relevant tools across the web, scrapes their websites, and returns a structured comparison + recommendation.

**Best for:** Comparing developer tools, finding alternatives, tech stack research.

---

## Shared Stack

| Component | Usage |
|---|---|
| [Ollama](https://ollama.com) + `llama3.2` | Local LLM inference |
| [Firecrawl](https://firecrawl.dev) | Web search & scraping |
| [LangGraph](https://github.com/langchain-ai/langgraph) | Agent orchestration |
| [LangChain Ollama](https://github.com/langchain-ai/langchain) | LLM integration |

---

## Setup

### Prerequisites
- Python 3.10+, Node.js 18+ (MCP agent only), Ollama

```bash
ollama pull llama3.2
pip install mcp langchain-mcp-adapters langgraph langchain-ollama langchain-core firecrawl-py pydantic python-dotenv
```

### Environment variables

Create a `.env` file in each project folder:

```env
FIRECRAWL_API_KEY=your_firecrawl_api_key_here
```

> Get your key at [firecrawl.dev](https://firecrawl.dev)

---

## Usage

**MCP Chat Agent:**
```bash
cd mcp-agent
python main.py
# Then chat: "Scrape https://example.com and summarize it"
```

**Research Agent:**
```bash
cd research-agent
python main.py
# Then query: "best open source databases for SaaS"
```
