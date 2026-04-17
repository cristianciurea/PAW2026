using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace Sem8PAW_1045
{
    public partial class Form1 : Form
    {
        double[] vect = new double[20];
        int nrElem = 0;
        bool vb = false;

        const int marg = 10;

        Color culoare = Color.Blue;

        Font font = new Font(FontFamily.GenericSansSerif, 12);

        public Form1()
        {
            InitializeComponent();
        }

        private void incarcaDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("fisier.txt");
            string linie = null;
            while((linie = sr.ReadLine())!=null)
            {
                vect[nrElem] = Convert.ToDouble(linie);
                nrElem++;
                vb = true;
            }
            sr.Close();
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            if(vb==true)
            {
                Rectangle rec = new Rectangle(panel1.ClientRectangle.X+marg,
                    panel1.ClientRectangle.Y+2*marg,
                    panel1.ClientRectangle.Width-2*marg,
                    panel1.ClientRectangle.Height-3*marg);
                Pen pen = new Pen(Color.Red, 3);
                gr.DrawRectangle(pen, rec);

                double latime = rec.Width / nrElem / 2;
                double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
                double vMax = vect.Max();

                for (int i = 0; i < nrElem; i++)
                    gr.DrawLine(pen, new Point((int)(rec.Location.X + (i + 1) * distanta + i * latime), (int)(rec.Location.Y + rec.Height)),
                        new Point((int)(rec.Location.X + (i + 1) * distanta + i * latime), (int)(rec.Location.Y + rec.Height - vect[i] / vMax * rec.Height)));

                /*Brush br = new SolidBrush(culoare);

                Rectangle[] recs = new Rectangle[nrElem];
                for(int i=0;i<nrElem;i++)
                {
                    recs[i] = new Rectangle((int)(rec.Location.X+(i+1)*distanta+i*latime),
                        (int)(rec.Location.Y+ rec.Height-vect[i]/vMax*rec.Height),
                        (int)latime,
                        (int)(vect[i] / vMax * rec.Height));
                    //gr.FillRectangle(br, recs[i]);
                    //gr.DrawRectangle(pen, recs[i]);
                    //gr.DrawEllipse(pen, recs[i]);
                    gr.DrawString(vect[i].ToString(), font, br,
                        new Point((int)(recs[i].Location.X+latime/2), recs[i].Location.Y - font.Height));
                }
                gr.FillRectangles(br, recs);

                for (int i = 0; i < nrElem - 1; i++)
                    gr.DrawLine(pen, new Point((int)(recs[i].Location.X + latime / 2), recs[i].Location.Y),
                        new Point((int)(recs[i + 1].Location.X + latime / 2), recs[i + 1].Location.Y));*/
            }
        }

        private void schimbaCuloareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                culoare = dlg.Color;
            panel1.Invalidate();
        }

        private void schimbaFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                font = dlg.Font;
            panel1.Invalidate();
        }

        private void pd_print(object sender, PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;

            gr.DrawString("Lista studentilor bursieri", font, new SolidBrush(Color.Black), 20, 40);
            gr.DrawString("Popescu Ionel", font, new SolidBrush(Color.Black), 20, 60);
            gr.DrawString("Ionescu Maricica", font, new SolidBrush(Color.Black), 20, 80);

            /*Graphics gr = e.Graphics;
            if (vb == true)
            {
                Rectangle rec = new Rectangle(e.PageBounds.X + marg,
                    e.PageBounds.Y + 2 * marg,
                    e.PageBounds.Width - 2 * marg,
                    e.PageBounds.Height - 3 * marg);
                Pen pen = new Pen(Color.Red, 3);
                gr.DrawRectangle(pen, rec);

                double latime = rec.Width / nrElem / 2;
                double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
                double vMax = vect.Max();

                Brush br = new SolidBrush(culoare);

                Rectangle[] recs = new Rectangle[nrElem];
                for (int i = 0; i < nrElem; i++)
                {
                    recs[i] = new Rectangle((int)(rec.Location.X + (i + 1) * distanta + i * latime),
                        (int)(rec.Location.Y + rec.Height - vect[i] / vMax * rec.Height),
                        (int)latime,
                        (int)(vect[i] / vMax * rec.Height));
                    //gr.FillRectangle(br, recs[i]);
                    //gr.DrawRectangle(pen, recs[i]);
                    //gr.DrawEllipse(pen, recs[i]);
                    gr.DrawString(vect[i].ToString(), font, br,
                        new Point((int)(recs[i].Location.X + latime / 2), recs[i].Location.Y - font.Height));
                }
                gr.FillRectangles(br, recs);

                for (int i = 0; i < nrElem - 1; i++)
                    gr.DrawLine(pen, new Point((int)(recs[i].Location.X + latime / 2), recs[i].Location.Y),
                        new Point((int)(recs[i + 1].Location.X + latime / 2), recs[i + 1].Location.Y));
            }*/
        }

        private void previzualizareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_print);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }

        private void save(Control c, String fisier)
        {
            Graphics gr = c.CreateGraphics();
            Bitmap bmp = new Bitmap(c.Width, c.Height);
            c.DrawToBitmap(bmp, new Rectangle(c.ClientRectangle.X,
                c.ClientRectangle.Y,
                c.ClientRectangle.Width,
                c.ClientRectangle.Height));
            bmp.Save(fisier);
            bmp.Dispose();
        }

        private void salvareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save(panel1, "grafic.bmp");
            MessageBox.Show("Salvat!");
        }
    }
}
