using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowSystem.Components.Interfaces
{
  public interface IWorkflow
  {
    IWorkflowContext Execute();
    IWorkflowContext Execute(IWorkflowContext context);
    IWorkflowContext Resume(IWorkflowContext context);
    IWorkflowContext GoToStep(IWorkflowContext context, string stepName);
  }
}
