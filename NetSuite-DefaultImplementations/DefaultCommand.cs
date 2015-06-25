using NetSuite_Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSuite_DefaultImplementations
{
    public class DefaultCommand : ICommand
    {
        private string _type;
        private string _commandText;

        public DefaultCommand(string commandText)
        {
            _commandText = commandText;
        }

        public DefaultCommand(string commandText, string type)
        {
            _type = type;
            _commandText = commandText;
        }

        public string Type
        {
            get {  return _type; }
        }

        public string Commandtext
        {
            get { return _commandText; }
        }

        public void Execute(ILogger logger)
        {
            logger.Log(this._commandText);
        }
    }
}
