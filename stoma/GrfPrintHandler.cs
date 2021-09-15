using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stoma.DataModels;

namespace stoma
{
    public static class GrfPrintHandler
    {

        public static void printPage(System.Drawing.Printing.PrintPageEventArgs e, PrintTemplate p)
        {
            p.rects.ForEach(line =>
            {
                e.Graphics.FillRectangle(line.fill, line.rect);
            });
            p.textLines.ForEach(text =>
            {
                e.Graphics.DrawString(text.text, text.font, text.fill, text.point);
            });

            
        }



    }
}
