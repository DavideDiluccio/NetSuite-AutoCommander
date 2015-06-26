using NetSuite_Commands.Contracts;
using NetSuite_DefaultImplementations.Commands;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSuite_DefaultImplementations
{
    public class CommandFactory
    {
        private static CommandFactory instance;

        private CommandFactory()
        {
        }

        public static CommandFactory Instance
        {
            get
            {
                return instance == null ? (instance = new CommandFactory()) : instance;
            }
        }

        public ICommand CreateCommand(string type, JToken cfg)
        {
            //Switch funzioni sui vari comandi
            switch (type)
            {
                case "itemPublish":
                    return new ItemPublishCommand(JsonConvert.DeserializeObject<ItemPublishCommandConfiguration>(cfg.ToString()));
                    break;
                default: throw new NotImplementedException();
                    break;
            }
        }
    }
}
