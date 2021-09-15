using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stoma.DataModels
{
    public class ServiceView
    {
        public string client;
        public string serviceID;
        public string serviceName;
        public string doctor;
        public string toothType;
        public string serviceDescr;
        public int orderID;
        public DateTime orderOpen;
        public DateTime? orderClosed;
        public float price;
        public float discount;
        public string toothName;

        public ServiceView(string client, string serviceID, string serviceName, string doctor, string toothType, string serviceDescr, int orderID, DateTime orderOpen, DateTime? orderClosed, float price, float discount, string toothName)
        {
            this.client = client;
            this.serviceID = serviceID;
            this.serviceName = serviceName;
            this.doctor = doctor;
            this.toothType = toothType;
            this.serviceDescr = serviceDescr;
            this.orderID = orderID;
            this.orderOpen = orderOpen;
            this.orderClosed = orderClosed;
            this.price = price;
            this.discount = discount;
            this.toothName = toothName;
        }

        public override string ToString()
        {
            return string.Format("client:{0} \n service:{1}-{2} ({5}) \n doctor:{3}\n tooth:{11} ({4}) \n order id:{6} \n opened: {7} \n closed:{8} \n price:{9} ({10}% discount)",
                client, serviceID, serviceName, doctor, toothType, serviceDescr, orderID, orderOpen.ToString(), orderClosed.HasValue?orderClosed.Value.ToString():"opened", price, (1-discount)*100, toothName);
        }
    }
}
