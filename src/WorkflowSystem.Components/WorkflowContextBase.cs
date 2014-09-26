using System;
using System.Collections.Generic;

using WorkflowSystem.Components.Interfaces;

namespace WorkflowSystem.Components
{
  public class WorkflowContextBase : IWorkflowContext
  {
    #region IWorkflowContext Members

    public ExecutionStatus ExecutionStatus { get; set; }
    public List<IExecutionPathNode> ExecutionPathNodes { get; set; }

    public string ResumeAtKey { get; set; }
    public string NavigateToStepName { get; set; }
    public Exception LastError { get; set; }

    #endregion

    public WorkflowContextBase()
    {
      this.ExecutionPathNodes = new List<IExecutionPathNode>();
    }
  }
}
