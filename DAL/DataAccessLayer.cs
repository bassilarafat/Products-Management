using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Products_Management.DAL
{
    class DataAccessLayer
    {
        //define a field (var)
        SqlConnection sqlconnection;

        //constructor to initialize connection object
        public DataAccessLayer()
        {
            sqlconnection = new SqlConnection(@"server=./SQLEXPRESS;Database=productDB;Integrated security=true");
            // true because we not using sql authentication but local server(windows auth) 
        }

        //method to open the connection 
        public void open()  
        {
            if (sqlconnection.State !=ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        //method to close the connection 
        public void close()
        {
            if (sqlconnection.State==ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
        
        //method to read data from DB through stored procedures (SELECT)
        public DataTable selectData(String stored_procedure,SqlParameter[] param) //sqlparameter is array inputtype 
        {
            //excute on server using sqlcommand  (use sqlcmd object )
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;   //same name of parameter
            sqlcmd.Connection = sqlconnection;       
            //check if thereis parameters or no 
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            //get data after excute sqlcommand and save it in DA
            SqlDataAdapter DA = new SqlDataAdapter(sqlcmd);

            // create obj with DataTable type
            DataTable DT = new DataTable();

            // add data in DT object
            DA.Fill(DT);
            return DT;
        }

        //method to excute in DB through stored proc (UPDATE, DELETE ,INSERT) no return values
        public void excuteCommand(String stored_procedure,SqlParameter[] param)
        {   
            //create object w
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
            // save param 
            if (param != null) 
            {
                sqlcmd.Parameters.AddRange(param);
            }
        sqlcmd.ExecuteNonQuery();
        }
    }
}

