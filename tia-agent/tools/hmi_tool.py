from tools.base_tool import BaseTool
from services.wrapper_client import wrapper

class CreateHMITool(BaseTool):
    name = "create_hmi"
    description = "Create HMI"

    def execute(self):
        return wrapper.create_hmi()