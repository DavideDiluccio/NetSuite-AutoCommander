using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSuite_Commands.Contracts
{
    public interface ICommand
    {
        string Type { get; }
        string Commandtext { get; }
        void Execute(ILogger logger);
    }
}
