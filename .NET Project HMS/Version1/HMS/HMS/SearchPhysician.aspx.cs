using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.HMS.BusinessLayer;
using DotNet.HMS.EntityLayer;
using System.Data;

namespace HMS
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillState();
                fillPlan();
                fillDepartment();
            }
        }


        void fillState()
        {
            BusinessSearchPhysician bus = new BusinessSearchPhysician();
            //if we dont use this DataTable 3 of the same State list prints in DropDownList
            DataTable dt = bus.BussinessFillStateDetails();//StateDtls DataTable Return

            cbState.DataTextField = dt.Columns[1].ToString();//State Name: Will be shown to user
            cbState.DataValueField = dt.Columns[0].ToString();//State ID: will be used in backend
            cbState.DataSource = dt;
            cbState.DataBind();
            ListItem li = new ListItem("Select State", "-1");
            cbState.Items.Insert(0, li);//Inserting "Select State" List Item in Position 0
        }
        void fillPlan()
        {
            BusinessSearchPhysician bus = new BusinessSearchPhysician();
            DataTable dt = bus.BussinessFillPlanDetails();//PlanDtls DataTable Returned

            cbPlan.DataTextField = dt.Columns[1].ToString();//Plan Name
            cbPlan.DataValueField = dt.Columns[0].ToString();//Plan ID
            cbPlan.DataSource = dt;
            cbPlan.DataBind();
            cbPlan.Items.Insert(0, new ListItem("Select Plan", "-1"));
        }
        void fillDepartment()
        {
            BusinessSearchPhysician bus = new BusinessSearchPhysician();
            DataTable dt = bus.BussinessFillDepartmentDetails();//PlanDtls DataTable Returned

            cbDepartment.DataTextField = dt.Columns[1].ToString();//Plan Name
            cbDepartment.DataValueField = dt.Columns[0].ToString();//Plan ID
            cbDepartment.DataSource = dt;
            cbDepartment.DataBind();
            cbDepartment.Items.Insert(0, new ListItem("Select Department", "-1"));
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            cbDepartment.SelectedIndex = 0;
            cbState.SelectedIndex = 0;
            cbPlan.SelectedIndex = 0;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            EntityPhysician objEn = new EntityPhysician();
            if(cbState.SelectedIndex==0)
            {
                //Error Message
            }
            else
            {
                objEn.StateId = cbState.SelectedValue;
            }

            if (cbPlan.SelectedIndex == 0)
            {
                //Error Message
            }
            else
            {
                objEn.PlanId = cbPlan.SelectedValue;
            }

            if (cbDepartment.SelectedIndex == 0)
            {
                //Error Message
            }
            else
            {
                objEn.DepartmentId = cbDepartment.SelectedValue;
            }

            BusinessSearchPhysician bus = new BusinessSearchPhysician();
            DataTable dt;
            dt = bus.businessFillPhysicianResult(objEn);
            gvSearchPhysicianResult.DataSource = dt;
            gvSearchPhysicianResult.DataBind();
        }
    }
}