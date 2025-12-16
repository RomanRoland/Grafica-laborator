namespace Grafica_lab_9
{
    public partial class Form1 : Form
    {
        TextBox txtAx, txtAy, txtAz;
        TextBox txtBx, txtBy, txtBz;
        TextBox txtCx, txtCy, txtCz;
        Button btnCompute;
        TextBox txtNormal;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Normală triunghi 3D";
            this.ClientSize = new Size(500, 400);
            this.DoubleBuffered = true;
            CreateUI();
        }
        private void CreateUI()
        {
            int y = 10;
            Label lblA = new Label() { Text = "A (x,y,z):", Location = new Point(10, y), AutoSize = true };
            txtAx = new TextBox() { Location = new Point(80, y), Width = 50, Text = "0" };
            txtAy = new TextBox() { Location = new Point(140, y), Width = 50, Text = "0" };
            txtAz = new TextBox() { Location = new Point(200, y), Width = 50, Text = "0" };
            this.Controls.Add(lblA); this.Controls.Add(txtAx); this.Controls.Add(txtAy); this.Controls.Add(txtAz);
            y += 30;
            Label lblB = new Label() { Text = "B (x,y,z):", Location = new Point(10, y), AutoSize = true };
            txtBx = new TextBox() { Location = new Point(80, y), Width = 50, Text = "1" };
            txtBy = new TextBox() { Location = new Point(140, y), Width = 50, Text = "0" };
            txtBz = new TextBox() { Location = new Point(200, y), Width = 50, Text = "0" };
            this.Controls.Add(lblB); this.Controls.Add(txtBx); this.Controls.Add(txtBy); this.Controls.Add(txtBz);
            y += 30;
            Label lblC = new Label() { Text = "C (x,y,z):", Location = new Point(10, y), AutoSize = true };
            txtCx = new TextBox() { Location = new Point(80, y), Width = 50, Text = "0" };
            txtCy = new TextBox() { Location = new Point(140, y), Width = 50, Text = "1" };
            txtCz = new TextBox() { Location = new Point(200, y), Width = 50, Text = "0" };
            this.Controls.Add(lblC); this.Controls.Add(txtCx); this.Controls.Add(txtCy); this.Controls.Add(txtCz);
            y += 40;
            btnCompute = new Button() { Text = "Calculează normală", Location = new Point(10, y), Width = 200 };
            btnCompute.Click += BtnCompute_Click;
            this.Controls.Add(btnCompute);
            y += 40;
            txtNormal = new TextBox() { Location = new Point(10, y), Width = 300, ReadOnly = true };
            this.Controls.Add(txtNormal);
        }

        private void BtnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                Vector3 A = new Vector3(
                    double.Parse(txtAx.Text),
                    double.Parse(txtAy.Text),
                    double.Parse(txtAz.Text)
                );
                Vector3 B = new Vector3(
                    double.Parse(txtBx.Text),
                    double.Parse(txtBy.Text),
                    double.Parse(txtBz.Text)
                );
                Vector3 C = new Vector3(
                    double.Parse(txtCx.Text),
                    double.Parse(txtCy.Text),
                    double.Parse(txtCz.Text)
                );
                Vector3 normal = ComputeNormal(A, B, C);
                txtNormal.Text = $"Normală unitate: {normal}";
            }
            catch
            {
                MessageBox.Show("Introduceți valori valide numerice!");
            }
        }
        public struct Vector3
        {
            public double X, Y, Z;
            public Vector3(double x, double y, double z)
            {
                X = x; Y = y; Z = z;
            }
            public static Vector3 operator -(Vector3 a, Vector3 b)
            {
                return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
            }
            public static Vector3 Cross(Vector3 a, Vector3 b)
            {
                return new Vector3(
                    a.Y * b.Z - a.Z * b.Y,
                    a.Z * b.X - a.X * b.Z,
                    a.X * b.Y - a.Y * b.X
                );
            }
            public double Length()
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
            public Vector3 Normalize()
            {
                double len = Length();
                if (len == 0) return new Vector3(0, 0, 0);
                return new Vector3(X / len, Y / len, Z / len);
            }
            public override string ToString()
            {
                return $"({X:F3}, {Y:F3}, {Z:F3})";
            }
        }

        public static Vector3 ComputeNormal(Vector3 A, Vector3 B, Vector3 C)
        {
            Vector3 U = B - A;
            Vector3 V = C - A;
            Vector3 N = Vector3.Cross(U, V);
            return N.Normalize();
        }
    }
}
