using NetSuite_Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSuite_DefaultImplementations
{
    public class MemoryExecutionContext : IExecuteContext
    {
        private ILogger logger;
        private string key;
        Type service;
        public MemoryExecutionContext(ILogger logger)
        {
            this.logger = logger;
        }
        public ILogger Logger
        {
            get { return logger; }
        }

        public void setSessionValue<T>(string key, T value)
        {
            this.key = key;
            service = typeof(value);
        }

        public T getSessionValue<T>(string key)
        {
            if (key == this.key)
            {
                return ;
            }
        }
    }
}
