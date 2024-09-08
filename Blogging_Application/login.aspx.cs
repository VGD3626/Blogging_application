using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace blog
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (ValidateUser(username, password))
            {
                Session["Username"] = username;

               
                Response.Redirect("~/home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid username or password.');</script>");
            }
        }

        private bool ValidateUser(string username, string password)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = "SELECT password FROM [User] WHERE username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string storedHash = result.ToString();
                            string passwordHash = HashPassword(password);
                            return storedHash == passwordHash;
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                        return false;
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        protected void btnRegisterRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Signup.aspx");
        }

    }
}
