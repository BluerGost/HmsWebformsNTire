using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//Connected Mode: DataReader;
using System.Data;//Disconnected Model: DataSet,DataTable,DataView
using DotNet.HMS.DataLayer;

namespace DotNet.HMS.DataLayer
{
    public class DataAddPhysician
    {
        DataAccess dataAccess = new DataAccess();
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        public int DataUpdateAddPhysician(SqlParameter[] objPara)
        {
            int result;
            dataAccess.cmd.CommandText = "spAddPhysician";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;

            dataAccess.cmd.Parameters.AddRange(objPara);

            dataAccess.con.Open();
            result = dataAccess.cmd.ExecuteNonQuery();//Failing because Physician Id is not getting inserted
            dataAccess.con.Close();
            return result;
        }

        public DataSet DataFillDepartmentDetails()
        {
            dataAccess.cmd.CommandText = "spGetDepartmentDetails";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;
            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            da.Fill(ds, "DepartmentDtls");
            dataAccess.con.Close();
            return ds;
        }

        public DataSet DataFillStateDetails()
        {
            dataAccess.cmd.CommandText = "spGetStateDetails";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;
            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            da.Fill(ds, "StateDtls");
            dataAccess.con.Close();
            return ds;
        }

        public DataSet DataFillPlanDetails()
        {
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
