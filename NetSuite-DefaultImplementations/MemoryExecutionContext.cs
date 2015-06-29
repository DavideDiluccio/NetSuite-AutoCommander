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
        private static Dictionary<string, object> bag = new Dictionary<string,object>();
        
        public MemoryExecutionContext(ILogger logger)
        {
            this.logger = logger;
            //bag = new Dictionary<string, object>();
        }
        public ILogger Logger
        {
            get { return logger; }
        }

        public void setSessionValue<T>(string key, T value)
        {
            bag[key] = value;
        }

        public T getSessionValue<T>(string key)
        {
            return (T)bag[key];
        }

        public void removeSessionValue(string key)
        {
            bag.Remove(key);
        }
    }
}
