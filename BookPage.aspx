<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookPage.aspx.cs" Inherits="BookPage" %>

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
        }
        .auto-style2 {
            font-size: xx-large;
            text-decoration: underline;
            color: #0000FF;
        }
        .auto-style3 {
            margin-left: 2px;
        }
        .auto-style4 {
            text-decoration: underline;
        }
        .auto-style5 {
            width: 100%;
            height: 97px;
        }
        .auto-style7 {
            width: 269px;
        }
        .auto-style8 {
            margin-left: 51px;
        }
        .auto-style9 {
            width: 100%;
            height: 109px;
        }
        .auto-style10 {
            margin-top: 32px;
        }
        .auto-style11 {
            width: 293px;
        }
        .auto-style12 {
            width: 292px;
        }
        .auto-style13 {
            width: 275px;
        }
        .auto-style14 {
            margin-left: 58px;
        }
        .auto-style15 {
            margin-left: 753px;
        }
    </style>
</head>
<body style="height: 834px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong><span class="auto-style2">BOOKS PAGE&nbsp;&nbsp; </span>
            <asp:Button ID="btnViewProfile" runat="server" CssClass="auto-style15" Font-Bold="True" Height="34px" OnClick="btnViewProfile_Click" Text="View Profile" Width="146px" />
            <asp:Button ID="btnLogOut" runat="server" CssClass="auto-style3" Font-Bold="True" Height="35px" Text="Log Out" Width="139px" OnClick="btnLogOut_Click" />
            </strong>
            <br />
            <asp:ImageButton ID="ImageButton1" runat="server" Height="211px" ImageUrl="~/4c5bbd1c80a73534fe47905fe2cee250.jpg" PostBackUrl="~/DescriptionPage.aspx" Width="306px" />
            <br />
            <br />
            <span class="auto-style4"><strong>Welcome to the Online Book Club Here you have the option to either Rate or Add your Own Book Enjoy... !!!</strong></span><br />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="BookID" DataSourceID="BookStoreDatabase" ForeColor="Black" Height="186px" Width="1075px">
            <Columns>
                <asp:BoundField DataField="BookID" HeaderText="BookID" InsertVisible="False" ReadOnly="True" SortExpression="BookID" />
                <asp:BoundField DataField="BookName" HeaderText="BookName" SortExpression="BookName" />
                <asp:BoundField DataField="BookAuthor" HeaderText="BookAuthor" SortExpression="BookAuthor" />
                <asp:BoundField DataField="BookGenre" HeaderText="BookGenre" SortExpression="BookGenre" />
                <asp:BoundField DataField="AverageRating" HeaderText="AverageRating" SortExpression="AverageRating" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="BookStoreDatabase" runat="server" ConnectionString="<%$ ConnectionStrings:BookStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:BookStoreConnectionString.ProviderName %>" SelectCommand="SELECT [BookID], [BookName], [BookAuthor], [BookGenre], [AverageRating] FROM [Books]"></asp:SqlDataSource>
        <strong>
        <br class="auto-style4" />
        <span class="auto-style4">Would you like to add a Book??<br />
        <br />
        </span>
        <asp:Button ID="btnAddBook" runat="server" Font-Bold="True" Text="Add Book" Width="123px" OnClick="btnAddBook_Click" />
        <br />
        </strong>
        <br />
        <span class="auto-style4"><strong>Would you like to Rate a Book??<br />
        </strong></span>
        <br />
        <asp:Button ID="btnRate" runat="server" Font-Bold="True" Text="Rate Book" Width="125px" OnClick="btnRate_Click" />
                        <asp:Label ID="lblRatingError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <br />
        <asp:Panel ID="PanelCheckBookID" runat="server" Height="102px" Width="1038px">
            <table class="auto-style5">
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Enter Book ID :"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtBookID" runat="server" Width="264px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblBookIDError" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="btnBookID" runat="server" CssClass="auto-style8" Font-Bold="True" Text="Check ID" Width="134px" OnClick="btnBookID_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="PanelAddRating" runat="server" CssClass="auto-style10" Height="135px" Width="1038px">
            <table class="auto-style9">
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Select a Rating 1 (lowest) and 5 (highest)"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="272px">
                            <asp:ListItem Value="1"></asp:ListItem>
                            <asp:ListItem Value="2"></asp:ListItem>
                            <asp:ListItem Value="3"></asp:ListItem>
                            <asp:ListItem Value="4"></asp:ListItem>
                            <asp:ListItem Value="5"></asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style13">
                        <asp:Button ID="btnAddRating" runat="server" CssClass="auto-style14" Font-Bold="True" Text="Rate Book" Width="133px" OnClick="btnAddRating_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style13">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <p>
                        &nbsp;</p>
    </form>
    </body>
</html>
