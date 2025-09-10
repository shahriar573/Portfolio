using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio_Website
{
    public partial class ExtendedInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var role = Session["UserRole"]?.ToString();
            if (role != "Admin")
            {
                Response.Redirect("Home.aspx");
                return;
            }

            if (!IsPostBack)
                BindProjects();
        }

        private DataTable GetProjectsData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT ProjectID, ProjectName, ProjectDescription FROM Projects", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.Columns.Add("IsEditing", typeof(bool));
                    foreach (DataRow row in dt.Rows) row["IsEditing"] = false;
                    return dt;
                }
            }
        }

        private void BindProjects()
        {
            rptProjects.DataSource = GetProjectsData();
            rptProjects.DataBind();
        }

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            string name = txtProjectName.Text.Trim();
            string desc = txtDescription.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;

            string connStr = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "INSERT INTO Projects(ProjectName, ProjectDescription) VALUES(@Name, @Desc)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Desc", desc);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            txtProjectName.Text = txtDescription.Text = "";
            BindProjects();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((System.Web.UI.WebControls.Button)sender).CommandArgument);
            string connStr = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "DELETE FROM Projects WHERE ProjectID=@ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            BindProjects();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((System.Web.UI.WebControls.Button)sender).CommandArgument);
            DataTable dt = GetProjectsData();
            foreach (DataRow row in dt.Rows) row["IsEditing"] = (int)row["ProjectID"] == id;
            rptProjects.DataSource = dt;
            rptProjects.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);
            var item = (RepeaterItem)btn.NamingContainer;
            string name = ((System.Web.UI.WebControls.TextBox)item.FindControl("txtEditName")).Text;
            string desc = ((System.Web.UI.WebControls.TextBox)item.FindControl("txtEditDesc")).Text;

            string connStr = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE Projects SET ProjectName=@Name, ProjectDescription=@Desc WHERE ProjectID=@ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Desc", desc);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            BindProjects();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BindProjects();
        }
    }
}
