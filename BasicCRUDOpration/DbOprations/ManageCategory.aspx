<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="BasicCRUDOpration.DbOprations.ManageCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="text-xl-center">Update Category Details </h1>
            <table align="center" class="bg-danger">
                 <tr>
                     <td>Category ID</td>
                     <td>
                         <asp:TextBox ID="CategoryID" runat="server"></asp:TextBox>
                         <asp:Button ID="btnFind" runat="server" Text="Find Category" OnClick="btnFind_Click" />
                     </td>
                 </tr>
                 <tr>
                     <td>Category Name</td>
                     <td>
                         <asp:TextBox ID="CategoryName" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnView" runat="server" Text="View All" OnClick="btnView_Click" />
                        &nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update Records" OnClick="btnUpdate_Click" />
                        &nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete Record" OnClick="btnDelete_Click" />
                        &nbsp;<asp:HyperLink ID="hyperlink" runat="server" NavigateUrl="~/DbOprations/AddCategory.aspx">Add New Categoeries</asp:HyperLink>
                    </td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    </td>
                </tr>
         </table>

        </div>
    </form>
</body>
</html>
