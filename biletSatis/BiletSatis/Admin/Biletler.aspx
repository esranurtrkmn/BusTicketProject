<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Biletler.aspx.cs" Inherits="BiletOtomasyon.Admin.Biletler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Biletler</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="header">
        <h4>Biletler</h4>
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
                <li><a href="BiletEkle.aspx" class=" waves-effect waves-light">Bilet Ekle</a></li>
                <li><a href="BiletSil.aspx" class=" waves-effect waves-light">Bilet Ara/Sil</a></li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
        <%--ÖRNEK OLARAK EKLEDIM BAKTIM--%>
    <div class="container">       
        <asp:Label ID="lblsefer" runat="server">Sefer No</asp:Label>
        <asp:DropDownList ID="drpSefer" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceDrp" DataTextField="SeferNo" DataValueField="SeferNo" OnDataBound="drpSefer_DataBound" OnSelectedIndexChanged="drpSefer_SelectedIndexChanged" CssClass="form-control">
            <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
        </asp:DropDownList>
        <asp:GridView ID="GridViewBiletler" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table size10 text-center text-uppercase" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:TemplateField HeaderText="Düzenle">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "BiletDuzenle.aspx?id=" + Eval("BiletNo") %>' Text='<%# "Düzenle" %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:SqlDataSource ID="BiletOtomasyon" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT dbo.Seferler.SeferNo, dbo.Biletler.BiletNo FROM dbo.Biletler INNER JOIN dbo.Seferler ON dbo.Biletler.SeferNo = dbo.Seferler.SeferNo">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceDrp" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT [SeferNo] FROM [Seferler]"></asp:SqlDataSource>
    </div>
        </div>
</asp:Content>
