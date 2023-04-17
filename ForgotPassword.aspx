<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

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
            text-align: left;
            font-size: xx-large;
            color: #0000FF;
            text-decoration: underline;
        }
        .auto-style2 {
            width: 100%;
            height: 93px;
        }
        .auto-style3 {
            width: 131px;
        }
        .auto-style5 {
            margin-top: 28px;
        }
        .auto-style6 {
            width: 100%;
            height: 86px;
        }
        .auto-style8 {
            width: 129px;
        }
        .auto-style10 {
            margin-top: 47px;
        }
        .auto-style11 {
            width: 100%;
            height: 110px;
        }
        .auto-style12 {
            width: 133px;
        }
        .auto-style13 {
            width: 288px;
        }
        .auto-style14 {
            width: 386px;
        }
        .auto-style15 {
            width: 353px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong>UPDATE PASSWORD</strong></div>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="207px" ImageUrl="~/4c5bbd1c80a73534fe47905fe2cee250.jpg" Width="329px" />
        <br />
        <br />
        <asp:Panel ID="EmailCheckPanel" runat="server" Height="98px">
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Enter Valid Email:"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <asp:TextBox ID="txtCheckEmail" runat="server" Width="376px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style13">
                        <asp:Button ID="btnCheckEmail" runat="server" Font-Bold="True" Text="Check Email" Width="142px" OnClick="btnCheckEmail_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style13">
                        <asp:Label ID="lblCheckEmailError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="SecurityCheckPanel" runat="server" CssClass="auto-style5" Height="97px">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Security Question:"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:Label ID="lblQuestionShow" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Security Answer:"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtSecAnswer" runat="server" Width="378px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSecAnswer" ErrorMessage="Enter Answer!!" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:Button ID="btnCheckAnswer" runat="server" Font-Bold="True" Text="Check Answer" Width="147px" OnClick="btnCheckAnswer_Click" />
                        <br />
                        <br />
                        <asp:Label ID="lblCheckAnswerError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="UpdatePasswordPanel" runat="server" CssClass="auto-style10" Height="113px">
            <table class="auto-style11">
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="lblNewPassword" runat="server" Font-Bold="True" Text="New Password:"></asp:Label>
                    </td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtNewPassword" runat="server" Width="368px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="Enter New Password!!" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="lblConfirmPassword" runat="server" Font-Bold="True" Text="Confirm Password:"></asp:Label>
                    </td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtCPassword" runat="server" Width="370px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtCPassword" ErrorMessage="Passwords do not Match!!" Font-Bold="True" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style15">
                        <asp:Button ID="btnUpdatePassword" runat="server" Font-Bold="True" Text="UpdatePassword" Width="154px" OnClick="btnUpdatePassword_Click" />
                        <br />
                        <br />
                        <asp:Label ID="lblUpdatePasswordError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
