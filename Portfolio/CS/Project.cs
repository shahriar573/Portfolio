using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Portfolio_Website
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        public static List<Project> GetProjects(string userId = null)
        {
            List<Project> list = new List<Project>();
            string connStr = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT ProjectID,ProjectName, ProjectDescription FROM Projects";


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(userId))
                        cmd.Parameters.AddWithValue("@UserID", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Project
                            {
                                ProjectID = Convert.ToInt32(reader["ProjectID"]),
                                ProjectName = reader["ProjectName"].ToString(),
                                ProjectDescription = reader["ProjectDescription"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
