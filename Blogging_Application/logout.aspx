<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="Blogging_Application.logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logout</title>
    <style type="text/css">
        body {
            font-family: 'Bahnschrift', Arial, sans-serif;
            background-color: #f7f7f7;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .main-content {
            max-width: 600px;
            margin: 40px auto;
            background-color: #ffffff;
            padding: 20px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            text-align: center;
        }

        .main-content h2 {
            font-size: 24px;
            color: #333;
        }

        .logout-message {
            margin-bottom: 20px;
            font-size: 18px;
            color: #555;
        }

        .link-button {
            display: inline-block;
            background-color: #0066FF;
            color: #ffffff;
            padding: 10px 20px;
            border-radius: 5px;
            text-decoration: none;
            font-family: 'Bahnschrift', Arial, sans-serif;
            font-size: 16px;
            font-weight: bold;
        }

        .link-button:hover {
            background-color: #0056e0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-content">
            <h2>Logout</h2>
            <div class="logout-message">
                <asp:Label ID="lblMessage" runat="server" Text="You have been successfully logged out."></asp:Label>
            </div>
            <div>
                <asp:LinkButton ID="linkbtnLogOut" runat="server" CssClass="link-button" OnClick="LinkbtnLogout_Click">
                    Click here to login again...
                </asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
