<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Blogging_Application.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blog Details</title>
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

        .header a {
            color: #ffffff;
            text-decoration: none;
            padding: 10px 15px;
            margin: 0 5px;
            border-radius: 5px;
            font-size: 16px;
        }

        .header a:hover {
            background-color: #0052cc;
        }

        .header .logo {
            font-size: 24px;
            font-weight: bold;
            flex: 1;
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

        .form-table {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }

        .form-table td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }

        .form-table input[type="text"] {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
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
            <!-- Blog Details Form -->
            <asp:Label ID="LblLetsExplore" runat="server" Text="----" Font-Bold="True" Font-Size="XX-Large" ForeColor="#3399FF"></asp:Label>
            <br />
            <br/>
            <asp:PlaceHolder ID="BlogPlaceHolder" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
