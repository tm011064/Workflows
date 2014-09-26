using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowSystem.Components
{
  public enum ExecutionStatus
  {
    Idle = 0,
    Running = 1,
    PausedAtStep = 2,
    PausedAfterStep = 3,
    Finished = 4,
    ExceptionOccurred = 5,
    NavigateToStep = 6,
    Cancelled = 7
  }
}
