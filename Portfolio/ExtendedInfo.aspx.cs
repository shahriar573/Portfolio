using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Portfolio_Website
{
    public partial class ExtendedInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var role = Session["UserRole"]?.ToString();
            if (role != "Admin")
            {
                Response.Redirect("Home.aspx"); // Only Admin can manage projects
                return;
            }

            if (!IsPostBack)
                BindProjects();
        }

        private void BindProjects()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Projects", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvProjects.DataSource = dt;
                    gvProjects.DataBind();
                }
            }
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

        protected void gvProjects_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvProjects.EditIndex = e.NewEditIndex;
            BindProjects();
        }

        protected void gvProjects_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvProjects.EditIndex = -1;
            BindProjects();
        }

        protected void gvProjects_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvProjects.DataKeys[e.RowIndex].Value);
            string name = ((System.Web.UI.WebControls.TextBox)gvProjects.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string desc = ((System.Web.UI.WebControls.TextBox)gvProjects.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

            string connStr = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE Projects SET ProjectName=@Name, [ProjectDescription]=@Desc WHERE ProjectID=@ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Desc", desc);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            gvProjects.EditIndex = -1;
            BindProjects();
        }

        protected void gvProjects_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvProjects.DataKeys[e.RowIndex].Value);

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
    }
}

