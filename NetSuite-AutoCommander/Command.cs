using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSuite_AutoCommander
{
    class Command
    {
        private string commandText;

        public Command()
        {
            commandText = "";
        }

        public Command(string commandText)
        {
            this.CommandText = commandText;
        }

        public string CommandText
        {
            get 
            {
                return commandText;
            }
            set 
            {
                if (value != null && value != "")
                {
                    commandText = value;
                }
            }
        }

        public string executeCommand()
        {
            if (commandText != "")
            {
                return commandText;
            }
            else
                return null;
        }
    }
}
