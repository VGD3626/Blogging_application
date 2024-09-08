using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Contexts;

namespace Blogging_Application
{
    public partial class myBlogs : System.Web.UI.Page
    {
        private SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private SqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["Username"]==null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                FillDdlChooseTitle();
                LoadBlogData();
            }
        }

        protected void FillDdlChooseTitle()
        {
            command = new SqlCommand("SELECT title FROM Blog WHERE author = @Username", connection);
            command.Parameters.AddWithValue("@Username", Session["Username"].ToString());

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                DdlChooseTitle.Items.Clear();
                DdlChooseTitle.Items.Add(new ListItem("Please select or add title", "0"));
                while (reader.Read())
                {
                    DdlChooseTitle.Items.Add(new ListItem(reader["title"].ToString(), reader["title"].ToString()));
                }

            }
            catch { 
            
            }
            finally
            {
                connection.Close();
            }

        }

        private void LoadBlogData()
        {
            command = new SqlCommand("SELECT * FROM Blog WHERE author = @Username", connection);
            command.Parameters.AddWithValue("@Username", Session["Username"]);

            try
            {
                if (Session["Username"] != null)
                {
                    
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        LblYourBlogs.Text = $"No Blogs, try creating one...";
                    }
                    else
                    {
                        LblYourBlogs.Text = $"Hey {Session["Username"]}, here are your Blogs...";
                    }
                    while (reader.Read())
                    {

                        Label titleLabel = new Label { Text = "Title:", Font = { Name = "Bahnschrift", Bold = true }, Height = 28 };
                        TextBox titleText = new TextBox { Text = reader["title"].ToString(), Font = { Name = "Bahnschrift" }, Height = 28, BackColor = System.Drawing.Color.FromArgb(230, 230, 255), BorderStyle = BorderStyle.None, Enabled=false };

                        Label authorLabel = new Label { Text = "Author:", Font = { Name = "Bahnschrift" }, Height = 28 };
                        TextBox authorText = new TextBox { Text = reader["author"].ToString(), Font = { Name = "Bahnschrift" }, Height = 28, BackColor = System.Drawing.Color.FromArgb(230, 230, 255), BorderStyle = BorderStyle.None, Enabled = false };

                        Label dateLabel = new Label { Text = "Date:", Font = { Name = "Bahnschrift" }, Height = 28 };
                        TextBox dateText = new TextBox { Text = reader["date"].ToString(), Font = { Name = "Bahnschrift" }, Height = 28, BackColor = System.Drawing.Color.FromArgb(230, 230, 255), BorderStyle = BorderStyle.None, Enabled = false };

                        TextBox blogContent = new TextBox { Text = reader["content"].ToString(), Font = { Name = "Bahnschrift" }, TextMode = TextBoxMode.MultiLine, Height = 400, Width = Unit.Percentage(100), BackColor = System.Drawing.Color.FromArgb(255, 255, 206), BorderStyle = BorderStyle.None, Enabled=false};

                        PlaceHolder placeHolder = new PlaceHolder();
                        placeHolder.Controls.Add(titleLabel);
                        placeHolder.Controls.Add(titleText);
                        placeHolder.Controls.Add(authorLabel);
                        placeHolder.Controls.Add(authorText);
                        placeHolder.Controls.Add(dateLabel);
                        placeHolder.Controls.Add(dateText);
                        placeHolder.Controls.Add(new Literal { Text = "<br/>" });
                        placeHolder.Controls.Add(blogContent);
                        placeHolder.Controls.Add(new Literal { Text = "<br/>" });
                        placeHolder.Controls.Add(new Literal { Text = "&nbsp;" });
                        placeHolder.Controls.Add(new Literal { Text = "<br/><br/><hr/><br/>" });


                        BlogPlaceHolder1.Controls.Add(placeHolder);
                    }
                    reader.Close();
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
            finally
            {
                connection.Close();
            }
        }


        protected void UpdateBlog_Click(object sender, EventArgs e)
        {
            string selectedTitle = DdlChooseTitle.SelectedValue;
            if (!string.IsNullOrEmpty(selectedTitle))
            {
                command = new SqlCommand("UPDATE Blog SET content = @Content, date = @Date WHERE title = @Title AND author = @Author", connection);
                command.Parameters.AddWithValue("@Content", blogContent.Text);
                command.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Title", selectedTitle);
                command.Parameters.AddWithValue("@Author", Session["Username"]);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }            
            LoadBlogData();
        }

        protected void DeleteBlog_Click(object sender, EventArgs e)
        {
            string selectedTitle = DdlChooseTitle.SelectedValue;
            if (!string.IsNullOrEmpty(selectedTitle))
            {
                command = new SqlCommand("DELETE FROM Blog WHERE title = @Title AND author = @Author", connection);
                command.Parameters.AddWithValue("@Title", selectedTitle);
                command.Parameters.AddWithValue("@Author", Session["Username"]);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                blogContent.Text = "";
                authorText.Text = "";
                dateText.Text = "";
            }
            FillDdlChooseTitle();
        }


        protected void LinkbtnFeed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }

        protected void LinkbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/logout.aspx");
        }

        protected void LinkbtnMyBlogs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/myBlogs.aspx");
        }

        protected void LinkbtnLogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }

       
        protected void fetchBlogData(object sender, EventArgs e)
        {
            LblYourBlogs.Text = "";
            string selectedTitle = DdlChooseTitle.SelectedValue;
            if (!string.IsNullOrEmpty(selectedTitle) && DdlChooseTitle.SelectedValue != "0")
            {
                command = new SqlCommand("SELECT content, date FROM Blog WHERE title = @Title AND author = @Author", connection);
                command.Parameters.AddWithValue("@Title", selectedTitle);
                command.Parameters.AddWithValue("@Author", Session["Username"]);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    blogContent.Text = reader["content"].ToString();
                    dateText.Text = reader["date"].ToString();
                }
                reader.Close();
                connection.Close();
            }
            else if (DdlChooseTitle.SelectedValue == "0")
            {
                blogContent.Text = "";
                authorText.Text = "";
                dateText.Text = "";
            }
            LoadBlogData();
        }

        protected void linkbtnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/createBlog.aspx");
        }

    }
}
