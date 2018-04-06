<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOfHMS.Master" AutoEventWireup="true" CodeBehind="EnrollPatient.aspx.cs" Inherits="HMS.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    <title>HMS: Enroll Patient</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormTitleContentPlaceHolder" runat="server">
     <h1>Enroll Patient</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormContentPlaceHolder" runat="server">
    
    <form runat="server">
        <div class="form-group">
            <label for="tbFirstName">First Name</label>
            <asp:TextBox CssClass="form-control" ID="tbFirstName" runat="server" placeholder="First Name"></asp:TextBox>
        </div>
         <div class="form-group">
            <label for="tbLastName">Last Name</label>
            <asp:TextBox CssClass="form-control" ID="tbLastName" runat="server"  placeholder="Last Name"></asp:TextBox>
        </div>
         <div class="form-group">
            <label for="tbDOB">Date Of Birth</label>
             <div class="form-inline">
                <asp:TextBox CssClass="form-control" ID="tbDOB" runat="server"  placeholder="Date Of Birth(dd-mm-yy)"> </asp:TextBox>
                <i id="logoForCalander"class="fa fa-calendar  fa-2x"></i>
                <ajaxToolkit:CalendarExtender ID="calanderDOB" runat="server" format="dd-MM-yy" PopupButtonID="logoForCalander" TargetControlID="tbDOB" TodaysDateFormat="dd-MM-yy"/>
             </div>
        </div>
        <%-- Age Skipped: Will Be a Derived Attribute . Calculated in Backend with DOB --%>
        <div class="form-group">
            <label for="rblSex">Sex</label>
             <div class="form-inline">
                 <asp:RadioButtonList ID="rblSex" runat="server" data-style="label-info"></asp:RadioButtonList>
             </div>
        </div>
        <div class="form-group">
            <label for="ddlBloodType">Blood Type</label>
             <div class="form-inline">
                 <asp:DropDownList ID="ddlBloodType" runat="server" CssClass="btn btn-default btn-default"></asp:DropDownList>
             </div>
        </div>
         <div class="form-group">
            <label for="tbEmail">Email Address</label>
            <asp:TextBox CssClass="form-control" ID="tbEmail" runat="server"  placeholder="Email Address"></asp:TextBox>
        </div>
         <div class="form-group">
            <label for="tbPhoneNumber">Phone Number</label>
            <asp:TextBox CssClass="form-control" ID="tbPhoneNumber" runat="server"  placeholder="Phone Number"></asp:TextBox>
        </div>
         <div class="form-group">
            <label for="ddlState">State</label><br />
             <asp:DropDownList ID="ddlState" runat="server" CssClass="btn btn-default btn-default"></asp:DropDownList>
            <%-- <ajaxToolkit:ComboBox ID="cbState" runat="server"></ajaxToolkit:ComboBox>--%>
         </div>
         <div class="form-group">
            <label for="ddlPlan">Plan</label><br />
             <asp:DropDownList ID="ddlPlan" runat="server" CssClass="btn btn-default"></asp:DropDownList>
            <%--<ajaxToolkit:ComboBox  ID="cbPlan" runat="server" ></ajaxToolkit:ComboBox>--%>
            
        </div>
        <asp:Button class="btn btn-success" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />
        <asp:Label ID="lblMassange" runat="server" Text="Label-For-ErrorMessage"></asp:Label>
      
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>          
</asp:Content>