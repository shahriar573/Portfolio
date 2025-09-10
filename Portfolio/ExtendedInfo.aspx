<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtendedInfo.aspx.cs" Inherits="Portfolio_Website.ExtendedInfo" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Projects</h2>
    <asp:Label ID="lblMessage" runat="server" CssClass="message" Text=""></asp:Label>
    <br />

    <asp:Repeater ID="rptProjects" runat="server">
        <ItemTemplate>
            <div class="project-card">
                <asp:PlaceHolder ID="phView" runat="server" Visible='<%# !(bool)Eval("IsEditing") %>'>
                    <h3><%# Eval("ProjectName") %></h3>
                    <p><%# Eval("ProjectDescription") %></p>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandArgument='<%# Eval("ProjectID") %>' OnClick="btnEdit_Click" CssClass="edit-btn" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("ProjectID") %>' OnClick="btnDelete_Click" CssClass="delete-btn" />
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phEdit" runat="server" Visible='<%# (bool)Eval("IsEditing") %>'>
                    <asp:TextBox ID="txtEditName" runat="server" Text='<%# Eval("ProjectName") %>' CssClass="edit-input"></asp:TextBox>
                    <asp:TextBox ID="txtEditDesc" runat="server" Text='<%# Eval("ProjectDescription") %>' CssClass="edit-input"></asp:TextBox>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%# Eval("ProjectID") %>' OnClick="btnUpdate_Click" CssClass="update-btn" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandArgument='<%# Eval("ProjectID") %>' OnClick="btnCancel_Click" CssClass="cancel-btn" />
                </asp:PlaceHolder>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <h3>Add New Project</h3>
    <div class="add-project-card">
        <asp:TextBox ID="txtProjectName" runat="server" Placeholder="Project Name"></asp:TextBox>
        <asp:TextBox ID="txtDescription" runat="server" Placeholder="Description"></asp:TextBox>
        <asp:Button ID="btnAddProject" runat="server" Text="Add Project" OnClick="btnAddProject_Click" CssClass="add-btn" />
    </div>
</asp:Content>
