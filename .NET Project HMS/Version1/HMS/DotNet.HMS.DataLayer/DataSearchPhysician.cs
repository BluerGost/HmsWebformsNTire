using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DotNet.HMS.DataLayer
{
    public class DataSearchPhysician
    {
        DataAccess dataAccess = new DataAccess();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        public DataSet dataFillPhysicianResult(SqlParameter[] objPara)
        {
            dataAccess.cmd.CommandText = "spGetSearchPhysicianResult";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;
            dataAccess.cmd.Parameters.AddRange(objPara);

            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            da.Fill(ds, "SearchPhysicianResult");
            dataAccess.con.Close();
            return ds;
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
