<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCategory.aspx.cs" Inherits="BasicCRUDOpration.DbOprations.ViewCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="text-text-center">View Details of Category</h1>
            <hr />
            <asp:Button ID="Button1" runat="server" Text="View All Details" OnClick="Button1_Click" /><br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
