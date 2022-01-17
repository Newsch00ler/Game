using Game.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new();
        Player player;
        Marker marker;
        Berries berries;
        Berries berries1;

        public Form1()
        {
            InitializeComponent();
            Random randomX = new Random();
            Random randomY = new Random();
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            int countScore = 0;
            txtScore.Text = $"{countScore}";
            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };

            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);

            player.OnBerriesOverlap += (p) =>
            {   
                countScore = countScore + 1;
                txtScore.Text = $"{countScore}";
                p.X = pbMain.Width / 2 + randomX.Next(-150, 550);
                p.Y = pbMain.Height / 2 + randomY.Next(-20, 375);
                p.count = 100;
            };

            if (berries == null)
            {
                berries = new Berries(pbMain.Width / 2 + randomX.Next(-150, 550), pbMain.Height / 2 + randomY.Next(-20, 375), 0);
                berries.WantsRemove += (p) =>
                {
                    p.X = pbMain.Width / 2 + randomX.Next(-150, 550);
                    p.Y = pbMain.Height / 2 + randomY.Next(-20, 375);
                    p.count = 100;
                };
            }
            if (berries1 == null)
            {
                berries1 = new Berries(pbMain.Width / 2 + randomX.Next(-150, 550), pbMain.Height / 2 + randomY.Next(-20, 375), 0);
                berries1.WantsRemove += (p) =>
                {
                    p.X = pbMain.Width / 2 + randomX.Next(-150, 550);
                    p.Y = pbMain.Height / 2 + randomY.Next(-20, 375);
                    p.count = 100;
                };
            }

            objects.Add(marker);
            objects.Add(berries);
            objects.Add(berries1);
            objects.Add(player);
        }
        private void updateplayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;

                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;

            player.X += player.vX;
            player.Y += player.vY;
        }
        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White); // фон

            updateplayer();

            foreach (var obj in objects.ToList()) // пересчёт пересечений
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
            }
            foreach (var obj in objects) // рендер объектов
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbMain.Invalidate(); 
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }
            marker.X = e.X;
            marker.Y = e.Y;
        }
    }
}
