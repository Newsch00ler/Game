using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    class Berries : BaseObject
    {
        public Action<Berries> WantsRemove;
        public int count = 100;
        public Berries(float x, float y, float angle) : base(x, y, angle)
        {
        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Indigo), -200, -200, 25, 25);
            g.FillEllipse(new SolidBrush(Color.Green), -190, -200, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Black), -187, -197, 5, 5);
            if (count > 0)
            {
                g.DrawString(
                    $"{count}%",
                    new Font("Verdana", 6), // шрифт и размер
                    new SolidBrush(Color.Indigo), // цвет шрифта
                    -180, -180 // точка в которой нарисовать текст
                    );
                count--;
            }
            else
            {
                WantsRemove?.Invoke(this);
            }
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-200, -200, 25, 25);
            return path;
        }
    }
}
