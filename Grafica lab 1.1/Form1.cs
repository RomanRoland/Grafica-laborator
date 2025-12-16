namespace Grafica_lab_1._1
{
    public partial class Form1 : Form
    {
        Point P1 = new Point(100, 150);
        Point P2 = new Point(300, 50);
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Blue, 2);
            Brush brush = Brushes.Red;
            g.DrawLine(pen, P1, P2);
            g.FillEllipse(brush, P1.X - 3, P1.Y - 3, 6, 6);
            g.FillEllipse(brush, P2.X - 3, P2.Y - 3, 6, 6);
        }
    }
}
