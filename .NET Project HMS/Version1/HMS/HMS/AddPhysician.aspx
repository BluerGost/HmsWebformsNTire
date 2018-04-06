<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOfHMS.Master" AutoEventWireup="true" CodeBehind="AddPhysician.aspx.cs" Inherits="HMS.WebForm4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    <title>HMS: Add Physician</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormTitleContentPlaceHolder" runat="server">
    <h1>Add Physician</h1>
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
            <label for="cbDepartment">Department</label><br /> <%--ID and Name--%>
            <ajaxtoolkit:combobox  ID="cbDepartment" runat="server"></ajaxtoolkit:combobox>
        </div>
          <div class="form-group">
            <label for="cbEducationalQualification">Educational qualification </label><br /> 
            <asp:TextBox CssClass="form-control" ID="tbEducationalQualification" runat="server"  placeholder="Educational Qualification"></asp:TextBox>
        </div>
          <div class="form-group">
            <label for="tbYearsOfExperience">Years Of Experience</label>
            <asp:TextBox CssClass="form-control" ID="tbYearsOfExperience" runat="server"  placeholder="Years Of Experience"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="cbState">State</label><br />
             <ajaxtoolkit:combobox ID="cbState" runat="server"></ajaxtoolkit:combobox>
        </div>
         <div class="form-group">
            <label for="cbPlan">Plan</label><br />
            <ajaxtoolkit:combobox  ID="cbPlan" runat="server"></ajaxtoolkit:combobox>
        </div>
        <asp:Button class="btn btn-default" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <asp:Button class="btn btn-default" ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    </form>
</asp:Content>
