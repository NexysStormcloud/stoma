using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stoma.DataModels
{
    public class OrderService
    {
        public string serviceID { get; private set; }
        public string toothType { get; private set; }
        public int doctorID { get; private set; }
        public float discount { get; private set; }

        public string toothName { get; private set; }

        public float servicePrice { get; private set; }

        public OrderService(string serviceID, string toothType, int doctorID, float discount, string toothName)
        {
            this.serviceID = serviceID;
            this.toothType = toothType;
            this.doctorID = doctorID;
            this.discount = discount;
            this.toothName = toothName;
            List<Service> l = DBHandler.GetServiceList(id: serviceID, tooth:toothType);

            servicePrice = l.Count > 0 ? l[0].price : 0;
        }
    }
}
