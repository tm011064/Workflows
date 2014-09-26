
using WorkflowSystem.Components.Interfaces;

namespace WorkflowSystem.Components
{
  public class ExecutionPathNode : IExecutionPathNode
  {
    #region IExecutionPathNode Members

    public string StepName { get; set; }
    public string StepKey { get; set; }
    public ExecutionPathNodeStatus ExecutionPathNodeStatus { get; set; }
    
    #endregion

    public ExecutionPathNode(string stepName, string stepKey, ExecutionPathNodeStatus executionPathNodeStatus)
    {
      this.StepName = stepName;
      this.StepKey = stepKey;
      this.ExecutionPathNodeStatus = executionPathNodeStatus;
    }
  }
}
