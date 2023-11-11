<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="BasicCRUDOpration.DbOprations.AddCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
         <h1 class="text-xl-center">Add Category Details </h1>
         <table align="center" class="bg-secondary">
             <tr>
                 <td>Category ID</td>
                 <td>
                     <asp:TextBox ID="CategoryID" runat="server"></asp:TextBox>
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
                    <asp:Button ID="btnSave" runat="server" Text="Save Record" OnClick="btnSave_Click" />
                    &nbsp;<asp:HyperLink ID="hyperlink" runat="server" NavigateUrl="~/DbOprations/ViewCategory.aspx">View All Records</asp:HyperLink>
                </td>
            </tr>
             <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
         </table>

     </div>
 </form>
</body>
</html>
