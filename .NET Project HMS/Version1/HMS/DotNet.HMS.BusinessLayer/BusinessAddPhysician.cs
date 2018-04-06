using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//Connected Mode: DataReader;
using System.Data;//Disconnected Model: DataSet,DataTable,DataView
using DotNet.HMS.DataLayer;
using DotNet.HMS.EntityLayer;

namespace DotNet.HMS.BusinessLayer
{
    public class BusinessAddPhysician
    {
        DataAddPhysician objDataAddPhysician = new DataAddPhysician();
    
        public int BusinessUpdateAddPhysician(EntityPhysician objEn)
        {
            int result;
            SqlParameter[] objPara = new SqlParameter[7];

            objPara[0] = new SqlParameter("@FirstName", SqlDbType.VarChar, 20);
            objPara[0].Value = objEn.FirstName;

            objPara[1] = new SqlParameter("@LastName", SqlDbType.VarChar, 20);
            objPara[1].Value = objEn.LastName;

            objPara[2] = new SqlParameter("@YearsOfExperience", SqlDbType.Int);
            objPara[2].Value = objEn.YearsOfExperience;

            objPara[3] = new SqlParameter("@DepartmentId", SqlDbType.VarChar, 4);
            objPara[3].Value = objEn.DepartmentId;

            objPara[4] = new SqlParameter("@StateId", SqlDbType.VarChar, 2);
            objPara[4].Value = objEn.StateId;

            objPara[5] = new SqlParameter("@PlanId", SqlDbType.VarChar, 4);
            objPara[5].Value = objEn.PlanId;

            objPara[6] = new SqlParameter("@EduQualification", SqlDbType.VarChar, 20);
            objPara[6].Value = objEn.EduQualification;

            result = objDataAddPhysician.DataUpdateAddPhysician(objPara);

            return result;
        }

        public DataTable BussinessFillDepartmentDetails()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt = objDataAddPhysician.DataFillDepartmentDetails().Tables["DepartmentDtls"];
            return dt;
        }

        public DataTable BussinessFillPlanDetails()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt = objDataAddPhysician.DataFillPlanDetails().Tables["PlanDtls"];
            return dt;
        }

        public DataTable BussinessFillStateDetails()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt = objDataAddPhysician.DataFillStateDetails().Tables["StateDtls"];
            return dt;
        }
    }
}
