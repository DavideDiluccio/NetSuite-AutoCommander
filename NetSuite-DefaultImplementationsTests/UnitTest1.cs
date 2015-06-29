using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetSuite_DefaultImplementations;
using NetSuite_Commands.Contracts;

namespace NetSuite_DefaultImplementationsTests
{
    class FakeLogger : ILogger
    {
        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MemoryExecutionContextTest1()
        {
            MemoryExecutionContext ctx = new MemoryExecutionContext(new FakeLogger());

            ctx.setSessionValue<int>("i1", 12);
            //Assert.AreEqual<int>(12, ctx.getSessionValue<int>("i1"));
        }
    }
}
