using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stoma.DataModels
{
    public class Service
    {
        public string serviceID;
        public string serviceName;
        public string toothtype;
        public float price;
        public string serviceDescription;
        

        public Service(string serviceID, string serviceName, string toothtype, float price, string serviceDescription)
        {
            this.serviceID = serviceID;
            this.serviceName = serviceName;
            this.toothtype = toothtype;
            this.price = price;
            this.serviceDescription = serviceDescription;
            

        }
        public override string ToString()
        {
            return serviceName + " #" + serviceID;

        }
    }
}
