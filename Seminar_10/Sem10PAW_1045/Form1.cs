using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sem10PAW_1045
{
    public partial class Form1 : Form
    {
        string connString;
        public Form1()
        {
            InitializeComponent();
            connString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=BD.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                //MessageBox.Show("merge!");
                OleDbCommand comanda = new OleDbCommand();
                comanda.CommandText = "SELECT * FROM studenti";
                comanda.Connection = conexiune;
                OleDbDataReader reader = comanda.ExecuteReader();
                while(reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["ID"].ToString());
                    itm.SubItems.Add(reader["nume"].ToString());
                    itm.SubItems.Add(reader["medie"].ToString());
                    itm.SubItems.Add(reader["facultate"].ToString());
                    itm.SubItems.Add(reader["forma"].ToString());
                    listView1.Items.Add(itm);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                foreach(ListViewItem itm in listView1.Items)
                    if(itm.Checked)
                    {
                        int id = Convert.ToInt32(itm.SubItems[0].Text);
                        comanda.CommandText = "UPDATE studenti SET forma='" + cbForma.Text + "' WHERE ID=" + id;
                        comanda.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                button1_Click(this, e);
            }
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                foreach (ListViewItem itm in listView1.Items)
                    if (itm.Selected)
                    {
                        int id = Convert.ToInt32(itm.SubItems[0].Text);
                        comanda.CommandText = "DELETE FROM studenti WHERE ID=" + id;
                        comanda.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                button1_Click(this, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "CREATE PROCEDURE StudentiFacultate AS SELECT * FROM studenti WHERE facultate=@facultate";
                comanda.ExecuteNonQuery();
                MessageBox.Show("Procedura creata!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "StudentiFacultate";
                comanda.CommandType = CommandType.StoredProcedure;
                comanda.Parameters.Add("@facultate", OleDbType.Char, 10).Value = "CSIE";
                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["ID"].ToString());
                    itm.SubItems.Add(reader["nume"].ToString());
                    itm.SubItems.Add(reader["medie"].ToString());
                    itm.SubItems.Add(reader["facultate"].ToString());
                    itm.SubItems.Add(reader["forma"].ToString());
                    listView1.Items.Add(itm);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
        }
    }
}
