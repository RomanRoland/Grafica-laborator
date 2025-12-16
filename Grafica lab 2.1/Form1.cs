namespace Grafica_lab_2._1
{
    public partial class Form1 : Form
    {
        enum StareSemafor
        {
            Rosu,
            Galben,
            Verde
        }
        StareSemafor stareCurenta = StareSemafor.Rosu;
        System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Simulare Semafor";
            this.Width = 300;
            this.Height = 500;
            this.DoubleBuffered = true;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private int contor = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            contor++;
            switch (stareCurenta)
            {
                case StareSemafor.Rosu:
                    if (contor >= 5)
                    {
                        stareCurenta = StareSemafor.Verde;
                        contor = 0;
                    }
                    break;
                case StareSemafor.Galben:
                    if (contor >= 2)
                    {
                        stareCurenta = StareSemafor.Rosu;
                        contor = 0;
                    }
                    break;
                case StareSemafor.Verde:
                    if (contor >= 5)
                    {
                        stareCurenta = StareSemafor.Galben;
                        contor = 0;
                    }
                    break;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.Black, 80, 50, 140, 300);

            DrawLight(g, 150, 100, Color.Red, stareCurenta == StareSemafor.Rosu);
            DrawLight(g, 150, 200, Color.Yellow, stareCurenta == StareSemafor.Galben);
            DrawLight(g, 150, 300, Color.Green, stareCurenta == StareSemafor.Verde);
        }
        private void DrawLight(Graphics g, int cx, int cy, Color color, bool on)
        {
            Brush b = on ? new SolidBrush(color) : Brushes.Gray;
            g.FillEllipse(b, cx - 30, cy - 30, 60, 60);
        }
    }
}
