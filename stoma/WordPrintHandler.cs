using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using stoma.DataModels;

namespace stoma
{
    public static class WordPrintHandler
    {


        private static void FindAndReplace(Application doc, object findText, object replaceWithText)
        {
            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }

        static string printDocument(string template, string[] tags, object[] content)
        {
            string result = "Успешно";
            try
            {
                Application app = new Application { Visible = true };
                try
                {
                    Document doc = app.Documents.Open(Settings.TemplatePath[template], ReadOnly: false, Visible: true);

                    try
                    {
                        doc.Activate();
                        for(int i = 0; i<tags.Length&&i<content.Length; i++)
                        {
                            FindAndReplace(app, tags[i], content[i]);
                        }

                        //doc.PrintOut();

                    }
                    catch(Exception e)
                    {
                        result = "не подходящий шаблон: "+e.Message;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        doc.Close(false, Type.Missing, Type.Missing);
                        Marshal.FinalReleaseComObject(doc);
                    }

                }
                catch(Exception e)
                {
                    result = "по указанному пути не найден файл шаблона: " + e;
                    app.Quit();
                    Marshal.FinalReleaseComObject(app);
                }

            }
            catch (Exception e)
            {
                result = "на устройстве не найдено MS Office Word. печать из шаблона невозможна. \n"+e;

            }


            return result;
        }

        public static string PrintDocument(string path, Dictionary<string,object> replacements)
        {
            string result = "Успешно";
            string[] tags = replacements.Keys.ToArray();
            object[] content = replacements.Values.ToArray();
            try
            {
                Application app = new Application { Visible = true };
                try
                {
                    Document doc = app.Documents.Open(path, ReadOnly: false, Visible: true);

                    try
                    {
                        doc.Activate();
                        for (int i = 0; i < tags.Length && i < content.Length; i++)
                        {
                            FindAndReplace(app, tags[i], content[i]);
                        }

                        //doc.PrintOut();

                    }
                    catch (Exception e)
                    {
                        result = "не подходящий шаблон: " + e.Message;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        doc.Close(false, Type.Missing, Type.Missing);
                        Marshal.FinalReleaseComObject(doc);
                    }

                }
                catch (Exception e)
                {
                    result = "по указанному пути не найден файл шаблона: " + e;
                    app.Quit();
                    Marshal.FinalReleaseComObject(app);
                }

            }
            catch (Exception e)
            {
                result = "на устройстве не найдено MS Office Word. печать из шаблона невозможна. \n" + e;

            }


            return result;
        }

        public static string PrintBlank(Person p, string tag)
        {
            string[] usedTags = {
                Settings.replacementTags.FullName,
                Settings.replacementTags.ShortName,
                Settings.replacementTags.Birthday,
                Settings.replacementTags.Addres,
                Settings.replacementTags.PassNum,
                Settings.replacementTags.PassCode,
                Settings.replacementTags.DateNow,
                Settings.replacementTags.DateNowShort
                
            };


            object[] content =
            {
                p.LastName+" "+p.FirstName+" "+p.PatrioName,
                p.FirstName[0]+"."+p.PatrioName[0]+". "+p.LastName,
                new DateTime(p.Birthday).ToShortDateString(),
                p.Address.Replace('\n',' '),
                p.passport,
                p.serie,
                DateTime.Now.ToLongDateString(),
                DateTime.Now.ToShortDateString()
                
            };

            return printDocument(tag, usedTags, content);
        }

        public static string PrintInvoice(Order o)
        {
            
            Person p = DBHandler.GetPerson(o.clientID);
            List<ServiceView> services = DBHandler.GetOrderedServiceList(o.orderID);
            float price = 0;
            services.ForEach(S =>
            {
                price += S.price * S.discount;
            });
            string[] usedTags = { 
                Settings.replacementTags.FullName,
                Settings.replacementTags.ShortName,
                Settings.replacementTags.OrderPrice,
                Settings.replacementTags.OrderPriceStr,
                Settings.replacementTags.PassNum, 
                Settings.replacementTags.PassSerie, 
                Settings.replacementTags.PassUFMS, 
                Settings.replacementTags.PassCode, 
                Settings.replacementTags.Addres, 
                Settings.replacementTags.Birthday, 
                Settings.replacementTags.PassIssued, 
                Settings.replacementTags.DateNow,
                Settings.replacementTags.DateNowShort,
                Settings.replacementTags.OrderIssued };

            object[] content =
            {
                p.LastName+" "+p.FirstName+" "+p.PatrioName,
                p.FirstName[0]+"."+p.PatrioName[0]+". "+p.LastName,
                string.Format("{0:F2}",price),
                Tools.ConvertNumToWords(price),
                p.passport,
                p.serie,
                p.ufms,
                p.ufmsCode,
                p.Address.Replace(Environment.NewLine, " "),
                new DateTime( p.Birthday).ToLongDateString(),
                new DateTime(p.passIssued).ToLongDateString(),
                DateTime.Now.ToLongDateString(),
                DateTime.Now.ToShortDateString(),
                o.issued.ToShortDateString()
            };
            return printDocument("invoice", usedTags, content);
        }

        public static string PrintAgreement(Person p, Doctor d)
        {

            string[] usedTags = {
                Settings.replacementTags.FullName,
                Settings.replacementTags.ShortName,
                Settings.replacementTags.Birthday,
                Settings.replacementTags.Addres,
                Settings.replacementTags.PassNum,
                Settings.replacementTags.PassCode,
                Settings.replacementTags.DateNow,
                Settings.replacementTags.DateNowShort,
                Settings.replacementTags.DoctorName
            };


            object[] content =
            {
                p.LastName+" "+p.FirstName+" "+p.PatrioName,
                p.FirstName[0]+"."+p.PatrioName[0]+". "+p.LastName,
                new DateTime(p.Birthday).ToShortDateString(),
                p.Address.Replace('\n',' '),
                p.passport,
                p.serie,
                DateTime.Now.ToLongDateString(),
                DateTime.Now.ToShortDateString(),
                d.firstName[0]+"."+d.patrioName[0]+". "+d.lastName
            };
            return printDocument("agreement", usedTags, content);


        }




    }
}
