from tools.base_tool import BaseTool
from services.wrapper_client import wrapper

class ConnectTool(BaseTool):
    name = "connect"
    description = "Connect"
    def execute(self):
        return wrapper.connect()

class DisconnectTool(BaseTool):
    name = "disconnect"
    description = "Disconnect"
    def execute(self):
        return wrapper.disconnect()