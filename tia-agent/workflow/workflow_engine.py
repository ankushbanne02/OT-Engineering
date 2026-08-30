class WorkflowEngine:

    @staticmethod
    def display(workflow):
        print("\nGenerated Workflow\n")
        for i, step in enumerate(workflow, start=1):
            print(f"{i}. {step['tool']}")
            if "args" in step:
                print(step["args"])
            print()

    @staticmethod
    def display_results(results):
        print("\nExecution Result\n")
        for result in results:
            status = "SUCCESS"
            if not result.success:
                status = "FAILED"
            print(f"{result.tool:<20} {status}")