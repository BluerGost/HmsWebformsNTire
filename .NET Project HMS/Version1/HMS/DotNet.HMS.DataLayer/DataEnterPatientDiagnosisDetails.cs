using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DotNet.HMS.DataLayer
{
    public class DataEnterPatientDiagnosisDetails
    {
        DataAccess dataAccess = new DataAccess();
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        public int dataUpdateEnterPatientDiagnosisDetails(SqlParameter[] objPara)
        {
            int result;

            dataAccess.cmd.CommandText = "spEnterPatientDiagnosisDetails";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;

            dataAccess.cmd.Parameters.AddRange(objPara);

            dataAccess.con.Open();
            //Output parameter not working
            result = dataAccess.cmd.ExecuteNonQuery();
            
            //Setting the output parameter value from Sql server to the SqlParameter class object.
            //Since we have passed the SqlParameter object array from Business Layer to Data Layer.
            //When we set value here it will be set to the passed(orginal) SqlParameter Class object that we passed before.
            objPara[0].Value = dataAccess.cmd.Parameters["@DiagnosisId"].Value;
            dataAccess.con.Close();
            return result;
        }

        public int dataUpdateEnterBillingDetails(SqlParameter[] objPara)
        {
            int result;

            dataAccess.cmd.CommandText = "spEnterBillingDetails";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;

            dataAccess.cmd.Parameters.AddRange(objPara);

            dataAccess.con.Open();
            result = dataAccess.cmd.ExecuteNonQuery();
            dataAccess.con.Close();

            return result;
        }
        public DataSet dataFillPatientIdName()
        {

            dataAccess.cmd.CommandText = "spGetPatientIdNameCombination";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;

            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            da.Fill(ds,"PatientIdNameCombo");
            dataAccess.con.Close();
            return ds;

        }

        public DataSet dataFillPhysicianIdName()
        {

            dataAccess.cmd.CommandText = "spGetPhysicianIdNameCombination";
            dataAccess.cmd.CommandType = CommandType.StoredProcedure;

            dataAccess.con.Open();
            da = new SqlDataAdapter(dataAccess.cmd);
            da.Fill(ds, "PhysicianIdNameCombo");
            dataAccess.con.Close();
            return ds;

        }
    }
}
