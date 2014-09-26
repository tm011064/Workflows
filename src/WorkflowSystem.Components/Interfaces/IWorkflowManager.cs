using System.Xml.Linq;

namespace WorkflowSystem.Components.Interfaces
{
  public interface IWorkflowManager
  {
    IWorkflowContext ExecuteWorkflow(string workflowName, IWorkflowContext context);
    IWorkflowContext ExecuteWorkflow(string workflowName);
    IWorkflowContext ResumeWorkflow(string workflowName, IWorkflowContext context);
    IWorkflowContext ResumeWorkflowFromStep(string workflowName, string stepName, IWorkflowContext context);

    void CompileWorkflows(XContainer container);
    void CompileWorkflows(WorkflowConfigSection workflowConfigSection);
  }
}
