using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;

namespace Portfolio_Website
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateNavigation();
            }
        }

        private void UpdateNavigation()
        {
            string role = Session["UserRole"]?.ToString();

            if (!string.IsNullOrEmpty(role))
            {
                lblUser.Text = "Logged in as " + role;
                btnLogin.Visible = false;
                btnLogout.Visible = true;

                navAdmin.Visible = role == "Admin";
                navMember.Visible = role == "Admin" || role == "Member";
                navGuest.Visible = false;
            }
            else
            {
                lblUser.Text = "Guest";
                btnLogin.Visible = true;
                btnLogout.Visible = false;

                navAdmin.Visible = false;
                navMember.Visible = false;
                navGuest.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connStr = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT UserID, Role FROM Users WHERE Username=@Username AND Password=@Password";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["Role"].ToString();
                            string userId = reader["UserID"].ToString();

                            Session["UserRole"] = role;
                            Session["UserID"] = userId;
                            FormsAuthentication.SetAuthCookie(username, false);

                            UpdateNavigation();
                            Response.Redirect("Home.aspx");
                            return;
                        }
                    }
                }
            }

            lblMessage.Text = "Invalid username or password!";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();

            UpdateNavigation();
            Response.Redirect("Home.aspx");
        }

        public void ShowMessage(string message, string type)
        {
            lblMessage.Text = message;
            lblMessage.CssClass = "message " + type;
        }
    }
}
