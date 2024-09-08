<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myBlogs.aspx.cs" Inherits="Blogging_Application.myBlogs" %>

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

        form-group {
            margin-bottom: 15px;
        }

        label {
            font-weight: bold;
            font-size: 18px;
            display: inline-block;
            margin-bottom: 8px;
        }

        input[type="text"], textarea {
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

        textarea {
            height: 400px;
            background-color: #ffffce;
        }

        .form-container {
            margin: 0 auto;
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

        .ddl {
            border: none;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="header">
            <div class="logo">
                <asp:LinkButton ID="linkbtnhome1" runat="server" OnClick="LinkbtnLogo_Click">Blogging Application</asp:LinkButton>
            </div>
            <div class="nav-links">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkbtnLogo_Click" CausesValidation="false">
    Blogging Application
                </asp:LinkButton>

                <asp:LinkButton ID="linkbtnFeed1" runat="server" OnClick="LinkbtnFeed_Click" CausesValidation="false">
    Feed
                </asp:LinkButton>

                <asp:LinkButton ID="linkbtnMyBlogs1" runat="server" OnClick="LinkbtnMyBlogs_Click" CausesValidation="false">
    My Blogs
                </asp:LinkButton>

                <asp:LinkButton ID="linkbtnAddNew" runat="server" OnClick="linkbtnAddNew_Click" CausesValidation="false">
    Write
                </asp:LinkButton>

                <asp:LinkButton ID="linkbtnLogOut1" runat="server" OnClick="LinkbtnLogout_Click" CausesValidation="false">
    Log Out
                </asp:LinkButton>
            </div>
        </div>

        <div class="main-content">
            <div>
                <div class="form-container">
                    <div class="form-group">
                        <asp:Label ID="titleLabel" runat="server" Text="Title:" Font-Bold="True" Font-Name="Bahnschrift" />
                        <br />
                        <asp:DropDownList ID="DdlChooseTitle" CssClass="ddl" runat="server" AutoPostBack="True" BackColor="#E6E6FF" Height="61px" Width="100%" OnSelectedIndexChanged="fetchBlogData">
                            <asp:ListItem Value="0">Please select or add title</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="authorLabel" runat="server" Text="Author:" Font-Bold="True" Font-Name="Bahnschrift" />
                        <asp:TextBox ID="authorText" runat="server" Text="author" Font-Name="Bahnschrift" Height="28" BackColor="#E6E6FF" BorderStyle="None" AutoPostBack="false" />
                    </div>

                    <div class="form-group">
                        <asp:Label ID="dateLabel" runat="server" Text="Date:" Font-Bold="True" Font-Name="Bahnschrift" />
                        <asp:TextBox ID="dateText" runat="server" Text="date" Font-Name="Bahnschrift" Height="28" BackColor="#E6E6FF" BorderStyle="None" AutoPostBack="false" />
                    </div>

                    <div class="form-group">
                        <asp:Label ID="contentLabel" runat="server" Text="Content:" Font-Bold="True" Font-Name="Bahnschrift" />
                        <asp:TextBox ID="blogContent" runat="server" Text="content" Font-Name="Bahnschrift" TextMode="MultiLine" Height="400px" Width="100%" BackColor="#FFFFCE" BorderStyle="None" AutoPostBack="false" />
                    </div>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUpdateBlog" runat="server" Text="Update" OnClick="UpdateBlog_Click" BackColor="#FF6600" Font-Bold="True" Font-Names="bahnschrift, small" ForeColor="White" BorderStyle="None" Height="33px" UseSubmitBehavior="False" Width="135px" />
            <asp:Button ID="btnDeleteBlog" runat="server" Text="Delete" OnClick="DeleteBlog_Click" BackColor="Red" Font-Bold="True" Font-Names="bahnschrift, small" ForeColor="White" BorderStyle="None" Height="33px" UseSubmitBehavior="False" Width="135px" />
            &nbsp;<div>
                <br />
                <br />
                <asp:Label ID="LblYourBlogs" runat="server" Text="n,mn" Font-Bold="True" Font-Size="XX-Large" ForeColor="#3399FF"></asp:Label>
                <br />
                <asp:PlaceHolder ID="BlogPlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>
    </form>
</body>
</html>
