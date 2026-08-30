import ollama
from config.settings import settings
from llm.llm_provider import LLMProvider

class OllamaProvider(LLMProvider):

    def __init__(self):
        self.client = ollama.Client(
            host=settings.OLLAMA_HOST
        )

    def generate(self, messages):
        response = self.client.chat(
            model=settings.OLLAMA_MODEL,
            messages=messages
        )

        return response["message"]["content"]