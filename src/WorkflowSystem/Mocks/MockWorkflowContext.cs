using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowSystem.Components;
using WorkflowSystem.Components.Interfaces;

namespace WorkflowSystem.Mocks
{
  public class MockWorkflowContext : IWorkflowContext
  {
    #region IWorkflowContext Members

    public ExecutionStatus ExecutionStatus { get; set; }

    public List<IExecutionPathNode> ExecutionPathNodes { get; set; }

    public string ResumeAtKey { get; set; }

    public Exception LastError { get; set; }

    #endregion

    public int Counter { get; set; }
    public TestEnum TestEnum { get; set; }
    public bool DoResumeAtPausedAt { get; set; }

    public MockWorkflowContext()
    {
      this.ExecutionPathNodes = new List<IExecutionPathNode>();
    }
  }
}
