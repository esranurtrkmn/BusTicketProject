<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Otobusler.aspx.cs" Inherits="BiletOtomasyon.Admin.Otobusler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Otobüsler</h4>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT [OtobusNo], [PlakaNumarasi], [KoltukTipi], [KoltukSayisi], [Model] FROM [Otobusler]" DeleteCommand="DELETE FROM [Otobusler] WHERE [OtobusNo] = @OtobusNo" InsertCommand="INSERT INTO [Otobusler] ([PlakaNumarasi], [KoltukTipi], [KoltukSayisi], [Model]) VALUES (@PlakaNumarasi, @KoltukTipi, @KoltukSayisi, @Model)" UpdateCommand="UPDATE [Otobusler] SET [PlakaNumarasi] = @PlakaNumarasi, [KoltukTipi] = @KoltukTipi, [KoltukSayisi] = @KoltukSayisi, [Model] = @Model WHERE [OtobusNo] = @OtobusNo">
                <DeleteParameters>
                    <asp:Parameter Name="OtobusNo" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="PlakaNumarasi" Type="String" />
                    <asp:Parameter Name="KoltukTipi" Type="String" />
                    <asp:Parameter Name="KoltukSayisi" Type="Int32" />
                    <asp:Parameter Name="Model" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="PlakaNumarasi" Type="String" />
                    <asp:Parameter Name="KoltukTipi" Type="String" />
                    <asp:Parameter Name="KoltukSayisi" Type="Int32" />
                    <asp:Parameter Name="Model" Type="String" />
                    <asp:Parameter Name="OtobusNo" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse navbar-ex1-collapse">
            <ul class="nav navbar-nav">
                <li><a href="OtobusEkle.aspx" class=" waves-effect waves-light">Otobüs Ekle</a></li>
                
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
        </div>
    <asp:GridView ID="gvOtobusler" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="OtobusNo" DataSourceID="SqlDataSource1" CssClass="table sizi21 size18" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField CancelText="İptal" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" NewText="Yeni" SelectText="Seç" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Güncelle" />
            <asp:BoundField DataField="OtobusNo" HeaderText="OtobusNo" InsertVisible="False" ReadOnly="True" SortExpression="OtobusNo" />
            <asp:BoundField DataField="PlakaNumarasi" HeaderText="PlakaNumarasi" SortExpression="PlakaNumarasi" />
            <asp:BoundField DataField="KoltukTipi" HeaderText="KoltukTipi" SortExpression="KoltukTipi" />
            <asp:BoundField DataField="KoltukSayisi" HeaderText="KoltukSayisi" SortExpression="KoltukSayisi" />
            <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
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
