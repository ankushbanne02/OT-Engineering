from pydantic import BaseModel

class ExecutionResult(BaseModel):
    tool: str
    success: bool
    message: str = ""
    response: dict = {}