import json
from pathlib import Path
from agents.base_agent import BaseAgent

class PlannerAgent(BaseAgent):

    def __init__(self):
        super().__init__()
        self.prompt = Path(
            "prompts/planner.txt"
        ).read_text()

    def plan(self, request):
        messages = [
            {
                "role":"system",
                "content":self.prompt
            },
            {
                "role":"user",
                "content":request
            }
        ]

        response = self.ask(messages)
        response = response.strip()

        if response.startswith("```"):
            response = response.replace("```json","")
            response = response.replace("```","")
            response = response.strip()

        return json.loads(response)