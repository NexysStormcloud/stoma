﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stoma
{
    public class VertSep : Control
    {
        private Color lineColor;
        private Pen linePen;

        public VertSep()
        {
            this.LineColor = Color.LightGray;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        public Color LineColor
        {
            get
            {
                return this.lineColor;
            }
            set
            {
                this.lineColor = value;

                this.linePen = new Pen(this.lineColor, 1);
                this.linePen.Alignment = PenAlignment.Inset;

                Refresh();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.linePen != null)
            {
                this.linePen.Dispose();
                this.linePen = null;
            }

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            int x = this.Width / 2;

            g.DrawLine(linePen, x, 0, x, this.Height);

            base.OnPaint(e);
        }
    }
}
