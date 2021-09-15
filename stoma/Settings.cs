using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Reflection;

namespace stoma
{
    
    public static class Settings
    {
        public struct Tags
        {
            public string FullName, Age, Birthday, Phone, Addres, FirstName, LastName, PatrioName, ShortName,
                PassNum, PassSerie, PassUFMS, PassCode, PassIssued,
                OrderIssued, OrderPrice, OrderPriceStr, OrderID,
                ServicePrice, ServiceText, ServiceName, ServiceID,
                DoctorName, DoctorProfile,
                DateNow, DateNowShort;

            public Tags(string fullName="#nameFull", string age="#age", string birthday="#birth", 
                string phone="#phone", string addres="#addr", string firstName="#firstName", 
                string lastName="#lastName", string patrioName="#patrioName", string shortName="#nameShort", 
                string passNum="#passNum", string passSerie="#passSerie", string passUFMS="#ufms", 
                string passCode="#uCode", string passIssued="#passIssued", 
                string orderIssued="#orderIssued", string orderPrice="#orderPrice", 
                string orderPriceStr="#orderLiteralPrice", string orderID="#orderID", 
                string servicePrice="#servicePrice", string serviceText="#serviceText", 
                string serviceName="#serviceName", string serviceID="#serviceID", 
                string doctorName="#doctorName", string doctorProfile="#doctorProfile", 
                string dateNow="#dateNowLong", string dateNowShort="#dateNowShort")
            {
                FullName = fullName;
                Age = age;
                Birthday = birthday;
                Phone = phone;
                Addres = addres;
                FirstName = firstName;
                LastName = lastName;
                PatrioName = patrioName;
                ShortName = shortName;
                PassNum = passNum;
                PassSerie = passSerie;
                PassUFMS = passUFMS;
                PassCode = passCode;
                PassIssued = passIssued;
                OrderIssued = orderIssued;
                OrderPrice = orderPrice;
                OrderPriceStr = orderPriceStr;
                OrderID = orderID;
                ServicePrice = servicePrice;
                ServiceText = serviceText;
                ServiceName = serviceName;
                ServiceID = serviceID;
                DoctorName = doctorName;
                DoctorProfile = doctorProfile;
                DateNow = dateNow;
                DateNowShort = dateNowShort;
            }
        }
        public static string DBPath { get; set; }

        public static float DAY_BEGIN_HOUR = 8;
        public static float DAY_END_HOUR = 14;
        public static int MINUTES_PER_PATIENT = 15;

        static string fileName = "settings.xml";

        public static Dictionary<string, string> toothTypes = new Dictionary<string, string>();

        public static Dictionary<string, string> toothNames = new Dictionary<string, string>();

        public static Dictionary<string,string> TemplatePath = new Dictionary<string, string>();

        //public static Dictionary<string, string> replacementTags = new Dictionary<string, string>();

        public static Tags replacementTags;

       

