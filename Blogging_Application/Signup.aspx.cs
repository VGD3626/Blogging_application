using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blogging_Application
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Validate passwords match
            if (password != confirmPassword)
            {
                // Handle password mismatch
                Response.Write("<script>alert('Passwords do not match.');</script>");
                return;
            }

            // Check if user already exists
            if (UserExists(username, email))
            {
                // Handle user already exists
                Response.Write("<script>alert('Username or email already exists.');</script>");
                return;
            }

            // Hash the password
            string hashedPassword = HashPassword(password);

            // Insert the user into the database
            bool isRegistered = RegisterUser(username, email, hashedPassword);

            if (isRegistered)
            {
                // Redirect to a confirmation page or login page
                Response.Write("<script>alert('Registration successful!');</script>");
                Response.Redirect("Login.aspx"); // Or another page
            }
            else
            {
                // Handle registration failure
                Response.Write("<script>alert('Registration failed.');</script>");
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

        private bool RegisterUser(string username, string email, string passwordHash)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = "INSERT INTO [User] (username,password,email) VALUES (@Username, @PasswordHash, @Email)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log or handle exception
                        Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                        return false;
                    }
                }
            }
        }

        private bool UserExists(string username, string email)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string query = "SELECT COUNT(*) FROM [User] WHERE username = @Username OR email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        connection.Open();
                        int userCount = (int)command.ExecuteScalar();
                        return userCount > 0;
                    }
                    catch (Exception ex)
                    {
                        // Log or handle exception
                        Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                        return false;
                    }
                }
            }
        }

        protected void btnLoginRedirect_Click(object sender, EventArgs e)
        {
            // Redirect to the login page
            Response.Redirect("Login.aspx");
        }
    }
}