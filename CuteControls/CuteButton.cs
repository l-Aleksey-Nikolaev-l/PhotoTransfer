using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace PhotoTransfer.CuteControls
{
    public class CuteButton : Button
    {
        private int borderSize = 2;
        private int borderRadius = 20;
        private Color borderColor = Color.RoyalBlue;

        [Category("Advanced settings")]
        public int BorderSize
        {
            get { return borderSize; }
            set 
            {
                if (value * 2 > borderRadius)
                {
                    value = borderRadius / 2;
                }
                else
                {
                    borderSize = value;
                }
                Invalidate();
            }
        }
        [Category("Advanced settings")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set 
            {
                if (value < borderSize * 2)
                {
                    value = borderSize * 2;
                }

                if (value * 2 > Height || value * 2 > Width)
                {
                    Size = new Size(value * 2, value * 2);
                    borderRadius = value;
                }
                else
                {
                    borderRadius = value;
                }
                Invalidate(); 
            }
        }
        [Category("Advanced settings")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }
        [Category("Advanced settings")]
        public Color BackgroundColor
        {
            get { return BackColor; }
            set { BackColor = value; }
        }

        public CuteButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 40);
            BackColor = Color.WhiteSmoke;
            FlatAppearance.BorderColor = BackColor;
            FlatAppearance.MouseDownBackColor = Color.Gray;
            FlatAppearance.MouseOverBackColor = Color.LightGray;
            MinimumSize = new Size(20, 20);
            Resize += new EventHandler(Button_Resize);
        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if (Height <= borderRadius * 2)
            {
                borderRadius = Height / 2;
            }
            if (Width <= borderRadius * 2)
            {
                borderRadius = Width / 2;
            }
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();

            radius = radius * 2;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            
            Rectangle rectSurface = ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);

            if (borderRadius > 2)
            {

                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using(GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius-borderSize))
                using(Pen penSurface = new Pen(Parent.BackColor, borderSize))
                using(Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    Region = new Region(pathSurface);

                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                    {
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.Default;

                Region = new Region(rectSurface);

                if (borderSize >= 1)
                {
                    using(Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width-1, Height-1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColor);
        }

        private void Container_BackColor(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                Invalidate();
            }
        }
    }
}