using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;//Connected Mode: DataReader;
using System.Data;//Disconnected Model: DataSet,DataTable,DataView

namespace DotNet.HMS.DataLayer
{
    public class DataEnrollPatient
    {
        DataAccess dataAccess = new DataAccess();
        DataSet ds = new DataSet();
        SqlDataAdapter da;


        public int DataUpdateEnrollPatientDetails(SqlParameter[] objPara)
        {
            int result;
            dataAccess.cmd.CommandText = "spEnterPatientDetails";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;

            dataAccess.cmd.Parameters.AddRange(objPara);

            dataAccess.con.Open();
            result = dataAccess.cmd.ExecuteNonQuery();
            dataAccess.con.Close();
            return result;
            //Still Have to type code here to inster data into database.

        }
        public DataSet DataFillStateDetails()
        {

            //dataAccess.cmd.CommandText= "SELECT * FROM tblState";
            //dt.cmd.CommandType = CommandType.Text;//(Default) So its ok it u wont write this

            dataAccess.cmd.CommandText = "spGetStateDetails";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;

            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
           // ds.Clear();
            da.Fill(ds,"StateDtls");
            dataAccess.con.Close();
            return ds;
        }

        public DataSet DataFillPlanDetails()
        {
            //dataAccess.cmd.CommandText = "SELECT * FROM tblPlan";
            dataAccess.cmd.CommandText = "spGetPlanDetails";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;
            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            da.Fill(ds, "PlanDtls");
            dataAccess.con.Close();
            return ds;

        }
    }
}
