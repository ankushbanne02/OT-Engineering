from llm.provider_factory import get_provider

class BaseAgent:

    def __init__(self):
        self.llm = get_provider()

    def ask(self, messages):
        return self.llm.generate(messages)