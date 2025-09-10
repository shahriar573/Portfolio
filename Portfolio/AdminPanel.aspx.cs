using System;
using System.Web;
namespace Portfolio_Website.Pages
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check role from Session or cookie
            string role = Session["UserRole"] as string;

            if (string.IsNullOrEmpty(role))
            {
                HttpCookie roleCookie = Request.Cookies["UserRole"];
                if (roleCookie != null)
                {
                    role = roleCookie.Value;
                    Session["UserRole"] = role; // restore from cookie
                }
            }

            // If not admin, block access
            if (role != "Admin")
            {
                Response.Redirect("~/Home.aspx"); // guests or members are redirected
            }
        }
    }
}