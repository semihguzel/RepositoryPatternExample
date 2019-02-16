<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCategory.aspx.cs" Inherits="RepositoryPattern.UI.CreateCategory" %>

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
                <div class="col-md-8 col-md-offset-3">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-group">
                                <label>Kategori Adı:</label>
                                <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                                <label>Aciklama</label>
                                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnEkle" runat="server" CssClass="btn btn-success form-control" Text="Ekle" OnClick="btnEkle_Click" />
                                <asp:Button ID="btnKategorilereGeriDon" runat="server" CssClass="btn btn-info form-control" Text="Kategori Listesine Geri Dön" OnClick="btnKategorilereGeriDon_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
