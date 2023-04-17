<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddBook.aspx.cs" Inherits="AddBook" %>

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
        }
        .auto-style2 {
            width: 152px;
        }
        .auto-style3 {
            font-size: large;
        }
        .auto-style4 {
            color: #000000;
        }
        .auto-style5 {
            text-decoration: underline;
        }
        .auto-style6 {
            width: 271px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong><span class="auto-style5">ADD BOOK</span><br />
            <span class="auto-style4">
            <br />
            <span class="auto-style3">Add Book to Website</span></span></strong></div>
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Name:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtName" runat="server" Width="256px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Author:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtAuthor" runat="server" Width="255px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Genre:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="DropDownList1Genre" runat="server" Height="16px" Width="265px">
                    <asp:ListItem>Fantasy</asp:ListItem>
                    <asp:ListItem>Fiction</asp:ListItem>
                    <asp:ListItem>Drama</asp:ListItem>
                    <asp:ListItem>Comedy</asp:ListItem>
                    <asp:ListItem>Poetry</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6">
                <asp:Button ID="btnAddBook" runat="server" Font-Bold="True" OnClick="btnAddBook_Click" Text="Add Book" Width="170px" />
            </td>
            <td>
                <asp:Label ID="lblAddBookError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
        <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    </form>
    </body>
</html>
