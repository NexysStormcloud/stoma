using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stoma.DataModels
{
    public class UserGroup
    {
        public int ID { get; private set; }
        public int mask { get; private set; }
        public string name { get; private set; }

        public UserGroup(int iD, int mask, string name)
        {
            ID = iD;
            this.mask = mask;
            this.name = name;
        }
    }
}
