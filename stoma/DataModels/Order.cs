using System;
using System.Collections.Generic;


namespace stoma.DataModels
{
    public class Order
    {
        string clientName;
        
        public int orderID { get; private set; }
        public DateTime issued { get; private set; }
        public DateTime closed { get; private set; }

        public int clientID { get; private set; }

        public Order(int orderID, DateTime issued, DateTime closed, int clientID, string clientName)
        {
            this.orderID = orderID;
            this.issued = issued;
            this.closed = closed;
            this.clientID = clientID;
            this.clientName = clientName;
            
        }

        public string Client()
        {
            string closedStr = closed >= issued ? "Оплачено" : "Ждёт оплаты";
            return clientName + " (" + clientID + ") " +closedStr;
        }
    }
}
