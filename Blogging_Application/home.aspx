<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Blogging_Application.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blog Details</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style8 {
            height: 42px;
            font-size: 22px;
        }
        .form-table {
            width: 100%;
            margin-top: 20px;
        }
        .form-table td {
            padding: 10px;
        }
        .form-table input[type="text"] {
            width: 300px;
            padding: 5px;
        }
        .auto-style10 {
            width: 48px;
            height: 24px;
        }
        .auto-style12 {
            height: 24px;
        }
        .auto-style13 {
            height: 24px;
            width: 492px;
        }
        .auto-style15 {
            height: 24px;
            width: 256px;
        }
        .auto-style17 {
            width: 45px;
            height: 24px;
        }
        .custom-style1 {
            font-family: Bahnschrift;
        }
        .auto-style18 {
            margin-left: 0px;
        }
    </style>
</head>
<body class="custom-style1">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style8">
                    <asp:LinkButton ID="linkbtnhome" runat="server" BackColor="#CCCCFF" BorderStyle="None" Font-Bold="True" Font-Italic="False" Font-Names="Bahnschrift" Font-Size="Medium" Font-Underline="False" ForeColor="#0066FF" Height="38px" OnClick="LinkbtnLogo_Click" OnClientClick="on" Width="705px">Blogging Application</asp:LinkButton>
                    <asp:LinkButton ID="linkbtnFeed" runat="server" BackColor="#DDDDFF" BorderStyle="None" Font-Bold="False" Font-Italic="False" Font-Names="Bahnschrift" Font-Size="Small" Font-Underline="False" ForeColor="Blue" Height="38px" OnClientClick="on" OnClick="LinkbtnFeed_Click" Width="133px" CssClass="auto-style18">Feed</asp:LinkButton>
                    <asp:LinkButton ID="linkbtnMyBlogs" runat="server" BackColor="#DDDDFF" BorderStyle="None" Font-Bold="False" Font-Italic="False" Font-Names="Bahnschrift" Font-Size="Small" Font-Underline="False" ForeColor="Blue" Height="38px" OnClientClick="on" OnClick="LinkbtnMyBlogs_Click" Width="133px">My blogs</asp:LinkButton>
                    <asp:LinkButton ID="linkbtnLogOut" runat="server" BackColor="#DDDDFF" BorderStyle="None" Font-Bold="False" Font-Italic="False" Font-Names="Bahnschrift" Font-Size="Small" Font-Underline="False" ForeColor="Blue" Height="38px" OnClientClick="on" OnClick="LinkbtnLogout_Click" Width="133px">Log out</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>

        <!-- Blog Details Form -->
    <table class="auto-style1">
        <tr>
            <td>
        <asp:PlaceHolder ID="BlogPlaceHolder" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
    </table>
        <p>
            &nbsp;</p>
    </form>
    </body>
</html>
