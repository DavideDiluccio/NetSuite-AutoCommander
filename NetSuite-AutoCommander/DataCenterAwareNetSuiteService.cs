using NetSuite_AutoCommander.com.netsuite.webservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace NetSuite_AutoCommander
{
    class DataCenterAwareNetSuiteService : NetSuite_AutoCommander.com.netsuite.webservices.NetSuiteService
    {
        public DataCenterAwareNetSuiteService(string account)
            : base()
        {
            System.Uri originalUri = new System.Uri(this.Url);
            DataCenterUrls urls = getDataCenterUrls(account).dataCenterUrls;
            Uri dataCenterUri = new Uri(urls.webservicesDomain + originalUri.PathAndQuery);
            this.Url = dataCenterUri.ToString();
        }
    }
}
