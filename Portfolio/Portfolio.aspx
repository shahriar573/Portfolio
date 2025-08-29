<%@ Page Title="Portfolio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Portfolio.aspx.cs" Inherits="Portfolio_Website.Portfolio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Portfolio</h2>

    <asp:Repeater ID="rptProjects" runat="server">
        <ItemTemplate>
            <div class="project-card">
                <h3><%# Eval("ProjectName") %></h3>
                <p><%# Eval("ProjectDescription") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
