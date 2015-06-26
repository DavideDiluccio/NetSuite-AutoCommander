using NetSuite_Commands.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using NetSuite_DefaultImplementations.com.netsuite.webservices;

namespace NetSuite_DefaultImplementations.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemPublishCommand: ICommand
    {
        private ItemPublishCommandConfiguration cfg;

        public ItemPublishCommand(ItemPublishCommandConfiguration cfg)
        {
            this.cfg = cfg;                        
        }

        public void Execute(ILogger logger)
        {
            throw new NotImplementedException();
        }

        public ItemPublishCommandConfiguration Cfg
        {
            get { return cfg; }
        }

        public InventoryItem addItem()
        {
            InventoryItem Item = new InventoryItem();

            Item.itemId = cfg.ItemName;
            Item.externalId = cfg.ItemID;
            
            Item.isOnline = cfg.Publish;
            Item.isOnlineSpecified = true;
            return Item;
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonObject]
    public class ItemPublishCommandConfiguration
    {
        [JsonProperty("id")]
        public string ItemID { get; set; }

        [JsonProperty("name")]
        public string ItemName { get; set; }

        [JsonProperty("publish")]
        public bool Publish { get; set; }
    }
}
