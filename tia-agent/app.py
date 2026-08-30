from agents.planner_agent import PlannerAgent
from workflow.workflow_engine import WorkflowEngine
from workflow.executor import WorkflowExecutor

planner = PlannerAgent()
executor = WorkflowExecutor()

def main():
    print("=" * 70)
    print("TIA Agent")
    print("=" * 70)

    while True:
        user = input("\nUser : ")
        if user.lower() == "exit":
            break
        try:
            workflow = planner.plan(user)
            WorkflowEngine.display(workflow)
            # executor.execute(workflow)
            results = executor.execute(workflow)
            WorkflowEngine.display_results(results)
        except Exception as ex:
            print(ex)

if __name__ == "__main__":
    main()