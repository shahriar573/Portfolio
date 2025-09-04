<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Portfolio_Website.Home" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home-container">
        <h2>Welcome to the Portfolio Site</h2>
        <p>Choose an option below:</p>

        <asp:Panel ID="pnlAdminOptions" runat="server" Visible="false" CssClass="center-panel">
            <h3>Admin Options</h3>
            <a href="ExtendedInfo.aspx">Manage Projects</a><br />
        </asp:Panel>

        <asp:Panel ID="pnlMemberOptions" runat="server" Visible="false" CssClass="center-panel">
            <h3>Member Options</h3>
            <a href="Portfolio.aspx">My Portfolio</a>
        </asp:Panel>

        <asp:Panel ID="pnlGuestOptions" runat="server" Visible="false" CssClass="center-panel">
            <h3>Guest Options</h3>
            <a href="Portfolio.aspx">View Portfolio</a>
            <a href="Home.aspx">Home</a>
        </asp:Panel>
    </div>
</asp:Content>
