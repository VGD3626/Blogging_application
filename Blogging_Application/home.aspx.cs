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
                connection.Open();
                adapter.Fill(ds, "Blog");

                foreach (DataRow r in ds.Tables["Blog"].Rows)
                {

                    Label authorLabel = new Label();
                    TextBox authorText = new TextBox();
                    Label titleLabel = new Label();
                    TextBox titleText = new TextBox();  
                    Label dateLabel = new Label();
                    TextBox dateText = new TextBox();
                    TextBox blogContent = new TextBox();

                    titleLabel.Text = "Title:";
                    titleLabel.Height = 28;
                    titleText.Text = r["title"].ToString();
                    titleText.Height = 28;
                    titleText.BackColor = System.Drawing.Color.FromArgb(230, 230, 255);
                    titleText.BorderStyle = BorderStyle.None;
                    titleText.Enabled = false;

                    authorLabel.Text = "Author:";
                    authorLabel.Height = 28;
                    authorText.Text = r["author"].ToString();
                    authorText.Height = 28;
                    authorText.BackColor = System.Drawing.Color.FromArgb(230, 230, 255);
                    authorText.BorderStyle = BorderStyle.None;
                    authorText.Enabled = false;

                    dateLabel.Text = "Date:";
                    dateLabel.Height = 28;
                    dateText.Text = r["date"].ToString();
                    dateText.Height = 28;
                    dateText.BackColor = System.Drawing.Color.FromArgb(230, 230, 255);
                    dateText.BorderStyle = BorderStyle.None;
                    dateText.Enabled = false;

                    blogContent.TextMode = TextBoxMode.MultiLine;
                    blogContent.Height = 283;
                    blogContent.Width = 1069;
                    blogContent.Text = r["content"].ToString();
                    blogContent.BackColor = System.Drawing.Color.FromArgb(255, 255, 206);
                    blogContent.BorderStyle = BorderStyle.None;
                    blogContent.Enabled = false;

                    PlaceHolder placeHolder = new PlaceHolder();
                    placeHolder.Controls.Add(titleLabel);
                    placeHolder.Controls.Add(titleText);
                    placeHolder.Controls.Add(authorLabel);
                    placeHolder.Controls.Add(authorText);
                    placeHolder.Controls.Add(dateLabel);
                    placeHolder.Controls.Add(dateText);
                    placeHolder.Controls.Add(new Literal { Text = "<br/>" });
                    placeHolder.Controls.Add(blogContent);
                    placeHolder.Controls.Add(new Literal { Text = "<br/><br/><br/>" });

                    BlogPlaceHolder.Controls.Add(placeHolder);
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
            Response.Write("<h1>Hey</h1>");
        }

        protected void LinkbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Write("<h1>Hey</h1>");
        }

        protected void LinkbtnMyBlogs_Click(object sender, EventArgs e)
        {
            Response.Write("<h1>Hey</h1>");
        }

        protected void LinkbtnLogo_Click(object sender, EventArgs e)
        {
            Response.Write("<h1>Hey</h1>");
        }
    }
}
