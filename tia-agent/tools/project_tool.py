from tools.base_tool import BaseTool
from services.wrapper_client import wrapper

class CreateProjectTool(BaseTool):
    name = "create_project"
    description = "Create Project"
    def execute(self,project_name):
        return wrapper.create_project(project_name)

class OpenProjectTool(BaseTool):
    name = "open_project"
    description = "Open Project"
    def execute(self,project_path):
        return wrapper.open_project(project_path)

class SaveProjectTool(BaseTool):
    name = "save_project"
    description = "Save Project"
    def execute(self):
        return wrapper.save_project()