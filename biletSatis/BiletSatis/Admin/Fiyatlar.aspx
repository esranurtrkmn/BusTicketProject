<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Fiyatlar.aspx.cs" Inherits="BiletOtomasyon.Admin.Fiyatlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Fiyatlar</h4>
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
                <li><a href="FiyatEkle.aspx" class=" waves-effect waves-light">Fiyat Ekle</a></li>
                
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
        </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT [FiyatNo], [BaslamaTerminali], [BitisTerminali], [Ucret] FROM [Fiyatlar]" DeleteCommand="DELETE FROM [Fiyatlar] WHERE [FiyatNo] = @FiyatNo" InsertCommand="INSERT INTO [Fiyatlar] ([BaslamaTerminali], [BitisTerminali], [Ucret]) VALUES (@BaslamaTerminali, @BitisTerminali, @Ucret)" UpdateCommand="UPDATE [Fiyatlar] SET [BaslamaTerminali] = @BaslamaTerminali, [BitisTerminali] = @BitisTerminali, [Ucret] = @Ucret WHERE [FiyatNo] = @FiyatNo">
        <DeleteParameters>
            <asp:Parameter Name="FiyatNo" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="BaslamaTerminali" Type="Int32" />
            <asp:Parameter Name="BitisTerminali" Type="Int32" />
            <asp:Parameter Name="Ucret" Type="Decimal" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="BaslamaTerminali" Type="Int32" />
            <asp:Parameter Name="BitisTerminali" Type="Int32" />
            <asp:Parameter Name="Ucret" Type="Decimal" />
            <asp:Parameter Name="FiyatNo" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="gvFiyatlar" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="FiyatNo" DataSourceID="SqlDataSource1" CssClass="table sizi21 size18" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField CancelText="İptal" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" NewText="Yeni" SelectText="Seç" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Güncelle" />
            <asp:BoundField DataField="FiyatNo" HeaderText="FiyatNo" InsertVisible="False" ReadOnly="True" SortExpression="FiyatNo" />
            <asp:BoundField DataField="BaslamaTerminali" HeaderText="BaslamaTerminali" SortExpression="BaslamaTerminali" />
            <asp:BoundField DataField="BitisTerminali" HeaderText="BitisTerminali" SortExpression="BitisTerminali" />
            <asp:BoundField DataField="Ucret" HeaderText="Ucret" SortExpression="Ucret" />
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
