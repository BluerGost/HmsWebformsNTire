using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.HMS.EntityLayer;
using DotNet.HMS.BusinessLayer;
using System.Data;
//using System.Data.SqlClient;

namespace HMS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillPatientIdName();
                fillPhysicianIdName();
                fillModeOfPayment();
                PanelBilling.Enabled = false;
            } 
        }
        public void fillPatientIdName()
        {
            BusinessEnterPatientDiagnosisDetails bus = new BusinessEnterPatientDiagnosisDetails();
            DataTable dt = new DataTable();
            dt = bus.businessFillPatientIdName();
            ddlPatientIdName.DataTextField = dt.Columns[0].ToString();//PatientIdName column form 
            ddlPatientIdName.DataValueField = dt.Columns[1].ToString();//patientId Column from Database
            ddlPatientIdName.DataSource = dt;
            ddlPatientIdName.DataBind();
            ddlPatientIdName.Items.Insert(0,new ListItem("Select Patient", "-1"));
        }

        public void fillPhysicianIdName()
        {
            BusinessEnterPatientDiagnosisDetails bus = new BusinessEnterPatientDiagnosisDetails();
            DataTable dt = new DataTable();
            dt = bus.businessFillPhysicianIdName();
            ddlPhysicianIdName.DataTextField = dt.Columns[0].ToString();
            ddlPhysicianIdName.DataValueField = dt.Columns[1].ToString();
            ddlPhysicianIdName.DataSource = dt;
            ddlPhysicianIdName.DataBind();
            ddlPhysicianIdName.Items.Insert(0, new ListItem("Select Physician", "-1"));
        }
        public void fillModeOfPayment()
        {
            ListItem selecteText = new ListItem("Select A Mode Of Payment", "-1");
            ListItem cardItem = new ListItem("Card","1");//Text,Value
            ListItem cashItem = new ListItem("Cash","2");

            ddlModeOfPayment.Items.Add(selecteText);
            ddlModeOfPayment.Items.Add(cardItem);
            ddlModeOfPayment.Items.Add(cashItem);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EntityPatientDiagnosis objEn = new EntityPatientDiagnosis();
            BusinessEnterPatientDiagnosisDetails objBus = new BusinessEnterPatientDiagnosisDetails();
            //PatientId
            if(ddlPatientIdName.SelectedItem.Value=="-1")
            {
                //Error Massage
            }
            else
            {
                objEn.PatientId = Convert.ToInt32(ddlPatientIdName.SelectedValue);
            }

            objEn.Symptoms = tbSymptoms.Text;
            objEn.DiagnosisProvided = tbDiagnosisProvided.Text;

            if (ddlPhysicianIdName.SelectedItem.Value == "-1")
            {
                //Error Massage
            }
            else
            {
                objEn.AdministeredBy = ddlPhysicianIdName.SelectedValue;
            }

            objEn.DateofDiagnosis = DateTime.ParseExact(tbDateofDiagnosis.Text, "dd-MM-yy", System.Globalization.CultureInfo.InvariantCulture);

            if(cbFollowUpRequired.Checked)
            {
                objEn.FollowUpRequired = "Y";
                objEn.DateOfFollowUp= DateTime.ParseExact(tbFollowUpDate.Text, "dd-MM-yy", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                objEn.FollowUpRequired = "N";
            }

            int result;
            result=objBus.businessUpdateEnterPatientDiagnosisDetails(objEn);
            if(result==1)//NonExecuteQuary(Stored Procedure) Execution Success
            {
                ViewState["DiagnosisId"] = objEn.DiagnosisId;//Save the DiagnosisId In a view State to pass later with billing Information.
                lblDiagnosisMassage.Text = "Data  Inserted Secussefully"+objEn.DiagnosisId;

                //Enable Billing section Disable Diagnosis Section. When Diagnosis Details inserted seccessfully in Database
                PanelBilling.Enabled = true;
                PanelDiagnosis.Enabled = false;
            }
            else
            {
                lblDiagnosisMassage.Text = "Data Insertion Error";
            }
            // Enabling the Billin Section(Panel) after clicking the Save Button
           

        }

        protected void cbFollowUpRequired_CheckedChanged(object sender, EventArgs e)
        {
            if(cbFollowUpRequired.Checked)
            {
                tbFollowUpDate.Enabled = true;
            }
            else
            {
                tbFollowUpDate.Enabled = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)//For  Entering Billing Informaiton in Database
        {
            //Database tblBilling mapped class form Entity Layer
            EntityBilling entityBilling = new EntityBilling();
            entityBilling.BillAmount = Convert.ToInt32(tbBillAmount.Text);

            entityBilling.ModeOfPayment = ddlModeOfPayment.SelectedItem.Text;
            if(ddlModeOfPayment.SelectedItem.Text== "Card")//Card value
            {
                entityBilling.CardNumber = tbCardNumber.Text;
            }
            //Get the DiagnosisId form the ViewState variable.
            if (ViewState != null)
            {
                entityBilling.DiagnosisId = Convert.ToInt32(ViewState["DiagnosisId"]);
            }
            BusinessEnterPatientDiagnosisDetails bus = new BusinessEnterPatientDiagnosisDetails();

            int result;
            result = bus.businessUpdateEnterBillingDetails(entityBilling);
            if (result == 1)
            {
                //Disable Billing section Enable Diagnosis Section. When Billing Details inserted seccessfully in Database.
                PanelBilling.Enabled = false;
                PanelDiagnosis.Enabled = true;
                lblBillingMassage.Text = "Data  Inserted Secussefully";
            }
            else
            {
                lblBillingMassage.Text = "Data Insertion Error";
            }

        }

        protected void ddlModeOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When User will Select Mode of Payment = "Card" in the dropdownlist(ddlModeofPayment) 
            //it will enable the textbox for Card number. User then 
            //will be able to enter their Card Number here

            if(ddlModeOfPayment.SelectedItem.Text == "Card")//Card
            {
                tbCardNumber.Enabled = true;
            }
            else
            {
                tbCardNumber.Enabled = false;
            }
        }
    }
}