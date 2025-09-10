<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Portfolio_Website.Pages.AdminPanel" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1>Admin Panel</h1>
        <div class="admin-nav-buttons">
            <a href="Home.aspx" class="home-btn">Home</a>
            <a href="AdminPanel.aspx" class="adminhome-btn">AdminHome</a>
        </div>
    </header>

    <main>
        <section id="manage-skills">
            <h2>Manage Skills</h2>
            <form id="skills-form">
                <input type="text" id="skill-name" placeholder="Skill Name">
                <button type="button" onclick="addSkill()">Add Skill</button>
            </form>
            <ul id="skills-list">
                <!-- Skills will be dynamically loaded here -->
            </ul>
        </section>

        <section id="manage-projects">
            <h2>Manage Projects</h2>
            <form id="projects-form">
                <input type="text" id="project-title" placeholder="Project Title">
                <input type="text" id="project-description" placeholder="Project Description">
                <button type="button" onclick="addProject()">Add Project</button>
            </form>
            <ul id="projects-list">
                <!-- Projects will be dynamically loaded here -->
            </ul>
        </section>
    </main>

    <script src="../Assets/Scripts/admin.js"></script>
</asp:Content>
