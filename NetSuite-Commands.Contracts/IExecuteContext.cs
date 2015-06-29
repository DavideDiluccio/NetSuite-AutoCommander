using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSuite_Commands.Contracts
{
    public interface IExecuteContext
    {
        ILogger Logger{get;}
        void setSessionValue<T>(string key, T value);
        T getSessionValue<T>(string key);
        void removeSessionValue(string key);
    }
}
