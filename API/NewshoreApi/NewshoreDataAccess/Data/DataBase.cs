using NewshoreDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreDataAccess.Data
{
    public class DataBase
    {

        private SqlConnection conn;

        public DataBase() {

            conn = new SqlConnection("Data Source=;Initial Catalog=;Persist Security Info=True;User ID=;Password=");
        }

        public string SaveRoute(Journey journey)
        {
            string result = "";

          //  try
          //  {
          //      SqlCommand command;
          //      SqlDataAdapter adapter = new SqlDataAdapter();
          //      String sql = "";

          //      sql = "";


          //      command = new SqlCommand(sql, conn);
          //              adapter.InsertCommand = new SqlCommand(sql, conn);
          //              adapter.InsertCommand.ExecuteNonQuery();

          //      command.Dispose();
		        //conn.Close();
          //  }
          //  catch(Exception ex)
          //  {
          //      result= ex.Message;
          //  }

            return result;
        }

        public Journey GetRoute()
        {
            Journey result = null;

            //try
            //{
            //    SqlCommand command;
            //    SqlDataAdapter adapter = new SqlDataAdapter();
            //    String sql = "";

            //    sql = "";


            //    //command = new SqlCommand(sql, conn);
            //    //adapter.InsertCommand = new SqlCommand(sql, conn);
            //    //adapter.InsertCommand.ExecuteNonQuery();

            //    command.Dispose();
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    result = ex.Message;
            //}

            return result;
        }

    }
}
