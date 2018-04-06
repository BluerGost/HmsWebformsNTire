<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOfHMS.Master" AutoEventWireup="true" CodeBehind="SearchPhysician.aspx.cs" Inherits="HMS.WebForm5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitleContentPlaceHolder" runat="server">
    <title>HMS: Search Physician</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormTitleContentPlaceHolder" runat="server">
    <h1>Search Physician</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormContentPlaceHolder" runat="server">
    <form runat="server">
         <div class="form-group">
            <label for="cbState">State</label><br />
             <ajaxtoolkit:combobox ID="cbState" runat="server" AutoCompleteMode="SuggestAppend"></ajaxtoolkit:combobox>
        </div>
         <div class="form-group">
            <label for="cbPlan" >Plan</label><br />
            <ajaxtoolkit:combobox  ID="cbPlan" runat="server" AutoCompleteMode="SuggestAppend"></ajaxtoolkit:combobox>
        </div>
        <div class="form-group">
            <label for="cbDepartment">Department</label><br /> <%--ID and Name--%>
            <ajaxtoolkit:combobox  ID="cbDepartment" runat="server" AutoCompleteMode="SuggestAppend"></ajaxtoolkit:combobox>
        </div>
        <%--Buttons(Search & Reset)--%>
        <asp:Button class="btn btn-default" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <asp:Button class="btn btn-default" ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
        <hr />
        <asp:GridView ID="gvSearchPhysicianResult" runat="server" CssClass="grid-view" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="physicianId" HeaderText="Physician ID" />
                <asp:BoundField DataField="firstName" HeaderText="First Name" />
                <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                <asp:BoundField DataField="departmentName" HeaderText="Department Name" />
                <asp:BoundField DataField="eduQualification" HeaderText="Educatin Qualification" />
                <asp:BoundField DataField="yearsOfExperience" HeaderText="Experience(in Years)" />
                <asp:BoundField DataField="planName" HeaderText="Plan Name" />
                <asp:BoundField DataField="stateName" HeaderText="State Name" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
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
