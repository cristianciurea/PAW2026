using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem9PAW_1045
{
    public partial class Form1 : Form
    {
        int y = 10;

        List<Student> listaStud = new List<Student>();

        public Form1()
        {
            InitializeComponent();
            listaStud.Add(new Student(21, "Gigel", 9.5f));
            listaStud.Add(new Student(22, "Maricica", 9.7f));
            listaStud.Add(new Student(23, "Dorel", 8.9f));
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.DoDragDrop(listaStud, DragDropEffects.Copy |
                DragDropEffects.Move);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if ((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else
                 if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string text = e.Data.GetData(typeof(string)).ToString();
            Graphics gr = panel1.CreateGraphics();
            gr.DrawString(text, this.Font, new SolidBrush(Color.Red), 10, y);
            y += 20;
            if (e.Effect == DragDropEffects.Move)
                textBox1.Clear();
            if (y > panel1.Height)
                panel1.Invalidate();
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            /*string text = e.Data.GetData(typeof(string)).ToString();
            foreach (Student s in listaStud)
                if (s.Nume == text)
                    listBox1.Items.Add(s.ToString());*/
            List<Student> listaNoua = (List<Student>)e.Data.GetData(typeof(List<Student>));
            if(listaNoua!=null)
            foreach (Student s in listaNoua)
                listBox1.Items.Add(s.ToString());
            if (e.Effect == DragDropEffects.Move)
                textBox1.Clear();
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            string text = e.Data.GetData(typeof(string)).ToString();
            string[] vs = text.Split(' ');
            foreach(Student s in listaStud)
                if(s.Nume==vs[1])
                {
                    ListViewItem itm = new ListViewItem(s.Varsta.ToString());
                    itm.SubItems.Add(s.Nume);
                    itm.SubItems.Add(s.Medie.ToString());
                    listView1.Items.Add(itm);
                }
            if (e.Effect == DragDropEffects.Move)
                listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(listBox1.Items.Count>0)
            listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if ((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else
                 if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if ((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else
                 if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;
        }
    }
}
