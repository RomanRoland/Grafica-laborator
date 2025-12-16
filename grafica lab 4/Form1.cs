namespace grafica_lab_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* dreptunghi
            Bitmap bmp = new Bitmap(400, 300);
            int xmin = 50;
            int ymin = 50;
            int xmax = 200;
            int ymax = 120;
            Color culoare = Color.Blue;
            for (int y = ymin; y <= ymax; y++)
            {
                for (int x = xmin; x <= xmax; x++)
                {
                    bmp.SetPixel(x, y, culoare);
                }
            }
            this.BackgroundImage = bmp;
            */
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int xmin = 50;
            int ymin = 50;
            int xmax = 200;
            int ymax = 120;
            Color culoare = Color.Blue;
            for (int y = ymin; y <= ymax; y++)
            {
                for (int x = xmin; x <= xmax; x++)
                {
                    e.Graphics.FillRectangle(new SolidBrush(culoare), x, y, 1, 1);
                }
            }
        }
    }
}
