using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stoma.DataModels
{
    public class User
    {
        public int ID
        {
            get;private set;
        }

        private string login, password;
        private int groupID;
        private long lastSession;

        public User() { }

        string userDetails;

        public User(int id, string login, string password, int groupID, long lastSession)
        {
            ID = id;
            this.login = login;
            this.password = password;
            this.groupID = groupID;
            this.lastSession = lastSession;
            Person p = DBHandler.GetPerson(ID);
            UserGroup g = DBHandler.GetGroup(groupID);
            userDetails = p.FirstName + " " + p.LastName + "(" + login + ":" + g.name + ")";
        }
        public User(object id, object login, object password, object groupID, object lastSession)
        {
            if (id != null) ID = (int)id;
            if (login != null) this.login = (string)login;
            if (password != null) this.password = (string)password;
            if (groupID != null) this.groupID = (int)groupID;
            if (lastSession != null) this.lastSession = (long)lastSession;
        }

        public override string ToString()
        {
            return userDetails;
        }
    }
}
