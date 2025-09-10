<%@ Page Title="Portfolio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Portfolio.aspx.cs" Inherits="Portfolio_Website.Portfolio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
    <h2>Portfolio</h2> 

    <!-- About Me Section -->
    <div class="about-me">
        <h3>About Me</h3>
        <p>
            I hail from a humble family in Bangladesh. My interests lie in Problem Solving and 
            Object-Oriented Programming. I also have a keen interest in Web Development, where I 
            explored building dynamic applications using modern frameworks that helped me bring out 
            the best in this portfolio. I value commitment in my work and often emphasize delivering 
            with dedication. At the same time, I enjoy reading about concepts like memory mapping, 
            which broaden my understanding and give me clearer insights into complex systems.
        </p>
    </div>

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
