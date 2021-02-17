<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Raporlar.aspx.cs" Inherits="BiletOtomasyon.Admin.Raporlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Raporlar</h4>
    </div>
        <div class="container">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand visible-xs-inline-block nav-logo" href="/">
                <img src="img/logo1.jpg" class="img-responsive" alt=""></a>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse navbar-ex1-collapse">
            <ul class="nav navbar-nav">
                <li><a href="#" class=" waves-effect waves-light">Günlük Satılan Bilet Sayısı</a></li>
                <li><a href="#" class=" waves-effect waves-light">Günlük Satılmayan Bilet Sayısı</a></li>
                <li><a href="#" class=" waves-effect waves-light">Kazanılan Para</a></li>
                <li><a href="#" class=" waves-effect waves-light">Rapor 4</a></li>
                <li><a href="#" class=" waves-effect waves-light">Rapor 5</a></li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
        </div>
</asp:Content>
