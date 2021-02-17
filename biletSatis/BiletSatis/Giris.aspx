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
<body style="background:url(img/bodybg4.jpg) no-repeat;">
    
    <form id="form1" runat="server">
        <div class="container" style="margin-left:30%; margin-top:10%;">
            <div class="container-fluid" style="font-family:Tahoma">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group bg-white" style="padding:5%;">
                            <h4 class="header text-center" style="color:red;">Yetkili Giriş Paneli</h4>
                            <p>Kullanıcı Adı</p>
                            <p>
                                <asp:TextBox ID="txtKullaniciAdi" runat="server" CssClass="form-control" placeholder="kullaniciadi giriniz.."></asp:TextBox>
                            </p>
                            <br />
                            <p>Parola</p>
                            <p>
                                <asp:TextBox ID="txtParola" runat="server" TextMode="Password" CssClass="form-control" placeholder="sifre giriniz.."></asp:TextBox>
                            </p>
                            <br />
                            <div class="wrapper">
                                <span class="group-btn">
                                    <asp:Button ID="btnGiris" runat="server" Text="GİRİŞ" CssClass="form-control bg-info" OnClick="btnGiris_Click" />
                                </span>
                            </div>
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
