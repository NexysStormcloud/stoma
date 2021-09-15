using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stoma.DataModels
{
    public class ToothType
    {
        public string code { get; private set; }

        public override string ToString()
        {
            return name;
        }
        public string name {
            get
            {
                if(Settings.toothTypes.ContainsKey(code)) return Settings.toothTypes[code];
                return "?";
            }

        }

        public ToothType(string code)
        {
            this.code = code;
        }
    }
}
