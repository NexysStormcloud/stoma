using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stoma.DataModels
{
    public class Doctor
    {
        public int id;
        public string firstName;
        public string patrioName;
        public string lastName;
        public string profile;
        public int todayClients;

        public Doctor(int id, string firstName, string patrioName, string lastName, string profile, int todayClients)
        {
            this.id = id;
            this.firstName = firstName;
            this.patrioName = patrioName;
            this.lastName = lastName;
            this.profile = profile;
            this.todayClients = todayClients;

        }

        public override string ToString()
        {
            return string.Format("{0}.{1}. {2} ({3})", firstName.Substring(0, 1), patrioName.Substring(0, 1), lastName, profile);
        }
    }
}
