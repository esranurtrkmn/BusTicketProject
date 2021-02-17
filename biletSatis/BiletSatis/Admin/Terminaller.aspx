<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Terminaller.aspx.cs" Inherits="BiletOtomasyon.Admin.Terminaller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Terminaller</h4>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT [IlKodu], [TerminalNo], [TerminalAdi] FROM [Terminaller] ORDER BY [IlKodu]" DeleteCommand="DELETE FROM [Terminaller] WHERE [TerminalNo] = @TerminalNo" InsertCommand="INSERT INTO [Terminaller] ([IlKodu], [TerminalAdi]) VALUES (@IlKodu, @TerminalAdi)" UpdateCommand="UPDATE [Terminaller] SET [IlKodu] = @IlKodu, [TerminalAdi] = @TerminalAdi WHERE [TerminalNo] = @TerminalNo">
                <DeleteParameters>
                    <asp:Parameter Name="TerminalNo" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="IlKodu" Type="Int32" />
                    <asp:Parameter Name="TerminalAdi" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="IlKodu" Type="Int32" />
                    <asp:Parameter Name="TerminalAdi" Type="String" />
                    <asp:Parameter Name="TerminalNo" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse navbar-ex1-collapse">
            <ul class="nav navbar-nav">
                <li><a href="TerminalEkle.aspx" class=" waves-effect waves-light">Terminal Ekle</a></li>
                
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
        </div>
    <asp:GridView ID="gvTerminaller" runat="server"  AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="TerminalNo" DataSourceID="SqlDataSource1" CssClass="table size18 sizi21 " CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField CancelText="İptal" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" NewText="Yeni" SelectText="Seç" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Güncelle" />
            <asp:BoundField DataField="IlKodu" HeaderText="İl Plaka Kodu" SortExpression="IlKodu" />
            <asp:BoundField DataField="TerminalNo" HeaderText="TerminalNo" SortExpression="TerminalNo" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="TerminalAdi" HeaderText="TerminalAdi" SortExpression="TerminalAdi" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"/>
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
</asp:Content>
