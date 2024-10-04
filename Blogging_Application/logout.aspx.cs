using System;

namespace Blogging_Application
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            lblMessage.Text = "You have successfully logged out. Thank you for visiting!";
        }

        protected void LinkbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }

        protected void LinkbtnMyBlogs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/myBlogs.aspx");
        }

        protected void LinkbtnLogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/logout.aspx");
        }

    }
}
