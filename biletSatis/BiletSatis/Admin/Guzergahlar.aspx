<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Guzergahlar.aspx.cs" Inherits="BiletOtomasyon.Admin.Guzergahlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Güzergahlar</h4>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT [GuzergahNo], [GuzergahAdi] FROM [Guzergahlar]" DeleteCommand="DELETE FROM [Guzergahlar] WHERE [GuzergahNo] = @GuzergahNo" InsertCommand="INSERT INTO [Guzergahlar] ([GuzergahNo], [GuzergahAdi]) VALUES (@GuzergahNo, @GuzergahAdi)" UpdateCommand="UPDATE [Guzergahlar] SET [GuzergahAdi] = @GuzergahAdi WHERE [GuzergahNo] = @GuzergahNo">
                <DeleteParameters>
                    <asp:Parameter Name="GuzergahNo" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="GuzergahNo" Type="Int32" />
                    <asp:Parameter Name="GuzergahAdi" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="GuzergahAdi" Type="String" />
                    <asp:Parameter Name="GuzergahNo" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse navbar-ex1-collapse">
            <ul class="nav navbar-nav">
                <li><a href="GuzergahEkle.aspx" class=" waves-effect waves-light">Güzergah Ekle</a></li>
                
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
        </div>
    <asp:GridView ID="gvGuzergahlar" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="GuzergahNo" DataSourceID="SqlDataSource1" CssClass="table sizi21 size18" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField CancelText="İptal" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" NewText="Yeni" SelectText="Seç" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Güncelle" />
            <asp:BoundField DataField="GuzergahNo" HeaderText="GuzergahNo" ReadOnly="True" SortExpression="GuzergahNo" />
            <asp:BoundField DataField="GuzergahAdi" HeaderText="GuzergahAdi" SortExpression="GuzergahAdi" />
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
