using System.Drawing;
using System.Windows.Forms;

namespace Strategy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tBoard1.Game.Timer = PlayTimer;
            tBoard1.Scroll += TBoard1_Scroll;
            PlayTimer.Start();
        }

        private void TBoard1_Scroll(object sender, ScrollEventArgs e)
        {
            mapPreview.Invalidate();
        }

        float ScrollStep = 0.1f;

        private void PlayTimer_Tick(object sender, System.EventArgs e)
        {
            if (Cursor.Position.X < Margin.Left)
            {
                tBoard1.ScrollPos -= new SizeF(ScrollStep, 0);
            }
            else if (Cursor.Position.X > Width - Margin.Right)
            {
                tBoard1.ScrollPos += new SizeF(ScrollStep, 0);
            }

            if (Cursor.Position.Y < Margin.Top)
            {
                tBoard1.ScrollPos -= new SizeF(0, ScrollStep);
            }
            else if (Cursor.Position.Y > Height - Margin.Bottom)
            {
                tBoard1.ScrollPos += new SizeF(0, ScrollStep);
            }

        }

        private void mapPreview_Paint(object sender, PaintEventArgs e)
        {
            var scaleX = (float) mapPreview.Width / tBoard1.Game.Map.Width;
            var scaleY = (float) mapPreview.Height / tBoard1.Game.Map.Height;

            e.Graphics.ScaleTransform(scaleX, scaleY);
            e.Graphics.DrawImage(tBoard1.Game.Map, Point.Empty);

            e.Graphics.DrawRectangle(Pens.Blue, tBoard1.ViewPort);
        }

        private void mapPreview_Click(object sender, System.EventArgs e)
        {

        }

        private void mapPreview_MouseDown(object sender, MouseEventArgs e)
        {
            tBoard1.ScrollPos = new PointF((float)e.X / mapPreview.Width, (float)e.Y / mapPreview.Height);
        }

        private void mapPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                tBoard1.ScrollPos = new PointF((float)e.X / mapPreview.Width, (float)e.Y / mapPreview.Height);
            }
        }

        private void turnButton_Click(object sender, System.EventArgs e)
        {
            tBoard1.Game.NextTurn();
            tBoard1.MoveToCell(tBoard1.Game.ActiveHero.CurrentCell);
        }

        private void tBoard1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
