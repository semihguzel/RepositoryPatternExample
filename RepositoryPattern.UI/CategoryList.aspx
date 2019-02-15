<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="RepositoryPattern.UI.CategoryList" %>

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
                <asp:GridView ID="grdCategories" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="grdCategories_RowCommand" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Kategori Adı">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("CategoryName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Açıklama">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" OnClientClick="window.document.forms[0].target = '_top'" CommandArgument='<%#Eval("CategoryID") %>' CommandName="git" Text='<%#Eval("Description") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnKategoriEkle" CssClass="btn btn-primary" Text="Kategori Ekle" CommandName="ekle" />
                                <asp:Button runat="server" ID="btnKategoriSil" CssClass="btn btn-danger" Text="Kategori Ekle" CommandName="sil" />
                                <asp:Button runat="server" ID="btnKategoriDuzenle" CssClass="btn btn-warning" Text="Kategori Ekle" CommandName="guncelle" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BackColor="CornflowerBlue" ForeColor="Maroon" Font-Bold="true" Font-Italic="true" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
