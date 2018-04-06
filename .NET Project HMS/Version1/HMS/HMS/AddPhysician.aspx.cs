using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.HMS.BusinessLayer;
using DotNet.HMS.EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace HMS
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillDepartment();
                fillState();
                fillPlan();
            }
        }

        void fillDepartment()//Write Correct Code
        {
            BusinessAddPhysician bus = new BusinessAddPhysician();
            DataTable dt = bus.BussinessFillDepartmentDetails();//PlanDtls DataTable Returned

            cbDepartment.DataTextField = dt.Columns[1].ToString();//Plan Name
            cbDepartment.DataValueField = dt.Columns[0].ToString();//Plan ID
            cbDepartment.DataSource = dt;
            cbDepartment.DataBind();
            cbDepartment.Items.Insert(0, new ListItem("Select Department", "-1"));
        }

    

        void fillState()
        {

            BusinessAddPhysician bus = new BusinessAddPhysician();
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
            BusinessAddPhysician bus = new BusinessAddPhysician();
            DataTable dt = bus.BussinessFillPlanDetails();//PlanDtls DataTable Returned

            cbPlan.DataTextField = dt.Columns[1].ToString();//Plan Name
            cbPlan.DataValueField = dt.Columns[0].ToString();//Plan ID
            cbPlan.DataSource = dt;
            cbPlan.DataBind();
            cbPlan.Items.Insert(0, new ListItem("Select Plan", "-1"));
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            //Reset Button Function(Reset all the control to the initial state)
            tbFirstName.Text = "";
            tbLastName.Text = "";
            cbDepartment.SelectedIndex = 0;
            tbEducationalQualification.Text = "";
            tbYearsOfExperience.Text = "";
            cbPlan.SelectedIndex = 0;
            cbState.SelectedIndex = 0;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Submit Button:submit the Physician Information to the DataBase
            BusinessAddPhysician objBus = new BusinessAddPhysician();
            EntityPhysician objEn = new EntityPhysician();

            objEn.FirstName = tbFirstName.Text;
            objEn.LastName = tbLastName.Text;
            if(cbDepartment.SelectedIndex==0)
            {
                //Show error message
            }
            else
            {
                objEn.DepartmentId = cbDepartment.SelectedValue;//Same as: SelectedItem.Value
                                                                //Gives the value of the selected index.
            }

            objEn.EduQualification = tbEducationalQualification.Text;
            objEn.YearsOfExperience = Convert.ToInt32(tbYearsOfExperience.Text);

            if (cbPlan.SelectedIndex==0)
            {
                //Show error message
            }
            else
            {
                objEn.PlanId = cbPlan.SelectedValue;
            }

            if(cbState.SelectedIndex==0)
            {
                //Show Error message
            }
            else
            {
                objEn.StateId = cbState.SelectedValue;
            }
            

            int result;
            result = objBus.BusinessUpdateAddPhysician(objEn);
        }
    }
}