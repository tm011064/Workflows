using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkflowSystem.Components.Interfaces
{
  public interface IWorkflowStep<TContext>
  {
    ExecutionStatus Run(TContext context);
  }
}
