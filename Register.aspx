<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

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
            height: 241px;
        }
        .auto-style3 {
            width: 108px;
        }
        .auto-style4 {
            width: 198px;
        }
        .auto-style5 {
            width: 108px;
            height: 42px;
        }
        .auto-style6 {
            width: 198px;
            height: 42px;
        }
        .auto-style7 {
            height: 42px;
        }
        .auto-style8 {
            text-decoration: underline;
            font-size: xx-large;
            color: #0000FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
        <div class="auto-style8">
            <strong>REGISTRATION PAGE </strong>
        </div>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="173px" ImageUrl="~/4c5bbd1c80a73534fe47905fe2cee250.jpg" Width="244px" />
        </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Text="Email:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtEmail" runat="server" Width="212px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter a Valid Email !" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblName" runat="server" Font-Bold="True" Text="Name :"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtName" runat="server" Width="210px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="Enter Name!" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblSurname" runat="server" Font-Bold="True" Text="Surname :"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtSurname" runat="server" Width="211px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSurname" ErrorMessage="Enter Surname!" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblSecurityQ" runat="server" Font-Bold="True" Text="Security Question:"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DropDownList1SQ" runat="server" Height="16px" Width="222px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Your Pet&#39;s Name?</asp:ListItem>
                        <asp:ListItem>Your Favorite Singer?</asp:ListItem>
                        <asp:ListItem>Favorite Color?</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style7">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList1SQ" ErrorMessage="Select a Question!!" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblSecurityA" runat="server" Font-Bold="True" Text="Security Answer:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtSecurityA" runat="server" Width="212px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Security Answer!!" Font-Bold="True" ForeColor="Red" ControlToValidate="txtSecurityA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblPassword" runat="server" Font-Bold="True" Text="Password :"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtPassword" runat="server" Width="212px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter a Password!" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Confirm Password :"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtCPassword" runat="server" Width="214px"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtCPassword" ControlToValidate="txtPassword" ErrorMessage="Passwords do not Match!" Font-Bold="True" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnRegister" runat="server" Font-Bold="True" Text="Register" Width="145px" OnClick="btnRegister_Click" />
        <br />
        <br />
        <asp:Label ID="lblRegistrationError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
