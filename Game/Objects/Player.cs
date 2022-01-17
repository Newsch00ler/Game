using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    class Player : BaseObject
    {
        public Action<Marker> OnMarkerOverlap;
        public Action<Berries> OnBerriesOverlap;
        public float vX, vY;
        public Player(float x, float y, float angle) : base(x, y, angle)
        {
        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Peru), -15, -15, 30, 30);
            g.FillEllipse(new SolidBrush(Color.Black), 5, -2, 3, -3); // глаз
            g.FillEllipse(new SolidBrush(Color.Black), 5, 2, 3, 3); // глаз
            g.DrawEllipse(new Pen(Color.Black, 3), -15, -15, 30, 30);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -20, 0); // иголки
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -20, 2);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -20, -2);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -19, 6);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -19, -6);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -18, 8);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -18, -8);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -17, 10);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -17, -10);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -15, 10);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -15, -10);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -14, 14);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -14, -14);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -12, 14);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -12, -14);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -9, 16);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -9, -16);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -7, 17);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -7, -17);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -6, 17);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -6, -17);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -4, 18);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -4, -18);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -3, 18);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, -3, -18);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 0, 19);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 0, -19);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 2, 21);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 2, -21);
            g.DrawLine(new Pen(Color.DarkRed, 2), 10, 0, 15, 0); // нос
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);
            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }
            else if (obj is Berries)
            {
                OnBerriesOverlap(obj as Berries);
            }
        }
    }
}
