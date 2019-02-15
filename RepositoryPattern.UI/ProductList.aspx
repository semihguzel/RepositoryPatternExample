<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="RepositoryPattern.UI.ProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row" style="margin-top:50px;">
                <asp:GridView ID="grdProducts" CssClass="table table-hover" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Ürün Adı">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("ProductName") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fiyat">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("UnitPrice","{0:C2}") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Stok Miktarı">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("UnitsInStock") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Kategori Adı">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("CategoryName") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BackColor="Crimson" />

                </asp:GridView>

                <asp:Button runat="server" ID="btnKategoriler" Text="Kategorilere Dön" CssClass="btn btn-info form-control" OnClick="btnKategoriler_Click"/>

            </div>
        </div>
    </form>
</body>
</html>
