using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stoma.DataModels
{
    public class DoctorScheduleRecord
    {

        public int doctID { get; private set; }
        public DateTime time { get; private set; }
        public string name { get; private set; }
        public string phone { get; private set; }
        public string addres { get; private set; }

        public DoctorScheduleRecord(int doctID, DateTime time, string name, string phone, string addres)
        {
            this.doctID = doctID;
            this.time = time;
            this.name = name;
            this.phone = phone;
            this.addres = addres;
        }
    }
}
