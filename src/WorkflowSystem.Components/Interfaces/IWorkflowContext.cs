using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkflowSystem.Components.Interfaces
{
  public interface IWorkflowContext
  {
    ExecutionStatus ExecutionStatus { get; set; }
    List<IExecutionPathNode> ExecutionPathNodes { get; set; }

    string ResumeAtKey { get; set; }
    Exception LastError { get; set; }
  }
}
