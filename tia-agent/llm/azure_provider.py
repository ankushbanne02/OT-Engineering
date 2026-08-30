from llm.llm_provider import LLMProvider

class AzureProvider(LLMProvider):
    def generate(self, messages):
        raise NotImplementedError()