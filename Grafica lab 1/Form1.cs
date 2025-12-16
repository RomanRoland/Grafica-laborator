namespace Grafica_lab_1
{
    public partial class Form1 : Form
    {
        public Bitmap canvas;
        public Form1()
        {
            InitializeComponent();
            PunctBitmapForm puncte = new PunctBitmapForm();
        }
    }
    public class PunctBitmapForm : Form
    {
        Bitmap canvas;
        public PunctBitmapForm()
        {
            this.Text = "Puncte pe Bitmap";
            this.Width = 400;
            this.Height = 300;
            this.Paint += new PaintEventHandler(DeseneazaPuncte);
            canvas = new Bitmap(this.Width, this.Height);
            canvas.SetPixel(50, 50, Color.Red);  // Desenăm 5 puncte în culori diferite
            canvas.SetPixel(70, 80, Color.Blue);
            canvas.SetPixel(120, 100, Color.Green);
            canvas.SetPixel(200, 150, Color.Purple);
            canvas.SetPixel(300, 200, Color.Orange);
            canvas.Save("puncte.png");   // Salvăm imaginea într-un fișier PNG
        }
        private void DeseneazaPuncte(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(canvas, 0, 0);
        }
    }
}
