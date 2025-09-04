<%@ Page Title="Portfolio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Portfolio.aspx.cs" Inherits="Portfolio_Website.Portfolio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Portfolio</h2>
    <h3>My Skills & Leadership Qualities</h3>

<h4>Skills</h4>
<asp:Repeater ID="rptSkills" runat="server">
    <ItemTemplate>
        <span class="skill-tag"><%# Container.DataItem %></span>
    </ItemTemplate>
</asp:Repeater>

<h5>Team Leadership Qualities</h5>
<asp:Repeater ID="rptLeadership" runat="server">
    <ItemTemplate>
        <span class="skill-tag"><%# Container.DataItem %></span>
    </ItemTemplate>
</asp:Repeater>

    <asp:Repeater ID="rptProjects" runat="server">
        <ItemTemplate>
            <div class="project-card">
                <h3><%# Eval("ProjectName") %></h3>
                <p><%# Eval("ProjectDescription") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
