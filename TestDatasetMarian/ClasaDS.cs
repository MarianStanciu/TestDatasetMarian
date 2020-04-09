using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatasetMarian
{
    public static class ClasaDS 
    {
        //private static object toataBD;

        //public static object GetToataBD()
        //{
        //    return toataBD;
        //}

        //private static void SetToataBD(object value)
        //{
        //    toataBD = value;
        //}

        public static DataSet metodaGenereazaDataSet()
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

        public static DataColumnCollection StructuraColoane( DataTable tabelLucru)
        {
            DataColumnCollection coloane = tabelLucru.Columns;
            // List < DataColumn > Tabele2 = view_DocDataSet.Tables[0].Columns.Cast<DataColumn>().ToList();
            foreach (DataColumn column in coloane)
            {
                ///////
            }

            return coloane ;
        }

        

    }

}
