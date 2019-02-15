<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="RepositoryPattern.UI.CreateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row" style="margin-top: 50px;">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtUnitsInStock" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
