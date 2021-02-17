<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Kullanicilar.aspx.cs" Inherits="BiletOtomasyon.Admin.Kullanicilar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header"><h4>Kullanıcılar</h4></div>   
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
                <li><a href="KullaniciEkle.aspx" class=" waves-effect waves-light">Kullanıcı Ekle</a></li>
                
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <asp:GridView ID="gvKullanicilar" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="DuzenleyenNo" DataSourceID="SqlDataSource1" CssClass="table size18 sizi21" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField CancelText="İptal" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" NewText="Yeni" SelectText="Seç" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Güncelle" />
            <asp:BoundField DataField="DuzenleyenNo" HeaderText="DuzenleyenNo" InsertVisible="False" ReadOnly="True" SortExpression="DuzenleyenNo" />
            <asp:BoundField DataField="TC" HeaderText="TC" SortExpression="TC" />
            <asp:BoundField DataField="Ad" HeaderText="Ad" SortExpression="Ad" />
            <asp:BoundField DataField="Soyad" HeaderText="Soyad" SortExpression="Soyad" />
            <asp:BoundField DataField="TelefonNo" HeaderText="TelefonNo" SortExpression="TelefonNo" />
            <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail" />
            <asp:CheckBoxField DataField="Cinsiyet" HeaderText="Cinsiyet" SortExpression="Cinsiyet" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT * FROM [Duzenleyenler]" DeleteCommand="DELETE FROM [Duzenleyenler] WHERE [DuzenleyenNo] = @DuzenleyenNo" InsertCommand="INSERT INTO [Duzenleyenler] ([TC], [Ad], [Soyad], [TelefonNo], [Mail], [Cinsiyet]) VALUES (@TC, @Ad, @Soyad, @TelefonNo, @Mail, @Cinsiyet)" UpdateCommand="UPDATE [Düzenleyenler] SET [TC] = @TC, [Ad] = @Ad, [Soyad] = @Soyad, [TelefonNo] = @TelefonNo, [Mail] = @Mail, [Cinsiyet] = @Cinsiyet WHERE [DuzenleyenNo] = @DuzenleyenNo">
        <DeleteParameters>
            <asp:Parameter Name="DuzenleyenNo" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TC" Type="String" />
            <asp:Parameter Name="Ad" Type="String" />
            <asp:Parameter Name="Soyad" Type="String" />
            <asp:Parameter Name="TelefonNo" Type="String" />
            <asp:Parameter Name="Mail" Type="String" />
            <asp:Parameter Name="Cinsiyet" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="TC" Type="String" />
            <asp:Parameter Name="Ad" Type="String" />
            <asp:Parameter Name="Soyad" Type="String" />
            <asp:Parameter Name="TelefonNo" Type="String" />
            <asp:Parameter Name="Mail" Type="String" />
            <asp:Parameter Name="Cinsiyet" Type="Boolean" />
            <asp:Parameter Name="DuzenleyenNo" Type="Int32" />
        </UpdateParameters>
        </asp:SqlDataSource>

    </div>
</asp:Content>
