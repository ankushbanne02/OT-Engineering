from tools.base_tool import BaseTool
from services.wrapper_client import wrapper

class CreatePLCTool(BaseTool):
    name = "create_plc"
    description = "Create PLC"

    def execute(self, plc_type):
        return wrapper.create_plc(plc_type)