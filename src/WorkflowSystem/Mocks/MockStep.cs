using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowSystem.Components;
using WorkflowSystem.Components.Interfaces;

namespace WorkflowSystem.Mocks
{
  public class MockStep_Initialize : IWorkflowStep<MockWorkflowContext>
  {
    public ExecutionStatus Run(MockWorkflowContext context)
    {
      Trace.WriteLine("start MockStep_Initialize");

      context = new MockWorkflowContext();

      context.Counter = 0;
      context.TestEnum = TestEnum.Value1;

      Trace.WriteLine("end MockStep_Initialize");

      return ExecutionStatus.Running;
    }
  }

  public class MockStep_IncreaseCounter : IWorkflowStep<MockWorkflowContext>
  {
    public ExecutionStatus Run(MockWorkflowContext context)
    {
      Trace.WriteLine("start MockStep_IncreaseCounter");

      context.Counter++;

      Trace.WriteLine("end MockStep_IncreaseCounter");

      return ExecutionStatus.Running;
    }
  }
}
