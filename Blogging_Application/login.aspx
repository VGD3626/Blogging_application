<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="blog.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body {
            font-family: Bahnschrift, Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .btn-login {
            background-color:#CCCCFF;
        }

        .btn-register {
            background-color:#DDDDFF;
        }

        .login-container {
            background: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 300px;
            max-width: 90%;
            text-align: center;
        }

        .login-container h2 {
            margin-bottom: 20px;
            color: #333;
        }

        .login-container label {
            display: block;
            margin-bottom: 8px;
            color: #666;
            text-align: left;
        }

        .login-container input[type="text"],
        .login-container input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .login-container input[type="submit"],
        .login-container input[type="button"] {
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            color: #fff;
            background-color: #007bff;
            cursor: pointer;
            font-size: 16px;
            margin: 5px;
        }

        .login-container input[type="submit"]:hover,
        .login-container input[type="button"]:hover {
            background-color: #0056b3;
        }

        .login-container input[type="button"].btn-secondary {
            background-color: #6c757d;
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }

        .login-container input[type="button"].btn-secondary:hover {
            background-color: #5a6268;
        }

        .error {
            color: #dc3545;
            font-size: 14px;
            margin-bottom: 15px;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 332px;
        }
        .auto-style3 {
            height: 28px;
        }
        .auto-style4 {
            width: 332px;
            height: 28px;
        }
    </style>
</head>
<body>
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2">
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>

            <asp:Label ID="lblUsername" runat="server" Text="Username:" AssociatedControlID="txtUsername"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                ErrorMessage="Username is required" CssClass="error"></asp:RequiredFieldValidator>

            <asp:Label ID="lblPassword" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="Password is required" CssClass="error"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
            <br />

            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" BackColor="#0066FF" Font-Bold="True" Font-Names="bahnschrift, small" ForeColor="White" />
            <asp:Button ID="btnRegisterRedirect" runat="server" Text="Register" OnClientClick="btnRegisterRedirect_Click" BackColor="#0066FF" Font-Bold="True" Font-Names="Bahnschrift" ForeColor="White" />

        </div>
    </form>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style4"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</body>
</html>
