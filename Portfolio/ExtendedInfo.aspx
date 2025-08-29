<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtendedInfo.aspx.cs" Inherits="Portfolio_Website.ExtendedInfo" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Projects</h2>
    <asp:Label ID="lblMessage" runat="server" CssClass="message" Text=""></asp:Label>
    <br />

    <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="False" DataKeyNames="ProjectID"
        OnRowEditing="gvProjects_RowEditing" OnRowCancelingEdit="gvProjects_RowCancelingEdit"
        OnRowUpdating="gvProjects_RowUpdating" OnRowDeleting="gvProjects_RowDeleting">
        <Columns>
            <asp:BoundField DataField="ProjectID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="ProjectName" HeaderText="Project Name" />
            <asp:BoundField DataField="ProjectDescription" HeaderText="Description" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <h3>Add New Project</h3>
    <asp:TextBox ID="txtProjectName" runat="server" Placeholder="Project Name"></asp:TextBox>
    <asp:TextBox ID="txtDescription" runat="server" Placeholder="Description"></asp:TextBox>
    <asp:Button ID="btnAddProject" runat="server" Text="Add Project" OnClick="btnAddProject_Click" />
</asp:Content>
