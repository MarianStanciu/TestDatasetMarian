﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatasetMarian
{
    public class ClasaDS : DataSet
    {
        //primire instructiune sql  - si daca returneaza valoare - sa adauge o tabela cu denumirea pe care o folosim
        // trimiterea instructiunii
        public void getSetFrom(String sSQL, String sNumeTabel)
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
        //public  DataSet metodaGenereazaDataSet()
        //{
        //    DataSet ToataBD= new DataSet() ;
        //    string sirConectare = @"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = proba_transare; Persist Security Info = True; User ID = sa; Password = pro";
        //    string selectieListaTablele = " select table_name from information_schema.tables";
        //    SqlConnection connection = new SqlConnection(sirConectare);
        //    List<string> tabele=new List<string>();
        //    SqlCommand command = new SqlCommand(selectieListaTablele, connection);
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    connection.Open();
        //    using (SqlDataReader reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {

        //            tabele.Add((string)reader["table_name"]);
        //        }
        //    }
        //    foreach (string s in tabele)
        //    {

        //        string queryString = "select * from " + s;
        //        SqlCommand command1 = new SqlCommand(queryString, connection);
        //        DataTable dtRecord = new DataTable(s);
        //        da.SelectCommand = command1;
        //        da.Fill(dtRecord);
        //        ToataBD.Tables.Add(dtRecord);                

        //        da.Fill(ToataBD);
        //    }                       
        //    return ToataBD;

        //}

        public DataColumnCollection StructuraColoane(string sTabelLucru)
        {
            DataColumnCollection coloane = this.Tables[sTabelLucru].Columns;
            return coloane;
        }
        //metoda pentru inserare
        public int Inserare(string sTabelLucru)
        {

            DataRow[] adaugate = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.Added);
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);
            string inserare = "insert into " + sTabelLucru + " (";
            for (int i = 0; i < dc.Count; i++)
            {
                if (i == 0)
                {
                    inserare = inserare + dc[i].ColumnName;
                }
                else
                {
                    inserare = inserare + "," + dc[i].ColumnName;
                }
            }
            inserare = inserare + " ) values ";

            for (int k = 0; k < adaugate.Length; k++)
            {
                DataRow r = adaugate[k];
                string linie = "";
                foreach (DataColumn f in dc)
                {
                    string tip = f.DataType.ToString();
                    string valoare = "";
                    switch (f.DataType.ToString())

                    {
                        case "System.String":
                            valoare = "'" + r[f.ColumnName].ToString() + "'";
                            break;
                        case "System.Int32":
                            valoare = r[f.ColumnName].ToString();
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

        //metoda pentru actalizare  marian
        public int Actualizare(string sTabelLucru)
        {
            DataRow[] modificate = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.ModifiedCurrent);
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);

            string actualizare = "Update  " + sTabelLucru + " set ";
            for (int k = 0; k < modificate.Length; k++)
            {
                for (int i = 1; i < dc.Count; i++)
                {
                    actualizare = actualizare + dc[i].ColumnName + "=";
                    DataRow r = (DataRow)modificate[k];
                    string linie = "";
                    //foreach (DataColumn f in dc)
                    //{
                    DataColumn f = dc[i];
                    string tip = f.DataType.ToString();
                    string valoare = "";
                    switch (f.DataType.ToString())
                    {
                        case "System.String":
                            valoare = "'" + r[f.ColumnName].ToString() + "'";
                            break;
                        case "System.Int32":
                            valoare = r[f.ColumnName].ToString();
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
                    if (i < dc.Count - 1)
                    {

                        actualizare = actualizare + linie + " ,";
                    }
                    if (i == dc.Count - 1)
                    {
                        actualizare = actualizare + linie;
                    }
                }
                actualizare = actualizare + " where id=" + modificate[k][dc[0].ColumnName].ToString();
                if (k < modificate.Length - 1)
                {
                    actualizare = actualizare + " Update  " + sTabelLucru + " set ";
                }
            }
            return modificate.Length;
        }

        public int Stergere(string sTabelLucru)
        {
            DataRow[] sterse = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.Deleted);
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);
            string stergere = " delete  from " + sTabelLucru + " where ";
            
                for (int k = 0; k < sterse.Length; k++)
                {
                    DataRow r = sterse[k];
                    
                DataColumn f = dc[0];
                string valoare = r[0, DataRowVersion.Original].ToString();
                stergere = stergere + dc[0].ColumnName + "=" + valoare;
                if (k < sterse.Length-1)
                {
                    stergere = stergere + " delete  from " + sTabelLucru + " where ";
                }
            }
            
            string sirConectare = @"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = proba_transare; Persist Security Info = True; User ID = sa; Password = pro";
            SqlConnection con = new SqlConnection(sirConectare);
            SqlCommand command = new SqlCommand(stergere, con);
            con.Open();
            command.ExecuteNonQuery();
            
            return sterse.Length;
            
        }
        //metoda actualizare adrian
        public int Actualizare2(string sTabelLucru)
        {
            DataRow[] modificate = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.ModifiedCurrent);
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);
            string actualizare = "Update  " + sTabelLucru + " set ";
            string valoare = "";

            // update + tabel + set numecoloana=valoare, numecoloana=valoare, ....
            for (int i = 0; i < dc.Count; i++)
            {
                for (int k = 0; k < modificate.Length; k++)
                {

                    if (i == 0)
                    {
                        actualizare = actualizare + dc[i].ColumnName;
                        //valoare = sTabelLucru.ro[modificate[k][i]];
                    }
                    if (i % 2 != 0)
                    {
                        actualizare = actualizare + "," + dc[i].ColumnName;
                    }
                    else
                    {
                        actualizare = actualizare + "=" + "valoare";
                    }
                    //actualizare = actualizare + ",";
                }

                //actualizare = actualizare + dc[i].ColumnName + "=";


            }
            return modificate.Length;
        }

        ///

    }
}
    

