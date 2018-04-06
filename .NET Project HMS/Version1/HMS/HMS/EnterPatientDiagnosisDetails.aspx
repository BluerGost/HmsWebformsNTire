<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOfHMS.Master" AutoEventWireup="true" CodeBehind="EnterPatientDiagnosisDetails.aspx.cs" Inherits="HMS.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    <title>HMS: Enter Patient Diagnosis Details</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormTitleContentPlaceHolder" runat="server">
     <h1>Enter Patient Diagnosis Details</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FormContentPlaceHolder" runat="server">
   
    <form runat="server">
        <asp:Panel ID="PanelDiagnosis" runat="server">
        <div class="form-group">
            <label for="ddlPatientIdName">Patient</label><br />
            <asp:DropDownList ID="ddlPatientIdName" runat="server" CssClass="btn btn-default"></asp:DropDownList>
        </div>
         <div class="form-group">
            <label for="tbSymptoms">Symptoms</label>
            <asp:TextBox CssClass="form-control" ID="tbSymptoms" runat="server"  placeholder="Symptoms"></asp:TextBox>
        </div>
         <div class="form-group">
            <label for="tbDiagnosisProvided">Diagnosis Provided</label>
            <asp:TextBox CssClass="form-control" ID="tbDiagnosisProvided" runat="server"  placeholder="Diagnosis Provided"></asp:TextBox>
        </div>
         <div class="form-group">
            <label for="ddlPhysicianIdName">Administered By</label><br />
            <asp:DropDownList ID="ddlPhysicianIdName" runat="server" CssClass="btn btn-default"></asp:DropDownList>
        </div>
         <div class="form-group">
            <label for="tbDateofDiagnosis">Date Of Diagnosis</label>

             <div class="form-inline">
              <asp:TextBox CssClass="form-control" ID="tbDateofDiagnosis" runat="server"  placeholder="Phone Number"></asp:TextBox>
                <i id="logoDateofDiagnosis"class="fa fa-calendar  fa-2x"></i>
                <ajaxToolkit:CalendarExtender ID="calanderDateofDiagnosis" runat="server" format="dd-MM-yy" PopupButtonID="logoDateofDiagnosis" TargetControlID="tbDateofDiagnosis" TodaysDateFormat="dd-MM-yy"/>
             </div>
         </div>
         <div class="form-group">
            <label for="cbFollowUpRequired">Follow-Up Required</label>
             <asp:CheckBox ID="cbFollowUpRequired" runat="server" Text="Yes" AutoPostBack="True" OnCheckedChanged="cbFollowUpRequired_CheckedChanged" />   
        </div>
         <div class="form-group">
            <label for="tbFollowUpDate">Follow-Up Date</label>             
             <div class="form-inline">
                <asp:TextBox CssClass="form-control" ID="tbFollowUpDate" runat="server" placeholder="Follow-Up Date(dd-mm-yy)" Enabled="false"></asp:TextBox>
                <i id="logoFollowUpDate"class="fa fa-calendar  fa-2x"></i>
                <ajaxToolkit:CalendarExtender ID="calanderFollowUpDate" runat="server" format="dd-MM-yy" PopupButtonID="logoFollowUpDate" TargetControlID="tbFollowUpDate" TodaysDateFormat="dd-MM-yy"/>
             </div>
         </div>
        <asp:Button class="btn btn-success" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
       </asp:Panel>
        <asp:Label ID="lblDiagnosisMassage" runat="server" Text="Label"></asp:Label>
         <hr />

        <%--Billing Informations--%>
        <asp:Panel ID="PanelBilling" runat="server">
        <div class="form-group">
        <label for="tbBillAmount">Bill Amount</label>
        <asp:TextBox  CssClass="form-control" ID="tbBillAmount" runat="server" placeholder="BillAmount(In BDT)"></asp:TextBox>
        </div>

         <div class="form-group">
        <label for="ddlModeOfPayment">Mode Of Payment</label><br />
        <asp:DropDownList ID="ddlModeOfPayment" runat="server" CssClass="btn btn-default" AutoPostBack="True" OnSelectedIndexChanged="ddlModeOfPayment_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div class="form-group">
        <label for="tbCardNumber">Card Number</label><br />
        <asp:TextBox  CssClass="form-control" ID="tbCardNumber" runat="server" placeholder="Card Number" Enabled="False"></asp:TextBox>
        </div>

        <asp:Button class="btn btn-success" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
         <br />  
         <asp:Label ID="lblBillingMassage" runat="server" Text="Label"></asp:Label>
        </asp:Panel>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>

</asp:Content>



