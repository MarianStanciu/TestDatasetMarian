using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatasetMarian
{
    public  class ClasaDS :DataSet
    {
        //primire instructiune sql  - si daca returneaza valoare - sa adauge o tabela cu denumirea pe care o folosim
        // trimiterea instructiunii
        public void getSetFrom (String sSQL, String sNumeTabel)
        {
            string sirConectare = @"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = proba_transare; Persist Security Info = True; User ID = sa; Password = pro";
            SqlConnection connection = new SqlConnection(sirConectare);
            connection.Open();

            SqlCommand command = new SqlCommand(sSQL, connection);
            DataTable tabelLucru = new DataTable(sNumeTabel);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            da.Fill(tabelLucru);
            this.Tables.Add(tabelLucru);
            

        }
        public  DataSet metodaGenereazaDataSet()
        {
            DataSet ToataBD= new DataSet() ;
            string sirConectare = @"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = proba_transare; Persist Security Info = True; User ID = sa; Password = pro";
            string selectieListaTablele = " select table_name from information_schema.tables";
            SqlConnection connection = new SqlConnection(sirConectare);
            List<string> tabele=new List<string>();
            SqlCommand command = new SqlCommand(selectieListaTablele, connection);
            SqlDataAdapter da = new SqlDataAdapter();
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    tabele.Add((string)reader["table_name"]);
                }
            }
            foreach (string s in tabele)
            {

                string queryString = "select * from " + s;
                SqlCommand command1 = new SqlCommand(queryString, connection);
                DataTable dtRecord = new DataTable(s);
                da.SelectCommand = command1;
                da.Fill(dtRecord);
                ToataBD.Tables.Add(dtRecord);                
              
                da.Fill(ToataBD);
            }                       
            return ToataBD;
                       
        }

        public  DataColumnCollection StructuraColoane(string sTabelLucru)
        {
            DataColumnCollection coloane = this.Tables[sTabelLucru].Columns;            
            return coloane ;
        }
        public  int Actualizare(string sTabelLucru)
        {
            
            DataRow[] adaugate = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.Added);
            DataRow[] sterse = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.Deleted);
            DataRow[] modificate = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.ModifiedCurrent);
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);
            string inserare = "insert into "+ sTabelLucru+ " (" ;
            for (int i=0; i<dc.Count;i++)
            {
                if (i == 0)
                {
                    inserare = inserare + dc[i].ColumnName;
                }
                else
                {
                    inserare = inserare +","+ dc[i].ColumnName;
                }
            }
            inserare = inserare + " ) values ";

            for (int k=0; k<adaugate.Length;k++)
                {
                DataRow r = adaugate[k];
                string linie = "";
                foreach (DataColumn f in dc)
                {
                   string tip= f.DataType.ToString();
                    string valoare = "";
                    switch (f.DataType.ToString())

                    {
                        case "System.String":
                            valoare = "'" + r[f.ColumnName].ToString() + "'";
                            break;
                        case "System.Int32":
                            valoare =r[f.ColumnName].ToString();
                            break;


                        default:
                            break;
                    }
                    if (string.IsNullOrEmpty(linie))
                    {
                        linie = linie + valoare;
                    }
                    else
                    {
                        linie = linie + "," + valoare;
                    }
                   
                }
                if (k == 0)
                {
                    inserare = inserare + " (" + linie + " )";
                }
                else
                {
                    inserare = inserare + " ,(" + linie + " )";
                }
                
                }


            return adaugate.Length;
        }



    }

}
