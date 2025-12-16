namespace Grafica_lab_7
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Nor Fractal Simplu";
            this.ClientSize = new Size(500, 500);
            this.DoubleBuffered = true;
            this.Paint += PaintScene;
        }
        private void PaintScene(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.SkyBlue);
            DrawFractalCloud(g, 250, 250, 80, 15);
        }

        private void DrawFractalCloud(Graphics g, float x, float y, float radius, int depth)
        {
            if (depth == 0)
                return;
            using (Brush brush = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
            {
                g.FillEllipse(
                    brush,
                    x - radius,
                    y - radius,
                    radius * 2,
                    radius * 2
                );
            }
            int children = 2;
            for (int i = 0; i < children; i++)
            {
                float angle = (float)(rand.NextDouble() * 2 * Math.PI);
                float distance = radius * 0.5f;
                float newX = x + (float)Math.Cos(angle) * distance;
                float newY = y + (float)Math.Sin(angle) * distance;
                DrawFractalCloud(
                    g,
                    newX,
                    newY,
                    radius * 0.5f,
                    depth - 1
                );
            }
        }
    }
}
