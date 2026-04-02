using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem7PAW_1047
{
    public partial class Form2 : Form
    {
        ArrayList lista2;
        public Form2(ArrayList lista)
        {
            InitializeComponent();
            lista2 = lista;

            TreeNode parinte = new TreeNode("Produse");
            treeView1.Nodes.Add(parinte);

            foreach(Produs p in lista2)
            {
                ListViewItem itm = new ListViewItem(p.Denumire);
                itm.SubItems.Add(p.Pret.ToString());
                itm.SubItems.Add(p.Cantitate.ToString());
                itm.SubItems.Add((p.Pret * p.Cantitate).ToString());

                listView1.Items.Add(itm);

                TreeNode copil = new TreeNode();
                copil.Text = p.Denumire + "|" + p.Pret + "|" + p.Cantitate;
                parinte.Nodes.Add(copil);
            }
            treeView1.ExpandAll();
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(contextMenuStrip1.SourceControl==listView1)
            {
                foreach(ListViewItem itm in listView1.Items)
                    if(itm.Checked)
                    {
                        string denumire = itm.SubItems[0].Text;
                        for (int i = 0; i < lista2.Count; i++)
                            if (((Produs)lista2[i]).Denumire == denumire)
                                lista2.RemoveAt(i);
                        itm.Remove();
                    }
            }
            else
                if(contextMenuStrip1.SourceControl==treeView1)
            {
                TreeNode parinte = treeView1.Nodes[0];
                foreach(TreeNode copil in parinte.Nodes)
                    if(copil!=null && copil.Checked)
                    {
                        string denumire = copil.Text.Split('|')[0];
                        for (int i = 0; i < lista2.Count; i++)
                            if (((Produs)lista2[i]).Denumire == denumire)
                                lista2.RemoveAt(i);
                        copil.Remove();
                    }
            }
        }
    }
}
