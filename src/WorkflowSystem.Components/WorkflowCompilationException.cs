using System;
using System.CodeDom.Compiler;

namespace WorkflowSystem.Components
{
  public class WorkflowCompilationException : Exception
  {
    public CompilerErrorCollection CompilerErrorCollection { get; private set; }

    public WorkflowCompilationException(CompilerErrorCollection errors)
    {
      this.CompilerErrorCollection = errors;
    }

    public WorkflowCompilationException(string errorMessage)
    {
      this.CompilerErrorCollection = new CompilerErrorCollection();

      CompilerError error = new CompilerError();
      error.ErrorText = errorMessage;

      this.CompilerErrorCollection.Add(error);
    }
  }
}
