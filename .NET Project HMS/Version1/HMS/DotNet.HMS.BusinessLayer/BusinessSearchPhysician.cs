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
    public class BusinessSearchPhysician
    {
        DataSearchPhysician objData = new DataSearchPhysician();

        public DataTable businessFillPhysicianResult(EntityPhysician objEntity)
        {
            SqlParameter[] objPara = new SqlParameter[3];
            objPara[0] = new SqlParameter("@StateId", SqlDbType.VarChar,2);
            objPara[0].Value = objEntity.StateId;
            objPara[1] = new SqlParameter("@PlanId", SqlDbType.VarChar,4);
            objPara[1].Value = objEntity.PlanId;
            objPara[2] = new SqlParameter("@DepartmentId", SqlDbType.VarChar,4);
            objPara[2].Value = objEntity.DepartmentId;
            DataTable objTable = new DataTable();
            objTable.Clear();
            objTable = objData.dataFillPhysicianResult(objPara).Tables["SearchPhysicianResult"];
            return objTable;

        }
        public DataTable BussinessFillDepartmentDetails()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt = objData.DataFillDepartmentDetails().Tables["DepartmentDtls"];
            return dt;
        }

        public DataTable BussinessFillPlanDetails()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt = objData.DataFillPlanDetails().Tables["PlanDtls"];
            return dt;
        }

        public DataTable BussinessFillStateDetails()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt = objData.DataFillStateDetails().Tables["StateDtls"];
            return dt;
        }
    }
}
