using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Products_Management.BL
{
    class CTL_LOGIN
    {
        //da method to return procedures use id and pass 
        public DataTable Login (String id ,String psd)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            //create parameters

            SqlParameter[] param = new SqlParameter[2];
            //declare first param
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = id;
            param[1] = new SqlParameter("@psd", SqlDbType.VarChar, 50);
            param[1].Value = psd;
            //open db connection 

            DAL.open();
            //call fun to excute  my proc
            DataTable dt = new DataTable();
            dt = DAL.selectData("logintable",param);
            DAL.close();
            return dt;
        }
    }
}
