from pydantic import BaseModel
from typing import Dict

class WorkflowStep(BaseModel):
    tool: str
    args: Dict = {}