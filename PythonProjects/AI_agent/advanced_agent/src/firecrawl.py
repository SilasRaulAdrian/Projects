import os
from firecrawl import FirecrawlApp
from dotenv import load_dotenv

load_dotenv()


class FirecrawlService:
    def __init__(self):
        api_key = os.getenv("FIRECRAWL_API_KEY")
        if not api_key:
            raise ValueError("Missing FIRECRAWL_API_KEY environment variable")
        self.app = FirecrawlApp(api_key=api_key)

    def search_companies(self, query: str, num_results: int = 5):
        try:
            result = self.app.search(
                query=f"{query} company pricing", limit=num_results
            )

            if hasattr(result, "data"):
                return result.data

            return result
        except Exception as e:
            print(e)
            return []

    def scrape_company_pages(self, url: str):
        try:
            result = self.app.scrape_url(url, formats=["markdown"])

            if isinstance(result, tuple):
                return result[0]

            return result
        except Exception as e:
            print(e)
            return None
