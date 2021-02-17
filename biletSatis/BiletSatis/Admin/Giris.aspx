<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="BiletOtomasyon.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="Content/mdb.min.css" rel="stylesheet" />
    <link href="Content/style.css" rel="stylesheet" />
    <title>Yetkili Girişi</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h4>Yetkili Giriş Sayfası</h4>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-offset-3 col-md-3">
                    <div class="form-login">

                        <h4 class="bg-primary text-center">Hoşgeldiniz.</h4>
                        <p>Kullanıcı Adı</p>
                        <p>
                            <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox>
                        </p>
                        <br />
                        <p>Parola</p>
                        <p>
                            <asp:TextBox ID="txtParola" runat="server"></asp:TextBox></p>
                        <br />
                        <div class="wrapper">
                            <span class="group-btn">
                                <asp:Button ID="btnGiris" runat="server" Text="Giriş" CssClass="form-control bg-blue" />
                            </span>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
    <script src="../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../Scripts/modernizr-2.8.3.js"></script>
    <script src="../Scripts/mdb.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
    <script src="../Scripts/respond.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
