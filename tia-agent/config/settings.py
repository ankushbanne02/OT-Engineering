from dotenv import load_dotenv
import os

load_dotenv()

class Settings:
    OLLAMA_HOST = os.getenv("OLLAMA_HOST")
    OLLAMA_MODEL = os.getenv("OLLAMA_MODEL")
    PROVIDER = os.getenv("LLM_PROVIDER")
    WRAPPER_URL = os.getenv("WRAPPER_URL")

settings = Settings()