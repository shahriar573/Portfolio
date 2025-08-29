using Portfolio_Website;
using System;
using System.Web.UI;

namespace Portfolio_Website
{
    public partial class Portfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindProjects();
        }

        private void BindProjects()
        {
            rptProjects.DataSource = Project.GetProjects();
            rptProjects.DataBind();
        }
    }
}
