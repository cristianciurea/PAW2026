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

namespace Sem12PAW_1045
{
    public partial class Form1 : Form
    {
        string connString;
        public Form1()
        {
            InitializeComponent();
            connString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=angajati.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SELECT * FROM angajati", conexiune);
            DataSet dataSet = new DataSet();
            adaptor.Fill(dataSet, "angajati");
            DataTable tabela = dataSet.Tables["angajati"];

            comboBox1.DataSource = tabela;
            comboBox1.DisplayMember = "nume";

            foreach (DataColumn coloana in tabela.Columns)
                textBox1.Text += coloana.ColumnName + "   ";
            textBox1.Text += Environment.NewLine;
            foreach(DataRow linie in tabela.Rows)
            {
                foreach (object camp in linie.ItemArray)
                    textBox1.Text += camp + "   ";
                textBox1.Text += Environment.NewLine;
            }

            foreach (DataColumn coloana in tabela.Columns)
            {
                ColumnHeader header = new ColumnHeader();
                header.Text = coloana.ColumnName;
                listView1.Columns.Add(header);
            }
            foreach(DataRow linie in tabela.Rows)
            {
                ListViewItem itm = new ListViewItem(linie[0].ToString());
                for(int i=1;i<linie.ItemArray.Length;i++)
                {
                    itm.SubItems.Add(linie[i].ToString());
                }
                listView1.Items.Add(itm);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SELECT * FROM angajati", conexiune);
            DataSet dataSet = new DataSet();
            adaptor.Fill(dataSet, "angajati");
            DataTable tabela = dataSet.Tables["angajati"];

            DataRow[] rows = tabela.Select("salariu>6000", "nume");
            foreach (DataRow linie in rows)
                textBox1.Text += linie["nume"] + "   " + linie["salariu"] + Environment.NewLine; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SELECT * FROM angajati", conexiune);
            DataSet dataSet = new DataSet();
            adaptor.Fill(dataSet, "angajati");
            DataTable tabela = dataSet.Tables["angajati"];

            DataView dv = new DataView(tabela);
            dv.RowFilter = "salariu>6000";
            dv.Sort = "nume";
            foreach(DataRowView linie in dv)
                textBox1.Text += linie["nume"] + "   " + linie["salariu"] + Environment.NewLine;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SELECT * FROM angajati", conexiune);
            DataSet dataSet = new DataSet();
            adaptor.Fill(dataSet, "angajati");
            DataTable tabela = dataSet.Tables["angajati"];

            adaptor.UpdateCommand = new OleDbCommand("UPDATE angajati SET salariu=salariu+1000 WHERE nume='"+comboBox1.Text+"'", conexiune);

            tabela.Rows[0].BeginEdit();
            tabela.Rows[0].EndEdit();

            adaptor.Update(tabela);
        }
    }
}
