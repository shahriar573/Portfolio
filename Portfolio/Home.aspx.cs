using System;
using System.Web.UI;

namespace Portfolio_Website
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowRoleOptions();
            }
        }

        private void ShowRoleOptions()
        {
            string role = Session["UserRole"]?.ToString();

            // Hide all first
            pnlAdminOptions.Visible = false;
            pnlMemberOptions.Visible = false;
            pnlGuestOptions.Visible = false;https://localhost:44366/Home.aspx.cs

            // Show based on role
            switch (role)
            {
                case "Admin":
                    pnlAdminOptions.Visible = true;
                    break;
                case "Member":
                    pnlMemberOptions.Visible = true;
                    break;
                default:
                    pnlGuestOptions.Visible = true;
                    break;
            }
        }
    }
}
