using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace stoma.DataModels
{
   
    public struct GraphRect
    {
        readonly int x, y, w, h;
        readonly string colorString;

        public Rectangle rect => new Rectangle(x, y, w, h);


        public Brush fill
        {
            get
            {
                
                return new SolidBrush(Tools.ColorFromHtml(colorString));
            }
        }

        
        public GraphRect(int x, int y, int w, int h, string colorString)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.colorString = colorString;
        }
    }
    public struct GraphString
    {
        public string text { get; private set; }
        readonly int x, y;
        readonly string colorString;
        readonly string fnt;

        public Point point => new Point(x, y);
        readonly float size;

        public Brush fill => new SolidBrush(Tools.ColorFromHtml(colorString));
        public Font font => new Font(fnt, size);

        public GraphString(string text, int x, int y, float size, string colorString, string font)
        {
            this.text = text;
            this.x = x;
            this.y = y;
            this.size = size;
            this.colorString = colorString;
            this.fnt = font;
        }
    }

    public class PrintTemplate
    {
        public List<GraphRect> rects;
        public List<GraphString> textLines;



        public PrintTemplate(string tmpPath, Dictionary<string,string> tags)
        {
            rects = new List<GraphRect>();
            textLines = new List<GraphString>();
            if (File.Exists(tmpPath))
            {
                //System.Windows.Forms.MessageBox.Show("настройки прочитаны");

                
                XmlDocument doc = new XmlDocument();
                doc.Load(tmpPath);

                XmlNodeList lines = doc.GetElementsByTagName("rect");
                foreach (XmlNode rect in lines)
                {
                    rects.Add(new GraphRect(int.Parse(rect.Attributes["x"].InnerText),
                        int.Parse(rect.Attributes["y"].InnerText),
                        int.Parse(rect.Attributes["w"].InnerText),
                        int.Parse(rect.Attributes["h"].InnerText),
                        rect.Attributes["color"].InnerText));
                }
                XmlNodeList labels = doc.GetElementsByTagName("label");
                foreach (XmlNode text in labels)
                {
                    
                    string txt = text.InnerText;
                    if (tags.ContainsKey(txt)) txt = tags[txt];
                    int? x = Tools.TryParseInt( text.Attributes["x"].InnerText);
                    int? y = Tools.TryParseInt(text.Attributes["y"].InnerText);
                    int? size = Tools.TryParseInt(text.Attributes["size"].InnerText);
                    string col = text.Attributes["color"].InnerText;
                    string font = text.Attributes["font"].InnerText;
                    textLines.Add(new GraphString(txt, x.Value,y.Value,size.Value, col, font ));
                }




            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Файл шаблона не найден по укзанному пути: " + tmpPath);
            }
        }



    }
}
