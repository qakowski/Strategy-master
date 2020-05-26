using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Strategy
{
    public partial class TBoard : UserControl
    {
        public float Zoom = 40;
        PointF _ScrollPos;

        public TGame Game = new TGame();

        public Matrix Transform
        {
            get 
            {
                var transform = new Matrix();
                transform.Translate(Width / 2f, Height / 2f);
                transform.Scale(Zoom, Zoom);
                transform.Translate(-ScrollPos.X*Game.Map.Width, -ScrollPos.Y*Game.Map.Height);
                return transform;
            }
        }

        public PointF project(PointF p)
        {
            var points = new PointF[] { p };
            Transform.TransformPoints(points);
            return points[0];
        }

        public PointF unproject(PointF p)
        {
            var points = new PointF[] { p };
            var transform = Transform;
            transform.Invert();
            transform.TransformPoints(points);
            return points[0];
        }

        public Rectangle ViewPort
        {
            get
            {
                var topLeft = unproject(new PointF(0, 0));
                var bottomRight = unproject(new PointF(Width, Height));
                
                return Rectangle.FromLTRB((int)topLeft.X, (int)topLeft.Y, (int)bottomRight.X, (int)bottomRight.Y);
            }
        }

        private PointF scrollPos;
        public PointF ScrollPos
        {
            get { return scrollPos; }
            set 
            { 
                scrollPos.X = Math.Min(Math.Max(value.X, 0), 1); 
                scrollPos.Y = Math.Min(Math.Max(value.Y, 0), 1);

                OnScroll(null);

                Invalidate();
            }
        }

        public TBoard()
        {
            InitializeComponent();
            MouseWheel += MakeZoom;
            DoubleBuffered = true;
            
        }

        private void MakeZoom(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                Zoom *= 0.9f;
            }
            else
            {
                Zoom *= 1.1f;
            }
            OnScroll(null);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.Transform = Transform;
            //e.Graphics.DrawImage(Game.Map, Point.Empty);

            var vp = Rectangle.Round(ViewPort);
            vp.Inflate(1, 1);
            var font = new Font("Arial", 12f / Zoom);
            for (int y = vp.Top; y < vp.Bottom; y++)
            {
                for (int x = vp.Left; x < vp.Right; x++)
                {
                    if (x < 0 || x >= Game.Map.Width || y < 0 || y >= Game.Map.Height)
                    {
                        continue;
                    }

                    var cell = Game.Cells[y, x];
                    var rc = new RectangleF(x, y, 1, 1);
                    if (cell.Piece is TTile)
                    {
                        var bitmap = Game.TileImages[cell.Piece.ImageIndex];
                        rc.Inflate(0.25f, 0.25f);
                        e.Graphics.DrawImage(bitmap, rc);
                    }
                    else if(cell.Piece is TArtifact)
                    {
                        var bitmap = Game.ArtifactImages[cell.Piece.ImageIndex];
                        rc.X -= 1;
                        rc.Width = 2;
                        e.Graphics.DrawImage(bitmap, rc);
                    }
                    else if(cell.Piece is TResource)
                    {
                        var bitmap = Game.ResImages[cell.Piece.ImageIndex];
                        rc.X -= 1;
                        rc.Width = 2;
                        e.Graphics.DrawImage(bitmap, rc);
                    }
                    else if(cell.Piece is THero)
                    {
                        var hero = (THero)cell.Piece;
                        var brush = new SolidBrush(hero.Player.ColorId);
                        
                        rc.Inflate(-0.25f, -0.25f);
                        e.Graphics.FillRectangle(brush, rc);
                        e.Graphics.DrawString(hero.Name, font, Brushes.Black, rc);
                    }
                }
            }
        }

        public void MoveToCell(TCell cell)
        {
            ScrollPos = new PointF((float)cell.X / Game.Map.Width, (float)cell.Y / Game.Map.Height);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }


    }
}
