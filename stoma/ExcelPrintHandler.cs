using stoma.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace stoma
{
    public static class ExcelPrintHandler
    {
        
        static void FindAndReplace(Excel.Range rnge, object what, dynamic value)
        {
            
                Excel.Range idField = rnge.Find(what, LookIn: Excel.XlFindLookIn.xlValues, LookAt: Excel.XlLookAt.xlPart,
                                SearchOrder: Excel.XlSearchOrder.xlByRows, SearchDirection: Excel.XlSearchDirection.xlNext, MatchCase: false);
            //System.Windows.Forms.MessageBox.Show(idField.Count.ToString());
            Excel.Range first = idField;
                while (idField != null)
                {
                    Excel.Range foundTemp = idField;
                    idField.Value2 = value;
                    
                    idField = rnge.FindNext(foundTemp);

                if (idField!=null && idField.Address == first.Address)
                    idField = null;
            }
            
        }

        public static string PrintOrder(Order order, string templatePath, object printer)
        {
            string result = "Страница отправлена на печать";

            Person p = DBHandler.GetPerson(order.clientID);
            List<ServiceView> svc = DBHandler.GetOrderedServiceList(order.orderID);
            //System.Windows.Forms.MessageBox.Show(p.Address);
            float price = 0;

            svc.ForEach(S =>
            {
                price += S.price * S.discount;
            });

            Dictionary<string, dynamic> Fill = new Dictionary<string, dynamic>
            {
                {Settings.replacementTags.FullName, p.LastName+" "+p.FirstName+" "+p.PatrioName},
                {Settings.replacementTags.OrderID, order.orderID.ToString() },
                {Settings.replacementTags.Addres, p.Address.Replace('\n',' ') },
                {Settings.replacementTags.OrderIssued, order.issued.ToLongDateString() },
                {Settings.replacementTags.OrderPrice, price },
                {Settings.replacementTags.Phone, p.Phone }
            };

            try
            {
                Excel.Application app = new Excel.Application();
                try
                {
                    Excel.Workbook WB = app.Workbooks.Open(templatePath);
                    try
                    {
                        Excel.Worksheet WS = WB.Worksheets[1];
                        Excel.Range rnge = WS.UsedRange;


                        foreach(var k in Fill)
                        {
                            FindAndReplace(rnge, k.Key, k.Value);
                        }

                        Excel.Range serviceRec = rnge.Find(Settings.replacementTags.ServiceText, Type.Missing,
                            Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
                            Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false,
                            Type.Missing, Type.Missing);
                        if (serviceRec != null)
                        {
                            int svccol = serviceRec.Column;
                            int svcrow = serviceRec.Row;
                            
                            Excel.Range priceRec = rnge.Find(Settings.replacementTags.ServicePrice, Type.Missing,
                            Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
                            Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false,
                            Type.Missing, Type.Missing);
                            if(priceRec!=null)
                            {
                                int pricecol = priceRec.Column;
                                Excel.Range start = WS.Cells[serviceRec.Row-1, serviceRec.Column];
                                Excel.Range end = WS.Cells[priceRec.Row, priceRec.Column - 1];
                                svc.ForEach(S =>
                                {
                                    //System.Windows.Forms.MessageBox.Show(serviceRec.Column+" "+ serviceRec.Row+" "+priceRec.Column+" "+priceRec.Row);
                                    end = WS.Cells[priceRec.Row, pricecol - 1];
                                    string serviceStr = S.serviceID + " " + S.serviceDescr;
                                    if (Settings.toothNames.ContainsKey(S.toothName) && S.toothName != "no") serviceStr +=" "+Settings.toothNames[ S.toothName];
                                    if (Settings.toothTypes.ContainsKey(S.toothType) && S.toothType != "ca") serviceStr += " (" + Settings.toothTypes[ S.toothType] + ")";
                                    if (S.discount < 1) serviceStr += " скидка:" + (1 - S.discount) * 100 + "%";
                                    Excel.Range line = WS.Rows[svcrow];
                                    line.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
                                    Excel.Range col1 = line.Columns[svccol];                                    
                                    Excel.Range col2 = line.Columns[pricecol];
                                    
                                    col1.Value2 = serviceStr;
                                    col2.Value2 = S.price * S.discount;

                                    

                                    //((Excel.Range)line.Columns[svccol]).Value2 = S.serviceID + " " + S.serviceDescr + " " + S.toothName + " (" + S.toothType + ")";
                                    //svcrow++;


                                });
                                //System.Windows.Forms.MessageBox.Show(start.Row + " " + start.Column + " " + end.Row + " " + end.Column);
                                WS.Range[start, end].Merge(true);



                            }




                        }




                        


                        rnge.PrintOutEx(ActivePrinter:printer);

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.FinalReleaseComObject(WS);
                        WB.Close(false, Type.Missing, Type.Missing);
                        Marshal.FinalReleaseComObject(WB);
                    }
                    catch(Exception e)
                    {
                        result = "Файл шаблона не содержит необходимых меток полей. ("+e.Message+"\n"+e.StackTrace+")";
                    }
                }
                catch
                {
                    result = "По указанному пути файл шаблона не найден";
                }
                app.Quit();
                Marshal.FinalReleaseComObject(app);
            }
            catch (Exception e)
            {
                result = "Excel на компьютере не обнаружен. печать из шаблона Excel не возможна: " + e.Message;

            }
            return result;
        }





    }
}
