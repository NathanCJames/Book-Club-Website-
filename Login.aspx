<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body
        {
            background-color:lightgreen;
        }
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 100%;
            height: 121px;
        }
        .auto-style3 {
            height: 38px;
        }
        .auto-style4 {
            height: 38px;
            width: 137px;
        }
        .auto-style5 {
            width: 137px;
        }
        .auto-style6 {
            height: 38px;
            width: 234px;
        }
        .auto-style7 {
            width: 234px;
        }
        .auto-style8 {
            font-size: xx-large;
            color: #0000FF;
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
        <div class="auto-style8">
            <strong>LOGIN</strong></div>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="180px" ImageUrl="~/4c5bbd1c80a73534fe47905fe2cee250.jpg" PostBackUrl="~/Login.aspx" Width="308px" OnClick="ImageButton1_Click" />
        </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblEmail" runat="server" Text="Email :" Font-Bold="True"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtEmail" runat="server" Width="243px"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter a Valid Email!!" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblPassword" runat="server" Text="Password :" Font-Bold="True"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtPassword" runat="server" Width="244px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter a Valid Password !!" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnLogin" runat="server" Font-Bold="True" OnClick="btnLogin_Click" Text="Log In" Width="123px" />
&nbsp;&nbsp;
        <asp:Label ID="lblLogInError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnRegister" runat="server" Font-Bold="True" OnClick="btnRegister_Click" Text="Register" Width="122px" CausesValidation="False" />
        <br />
        <br />
        <asp:Button ID="btnForgotPassword" runat="server" Font-Bold="True" Text="Forgot Password" Width="125px" OnClick="btnForgotPassword_Click" CausesValidation="False" />
        <br />
        <br />
    </form>
</body>
</html>
