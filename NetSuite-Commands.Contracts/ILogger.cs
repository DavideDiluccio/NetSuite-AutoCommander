using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSuite_Commands.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void Log(string message);
    }
}
