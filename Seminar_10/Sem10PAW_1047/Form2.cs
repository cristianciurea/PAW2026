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

namespace Sem10PAW_1047
{
    public partial class Form2 : Form
    {
        string connString;
        public Form2()
        {
            InitializeComponent();
            connString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=BD.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                //MessageBox.Show("s-a deschis!");
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                comanda.CommandText = "SELECT MAX(ID) FROM abonati";
                int id = Convert.ToInt32(comanda.ExecuteScalar());

                comanda.CommandText = "INSERT INTO abonati VALUES(?,?,?,?)";
                comanda.Parameters.Add("ID", OleDbType.Integer).Value = id + 100;
                comanda.Parameters.Add("nume", OleDbType.Char, 20).Value = tbNume.Text;
                comanda.Parameters.Add("sumaPlata", OleDbType.Double).Value = Convert.ToDouble(tbSumaPlata.Text);
                comanda.Parameters.Add("categorie", OleDbType.Char, 10).Value = cbCategorie.Text;
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                tbNume.Clear();
                tbSumaPlata.Clear();
                cbCategorie.Text = "";
            }
        }
    }
}
