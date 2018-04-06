using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DotNet.HMS.DataLayer;
using DotNet.HMS.EntityLayer;
using System.Data.SqlClient;//Disconnect Model: For SqlParameter

namespace DotNet.HMS.BusinessLayer
{
    public class BusinessEnrollPatient
    {
        DataEnrollPatient objDataEntrollPatient = new DataEnrollPatient();

        public int BussinessUpdateEnrollPatientDetails(EntityPatientDetails objEn)
        {
            int result;
            SqlParameter[] objPara = new SqlParameter[9];

            objPara[0] = new SqlParameter("@FirstName", SqlDbType.VarChar, 20);
            objPara[0].Value = objEn.FirstName;


            objPara[1] = new SqlParameter("@LastName", SqlDbType.VarChar, 20);
            objPara[1].Value = objEn.LastName;

            objPara[2] = new SqlParameter("@DateOfBirth", SqlDbType.Date);
            objPara[2].Value = objEn.DateOfBirth;

            //Age Skipped:Calculated in Database as derived attribute

            objPara[3] = new SqlParameter("@Sex", SqlDbType.VarChar,1);
            objPara[3].Value = objEn.Sex;

            objPara[4] = new SqlParameter("@BloodType", SqlDbType.VarChar, 3);
            objPara[4].Value = objEn.BloodType;

            objPara[5] = new SqlParameter("@PhoneNumber", SqlDbType.Int);
            objPara[5].Value = objEn.PhoneNumber;

            objPara[6] = new SqlParameter("@Email", SqlDbType.VarChar,20);
            objPara[6].Value = objEn.Email;

            objPara[7] = new SqlParameter("@StateId", SqlDbType.VarChar,2);
            objPara[7].Value = objEn.StateId;

            objPara[8] = new SqlParameter("@PlanId", SqlDbType.VarChar, 4);
            objPara[8].Value = objEn.PlanId;

            result = objDataEntrollPatient.DataUpdateEnrollPatientDetails(objPara);

            return result;
        }
        public DataTable BussinessFillStateDetails()
        {
            DataTable objTable = new DataTable();
            objTable.Clear();
            objTable = objDataEntrollPatient.DataFillStateDetails().Tables["StateDtls"];
            return objTable;
        }
        public DataTable BussinessFillPlanDetails()
        {
            DataTable objTable = new DataTable();
            objTable.Clear();
            objTable = objDataEntrollPatient.DataFillPlanDetails().Tables["PlanDtls"];
            return objTable;
        }

    }
}
