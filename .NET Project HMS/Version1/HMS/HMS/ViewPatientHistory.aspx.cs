using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DotNet.HMS.BusinessLayer;
using DotNet.HMS.EntityLayer;


namespace HMS
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillPatientId();
                fillPatientFirstName();
                fillPatientLastName();
            }
        }

        public void fillPatientId()
        {
            BusinessViewPatientHistory bus = new BusinessViewPatientHistory();
            DataTable dt = bus.businessFillPatientId();

            ddlPatientId.DataTextField = dt.Columns[0].ToString();//Patient Id
            ddlPatientId.DataValueField = dt.Columns[0].ToString();//Patient Id
            ddlPatientId.DataSource = dt;
            ddlPatientId.DataBind();

            ListItem li = new ListItem("Select Patient-Id","-1");
            ddlPatientId.Items.Insert(0,li);
            //Inserted Listitem Index in ddlPatientId control is [0]
            //But its valeu is -1
        }
        public void fillPatientFirstName()
        {
            BusinessViewPatientHistory bus = new BusinessViewPatientHistory();
            DataTable dt = bus.businessFillPatientFirstName();

            ddlFirstName.DataTextField = dt.Columns[0].ToString();//Patient First Name
            ddlFirstName.DataValueField = dt.Columns[0].ToString();//Patient First Name
            ddlFirstName.DataSource = dt;
            ddlFirstName.DataBind();

            ListItem li = new ListItem("Select Patient\'s First Name", "-1");
            ddlFirstName.Items.Insert(0, li);
            //Inserted Listitem Index in ddlFirstName control is [0]
            //But its valeu is -1
        }
        public void fillPatientLastName()
        {
            BusinessViewPatientHistory bus = new BusinessViewPatientHistory();
            DataTable dt = bus.businessFillPatientLastName();

            ddlLastName.DataTextField = dt.Columns[0].ToString();//Patient Last Name
            ddlLastName.DataValueField = dt.Columns[0].ToString();//Patient Last Name
            ddlLastName.DataSource = dt;
            ddlLastName.DataBind();

            ListItem li = new ListItem("Select Patient\'s Last Name", "-1");
            ddlLastName.Items.Insert(0, li);
            //Inserted Listitem Index in ddlLastName control is [0]
            //But its valeu is -1
        }
        protected void btnReset_Click(object sender, EventArgs e)//Reset the Input controls
        {
            ddlPatientId.SelectedIndex = 0;
            ddlFirstName.SelectedIndex = 0;
            ddlLastName.SelectedIndex = 0;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            EntityPatientDetails objEntity = new EntityPatientDetails();
            BusinessViewPatientHistory objBus = new BusinessViewPatientHistory();
            DataTable dt = new DataTable();

            if(ddlPatientId.SelectedIndex == 0)//PatientId not selected in DropDownList
            {
                objEntity.FirstName = ddlFirstName.SelectedItem.Text;
                objEntity.LastName = ddlLastName.SelectedItem.Text;
                dt.Clear();
                dt = objBus.businessFillPatientHistoryUsingPatientName(objEntity);
            }
            else if(ddlFirstName.SelectedIndex == 0 &&  ddlLastName.SelectedIndex == 0)//Firsname and LastName not selected in DropDownList
            {
                objEntity.PatientId = Convert.ToInt32(ddlPatientId.SelectedItem.Text);
                dt.Clear();
                dt = objBus.businessFillPatientHistoryUsingPatientId(objEntity);
            }
            else
            {
                //Error massage: Eiter enter Patient Id or First Name and Lastname of the Patient whoes history you want to see.
            }
            gvViewPatientHistory.DataSource = dt;
            gvViewPatientHistory.DataBind();
            
        
           
        }

        protected void ddlPatientId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlPatientId.SelectedIndex!=0)//Selected item is not the initial item(i.e.:Select Patient-ID)
            {
                ddlFirstName.Enabled = false;
                ddlLastName.Enabled = false;
            }
            else
            {
                ddlFirstName.Enabled = true;
                ddlLastName.Enabled = true;
            }
        }

        protected void ddlFirstName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlFirstName.SelectedIndex!=0)
            {
                ddlPatientId.Enabled = false;
            }
            else
            {
                ddlPatientId.Enabled = true;
            }
        }

        protected void ddlLastName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLastName.SelectedIndex != 0)
            {
                ddlPatientId.Enabled = false;
            }
            else
            {
                ddlPatientId.Enabled = true;
            }
        }
    }
}