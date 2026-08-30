from config.settings import settings
from llm.ollama_provider import OllamaProvider
from llm.azure_provider import AzureProvider

def get_provider():

    if settings.PROVIDER == "ollama":
        return OllamaProvider()

    if settings.PROVIDER == "azure":
        return AzureProvider()

    raise Exception("Unknown Provider")