namespace Grafica_lab_1._4
{
    public partial class Form1 : Form
    {
        float scale = 40f;
        float step = 0.05f;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PointF origin = new PointF(
                ClientSize.Width / 2,
                ClientSize.Height / 2
            );
            DrawAxes(g, origin);
            DrawFunction(g, origin, x => x * x, Color.Red);
            DrawFunction(g, origin, x => Math.Sin(x), Color.Blue);
        }
        private void DrawAxes(Graphics g, PointF origin)
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.DrawLine(pen, 0, origin.Y, ClientSize.Width, origin.Y);
                g.DrawLine(pen, origin.X, 0, origin.X, ClientSize.Height);
            }
        }
        private void DrawFunction(
            Graphics g,
            PointF origin,
            Func<float, double> f,
            Color color)
        {
            using (Pen pen = new Pen(color, 2))
            {
                bool firstPoint = true;
                PointF prev = new PointF();
                float xMin = -origin.X / scale;
                float xMax = (ClientSize.Width - origin.X) / scale;

                for (float x = xMin; x <= xMax; x += step)
                {
                    double y = f(x);
                    PointF current = new PointF(
                        origin.X + x * scale,
                        origin.Y - (float)y * scale
                    );

                    if (!firstPoint)
                        g.DrawLine(pen, prev, current);
                    prev = current;
                    firstPoint = false;
                }
            }
        }
    }
}
