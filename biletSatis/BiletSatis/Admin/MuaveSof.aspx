<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MuaveSof.aspx.cs" Inherits="BiletOtomasyon.Admin.MuaveSof" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Muavin ve Şöförler</h4>
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
                <li><a href="MuavinEkle.aspx" class=" waves-effect waves-light">Muavin Ekle</a></li>
                <li><a href="SoforEkle.aspx" class=" waves-effect waves-light">Şöför Ekle</a></li>
                <li><a href="MuavinAtama.aspx" class=" waves-effect waves-light">Muavin Atama</a></li>
                <li><a href="SoforAtama.aspx" class=" waves-effect waves-light">Şöför Atama</a></li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
        </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT * FROM [Muavinler]" DeleteCommand="DELETE FROM [Muavinler] WHERE [MuavinNo] = @MuavinNo" InsertCommand="INSERT INTO [Muavinler] ([TC], [Ad], [Soyad], [TelefonNo], [Adres], [Cinsiyet]) VALUES (@TC, @Ad, @Soyad, @TelefonNo, @Adres, @Cinsiyet)" UpdateCommand="UPDATE [Muavinler] SET [TC] = @TC, [Ad] = @Ad, [Soyad] = @Soyad, [TelefonNo] = @TelefonNo, [Adres] = @Adres, [Cinsiyet] = @Cinsiyet WHERE [MuavinNo] = @MuavinNo">
        <DeleteParameters>
            <asp:Parameter Name="MuavinNo" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TC" Type="String" />
            <asp:Parameter Name="Ad" Type="String" />
            <asp:Parameter Name="Soyad" Type="String" />
            <asp:Parameter Name="TelefonNo" Type="String" />
            <asp:Parameter Name="Adres" Type="String" />
            <asp:Parameter Name="Cinsiyet" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="TC" Type="String" />
            <asp:Parameter Name="Ad" Type="String" />
            <asp:Parameter Name="Soyad" Type="String" />
            <asp:Parameter Name="TelefonNo" Type="String" />
            <asp:Parameter Name="Adres" Type="String" />
            <asp:Parameter Name="Cinsiyet" Type="Boolean" />
            <asp:Parameter Name="MuavinNo" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="vgSoforler" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="SoforNo" DataSourceID="SqlDataSource2" CssClass="table sizi21 size18" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField CancelText="İptal" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" NewText="Yeni" SelectText="Seç" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Güncelle" />
            <asp:BoundField DataField="SoforNo" HeaderText="SoforNo" InsertVisible="False" ReadOnly="True" SortExpression="SoforNo" />
            <asp:BoundField DataField="TC" HeaderText="TC" SortExpression="TC" />
            <asp:BoundField DataField="Ad" HeaderText="Ad" SortExpression="Ad" />
            <asp:BoundField DataField="Soyad" HeaderText="Soyad" SortExpression="Soyad" />
            <asp:BoundField DataField="TelefonNo" HeaderText="TelefonNo" SortExpression="TelefonNo" />
            <asp:BoundField DataField="Adres" HeaderText="Adres" SortExpression="Adres" />
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
    <br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT * FROM [Soforler]" DeleteCommand="DELETE FROM [Soforler] WHERE [SoforNo] = @SoforNo" InsertCommand="INSERT INTO [Soforler] ([TC], [Ad], [Soyad], [TelefonNo], [Adres]) VALUES (@TC, @Ad, @Soyad, @TelefonNo, @Adres)" UpdateCommand="UPDATE [Soforler] SET [TC] = @TC, [Ad] = @Ad, [Soyad] = @Soyad, [TelefonNo] = @TelefonNo, [Adres] = @Adres WHERE [SoforNo] = @SoforNo">
        <DeleteParameters>
            <asp:Parameter Name="SoforNo" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TC" Type="String" />
            <asp:Parameter Name="Ad" Type="String" />
            <asp:Parameter Name="Soyad" Type="String" />
            <asp:Parameter Name="TelefonNo" Type="String" />
            <asp:Parameter Name="Adres" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="TC" Type="String" />
            <asp:Parameter Name="Ad" Type="String" />
            <asp:Parameter Name="Soyad" Type="String" />
            <asp:Parameter Name="TelefonNo" Type="String" />
            <asp:Parameter Name="Adres" Type="String" />
            <asp:Parameter Name="SoforNo" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="gvMuavinler" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="MuavinNo" DataSourceID="SqlDataSource1" CssClass=" table sizi21 size18" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField CancelText="İptal" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" NewText="Yeni" SelectText="Seç" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Günelle" />
            <asp:BoundField DataField="MuavinNo" HeaderText="MuavinNo" InsertVisible="False" ReadOnly="True" SortExpression="MuavinNo" />
            <asp:BoundField DataField="TC" HeaderText="TC" SortExpression="TC" />
            <asp:BoundField DataField="Ad" HeaderText="Ad" SortExpression="Ad" />
            <asp:BoundField DataField="Soyad" HeaderText="Soyad" SortExpression="Soyad" />
            <asp:BoundField DataField="TelefonNo" HeaderText="TelefonNo" SortExpression="TelefonNo" />
            <asp:BoundField DataField="Adres" HeaderText="Adres" SortExpression="Adres" />
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
</asp:Content>
