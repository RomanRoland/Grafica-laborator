namespace Grafcica_lab_8
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        private int depth = 1;
        private TrackBar trackDepth;
        private Label lblDepth;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Nor Fractal Interactiv";
            this.ClientSize = new Size(500, 500);
            this.DoubleBuffered = true;
            CreateUI();
            this.Paint += PaintScene;
        }
        private void CreateUI()
        {
            lblDepth = new Label()
            {
                Text = "Iterații fractale: 1",
                Location = new Point(10, 10),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            trackDepth = new TrackBar()
            {
                Minimum = 1,
                Maximum = 6,
                Value = 1,
                TickFrequency = 1,
                Location = new Point(10, 30),
                Width = 200
            };
            trackDepth.Scroll += (s, e) =>
            {
                depth = trackDepth.Value;
                lblDepth.Text = $"Iterații fractale: {depth}";
                Invalidate(); // redesenare în timp real
            };
            Controls.Add(lblDepth);
            Controls.Add(trackDepth);
        }
        private void PaintScene(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.SkyBlue); // cer
            DrawFractalCloud(g, 250, 280, 80, depth);
        }
        private void DrawFractalCloud(Graphics g, float x, float y, float radius, int depth)
        {
            if (depth == 0)
                return;
            using (Brush brush = new SolidBrush(Color.FromArgb(180, 255, 255, 255)))
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
                float distance = radius * 0.6f;

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
