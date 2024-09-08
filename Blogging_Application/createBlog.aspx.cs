using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blogging_Application
{
    public partial class createBlog : Page
    {
        private SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private SqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            titleText.Text = "Enter the title here...";
            blogContent.Text = "Write your thoughts...";
            authorText.Text = Session["Username"].ToString();
            authorText.Enabled = false;
            dateText.Text = DateTime.Now.ToString();
            dateText.Enabled = false;
        }

        protected void btnCreateBlog_Click(object sender, EventArgs e)
        {
            command = new SqlCommand("SELECT COUNT(*) FROM Blog WHERE Title = @Title", connection);
            command.Parameters.AddWithValue("@Title", titleText.Text);
            connection.Open();
            int c = (int)command.ExecuteScalar();
            connection.Close();

            if (c > 0)
            {
                Label errorLabel = new Label
                {
                    Text = "Error: A blog with this title already exists. Please choose a different title.",
                    ForeColor = System.Drawing.Color.Red
                };
                titleText.Text = "Enter the title here...";
                BlogPlaceHolder3.Controls.Add(errorLabel);
            }
            else
            {
                BlogPlaceHolder3.Controls.Clear();
                command = new SqlCommand("INSERT INTO Blog (title, author, date, content) VALUES (@Title, @Author, @Date, @Content)", connection);
                command.Parameters.AddWithValue("@Title", titleText.Text);
                command.Parameters.AddWithValue("@Author", Session["Username"]);
                command.Parameters.AddWithValue("@Date", dateText.Text);
                command.Parameters.AddWithValue("@Content", blogContent.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                titleText.Text = "Enter the title here...";
                blogContent.Text = "Write your thoughts...";
                authorText.Text = Session["Username"].ToString();
                dateText.Text = DateTime.Now.Date.ToString();
            }
        }

        protected void LinkbtnFeed_Click(object sender, EventArgs e)
        {
            titleText.Text = "Enter the title here...";
            blogContent.Text = "Write your thoughts...";
            Response.Redirect("~/home.aspx");
        }

        protected void LinkbtnLogout_Click(object sender, EventArgs e)
        {
            titleText.Text = "Enter the title here...";
            blogContent.Text = "Write your thoughts...";
            Response.Redirect("~/logout.aspx");
        }

        protected void LinkbtnMyBlogs_Click(object sender, EventArgs e)
        {
            titleText.Text = "Enter the title here...";
            blogContent.Text = "Write your thoughts...";
            Response.Redirect("~/myBlogs.aspx");
        }

        protected void LinkbtnLogo_Click(object sender, EventArgs e)
        {
            titleText.Text = "Enter the title here...";
            blogContent.Text = "Write your thoughts...";
            Response.Redirect("~/home.aspx");
        }

        protected void linkbtnAddNew_Click(object sender, EventArgs e)
        {
            titleText.Text = "Enter the title here...";
            blogContent.Text = "Write your thoughts...";
            Response.Redirect("~/createBlog.aspx");
        }

        protected void blogContent_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
