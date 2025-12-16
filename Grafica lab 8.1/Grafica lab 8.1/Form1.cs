namespace Grafica_lab_8._1
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        private int numPoints = 1000;
        private TrackBar trackPoints;
        private Label lblPoints;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Barnsley Fern – Fractal Interactiv";
            this.ClientSize = new Size(500, 500);
            this.DoubleBuffered = true;
            CreateUI();
            this.Paint += Form1_Paint;
        }
        private void CreateUI()
        {
            lblPoints = new Label()
            {
                Text = "Număr puncte: 1000",
                Location = new Point(10, 10),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            trackPoints = new TrackBar()
            {
                Minimum = 1000,
                Maximum = 100000,
                Value = 1000,
                TickFrequency = 10000,
                SmallChange = 1000,
                LargeChange = 10000,
                Location = new Point(10, 30),
                Width = 300
            };

            trackPoints.Scroll += (s, e) =>
            {
                numPoints = trackPoints.Value;
                lblPoints.Text = $"Număr puncte: {numPoints}";
                Invalidate(); 
            };

            Controls.Add(lblPoints);
            Controls.Add(trackPoints);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            DrawBarnsleyFern(g, numPoints);
        }

        private void DrawBarnsleyFern(Graphics g, int points)
        {
            float x = 0, y = 0;

            for (int i = 0; i < points; i++)
            {
                double r = rand.NextDouble();
                float xNew, yNew;
                if (r < 0.01)
                {
                    xNew = 0;
                    yNew = 0.16f * y;
                }
                else if (r < 0.86)
                {
                    xNew = 0.85f * x + 0.04f * y;
                    yNew = -0.04f * x + 0.85f * y + 1.6f;
                }
                else if (r < 0.93)
                {
                    xNew = 0.2f * x - 0.26f * y;
                    yNew = 0.23f * x + 0.22f * y + 1.6f;
                }
                else
                {
                    xNew = -0.15f * x + 0.28f * y;
                    yNew = 0.26f * x + 0.24f * y + 0.44f;
                }
                x = xNew;
                y = yNew;
                int px = (int)(ClientSize.Width / 2 + x * 50);
                int py = (int)(ClientSize.Height - y * 50);
                float t = (float)i / points;
                Color color = Color.FromArgb(
                    0,
                    (int)(100 + 155 * t),
                    0
                );

                using (Brush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, px, py, 1, 1);
                }
            }
        }
    }
}
