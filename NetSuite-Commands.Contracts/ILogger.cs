using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSuite_Commands.Contracts
{
    /// <summary>
    /// Interfaccia che logga i comandi
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Metodo che logga i comandi
        /// </summary>
        /// <param name="message">stringa da loggare</param>
        void Log(string message);
    }
}
