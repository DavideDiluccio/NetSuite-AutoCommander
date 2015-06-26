using NetSuite_Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSuite_DefaultImplementations.Commands
{
    public class DefaultCommand : ICommand
    {
        private string _commandText;

        public DefaultCommand(string commandText)
        {
            _commandText = commandText;
        }

        public void Execute(ILogger logger)
        {
            logger.Log(this._commandText);
        }
    }
}
