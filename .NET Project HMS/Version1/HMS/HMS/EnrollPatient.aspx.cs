using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.HMS.BusinessLayer;
using System.Data;
using DotNet.HMS.EntityLayer;

namespace HMS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack==true)
            {
                fillState();
                fillPlan();
                fillSex();
                fillBloodType();
            }
            

        }
        public void fillSex()
        {
            rblSex.Items.Add(new ListItem("Male", "1"));
            rblSex.Items.Add(new ListItem("Female", "2"));
            rblSex.Items.Add(new ListItem("Other", "3"));
            
        }
        public void fillBloodType()
        {
            ddlBloodType.Items.Add(new ListItem("Select Blood Group","-1"));
            ddlBloodType.Items.Add(new ListItem("O+", "1"));
            ddlBloodType.Items.Add(new ListItem("O-", "2"));
            ddlBloodType.Items.Add(new ListItem("A+", "3"));
            ddlBloodType.Items.Add(new ListItem("A-", "4"));
            ddlBloodType.Items.Add(new ListItem("B+", "5"));
            ddlBloodType.Items.Add(new ListItem("B-", "6"));
            ddlBloodType.Items.Add(new ListItem("AB+", "7"));
            ddlBloodType.Items.Add(new ListItem("AB-", "8"));
        }

        public void fillState()
        {
            BusinessEnrollPatient bus = new BusinessEnrollPatient();
            //if we dont use this DataTable 3 of the same State list prints in DropDownList
            DataTable dt = bus.BussinessFillStateDetails();//StateDtls DataTable Return

            ddlState.DataTextField = dt.Columns[1].ToString();//State Name: Will be shown to user
            ddlState.DataValueField = dt.Columns[0].ToString();//State ID: will be used in backend
            ddlState.DataSource = dt;
            ddlState.DataBind();
            ListItem li = new ListItem("Select State", "-1");
            ddlState.Items.Insert(0,li);//Inserting "Select State" List Item in Position 0
        }

        public void fillPlan()
        {
            BusinessEnrollPatient bus = new BusinessEnrollPatient();
            DataTable dt = bus.BussinessFillPlanDetails();//PlanDtls DataTable Returned

            ddlPlan.DataTextField = dt.Columns[1].ToString();//Plan Name
            ddlPlan.DataValueField = dt.Columns[0].ToString();//Plan ID
            ddlPlan.DataSource = dt;
            ddlPlan.DataBind();
            ddlPlan.Items.Insert(0, new ListItem("Select Plan", "-1"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EntityPatientDetails objEn = new EntityPatientDetails();
            objEn.FirstName = tbFirstName.Text;
            objEn.LastName = tbLastName.Text;
            objEn.DateOfBirth = DateTime.ParseExact(tbDOB.Text, "dd-MM-yy", System.Globalization.CultureInfo.InvariantCulture);
            
            //objEn.Age
            objEn.Sex = rblSex.SelectedItem.Text;
            if(ddlBloodType.SelectedItem.Value=="-1")
            {
                //Error Massage
            }
            else
            {
                objEn.BloodType = ddlBloodType.SelectedItem.Text;
            }

            if (ddlState.SelectedItem.Value == "-1")
            {
                //Error Massage
            }
            else
            {
                objEn.StateId = ddlState.SelectedItem.Value;
            }

            if (ddlPlan.SelectedItem.Value == "-1")
            {
                //Error Massage
            }
            else
            {
                objEn.PlanId = ddlPlan.SelectedItem.Value;
            }

            objEn.PhoneNumber = Convert.ToInt32(tbPhoneNumber.Text);
            objEn.Email = tbEmail.Text;
            
            

            BusinessEnrollPatient bus = new BusinessEnrollPatient();
            int result;
            result = bus.BussinessUpdateEnrollPatientDetails(objEn);

            if(result==1)
            {
                lblMassange.Text="Data Insertion Successfull" + result;
            }
            else
            {
               lblMassange.Text = "ERROR";
            }


            //Response.Write("Selected Index: " + ddlState.SelectedIndex+"<br/>");
            //Response.Write("Selected Text: " + ddlState.SelectedItem.Text + "<br/>");
            //Response.Write("Selected Value: " + ddlState.SelectedValue + "<br/>");
        }
    }
}