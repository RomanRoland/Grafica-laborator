namespace Lab_grafica_1._2
{
    public partial class Form1 : Form
    {
        Point A = new Point(100, 100);
        Point B = new Point(350, 150);
        Point C = new Point(200, 300);
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawPoint(g, A, Color.Black);
            DrawPoint(g, B, Color.Black);
            DrawPoint(g, C, Color.Black);
            DrawLineBresenham(g, A, B, Color.Red, 1);
            DrawLineBresenham(g, B, C, Color.Blue, 2);
            DrawLineBresenham(g, C, A, Color.Green, 3);
        }
        private void DrawLineBresenham(Graphics g, Point p1, Point p2, Color color, int thickness)
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
                DrawPixel(g, x1, y1, color, thickness);

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
        private void DrawPixel(Graphics g, int x, int y, Color color, int size = 1)
        {
            using (Brush b = new SolidBrush(color))
            {
                g.FillRectangle(b, x - size / 2, y - size / 2, size, size);
            }
        }
        private void DrawPoint(Graphics g, Point p, Color color)
        {
            using (Brush b = new SolidBrush(color))
            {
                g.FillEllipse(b, p.X - 4, p.Y - 4, 8, 8);
            }
        }
    }
}
