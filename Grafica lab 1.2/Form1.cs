namespace Grafica_lab_1._2
{
    public partial class Form1 : Form
    {
        Point? P1 = null;
        Point? P2 = null;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MouseClick += Form1_MouseClick;
            this.Paint += Form1_Paint;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (P1 == null)
                P1 = e.Location;
            else if (P2 == null)
                P2 = e.Location;
            else
            {
                P1 = e.Location;
                P2 = null;
            }
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (P1 != null)
                DrawPixel(g, P1.Value.X, P1.Value.Y, Color.Red);

            if (P1 != null && P2 != null)
            {
                DrawPixel(g, P2.Value.X, P2.Value.Y, Color.Red);
                DrawLineBresenham(g, P1.Value, P2.Value, Color.Blue);
            }
        }
        private void DrawLineBresenham(Graphics g, Point p1, Point p2, Color color)
        {
            int x1 = p1.X;
            int y1 = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;

            int err = dx - dy;

            while (true)
            {
                DrawPixel(g, x1, y1, color);

                if (x1 == x2 && y1 == y2)
                    break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }
        }
        private void DrawPixel(Graphics g, int x, int y, Color color)
        {
            using (Brush b = new SolidBrush(color))
            {
                g.FillRectangle(b, x, y, 1, 1);
            }
        }
    }
}
