namespace graflab3
{
    public partial class Form1 : Form
    {
        public double isX = -1;
        public double ieX = 3;
        public double isY = -2.4;
        public double ieY = 2.4;
        public double acc = 2000;

        Graphics graph;
        Bitmap bitmap;

        public Graph RTOA(Graph toConvert)
        {
            double ux = pictureBox1.Width / (ieX - isX);
            double uy = pictureBox1.Height / (ieY - isY);

            return new Graph((-isX + toConvert.X) * ux, pictureBox1.Height - (-isY + toConvert.Y * uy));
        }

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bitmap);
        }

        public double f(double x)
        {
            return Math.Sin(x);
        }
        public double g(double x)
        {
            return Math.Cos(x);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graph.DrawLine(Pens.Red, RTOA(new Graph(isX, 0)).ToPointF(), RTOA(new Graph(ieX, 0)).ToPointF());
            graph.DrawLine(Pens.Red, RTOA(new Graph(0, isY)).ToPointF(), RTOA(new Graph(0, ieY)).ToPointF());

            Graph buffer;
            double accStep = (ieX - isX) / acc;
            for (double x = isX; x <= ieX; x += accStep)
            {
                buffer = RTOA (new Graph(x, f(x)));
                buffer.Draw(graph);

                buffer = RTOA(new Graph(x, g(x)));
                buffer.Draw(graph);
            }
            pictureBox1.Image = bitmap;
        }
    }
}
