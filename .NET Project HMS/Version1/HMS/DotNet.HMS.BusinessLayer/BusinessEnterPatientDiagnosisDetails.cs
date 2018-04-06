using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//Disconnect
using System.Data.SqlClient;
using DotNet.HMS.DataLayer;
using DotNet.HMS.EntityLayer;

namespace DotNet.HMS.BusinessLayer
{
    public class BusinessEnterPatientDiagnosisDetails
    {
        DataTable dt = new DataTable();
        DataEnterPatientDiagnosisDetails objData = new DataEnterPatientDiagnosisDetails();


        public int businessUpdateEnterPatientDiagnosisDetails(EntityPatientDiagnosis objEn)
        {
            SqlParameter[] objPara = new SqlParameter[8];

            objPara[0] = new SqlParameter("@DiagnosisId", SqlDbType.Int);
            //objEn.DiagnosisId = objPara[0].ParameterName().Value;
            //objPara[0].Value = objEn.DiagnosisId;
            objPara[0].Direction = ParameterDirection.Output;

            objPara[1] = new SqlParameter("@PatientId",SqlDbType.Int);
            objPara[1].Value = objEn.PatientId;

            objPara[2] = new SqlParameter("@Symptoms", SqlDbType.VarChar,20);
            objPara[2].Value = objEn.Symptoms;

            objPara[3] = new SqlParameter("@DiagnosisProvided", SqlDbType.VarChar,30);
            objPara[3].Value = objEn.DiagnosisProvided;

            objPara[4] = new SqlParameter("@AdministeredBy", SqlDbType.VarChar,5);
            objPara[4].Value = objEn.AdministeredBy;

            objPara[5] = new SqlParameter("@DateofDiagnosis", SqlDbType.Date);
            objPara[5].Value = objEn.DateofDiagnosis;

            objPara[6] = new SqlParameter("@FollowUpRequired", SqlDbType.VarChar,1);
            objPara[6].Value = objEn.FollowUpRequired;

            objPara[7] = new SqlParameter("@DateOfFollowUp", SqlDbType.Date);
            objPara[7].Value = objEn.DateOfFollowUp;
   
            int result;
            result = objData.dataUpdateEnterPatientDiagnosisDetails(objPara);
            //We are getting the output parameter from SqlParameter Class Object index:0 which is DiagnosisId
            //And we are setting that value to the DiagnosisId Property in the Entity Layer.
            objEn.DiagnosisId =Convert.ToInt32( objPara[0].Value);
            return result;
        }

        public int businessUpdateEnterBillingDetails(EntityBilling entityBilling)
        {
            SqlParameter[] objPara = new SqlParameter[4];      

            objPara[0] = new SqlParameter("@BillAmount", SqlDbType.VarChar, 20);
            objPara[0].Value = entityBilling.BillAmount;

            objPara[1] = new SqlParameter("@ModeOfPayment", SqlDbType.VarChar, 5);
            objPara[1].Value = entityBilling.ModeOfPayment;

            objPara[2] = new SqlParameter("@CardNumber", SqlDbType.VarChar, 30);
            objPara[2].Value = entityBilling.CardNumber;

            objPara[3] = new SqlParameter("@DiagnosisId", SqlDbType.Int);
            objPara[3].Value = entityBilling.DiagnosisId;

            int result;
            result = objData.dataUpdateEnterBillingDetails(objPara);
            return result;
        }


        public DataTable businessFillPatientIdName()
        {
            dt.Clear();
            dt = objData.dataFillPatientIdName().Tables["PatientIdNameCombo"];
            return dt;
        }

        public DataTable businessFillPhysicianIdName()
        {
            dt.Clear();
            dt = objData.dataFillPhysicianIdName().Tables["PhysicianIdNameCombo"];
            return dt;
        }
    }
}
    

       
 


   
    

