using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;
using WorkflowSystem.Components;

using WorkflowSystem.Mocks;

namespace WorkflowSystem
{
  public class WorkflowTests
  {
    #region private methods
    private WorkflowManager CreateAndCompileWorkflowManager(string xml)
    {
      XDocument document = XDocument.Parse(xml);
      WorkflowManager workflowManager = new WorkflowManager();

      try { workflowManager.CompileWorkflows(document); }
      catch (WorkflowCompilationException err)
      {
        foreach (CompilerError error in err.CompilerErrorCollection)
          Trace.WriteLine(error.ErrorText);

        return null;
      }
      catch(Exception err)
      {
        Trace.WriteLine(err.Message);
        Trace.WriteLine(err.StackTrace);

        return null;
      }

      return workflowManager;
    }
    #endregion

    private string _workflows_Test_Simple =
@"
<workflows>
  <workflow name=""Test_Simple"">
    <namespaces>
      <using namespace=""WorkflowSystem.Mocks"" />
    </namespaces>
    <rundown contextType=""WorkflowSystem.Mocks.MockWorkflowContext, WorkflowSystem"">
<![CDATA[

  @executeStep(""Step1"", ""WorkflowSystem.Mocks.MockStep_Initialize, WorkflowSystem"")
  @executeStep(""Step2"", ""WorkflowSystem.Mocks.MockStep_IncreaseCounter, WorkflowSystem"")
  @executeStep(""Step3"", ""WorkflowSystem.Mocks.MockStep_IncreaseCounter, WorkflowSystem"")

]]>
    </rundown>    
  </workflow>
</workflows>
";

    public void Test_Simple()
    {
      Trace.WriteLine("Start Test_Simple");

      WorkflowManager workflowManager = CreateAndCompileWorkflowManager(_workflows_Test_Simple);

      MockWorkflowContext mockWorkflowContext = workflowManager.ExecuteWorkflow("Test_Simple") as MockWorkflowContext;

      Assert.IsNotNull(mockWorkflowContext);
      Assert.AreEqual(ExecutionStatus.Finished, mockWorkflowContext.ExecutionStatus);
      Assert.AreEqual("Step1", mockWorkflowContext.ExecutionPathNodes[0].StepName);
      Assert.AreEqual("Step2", mockWorkflowContext.ExecutionPathNodes[1].StepName);
      Assert.AreEqual("Step3", mockWorkflowContext.ExecutionPathNodes[2].StepName);

      Assert.AreEqual(2, mockWorkflowContext.Counter);
    }

  }
}
