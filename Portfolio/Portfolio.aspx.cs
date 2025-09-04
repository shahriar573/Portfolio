using Portfolio_Website;
using System;
using System.Web.UI;

namespace Portfolio_Website
{
    public partial class Portfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProjects();
                BindSkills();
                BindLeadershipQualities();
            }

        }

        private void BindProjects()
        {
           
            rptProjects.DataSource = Project.GetProjects();
            rptProjects.DataBind();
        }

        private void BindSkills()
        {
            string[] skills = { "C#", "ASP.NET", "JavaScript", "HTML/CSS", "SQL" };
            rptSkills.DataSource = skills;
            rptSkills.DataBind();
        }

        private void BindLeadershipQualities()
        {
            string[] qualities = { "Teamwork", "Communication", "Problem Solving", "Conflict Resolution", "Time Management" };
            rptLeadership.DataSource = qualities;
            rptLeadership.DataBind();
        }
    }
}
