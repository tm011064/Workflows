using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowSystem
{
  class Program
  {
    static void Main(string[] args)
    {
      log4net.Config.XmlConfigurator.Configure();

      WorkflowTests workflowTests = new WorkflowTests();
      workflowTests.Test_Simple();
    }
  }
}
