namespace Grafica_lab_2
{
    public partial class Form1 : Form
    {
        int n = 0;
        float r = 0;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Poligon regulat înscris într-un cerc";
            this.Width = 800;
            this.Height = 600;
            this.DoubleBuffered = true;
            CreateUI();
        }
        TextBox txtN;
        TextBox txtR;
        Button btnDraw;
        private void CreateUI()
        {
            Label lblN = new Label()
            {
                Text = "Număr laturi (n ≥ 3):",
                Location = new Point(10, 15),
                AutoSize = true
            };
            txtN = new TextBox()
            {
                Location = new Point(150, 12),
                Width = 60
            };
            Label lblR = new Label()
            {
                Text = "Rază r:",
                Location = new Point(10, 45),
                AutoSize = true
            };
            txtR = new TextBox()
            {
                Location = new Point(150, 42),
                Width = 60
            };
            btnDraw = new Button()
            {
                Text = "Desenează",
                Location = new Point(10, 75),
                Width = 200
            };
            btnDraw.Click += BtnDraw_Click;
            Controls.Add(lblN);
            Controls.Add(txtN);
            Controls.Add(lblR);
            Controls.Add(txtR);
            Controls.Add(btnDraw);
        }
        private void BtnDraw_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtN.Text, out n) || n < 3)
            {
                MessageBox.Show("Introduceți un n valid (n ≥ 3)");
                return;
            }
            if (!float.TryParse(txtR.Text, out r) || r <= 0)
            {
                MessageBox.Show("Introduceți o rază validă");
                return;
            }
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (n < 3 || r <= 0)
                return;
            Graphics g = e.Graphics;
            PointF center = new PointF(
                ClientSize.Width / 2,
                ClientSize.Height / 2 + 40
            );
            DrawPolygon(g, center, n, r);
        }
        private void DrawPolygon(Graphics g, PointF center, int n, float radius)
        {
            PointF[] points = new PointF[n];
            for (int i = 0; i < n; i++)
            {
                double angle = 2 * Math.PI * i / n;

                float x = center.X + radius * (float)Math.Cos(angle);
                float y = center.Y - radius * (float)Math.Sin(angle);

                points[i] = new PointF(x, y);
            }
            g.DrawEllipse(Pens.LightGray,
                center.X - radius,
                center.Y - radius,
                2 * radius,
                2 * radius);
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                g.DrawPolygon(pen, points);
            }
            foreach (var p in points)
                g.FillEllipse(Brushes.Red, p.X - 3, p.Y - 3, 6, 6);
        }
    }
}
