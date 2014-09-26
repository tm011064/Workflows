using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkflowSystem.Components.Interfaces
{
  public interface IExecutionPathNode
  {
    string StepName { get; set; }
    string StepKey { get; set; }
    ExecutionPathNodeStatus ExecutionPathNodeStatus { get; set; }
  }
}
