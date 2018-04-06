<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOfHMS.Master" AutoEventWireup="true" CodeBehind="ViewPatientHistory.aspx.cs" Inherits="HMS.WebForm3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    <title>HMS: View Patient History</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormTitleContentPlaceHolder" runat="server">
    <h1>View Patient History</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="form-group">
            <label for="tbPatientId">Patient ID</label><br />
            <asp:DropDownList ID="ddlPatientId" CssClass="btn btn-default" runat="server" OnSelectedIndexChanged="ddlPatientId_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
        <asp:label runat="server">-----------------OR-------------------</asp:label>
        <div class="form-group">
            <label for="cbFirstName">First Name</label><br />
            <asp:DropDownList ID="ddlFirstName" CssClass="btn btn-default" runat="server" OnSelectedIndexChanged="ddlFirstName_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="cbLastName">Last Name</label><br />
            <asp:DropDownList ID="ddlLastName" CssClass="btn btn-default" runat="server" OnSelectedIndexChanged="ddlLastName_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
        <asp:Button class="btn btn-default" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <asp:Button class="btn btn-default" ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
      
      <hr />

        <asp:GridView ID="gvViewPatientHistory" class="grid-view" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Patient ID" DataField="patientId" />
                <asp:BoundField HeaderText="First Name" DataField="firstName" />
                <asp:BoundField HeaderText="Last Name" DataField="lastName" />
                <asp:BoundField HeaderText="Date of Diagnosis" DataField="dateOfDiagnosis" DataformatString="{0:d}"/>
                <asp:BoundField HeaderText="Physician ID" DataField="administeredBy" />
                <asp:BoundField HeaderText="Symptoms" DataField="symptoms" />
                <asp:BoundField HeaderText="Diagnosis" DataField="diagnosisProvided" />
                <asp:BoundField HeaderText="Follow-Up Date" DataField="dateOfFollowUp" DataformatString="{0:d}"/>
                <asp:BoundField HeaderText="Bill Amount" DataField="billAmount"/>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
       

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
</asp:Content>
