using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blogging_Application
{
    public partial class home : System.Web.UI.Page
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBlogData();
            }
        }

        private void LoadBlogData()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
            connection = new SqlConnection(connStr);
            command = new SqlCommand("SELECT * FROM Blog", connection);
            adapter = new SqlDataAdapter(command);
            ds = new DataSet();

            try
            {
                if (Session["Username"]!=null) 
                { 
                LblLetsExplore.Text = "Explore...";
                connection.Open();
                adapter.Fill(ds, "Blog");

                foreach (DataRow r in ds.Tables["Blog"].Rows)
                {

                    Label titleLabel = new Label();
                    TextBox titleText = new TextBox();
                    titleLabel.Text = "Title:";
                    titleLabel.Font.Name = "Bahnschrift";
                    titleLabel.Font.Bold = true;
                    titleLabel.Height = 28;
                    titleText.Text = r["title"].ToString();
                    titleText.Font.Name = "Bahnschrift";
                    titleText.Height = 28;
                    titleText.BackColor = System.Drawing.Color.FromArgb(230, 230, 255);
                    titleText.BorderStyle = BorderStyle.None;
                    titleText.Enabled = false;

                    // Author
                    Label authorLabel = new Label();
                    TextBox authorText = new TextBox();
                    authorLabel.Text = "Author:";
                    authorLabel.Font.Name = "Bahnschrift";
                    authorLabel.Height = 28;
                    authorText.Text = r["author"].ToString();
                    authorText.Font.Name = "Bahnschrift";
                    authorText.Height = 28;
                    authorText.BackColor = System.Drawing.Color.FromArgb(230, 230, 255);
                    authorText.BorderStyle = BorderStyle.None;
                    authorText.Enabled = false;

                    // Date
                    Label dateLabel = new Label();
                    TextBox dateText = new TextBox();
                    dateLabel.Text = "Date:";
                    dateLabel.Font.Name = "Bahnschrift";
                    dateLabel.Height = 28;
                    dateText.Text = r["date"].ToString();
                    dateText.Font.Name = "Bahnschrift";
                    dateText.Height = 28;
                    dateText.BackColor = System.Drawing.Color.FromArgb(230, 230, 255);
                    dateText.BorderStyle = BorderStyle.None;
                    dateText.Enabled = false;

                    // Blog content
                    TextBox blogContent = new TextBox();
                    blogContent.TextMode = TextBoxMode.MultiLine;
                    blogContent.Height = 400;
                    blogContent.Width = Unit.Percentage(100);
                    blogContent.Text = r["content"].ToString();
                    blogContent.Font.Name = "Bahnschrift";
                    blogContent.BackColor = System.Drawing.Color.FromArgb(255, 255, 206);
                    blogContent.BorderStyle = BorderStyle.None;
                    blogContent.Enabled = false;

                    // Add controls to placeholder
                    PlaceHolder placeHolder = new PlaceHolder();
                    placeHolder.Controls.Add(titleLabel);
                    placeHolder.Controls.Add(titleText);
                    placeHolder.Controls.Add(authorLabel);
                    placeHolder.Controls.Add(authorText);
                    placeHolder.Controls.Add(dateLabel);
                    placeHolder.Controls.Add(dateText);
                    placeHolder.Controls.Add(new Literal { Text = "<br/>" });
                    placeHolder.Controls.Add(blogContent);
                    placeHolder.Controls.Add(new Literal { Text = "<br/><br/><hr/><br/>" });
                    if (BlogPlaceHolder != null)
                    {
                        BlogPlaceHolder.Controls.Add(placeHolder);
                    }
                }
            }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
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

        protected void linkbtnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/createBlog.aspx");
        }
    }
}
