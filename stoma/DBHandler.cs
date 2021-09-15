using System;
using System.Collections.Generic;
using System.Linq;

using System.Data.SQLite;
//using Dapper;
//using System.Configuration;
using System.Data;
using stoma.DataModels;

namespace stoma
{

    class DBHandler
    {

        public static event Action<object, EventArgs> onScheduleChanded;

        SQLiteConnection connection;

        public DBHandler()
        {
            connection = new SQLiteConnection(Settings.DBPath);  

            

        }


        //обновление структуры БД через команду программы для того, чтобы не потерять введённые данные из старой базы при замене. 
        //хотя проще бы внести изменения руками непосредсвенно в базу...
        public static void updateDBversion()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {
                //лучше бы использовать версии БД, но пока так. (проверяем что в текущей базе есть поле toothNum, и если нет - обновляем.
                string query = "SELECT toothNum FROM OrderService";
                //appSetting app = new appSetting();
                //app.SaveConnectionString("Default", "Data source=.\\stoma.db");
                bool result = false;
                conn.Open();
                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {
                    try
                    {
                        using (SQLiteDataReader rdr = c.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                //база актуальная (как минимум по этому полю)
                            }
                        }
                    }
                    catch (SQLiteException e)
                    {
                        result = true;

                    }
                }
                //если прилетела ошибка от sql, значит меняем структуру и заодно представление OrderedServiceList
                if (result)
                {
                    query = "ALTER TABLE OrderService ADD COLUMN toothNum TEXT";
                    using (SQLiteCommand c = new SQLiteCommand(query, conn))
                    {
                        c.ExecuteNonQuery();
                    }
                    query = "DROP VIEW IF EXISTS OrderedServiceList";
                    using (SQLiteCommand c = new SQLiteCommand(query, conn))
                    {
                        c.ExecuteNonQuery();
                    }

                    query = "CREATE VIEW OrderedServiceList AS " +
                    "SELECT firstName || ' ' || lastName AS client, " +
                    "OrderService.serviceID, " +
                    "serviceName, " +
                    "doctCaption || ' ' || ( " +
                    "SELECT lastName || ' ' || SUBSTR(firstName, 1, 1) || '.' || SUBSTR(patrioName, 1, 1) || '.' " +
                    "FROM Persons " +
                    "WHERE Persons.ID = OrderService.doctID) AS doctor, OrderService.toothType, serviceDescr, OrderService.orderID, " +
                    "orderOpen, orderPaid, price, discount, toothNum " +
                    "FROM OrderService " +
                    "LEFT JOIN Orders ON Orders.orderID = OrderService.orderID " +
                    "LEFT JOIN Persons ON Persons.ID = orderSubj " +
                    "LEFT JOIN ServiceTable ON OrderService.serviceID = ServiceTable.serviceID AND OrderService.toothType = ServiceTable.toothType " +
                    " LEFT JOIN Doctors ON Doctors.doctID = OrderService.doctID; ";

                    using (SQLiteCommand c = new SQLiteCommand(query, conn))
                    {
                        c.ExecuteNonQuery();
                    }

                }
                query = "SELECT passport FROM Persons";
                result = false;
                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {
                    try
                    {
                        using (SQLiteDataReader rdr = c.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                //база актуальная (как минимум по этому полю)
                            }
                        }
                    }
                    catch (SQLiteException e)
                    {
                        result = true;

                    }
                }
                if (result)
                {
                    string[] queryList =
                    {
                        "ALTER TABLE Persons ADD COLUMN passport TEXT DEFAULT ''",
                        "ALTER TABLE Persons ADD COLUMN serie TEXT DEFAULT ''",
                        "ALTER TABLE Persons ADD COLUMN ufms TEXT DEFAULT ''",
                        "ALTER TABLE Persons ADD COLUMN ufmsCode TEXT DEFAULT ''"
                    };
                    using (var t = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (var q in queryList)
                            {
                                using (SQLiteCommand c = new SQLiteCommand(q, conn))
                                {

                                    c.ExecuteNonQuery();
                                }
                            }
                            t.Commit();

                        }
                        catch (SQLiteException e)
                        {
                            System.Windows.Forms.MessageBox.Show(e.Message);
                            t.Rollback();
                            t.Dispose();
                        }
                    }

                }

                query = "SELECT passIssued FROM Persons";
                result = false;
                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {
                    try
                    {
                        using (SQLiteDataReader rdr = c.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                //база актуальная (как минимум по этому полю)
                            }
                        }
                    }
                    catch (SQLiteException e)
                    {
                        result = true;

                    }
                }
                if (result)
                {
                    query = "ALTER TABLE Persons ADD COLUMN passIssued BIGINT DEFAULT 0";
                    
                    using (var t = conn.BeginTransaction())
                    {
                        try
                        {
                            
                                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                                {

                                    c.ExecuteNonQuery();
                                }
                            
                            t.Commit();

                        }
                        catch (SQLiteException e)
                        {
                            System.Windows.Forms.MessageBox.Show(e.Message);
                            t.Rollback();
                            t.Dispose();
                        }
                    }

                }

                conn.Close();
            }
        }

        public SQLiteConnection getConnection()
        {
            return connection;
        }

        

        public static UserGroup GetGroup(int grpID)
        {
            UserGroup result = new UserGroup(0, 0, "Гости");
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                string query = "SELECT * FROM UserGroups WHERE groupID=@id";
                conn.Open();
                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = grpID;
                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            result = new UserGroup(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2));
                        }
                    }

                }

            }
            return result;
        }

        public static List<DoctorScheduleRecord> GetDoctorsSchedule()
        {
            List<DoctorScheduleRecord> result = new List<DoctorScheduleRecord>();
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                string query = "SELECT * FROM getDoctorsSchedule";

                SQLiteCommand c = new SQLiteCommand(query, conn);

                conn.Open();
                using (SQLiteDataReader rdr = c.ExecuteReader())
                {


                    while (rdr.Read())
                    {
                        DoctorScheduleRecord np = new DoctorScheduleRecord(
                            rdr.GetInt32(0),
                            new DateTime(rdr.GetInt64(1)),
                            rdr.GetString(2),
                            rdr.GetString(3),
                            rdr.GetString(4)                            
                            );
                        result.Add(np);
                    }
                }
                conn.Close();

            }


            return result;
        }
        public static int CreateNewOrder(int clientID, List<OrderService> services, string name)
        {
            int result = -1;
            DateTime time = DateTime.Now;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {
                
                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                SQLiteTransaction t = conn.BeginTransaction();
                try
                {
                    string query = "INSERT INTO Orders (orderOpen, orderSubj) VALUES(@time, @client)";
                    using (SQLiteCommand c = new SQLiteCommand(query, conn))
                    {
                        c.Parameters.Add("@time", DbType.Int64).Value = time.Ticks;
                        c.Parameters.Add("@client", DbType.Int32).Value = clientID;

                        c.ExecuteNonQuery();
                        
                    }
                    query = "SELECT last_insert_rowid()";
                    using (SQLiteCommand c = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader rdr = c.ExecuteReader())
                        {


                            while (rdr.Read())
                            {
                                result = rdr.GetInt32(0);
                                //System.Windows.Forms.MessageBox.Show(result.ToString());
                            }
                        }
                    }
                    query = "INSERT INTO OrderService (orderID, discount, doctID, serviceID, toothType, toothNum) VALUES(@ord, @disc, @doct, @serv, @tooth,@num)";
                    services.ForEach(S =>
                    {
                        using(SQLiteCommand c= new SQLiteCommand(query, conn))
                        {
                            c.Parameters.Add("@ord", DbType.Int32).Value = result;
                            c.Parameters.Add("@disc", DbType.Single).Value = S.discount;
                            c.Parameters.Add("@doct", DbType.Int32).Value = S.doctorID;
                            c.Parameters.Add("@serv", DbType.String).Value = S.serviceID;
                            c.Parameters.Add("@tooth", DbType.String).Value = S.toothType;
                            c.Parameters.Add("@num", DbType.String).Value = S.toothName;

                            c.ExecuteNonQuery();
                        }

                    });
                    System.Windows.Forms.MessageBox.Show(string.Format("Наряд №{0} от {1} создан", result, time));
                    t.Commit();
                }
                catch (SQLiteException e)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Не удалось создать наряд. причина: {0}", e.Message));
                    t.Rollback();
                    t.Dispose();
                    //throw e;
                }
                conn.Close();

            }
            return result;
        }

        public static int EditDoctor(int id, string profile)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                SQLiteTransaction t = conn.BeginTransaction();
                using (SQLiteCommand c = new SQLiteCommand(@"UPDATE Doctors SET doctCaption=@capt WHERE doctID=@id", conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = id;
                    c.Parameters.Add("@capt", DbType.String).Value = profile;


                    try
                    {

                        result = c.ExecuteNonQuery();


                        t.Commit();
                        System.Windows.Forms.MessageBox.Show(string.Format("Профиль {0} ({1}) изменён", id, profile));
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Профиль {0} не удалось изменить, (причина: {1}).", id, e.Message));
                        //t.Rollback();
                        t.Dispose();
                        //throw e;
                    }


                }
                conn.Close();

            }





            return result;
        }

        public static int AddNewDoctor(int id, string profile)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                SQLiteTransaction t = conn.BeginTransaction();
                using (SQLiteCommand c = new SQLiteCommand(@"INSERT INTO Doctors (doctID, doctCaption) VALUES (@id, @capt)", conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = id;
                    c.Parameters.Add("@capt", DbType.String).Value = profile;

                    
                    try
                    {

                        result = c.ExecuteNonQuery();


                        t.Commit();                        
                        System.Windows.Forms.MessageBox.Show(string.Format("Профиль {0} ({1}) добавлен", id, profile));
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Профиль {0} не добавлен, (причина: {1}).\n запись с таким номером уже существует?", id, e.Message));
                        //t.Rollback();
                        t.Dispose();
                        //throw e;
                    }


                }
                conn.Close();

            }





            return result;
        }

        public static int DeleteDoctor(int doctID)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                SQLiteTransaction t = conn.BeginTransaction();
                using (SQLiteCommand c = new SQLiteCommand(@"DELETE FROM Doctors WHERE doctID=@id", conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = doctID;
                                        
                    try
                    {

                        result = c.ExecuteNonQuery();


                        t.Commit();                        
                        System.Windows.Forms.MessageBox.Show(string.Format("Профиль {0} удалён", doctID));
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Профиль {0} не может быть удалён, (причина: {1}).\n запись задействована?",doctID, e.Message));
                        //t.Rollback();
                        t.Dispose();
                        //throw e;
                    }


                }
                conn.Close();

            }





            return result;
        }

        public static int CloseOrder(int orderID)
        {
            int result = -1;

            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                SQLiteTransaction t = conn.BeginTransaction();
                string querry = "UPDATE Orders SET orderPaid=@time WHERE orderID=@id";
                try
                {
                    using(SQLiteCommand c = new SQLiteCommand(querry, conn))
                    {
                        c.Parameters.Add("@id", DbType.Int32).Value = orderID;
                        c.Parameters.Add("@time", DbType.Int64).Value = DateTime.Now.Ticks;
                        c.ExecuteNonQuery();


                    }

                    

                    t.Commit();
                    System.Windows.Forms.MessageBox.Show(string.Format("Наряд №{0} успешно оплачен.", orderID));
                }
                catch (SQLiteException e)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Не удалось внести изменения в наряд №{0} ({1})",orderID, e.Message));
                    t.Rollback();
                    t.Dispose();

                    //throw e;
                }
                conn.Close();

            }

            return result;
        }

        public static int DeleteOrder(int orderID)
        {
            int result = -1;

            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                SQLiteTransaction t = conn.BeginTransaction();
                string querry = "DELETE FROM Orders WHERE orderID=@id";
                try
                {
                    using (SQLiteCommand c = new SQLiteCommand(querry, conn))
                    {
                        c.Parameters.Add("@id", DbType.Int32).Value = orderID;
                        
                        c.ExecuteNonQuery();


                    }



                    t.Commit();
                    System.Windows.Forms.MessageBox.Show(string.Format("Наряд №{0} удалён из базы.", orderID));
                }
                catch (SQLiteException e)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Не удалось удалить наряд! ({0})", e.Message));
                    t.Rollback();
                    t.Dispose();

                    //throw e;
                }
                conn.Close();

            }

            return result;
        }

        public static int AddServiceBunch(string id, string name, string descr, float price, string toothSet)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                SQLiteTransaction t = conn.BeginTransaction();
                try
                {
                    using (SQLiteCommand c = new SQLiteCommand(@"INSERT INTO ServiceTable (serviceID, toothType, serviceName, price, serviceDescr) VALUES(@id, @tt, @sn, @pr, @sd)", conn))
                    {
                        c.Parameters.Add("@id", DbType.String).Value = id;
                        c.Parameters.Add("@tt", DbType.String).Value = toothSet;
                        c.Parameters.Add("@sn", DbType.String).Value = name;
                        c.Parameters.Add("@pr", DbType.Decimal).Value = price;
                        c.Parameters.Add("@sd", DbType.String).Value = descr;
                        result = c.ExecuteNonQuery();

                        //onScheduleChanded?.Invoke(conn, new EventArgs());



                    }
                    
                    t.Commit();
                    System.Windows.Forms.MessageBox.Show("Услуги добавлены успешно");

                }
                catch (SQLiteException e)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Не удалось добавить услуги в список ({0})", e.Message));
                    t.Rollback();
                    t.Dispose();
                    
                    //throw e;
                }
                conn.Close();

            }





            return result;
        }

       
        public static int RegisterNewPerson(Person person)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                using (SQLiteCommand c = new SQLiteCommand(@"INSERT INTO Persons (ID, firstName, lastName, birthDay, phone, address, patrioName) VALUES (@id, @name, @surname, @bd, @phone, @addres, @patrio)", conn))
                {
                    if(person.personID>=0) c.Parameters.Add("@id", DbType.Int32).Value = person.personID;
                    else c.Parameters.Add("@id", DbType.Int32).Value = DBNull.Value;
                    c.Parameters.Add("@name", DbType.String).Value = person.FirstName;
                    c.Parameters.Add("@surname", DbType.String).Value = person.LastName;                    
                    c.Parameters.Add("@bd", DbType.Int64).Value = person.Birthday;
                    c.Parameters.Add("@phone", DbType.String).Value = person.Phone;
                    c.Parameters.Add("@addres", DbType.String).Value = person.Address;
                    c.Parameters.Add("@patrio", DbType.String).Value = person.PatrioName;
                    SQLiteTransaction t = conn.BeginTransaction();
                    try
                    {

                        result = c.ExecuteNonQuery();
                        if (result > 0)
                            result = (int)conn.LastInsertRowId;


                        t.Commit();
                        onScheduleChanded?.Invoke(conn, new EventArgs());
                        System.Windows.Forms.MessageBox.Show(string.Format("Запись на {0} {1} {2} добавлена", person.FirstName, person.PatrioName, person.LastName));
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Запись на {0} {1} {2} не добавлена, (причина: {3}).\n запись с таким номером уже существует?", person.FirstName, person.PatrioName, person.LastName, e.Message));
                        t.Rollback();
                        t.Dispose();
                        //throw e;
                    }
                }
                conn.Close();

            }





            return result;
        }

        public static int RemovePersonRecord(int ID)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                using (SQLiteCommand c = new SQLiteCommand(@"DELETE FROM Persons WHERE ID=@id", conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = ID;

                    SQLiteTransaction t = conn.BeginTransaction();
                    try
                    {

                        result = c.ExecuteNonQuery();


                        t.Commit();

                        onScheduleChanded?.Invoke(conn, new EventArgs());
                        System.Windows.Forms.MessageBox.Show("запись удалена");
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show("запись не удалена! (причина: " + e.Message+")\n Данная запись используется?");
                        t.Rollback();
                        t.Dispose();
                        //throw e;
                    }
                }

            }

            return result;

        }

        public static int RemoveService(string ID, string toothType = null)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                string command = @"DELETE FROM ServiceTable WHERE serviceID=@id";
                if (toothType != null)
                {
                    command = @"DELETE FROM ServiceTable WHERE serviceID=@id AND toothType=@tt";
                }

                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                using (SQLiteCommand c = new SQLiteCommand(command, conn))
                {
                    c.Parameters.Add("@id", DbType.String).Value = ID;
                    c.Parameters.Add("@tt", DbType.String).Value = toothType;
                    string msg = "услуга удалена";
                    if (toothType != null) msg += " для зуба "+toothType;
                    SQLiteTransaction t = conn.BeginTransaction();
                    try
                    {

                        result = c.ExecuteNonQuery();


                        t.Commit();

                        onScheduleChanded?.Invoke(conn, new EventArgs());
                        System.Windows.Forms.MessageBox.Show(msg);
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show("запись не удалена! (причина: " + e.Message + ")\n услуга присутствует в нарядах?");
                        t.Rollback();
                        t.Dispose();
                        //throw e;
                    }
                }

            }

            return result;

        }

        public static int EditPersonAdv(int personID, string passport, string serie, string ufms, string ucode, DateTime issued)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                using (SQLiteCommand c = new SQLiteCommand(@"UPDATE Persons SET passport=@ps, serie=@psr, ufms=@ufms, ufmsCode=@uCode, passIssued=@issued WHERE ID=@id", conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = personID;
                    c.Parameters.Add("@ps", DbType.String).Value = passport;
                    c.Parameters.Add("@psr", DbType.String).Value = serie;
                    c.Parameters.Add("@ufms", DbType.String).Value = ufms;
                    c.Parameters.Add("@uCode", DbType.String).Value = ucode;
                    c.Parameters.Add("@issued", DbType.Int64).Value = issued.Ticks;
                    
                    SQLiteTransaction t = conn.BeginTransaction();
                    try
                    {

                        result = c.ExecuteNonQuery();


                        t.Commit();
                        //onScheduleChanded?.Invoke(conn, new EventArgs());
                        System.Windows.Forms.MessageBox.Show(string.Format("Пасспортные данные для записи {0} изменены", personID));
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Пасспортные данные для записи {0} не изменены. (ошибка {1})", personID, e.Message));
                        t.Rollback();
                        t.Dispose();
                        //throw e;
                    }


                }
                conn.Close();

            }


            return result;
        }

        public static int EditPersonRecord(int personID, string Name, string Patrio, string Surname, DateTime birthday, string phone, string addres)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                using (SQLiteCommand c = new SQLiteCommand(@"UPDATE Persons SET firstName=@fn, lastName=@ln, patrioName=@pn, birthDay=@bd, phone=@ph, address=@ad WHERE ID=@id", conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = personID;
                    c.Parameters.Add("@fn", DbType.String).Value = Name;
                    c.Parameters.Add("@ln", DbType.String).Value = Surname;
                    c.Parameters.Add("@pn", DbType.String).Value = Patrio;
                    c.Parameters.Add("@bd", DbType.Int64).Value = birthday.Ticks;
                    c.Parameters.Add("@ph", DbType.String).Value = phone;
                    c.Parameters.Add("@ad", DbType.String).Value = addres;
                    SQLiteTransaction t = conn.BeginTransaction();
                    try
                    {

                        result = c.ExecuteNonQuery();


                        t.Commit();
                        //onScheduleChanded?.Invoke(conn, new EventArgs());
                        System.Windows.Forms.MessageBox.Show(string.Format("Запись {0} изменена", personID));
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Запись {0} не изменена. (ошибка {1})", personID, e.Message));
                        t.Rollback();
                        t.Dispose();
                        //throw e;
                    }


                }
                conn.Close();

            }


            return result;
        }

        public static int EditUserRecord(int userID, string login, string password)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                using (SQLiteCommand c = new SQLiteCommand(@"UPDATE Users SET login=@lg, password=@ps WHERE ID=@id", conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = userID;
                    c.Parameters.Add("@lg", DbType.String).Value = login;
                    c.Parameters.Add("@ps", DbType.String).Value = password;
                    
                    SQLiteTransaction t = conn.BeginTransaction();
                    try
                    {

                        result = c.ExecuteNonQuery();


                        t.Commit();
                        //onScheduleChanded?.Invoke(conn, new EventArgs());
                        System.Windows.Forms.MessageBox.Show(string.Format("Учётная запись {0} изменена успешно", userID));
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Запись {0} не изменена. (ошибка {1})", userID, e.Message));
                        t.Rollback();
                        t.Dispose();
                        //throw e;
                    }


                }
                conn.Close();

            }


            return result;
        }

        public static int AddScheduleRecord(int doctID, int personID, DateTime time, string serviceID)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                using (SQLiteCommand c = new SQLiteCommand(@"INSERT INTO Schedule (doctorID, personID, dateTime) VALUES (@did, @pid, @dt)", conn))
                {
                    c.Parameters.Add("@did", DbType.Int32).Value = doctID;
                    c.Parameters.Add("@pid", DbType.Int32).Value = personID;
                    c.Parameters.Add("@dt", DbType.Int64).Value = time.Ticks;
                    //if (serviceID != string.Empty)
                    //{
                        //c.Parameters.Add("@sid", DbType.String).Value = serviceID;
                    //}
                    //else
                    //{
                    //    c.Parameters.Add("@sid", DbType.String).Value = DBNull.Value;
                    //}

                    SQLiteTransaction t = conn.BeginTransaction();
                    try
                    {
                        
                        result = c.ExecuteNonQuery();
                        
                        
                        t.Commit();
                        onScheduleChanded?.Invoke(conn, new EventArgs());
                        System.Windows.Forms.MessageBox.Show(string.Format("Запись на {0} добавлена", time.ToShortTimeString()));
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("Запись не может быть добавлена. (ошибка {0})", e.Message));
                        t.Rollback();
                        t.Dispose();
                        //throw e;
                    }
                }
                conn.Close();

            }





            return result;
        }

        

        public static int RemoveScheduleRecord(int recordID)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {




                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                using (SQLiteCommand c = new SQLiteCommand(@"DELETE FROM Schedule WHERE recordID=@id", conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = recordID;

                    SQLiteTransaction t = conn.BeginTransaction();
                    try
                    {
                        


                        result = c.ExecuteNonQuery();


                        t.Commit();

                        onScheduleChanded?.Invoke(conn, new EventArgs());
                        System.Windows.Forms.MessageBox.Show("запись удалена");
                    }
                    catch (SQLiteException e)
                    {
                        System.Windows.Forms.MessageBox.Show("запись не удалена! причина: "+e.Message);
                        t.Rollback();
                        t.Dispose();
                        throw e;
                    }

                }
                conn.Close();
            }

            
            return result;
        }

        public static List<Person> GetPersonList()
        {
            List<Person> result = new List<Person>();
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                string query = "SELECT * FROM Persons";

                SQLiteCommand c = new SQLiteCommand(query, conn);




                conn.Open();
                using (SQLiteDataReader rdr = c.ExecuteReader())
                {


                    while (rdr.Read())
                    {
                        Person np = new Person(
                            rdr.GetInt32(0),
                            rdr.GetString(1),
                            rdr.GetString(6),
                            rdr.GetString(2),
                            rdr.GetString(4),
                            rdr.GetString(5),
                            rdr.GetInt64(3)
                            );
                        result.Add(np);
                    }
                }


                conn.Close();

            }
            return result;
        }

        public static List<ServiceView> GetOrderedServiceList(int orderID=-1)
        {
            List<ServiceView> result = new List<ServiceView>();
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {
                string query = "SELECT * FROM OrderedServiceList";
                if (orderID >= 0) query += " WHERE orderID=@order";


                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {
                    if (orderID >= 0) c.Parameters.Add("@order", DbType.Int32).Value = orderID;
                    conn.Open();
                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            DateTime? closeTimeMark = null;
                            //System.Windows.Forms.MessageBox.Show(rdr.GetValue(8).ToString());
                            long? mrk = Tools.TryParseLong(rdr.GetValue(8).ToString());
                            //if (!rdr.IsDBNull(8)) mrk = rdr.GetInt64(8);
                             
                            if (mrk.HasValue && mrk.Value>0) closeTimeMark = new DateTime(mrk.Value);
                            result.Add(new ServiceView(
                                rdr.GetString(0),
                                rdr.GetString(1),
                                rdr.GetString(2),
                                rdr.GetString(3),
                                rdr.GetString(4),
                                rdr.GetString(5),
                                rdr.GetInt32(6),
                                new DateTime(rdr.GetInt64(7)),
                                closeTimeMark,
                                rdr.GetFloat(9),
                                rdr.GetFloat(10),
                                rdr.GetValue(11).ToString()
                                ));
                        }
                    }
                }
            }
            return result;
        }

        

        public static List<Order> GetOrders()
        {
            List<Order> result = new List<Order>();

            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {
                string query = "SELECT orderID, orderOpen,  orderSubj, orderPaid, lastName||' '||SUBSTR(firstName,1,1)||'.'||SUBSTR(patrioName,1,1)||'.' AS client FROM Orders LEFT JOIN Persons ON Persons.ID=orderSubj";

                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {
                    conn.Open();
                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            DateTime closeTimeMark = DateTime.MinValue;
                            //System.Windows.Forms.MessageBox.Show(rdr.GetValue(8).ToString());
                            long? mrk = Tools.TryParseLong(rdr.GetValue(3).ToString());
                            //if (!rdr.IsDBNull(8)) mrk = rdr.GetInt64(8);

                            if (mrk.HasValue && mrk.Value > 0) closeTimeMark = new DateTime(mrk.Value);
                            result.Add(new Order(
                                rdr.GetInt32(0),
                                new DateTime(rdr.GetInt64(1)),                                
                                closeTimeMark,
                                rdr.GetInt32(2),
                                rdr.GetString(4)
                                ));
                        }
                    }
                }
            }



            return result;
        }

        public static List<Doctor> GetDoctors()
        {
            List<Doctor> result = new List<Doctor>();
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                string query = "SELECT * FROM getDoctors";

                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {




                    conn.Open();
                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int id = rdr.GetInt32(0);
                            string cap = rdr.GetString(1);
                            string name = rdr.GetString(2);
                            string patrio = rdr.GetString(3);
                            string surname = rdr.GetString(4);
                            int clients = rdr.GetInt32(5);
                            //string doctString = name[0] + "." + patrio[0] + ". " + surname + " (" + cap + ")";
                            Doctor d = new Doctor(id, name, patrio, surname, cap,clients);
                             
                            result.Add(d);
                        }
                    }
                }


                conn.Close();

            }
            return result;


        }

        public static Person GetPerson(int id)
        {
            Person result = null;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                string query = "SELECT * FROM Persons WHERE Persons.ID=@id";

                conn.Open();
                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = id;

                    
                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int pid = rdr.GetInt32(0);
                            string fname = rdr.GetValue(1).ToString();
                            string lname = rdr.GetValue(2).ToString();
                            long bd = (long)rdr.GetValue(3);
                            string phone = rdr.GetValue(4).ToString();
                            string addr = rdr.GetValue(5).ToString();
                            string pname = rdr.GetValue(6).ToString();
                            string pass = rdr.GetValue(7).ToString();
                            string serie = rdr.GetValue(8).ToString();
                            string ufms = rdr.GetValue(9).ToString();
                            string ufmsc = rdr.GetValue(10).ToString();
                            long passIssued = (long)rdr.GetValue(11);
                            result = new Person(pid,fname,pname,lname,phone,addr,bd,pass,serie,ufms,ufmsc,passIssued
                                
                                );
                        }
                    }

                    
                }
                conn.Close();
            }
            
            return result;
        }

        public static List<Service> GetServiceList(bool distinct = false, string id = null, string tooth=null)
        {
            List<Service> result = new List<Service>();
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                string query = "SELECT * FROM  ServiceTable";
                if (id!=null && tooth!=null) query += " WHERE serviceID=@id AND toothType=@tooth";
                if (distinct) query+=" GROUP BY serviceID";
                






                conn.Open();
                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {
                    if (id != null && tooth!=null)
                    {
                        c.Parameters.Add("@id", DbType.String).Value = id;
                        c.Parameters.Add("@tooth", DbType.String).Value = tooth;
                    }
                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //string id = rdr.GetString(0);
                            //string name = rdr.GetString(1);
                            //int tooth = rdr.GetInt32(2);
                            //float price = rdr.GetFloat(3);
                            //string descr = rdr.GetString(4);
                            //string av = rdr.GetString(5);
                            Service ns = new Service(rdr.GetString(0), rdr.GetString(2), rdr.GetString(1), rdr.GetFloat(3), rdr.GetString(4));
                            result.Add(ns);
                        }
                    }


                }
                conn.Close();

            }
            return result;
        }

        public static List<ToothType> GetServiceToothList(string serviceID)
        {
            List<ToothType> result = new List<ToothType>();
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                string query = "SELECT toothType FROM ServiceTable WHERE serviceID=@id";
                






                conn.Open();
                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {
                    c.Parameters.Add("@id", DbType.String).Value = serviceID;
                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //string id = rdr.GetString(0);
                            //string name = rdr.GetString(1);
                            //int tooth = rdr.GetInt32(2);
                            //float price = rdr.GetFloat(3);
                            //string descr = rdr.GetString(4);
                            //string av = rdr.GetString(5);
                            string ns = rdr.GetString(0);                            
                            result.Add(new ToothType(ns));
                        }
                    }


                }
                conn.Close();

            }
            return result;
        }

        public static string GetConnectionPath()
        {
            string result = "";
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {
                result = conn.ConnectionString;
            }
            return result;
        }

        public static List<scheduleRecord> getSchedule()
        {
            List<scheduleRecord> result = new List<scheduleRecord>();
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                string query = "SELECT recordID, doctorID, personID, dateTime, firstName||' '||lastName AS nameString FROM Schedule LEFT JOIN Persons ON Persons.ID = personID ORDER BY dateTime ASC";
                conn.Open();
                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {


                    
                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            scheduleRecord rec = new scheduleRecord();
                            rec.recordID = rdr.GetInt32(0);
                            rec.docID = rdr.GetInt32(1);
                            rec.personID = rdr.GetInt32(2);
                            rec.timeMark = rdr.GetInt64(3);
                            
                            rec.personName = rdr.GetString(4);
                            DateTime dat = new DateTime(rec.timeMark);
                            rec.timeString = dat.ToShortTimeString();
                            result.Add(rec);

                        }
                    }



                    

                }
                conn.Close();
            }
            return result;
        }

        public static bool CheckUser(string login)
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {
                string querry = "SELECT ID FROM Users WHERE login=@log";
                conn.Open();
                using (SQLiteCommand c = new SQLiteCommand(querry, conn))
                {
                    c.Parameters.Add("@log", DbType.String).Value = login;

                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {
                        if (rdr.Read()) result = true;
                    }
                }
                conn.Close();


            }
            return result;

        }

        public static int AddUser(int userID, string login, string password, int groupID)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                using (SQLiteCommand c = new SQLiteCommand(@"INSERT INTO Users (ID, login, password, groupID) VALUES(@id, @log, @pass, @grp)", conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = userID;
                    c.Parameters.Add("@log", DbType.String).Value = login;
                    c.Parameters.Add("@pass", DbType.String).Value = password;
                    c.Parameters.Add("@grp", DbType.Int32).Value = groupID;


                    using (SQLiteTransaction t = conn.BeginTransaction())
                    {
                        try
                        {

                            result = c.ExecuteNonQuery();


                            t.Commit();
                            //onScheduleChanded?.Invoke(conn, new EventArgs());
                            System.Windows.Forms.MessageBox.Show(string.Format("Учётная запись {0} добавлена успешно", userID));
                        }
                        catch (SQLiteException e)
                        {
                            System.Windows.Forms.MessageBox.Show(string.Format("Запись {0} не может быть добавлена. (ошибка {1})", userID, e.Message));
                            t.Rollback();
                            t.Dispose();
                            //throw e;
                        }
                    }


                }
                conn.Close();

            }


            return result;


        }

        public static int DeleteUser(int userID)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {

                conn.Open();
                var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                pragma.ExecuteNonQuery();
                using (SQLiteCommand c = new SQLiteCommand(@"DELETE FROM Users WHERE ID=@id", conn))
                {
                    c.Parameters.Add("@id", DbType.Int32).Value = userID;                    


                    using (SQLiteTransaction t = conn.BeginTransaction())
                    {
                        try
                        {

                            result = c.ExecuteNonQuery();


                            t.Commit();
                            //onScheduleChanded?.Invoke(conn, new EventArgs());
                            System.Windows.Forms.MessageBox.Show(string.Format("Учётная запись {0} удалена успешно", userID));
                        }
                        catch (SQLiteException e)
                        {
                            System.Windows.Forms.MessageBox.Show(string.Format("Запись {0} не может удалена. (ошибка {1})", userID, e.Message));
                            t.Rollback();
                            t.Dispose();
                            //throw e;
                        }
                    }


                }
                conn.Close();

            }


            return result;


        }


        public static bool HasUsers()
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {
                
                string querry = "SELECT ID FROM Users";
                conn.Open();
                using (SQLiteCommand c = new SQLiteCommand(querry, conn))
                {

                    
                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {
                        if (rdr.Read()) result = true;
                    }
                }
                conn.Close();


            }
            return result;
        }

        public static User Authorize(string login, string password)
        {
            User result = null;
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {
                
                string query = "SELECT * FROM Users WHERE LOWER(login)=LOWER(@ul) AND password=@up";
                conn.Open();
                using (SQLiteCommand c = new SQLiteCommand(query, conn))
                {

                    c.Parameters.Add("@ul", DbType.String).Value = login;
                    c.Parameters.Add("@up", DbType.String).Value = password;
                    
                    using (SQLiteDataReader rdr = c.ExecuteReader())
                    {



                        if (rdr.Read())
                        {
                            //Console.WriteLine($@"{rdr.GetInt32(0),-3} {rdr.GetString(1),-8} {rdr.GetString(2),8}");
                            result = new User(
                                rdr.GetInt32(0),
                                rdr.GetString(1),
                                rdr.GetString(2),
                                rdr.GetInt32(3),
                                0);

                        }
                    }
                }

                conn.Close();

            }
            return result;

            

        }

        public static void ClearDB()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Settings.DBPath))
            {
                string[] queryList = new string[]
                {
                    "DELETE FROM OrderService",
                    "DELETE FROM sqlite_sequence WHERE name='OrderService';",
                    "DELETE FROM Orders",
                    "DELETE FROM sqlite_sequence WHERE name='Orders';",
                    "DELETE FROM ServiceTable",
                    "DELETE FROM sqlite_sequence WHERE name='ServiceTable';",
                    "DELETE FROM Schedule",
                    "DELETE FROM sqlite_sequence WHERE name='Schedule';",
                    "DELETE FROM Users",
                    "DELETE FROM sqlite_sequence WHERE name='Users';",
                    "DELETE FROM UserGroups",
                    "DELETE FROM sqlite_sequence WHERE name='UserGroups';",
                    "DELETE FROM Doctors",
                    "DELETE FROM sqlite_sequence WHERE name='Doctors';",
                    "DELETE FROM Persons",
                    "DELETE FROM sqlite_sequence WHERE name='Persons';",
                };
                conn.Open();
                foreach (string comm in queryList)
                {
                    using (SQLiteCommand c = new SQLiteCommand(comm, conn))
                    {
                        c.ExecuteNonQuery();


                    }
                }
                conn.Close();
            }
        }
        
    }
}
