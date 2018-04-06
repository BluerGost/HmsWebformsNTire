using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DotNet.HMS.DataLayer;
using DotNet.HMS.EntityLayer;

namespace DotNet.HMS.BusinessLayer
{
    public class BusinessViewPatientHistory
    {
        DataViewPatientHistory objDataViewPatient = new DataViewPatientHistory();


        public DataTable businessFillPatientHistoryUsingPatientId(EntityPatientDetails objEntity)
        {
            SqlParameter[] objPara = new SqlParameter[1];
            objPara[0] = new SqlParameter("@PatientId", SqlDbType.Int);
            objPara[0].Value = objEntity.PatientId;
            DataTable objTable = new DataTable();
            objTable.Clear();
            objTable = objDataViewPatient.DataFillPatientHistoryUsingPatientId(objPara).Tables["PatientHistoryUsingId"];
            return objTable;
        }

        public DataTable businessFillPatientHistoryUsingPatientName(EntityPatientDetails objEntity)
        {
            SqlParameter[] objPara = new SqlParameter[2];
            objPara[0] = new SqlParameter("@FirstName", SqlDbType.VarChar,20);
            objPara[0].Value = objEntity.FirstName;
            objPara[1] = new SqlParameter("@LastName", SqlDbType.VarChar, 20);
            objPara[1].Value = objEntity.LastName;
            DataTable objTable = new DataTable();
            objTable.Clear();
            objTable = objDataViewPatient.DataFillPatientHistoryUsingPatientName(objPara).Tables["PatientHistoryUsingName"];
            return objTable;
        }


        public DataTable businessFillPatientId()
        {
            DataTable objTable = new DataTable();
            objTable.Clear();
            objTable = objDataViewPatient.DataFillPatientId().Tables["PatientId"];
            return objTable;
        }

        public DataTable businessFillPatientFirstName()
        {
            DataTable objTable = new DataTable();
            objTable.Clear();
            objTable = objDataViewPatient.DataFillPatientFirstName().Tables["PatientFirstName"];
            return objTable;
        }

        public DataTable businessFillPatientLastName()
        {
            DataTable objTable = new DataTable();
            objTable.Clear();
            objTable = objDataViewPatient.DataFillPatientLastName().Tables["PatientLastName"];
            return objTable;
        }
    }
}
