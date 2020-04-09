using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDatasetMarian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ElementePredefinite();
            //DataSet abc= ClasaDS.metodaGenereazaDataSet();
            ClasaDS.metodaGenereazaDataSet();
            //int bbb = abc.Tables.Count;
            //ClasaDS.StructuraColoane(ClasaDS.metodaGenereazaDataSet().Tables["tabelLucru"]);
        }
        DataSet valoriPredefiniteAsociatie;
        DsTest1TableAdapters.vMTbATableAdapter TA = new DsTest1TableAdapters.vMTbATableAdapter();

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsTest1.vMTbA' table. You can move, or remove it, as needed.
            this.vMTbATableAdapter.Fill(this.dsTest1.vMTbA);

            //dataGridView1.DataSource = TA.GetData();
            //dataGridView1.DataSource = this.dsTest1.vMTbA;
            dataGridView1.DataSource = this.dsTest1.vMTbA;
            int ww = this.dsTest1.Tables[0].Rows.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            string valoare =textBox2.Text ;

            {
                
               TA.InserareTrigger(nume, valoare);
                textBox1.Clear();
                textBox2.Clear();

                dataGridView1.DataSource = TA.GetData();
                // TA.Adapter.TableMappings.
                //DataTable dt1=DsTest1.v
               
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ww = this.dsTest1.Tables[0].Rows.Count;

            string a1 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string a2 = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //TA.InserareTrigger(a1, a2);
            textBox1.Clear();
            textBox2.Clear();
            this.dsTest1.Tables[0].Rows.Add( 0,"asociatie","verificare100");
            DataRow [] nemodificate = this.dsTest1.Tables[0].Select(null, null, DataViewRowState.Unchanged);
            DataRow [] adaugate= this.dsTest1.Tables[0].Select(null, null, DataViewRowState.Added);
            DataRow [] sterse= this.dsTest1.Tables[0].Select(null, null, DataViewRowState.Deleted);
            DataRow [] modificate= this.dsTest1.Tables[0].Select(null, null, DataViewRowState.ModifiedCurrent);
            foreach (DataRow row in this.dsTest1.Tables[0].Rows)
            {
                if(nemodificate.Length == ww)
                {
                    MessageBox.Show("Notificare", "nu sunt modificari facute in tabel" );
                }

            }
            dataGridView1.DataSource = TA.GetData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int id= (int)(dataGridView1.CurrentRow.Cells[0].Value);
            string a1 = textBox1.Text;
            string a2 = textBox2.Text;
            TA.UpdateQuery(a1, a2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vMTbABindingSource.EndEdit();
           //vMTbATableAdapter.
        }
        private DataSet ElementePredefinite()
        {
            string selectie = "select *from vMTbA";
            string sirConectare = @"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = proba_transare; Persist Security Info = True; User ID = sa; Password = pro";
           
            SqlConnection connection = new SqlConnection(sirConectare);
            SqlCommand command = new SqlCommand(selectie, connection);
            SqlDataAdapter da = new SqlDataAdapter();
            valoriPredefiniteAsociatie = new DataSet();
            da.SelectCommand = command;
            da.Fill(valoriPredefiniteAsociatie);
            return valoriPredefiniteAsociatie;

        }
        //public static int Inserare(DataTable tabelLucru)
        //{
        //   // DataRow[] nemodificate = ClasaDS.metodaGenereazaDataSet().Tables["tabelLucru"].Select(null, null, DataViewRowState.Unchanged);
        //    DataRow[] adaugate = ClasaDS.metodaGenereazaDataSet().Tables["tabelLucru"].Select(null, null, DataViewRowState.Added);
        //    //DataRow[] sterse = ClasaDS.metodaGenereazaDataSet().Tables["tabelLucru"].Select(null, null, DataViewRowState.Deleted);
        //    //DataRow[] modificate = ClasaDS.metodaGenereazaDataSet().Tables["tabelLucru"].Select(null, null, DataViewRowState.ModifiedCurrent);
        //    if (adaugate.Length > 0) 
        //    //foreach (DataRow r in adaugate)
        //    //{
        //    //    string inserare = "insert into tabelLucru" + "(" + ClasaDS.StructuraColoane(tabelLucru) + ")" + "values";

        //    //    string values = ""
        //    //}
            
        //    return adaugate.Length;
        //}
    }
}
