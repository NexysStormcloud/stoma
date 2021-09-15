using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stoma.DataModels
{
    public class Person
    {
        public int personID
        { get; private set; }
        public string FirstName
        { get; private set; }

        public string PatrioName
        { get; private set; }

        public string LastName
        { get; private set; }

        public string Phone
        { get; private set; }
        public string Address
        { get; private set; }

        public long Birthday
        { get; private set; }

        public string passport { get; private set; }
        public string serie { get; private set; }
        public string ufms { get; private set; }
        public string ufmsCode { get; private set; }

        public long passIssued
        {
            get; private set;
        }

        public Person(int personID, string firstName, string patrioName, string lastName, string phone, string address, long birthday, string passport="", string serie="", string ufms="", string ufmsCode="", long passIssued=0)
        {
            this.personID = personID;
            FirstName = firstName;
            PatrioName = patrioName;
            LastName = lastName;
            Phone = phone;
            Address = address;
            Birthday = birthday;
            this.passport = passport;
            this.serie = serie;
            this.ufms = ufms;
            this.ufmsCode = ufmsCode;
            this.passIssued = passIssued;
        }

        public override string ToString()
        {
            return string.Format("Номер:{0} \n ФИО: {3} {1} {2} \n Телефон: {4} \n Адрес: {5} \n Дата рождения: {6}",
                personID, FirstName, PatrioName, LastName, Phone, Address, new DateTime(Birthday).ToShortDateString());
        }
    }
}
