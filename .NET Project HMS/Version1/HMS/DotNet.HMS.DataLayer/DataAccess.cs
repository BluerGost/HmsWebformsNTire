using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace DotNet.HMS.DataLayer
{
    public class DataAccess
    {
        public SqlConnection con;
        public SqlCommand cmd;

        public DataAccess()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();

            //Setting the Connection String From Web.config Page.
            con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionHMS"].ConnectionString;
            //Setting the SqlCommand Connection String to the Web.config Connection String.
            cmd.Connection = con;
        }
    }
}
