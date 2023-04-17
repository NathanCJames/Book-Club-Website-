<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfilePage.aspx.cs" Inherits="ProfilePage" %>

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
            color: #0000FF;
            text-decoration: underline;
            font-size: xx-large;
        }
        .auto-style2 {
            width: 100%;
            height: 113px;
        }
        .auto-style5 {
            width: 447px;
        }
        .auto-style6 {
            width: 132px;
        }
        .auto-style7 {
            text-decoration: underline;
        }
        .auto-style8 {
            width: 100%;
            height: 104px;
        }
        .auto-style9 {
            width: 86px;
        }
        .auto-style10 {
            height: 525px;
        }
        .auto-style12 {
            width: 485px;
        }
        .auto-style13 {
            margin-bottom: 0px;
        }
        .auto-style14 {
            margin-left: 6px;
        }
        .auto-style15 {
            margin-left: 797px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style10">
        <div class="auto-style1">
            <strong>VIEW PROFILE<asp:Button ID="btnViewBooks" runat="server" CssClass="auto-style15" Font-Bold="True" Height="34px" OnClick="btnViewBooks_Click" Text="View Books" Width="109px" />
            <asp:Button ID="btnLogOut" runat="server" CssClass="auto-style14" Font-Bold="True" ForeColor="Black" Height="36px" OnClick="btnLogOut_Click" Text="Log Out" Width="109px" CausesValidation="False" />
            <br />
            </strong>
        </div>
        <asp:Panel ID="Panel1" runat="server" Height="121px">
            <table class="auto-style2">
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="lblName" runat="server" Font-Bold="True" Text="Name:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="lblName1" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="lblSurname" runat="server" Font-Bold="True" Text="Surname:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="lblSurname1" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Text="E-Mail:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="lblEmail1" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <asp:Button ID="btnUpdateDetails" runat="server" Font-Bold="True" Height="35px" Text="Update User Details" Width="153px" OnClick="btnUpdateDetails_Click" />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style7" Font-Bold="True" ForeColor="Blue" NavigateUrl="~/ForgotPassword.aspx">Change Password?</asp:HyperLink>
        <br />
        <br />
        <asp:Panel ID="UpdatePanel" runat="server" Height="109px">
            <table class="auto-style8">
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Name:"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtName" runat="server" Width="340px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Enter Your Name!!" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Surname:"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtSurname" runat="server" Width="337px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSurname" ErrorMessage="Enter Your Surname!!" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        &nbsp;</td>
                    <td class="auto-style12">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="auto-style13" Font-Bold="True" Height="33px" OnClick="btnUpdate_Click" Text="Update" Width="157px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <br />
&nbsp;
        <br />
        <br />
        <br />
        <p>
        <asp:Label ID="lblUpdateError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </p>
    </form>
</body>
</html>
