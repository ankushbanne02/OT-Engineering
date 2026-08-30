import streamlit as st

from agents.planner_agent import PlannerAgent
from workflow.executor import WorkflowExecutor

planner = PlannerAgent()
executor = WorkflowExecutor()

st.set_page_config(
    page_title="TIA Portal AI Assistant",
    page_icon="🤖",
    layout="wide"
)

st.title("🤖 TIA Portal AI Assistant")
st.caption("Create Projects • PLC • HMI • Execute using Siemens Openness")

# Session State
if "workflow" not in st.session_state:
    st.session_state.workflow = None

if "results" not in st.session_state:
    st.session_state.results = None

if "prompt" not in st.session_state:
    st.session_state.prompt = ""

# Chat Input
user_input = st.chat_input("What do you want to create?")

if user_input:

    st.session_state.prompt = user_input

    with st.spinner("Planning workflow..."):
        st.session_state.workflow = planner.plan(user_input)

    st.session_state.results = None

# Show Prompt
if st.session_state.prompt:

    st.subheader("User Request")

    st.info(st.session_state.prompt)

# Show Workflow
if st.session_state.workflow:

    workflow = st.session_state.workflow

    st.subheader("Generated Workflow")

    for i, step in enumerate(workflow, start=1):
        st.markdown(f"### {i}. {step['tool']}")
        if "args" in step:
            st.json(step["args"])

    col1, col2 = st.columns(2)

    with col1:
        execute = st.button(
            "▶ Execute Workflow",
            use_container_width=True
        )

    with col2:
        clear = st.button(
            "🗑 Clear",
            use_container_width=True
        )

    if clear:
        st.session_state.workflow = None
        st.session_state.results = None
        st.session_state.prompt = ""
        st.rerun()

    if execute:
        status = st.status(
            "Executing Workflow...",
            expanded=True
        )

        results = []

        for step in workflow:
            status.write(f"Executing **{step['tool']}**")
            result = executor.execute([step])[0]
            results.append(result)

        status.update(
            label="Workflow Completed",
            state="complete"
        )

        st.session_state.results = results

# Show Results
if st.session_state.results:

    st.subheader("Execution Results")

    for result in st.session_state.results:
        if result.success:
            st.success(f"✅ {result.tool} : {result.message}")

        else:
            st.error(f"❌ {result.tool} : {result.message}")

        with st.expander(f"View Response : {result.tool}"):
            st.json(result.response)