using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafica_lab5
{
    public class FereastraClipping : Form
    {
        const int INTERIOR = 0;
        const int STANGA = 1;
        const int DREAPTA = 2;
        const int JOS = 4;
        const int SUS = 8;
        float xmin = 100, ymin = 100, xmax = 300, ymax = 200;
        public FereastraClipping()
        {
            this.Text = "Cohen-Sutherland";
            this.Width = 600;
            this.Height = 450;
            this.Paint += Desenare;
        }
        int CodRegiune(float x, float y)
        {
            int cod = INTERIOR;
            if (x < xmin) cod |= STANGA;
            else if (x > xmax) cod |= DREAPTA;
            if (y < ymin) cod |= JOS;
            else if (y > ymax) cod |= SUS;
            return cod;
        }
        void Clipping(Graphics g, float x1, float y1, float x2, float y2)
        {
            int cod1 = CodRegiune(x1, y1);
            int cod2 = CodRegiune(x2, y2);
            bool acceptata = false;

            while (true)
            {
                if ((cod1 | cod2) == 0)
                {
                    acceptata = true;
                    break;
                }
                else if ((cod1 & cod2) != 0)
                {
                    break;
                }
                else
                {
                    int codExterior = (cod1 != 0) ? cod1 : cod2;
                    float x = 0, y = 0;

                    if ((codExterior & SUS) != 0)
                    {
                        x = x1 + (x2 - x1) * (ymax - y1) / (y2 - y1);
                        y = ymax;
                    }
                    else if ((codExterior & JOS) != 0)
                    {
                        x = x1 + (x2 - x1) * (ymin - y1) / (y2 - y1);
                        y = ymin;
                    }
                    else if ((codExterior & DREAPTA) != 0)
                    {
                        y = y1 + (y2 - y1) * (xmax - x1) / (x2 - x1);
                        x = xmax;
                    }
                    else if ((codExterior & STANGA) != 0)
                    {
                        y = y1 + (y2 - y1) * (xmin - x1) / (x2 - x1);
                        x = xmin;
                    }

                    if (codExterior == cod1)
                    {
                        x1 = x; y1 = y; cod1 = CodRegiune(x1, y1);
                    }
                    else
                    {
                        x2 = x; y2 = y; cod2 = CodRegiune(x2, y2);
                    }
                }
            }

            if (acceptata)
            {
                Pen p = new Pen(Color.Red, 2);
                g.DrawLine(p, x1, y1, x2, y2);
            }
        }
        void Desenare(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawRectangle(new Pen(Color.Black, 2), xmin, ymin, xmax - xmin, ymax - ymin);
            g.DrawLine(new Pen(Color.Green, 1), 50, 50, 400, 250);

            Clipping(g, 50, 50, 400, 250);
        }
        [STAThread]
        public static void Main()
        {
            Application.Run(new FereastraClipping());
        }
    }
}
