<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createBlog.aspx.cs" Inherits="Blogging_Application.createBlog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            font-family: 'Bahnschrift', Arial, sans-serif;
            background-color: #f7f7f7;
            margin: 0;
            padding: 0;
        }

        .header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            background-color: #0066FF;
            padding: 10px 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            color: #fff;
        }

            .header .logo {
                font-size: 24px;
                font-weight: bold;
                flex: 1;
            }

            .header a {
                color: #ffffff;
                text-decoration: none;
                padding: 10px 15px;
                margin: 0 5px;
                border-radius: 5px;
                font-size: 16px;
            }

            .header .nav-links {
                display: flex;
                gap: 10px;
            }

        .main-content {
            max-width: 900px;
            margin: 40px auto;
            background-color: #ffffff;
            padding: 20px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        .form-container {
            margin: 0 auto;
        }

        .ddl {
            border: none;
        }

        textarea {
            height: 400px;
            background-color: #ffffce;
        }

        textarea {
            font-family: 'Bahnschrift', sans-serif;
            font-size: 16px;
            background-color: #e6e6ff;
            border: none;
            border-bottom: 1px solid #000;
            height: 28px;
            padding: 5px;
            width: 100%;
            box-sizing: border-box;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="logo">
                <asp:LinkButton ID="linkbtnhome" runat="server" OnClick="LinkbtnLogo_Click">Blogging Application</asp:LinkButton>
            </div>
            <div class="nav-links">
                <asp:LinkButton ID="linkbtnFeed" runat="server" OnClick="LinkbtnFeed_Click">Feed</asp:LinkButton>
                <asp:LinkButton ID="linkbtnMyBlogs" runat="server" OnClick="LinkbtnMyBlogs_Click">My Blogs</asp:LinkButton>
                <asp:LinkButton ID="linkbtnAddNew" runat="server" OnClick="linkbtnAddNew_Click">Write</asp:LinkButton>
                <asp:LinkButton ID="linkbtnLogOut1" runat="server" OnClick="LinkbtnLogout_Click">Log Out</asp:LinkButton>
            </div>
        </div>

        <div class="main-content">
                <div class="form-container">
                    <div class="form-group">
                        <asp:Label ID="titleLabel" runat="server" Text="Title:" Font-Bold="True" Font-Name="Bahnschrift" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                        <asp:TextBox ID="titleText" runat="server" Font-Name="Bahnschrift" Height="28px" BackColor="#E6E6FF" BorderStyle="None" AutoPostBack="False" Width="100%" />
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="titleText" ErrorMessage="Title is required." ForeColor="Red" />
                        &nbsp;</div>
                    <div class="form-group">
                        <asp:Label ID="authorLabel" runat="server" Text="Author:" Font-Bold="True" Font-Name="Bahnschrift" />
                        &nbsp;&nbsp;
                       
                        <asp:TextBox ID="authorText" runat="server" Font-Name="Bahnschrift" Height="28px" BackColor="#E6E6FF" BorderStyle="None" AutoPostBack="false" Width="100%" />
                        <asp:RequiredFieldValidator ID="rfvAuthor" runat="server" ControlToValidate="authorText" ErrorMessage="Author is required." ForeColor="Red" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="dateLabel" runat="server" Text="Date:" Font-Bold="True" Font-Name="Bahnschrift" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                        <asp:TextBox ID="dateText" runat="server" Font-Name="Bahnschrift" Height="28" BackColor="#E6E6FF" BorderStyle="None" AutoPostBack="false" Width="100%" />
                        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="dateText" ErrorMessage="Date is required." ForeColor="Red" />
                        <asp:RegularExpressionValidator ID="revDate" runat="server" ControlToValidate="dateText" ErrorMessage="Enter a valid date (MM/dd/yyyy) HH:MM:SS [AM/PM]" ValidationExpression="^\d{2}-\d{2}-\d{4} \d{2}:\d{2}:\d{2} (AM|PM)$" ForeColor="Red" />
                        <br />
                        <br />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="contentLabel" runat="server" Text="Content:" Font-Bold="True" Font-Name="Bahnschrift" />
                        <asp:TextBox ID="blogContent" runat="server" Font-Name="Bahnschrift" TextMode="MultiLine" Height="303px" Width="100%" BackColor="#FFFFCE" BorderStyle="None" AutoPostBack="false" />
                        <asp:RequiredFieldValidator ID="rfvContent" runat="server" ControlToValidate="blogContent" ErrorMessage="Content is required." ForeColor="Red" />
                    </div>
                    <br />
                    <asp:Button ID="btnCreateBlog" runat="server" Text="Create one!" OnClick="btnCreateBlog_Click" BackColor="#0066FF" Font-Bold="True" Font-Names="bahnschrift, small" ForeColor="White" BorderStyle="None" Height="33px" UseSubmitBehavior="False" Width="135px" />
                </div>
                <asp:PlaceHolder ID="BlogPlaceHolder3" runat="server"></asp:PlaceHolder>
            </div>
    </form>
</body>
</html>