        public static bool ReadSettings()
        {
            DBPath = System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            


            if (File.Exists(fileName))
            {
                //System.Windows.Forms.MessageBox.Show("настройки прочитаны");
                
                
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);

                DAY_BEGIN_HOUR = float.Parse( doc.GetElementsByTagName("DAY_BEGIN_HOUR")[0].InnerText);
                
                DAY_END_HOUR = float.Parse(doc.GetElementsByTagName("DAY_END_HOUR")[0].InnerText);
                
                MINUTES_PER_PATIENT = int.Parse(doc.GetElementsByTagName("MINUTES_PER_PATIENT")[0].InnerText);

                XmlNodeList toothY = doc.SelectNodes("//settings/ToothSet/toothType");
                toothTypes.Clear();
                foreach(XmlNode n in toothY)
                {
                    //System.Windows.Forms.MessageBox.Show(n.Attributes["id"].InnerText + " " + n.InnerText);
                    toothTypes.Add(n.Attributes["id"].InnerText, n.InnerText);
                }
                XmlNodeList toothN = doc.SelectNodes("//settings/ToothNum/tooth");
                foreach(XmlNode nm in toothN)
                {
                    toothNames.Add(nm.Attributes["id"].InnerText, nm.InnerText);
                }
                XmlNodeList TemplatePaths = doc.SelectNodes("//settings/Templates/Template");
                if (TemplatePaths.Count > 0)
                {
                    TemplatePath = new Dictionary<string, string>();
                   
                    foreach(XmlNode path in TemplatePaths)
                    {
                        if(path.ChildNodes.Count<2)
                            TemplatePath.Add(path.Attributes["name"].InnerText, path.InnerText);
                        else
                        {
                            //System.Windows.Forms.MessageBox.Show(path.ChildNodes.Count.ToString());
                            foreach (XmlNode sub in path.ChildNodes)
                            {
                                TemplatePath.Add(path.Attributes["name"].InnerText + "." + sub.Attributes["name"].InnerText, sub.InnerText);
                            }
                        }
                        
                    }
                    //System.Windows.Forms.MessageBox.Show(Tools.Combine(TemplatePath));
                }
                XmlNodeList tags = doc.SelectNodes("//settings/ReplacementTags")[0].ChildNodes;
                replacementTags = new Tags();
                string msg = "";
                object inp = replacementTags;
                foreach (XmlNode tag in tags)
                {
                    try
                    {
                        FieldInfo f = inp.GetType().GetField(tag.Name);
                        if (f != null)
                        {
                            object value = tag.InnerText;
                            
                            f.SetValue(inp, value);
                            
                            //System.Windows.Forms.MessageBox.Show(tag.Name+":"+tag.InnerText+" "+f.Name+":"+f.GetValue(inp));
                        }
                        else msg+= tag.Name + " не найдено \n";
                    }
                    catch(Exception e)
                    {
                        msg += tag.Name + " не найдено \n";
                    }
                    
                    
                }
                replacementTags = (Tags)inp;
                if (msg != string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show("Некоторые тэги не были назначены \n" + msg);
                    

                }
                //System.Windows.Forms.MessageBox.Show(replacementTags.FullName);



                return true;
            }

            System.Windows.Forms.MessageBox.Show("не найден файл настроек");
            return false;
        }

        public static void StoreTemplatePath(string path, string template, string sub="")
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(fileName))
            {
                doc.Load(fileName);
                //XmlNode root = doc.DocumentElement;
                XmlNodeList xnList = doc.SelectNodes(string.Format("//settings/Templates/Template[@name='{0}']",template));
                if (sub != "") xnList = doc.SelectNodes(string.Format("//settings/Templates/Template[@name='{0}']/Type[@name='{1}']", template, sub));
                if (xnList.Count > 0)
                {
                    foreach (XmlNode xn in xnList)
                    {
                        xn.InnerText = path;
                        System.Windows.Forms.MessageBox.Show("путь к шаблону сохранён: " + path);
                    }
                }
                else
                {
                    if (sub == "")
                    {
                        XmlNodeList n = doc.SelectNodes("//settings/Templates");
                        XmlElement node = doc.CreateElement("Template");
                        XmlAttribute atr = doc.CreateAttribute("name");
                        atr.InnerText = template;
                        node.Attributes.Append(atr);
                        node.InnerText = path;
                        n[0].AppendChild(node);
                        
                    }
                    else
                    {
                        XmlNodeList n = doc.SelectNodes("//settings/Templates");
                        XmlElement node = doc.CreateElement("Template");
                        XmlAttribute atr = doc.CreateAttribute("name");
                        XmlElement subnode = doc.CreateElement("Type");
                        XmlAttribute subAttr = doc.CreateAttribute("name");

                        atr.InnerText = template;
                        node.Attributes.Append(atr);
                        subAttr.InnerText = sub;
                        subnode.Attributes.Append(subAttr);
                        subnode.InnerText = path;                        
                        n[0].AppendChild(node);
                        node.AppendChild(subnode);
                    }
                    System.Windows.Forms.MessageBox.Show("путь к шаблону задан: " + path);
                }

                doc.Save(fileName);
                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("не найден файл настроек");
            }
        }


    }
}
