from tools.registry import TOOLS
from services.logger import Logger
from models.execution_result import ExecutionResult

class WorkflowExecutor:

    def execute(self, workflow):
        results = []
        Logger.log("Workflow Started")

        for step in workflow:
            tool_name = step["tool"]
            args = step.get("args", {})
            tool = TOOLS.get(tool_name)

            if tool is None:
                result = ExecutionResult(
                    tool=tool_name,
                    success=False,
                    message="Tool not found"
                )
                results.append(result)
                continue

            Logger.log(f"Executing {tool_name}")
            print(step)

            response = tool.execute(**args)

            result = ExecutionResult(
                tool=tool_name,
                success=response.success,
                message=response.message,
                response=response.model_dump()
            )
            results.append(result)

        Logger.log("Workflow Completed")
        return results