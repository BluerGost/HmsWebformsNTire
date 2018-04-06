using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DotNet.HMS.DataLayer
{
   public class DataViewPatientHistory
    {
        DataAccess dataAccess = new DataAccess();
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        public DataSet DataFillPatientHistoryUsingPatientId(SqlParameter[] objPara)
        {
            dataAccess.cmd.CommandText = "spGetPatientHistoryUsingId";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;
            dataAccess.cmd.Parameters.AddRange(objPara);

            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            da.Fill(ds, "PatientHistoryUsingId");
            dataAccess.con.Close();
            return ds;

        }
        public DataSet DataFillPatientHistoryUsingPatientName(SqlParameter[] objPara)
        {
            dataAccess.cmd.CommandText = "spGetPatientHistoryUsingName";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;
            dataAccess.cmd.Parameters.AddRange(objPara);

            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            da.Fill(ds, "PatientHistoryUsingName");
            dataAccess.con.Close();
            return ds;
        }
        public DataSet DataFillPatientId()
        {
            dataAccess.cmd.CommandText = "spGetPatientId";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;

            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            // ds.Clear();
            da.Fill(ds, "PatientId");
            dataAccess.con.Close();
            return ds;
        }
        public DataSet DataFillPatientFirstName()
        {
            dataAccess.cmd.CommandText = "spGetPatientFirstName";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;

            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            // ds.Clear();
            da.Fill(ds, "PatientFirstName");
            dataAccess.con.Close();
            return ds;
        }

        public DataSet DataFillPatientLastName()
        {
            dataAccess.cmd.CommandText = "spGetPatientLastName";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;

            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            // ds.Clear();
            da.Fill(ds, "PatientLastName");
            dataAccess.con.Close();
            return ds;
        }
    }
}
