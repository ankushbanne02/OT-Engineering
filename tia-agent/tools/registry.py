from tools.connection_tool import *
from tools.project_tool import *
from tools.plc_tool import *
from tools.hmi_tool import *

TOOLS = {
    ConnectTool.name:
        ConnectTool(),

    DisconnectTool.name:
        DisconnectTool(),

    CreateProjectTool.name:
        CreateProjectTool(),

    OpenProjectTool.name:
        OpenProjectTool(),

    SaveProjectTool.name:
        SaveProjectTool(),

    CreatePLCTool.name:
        CreatePLCTool(),

    CreateHMITool.name:
        CreateHMITool()
}