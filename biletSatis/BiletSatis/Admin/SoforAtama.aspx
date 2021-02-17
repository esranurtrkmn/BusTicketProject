<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SoforAtama.aspx.cs" Inherits="BiletOtomasyon.Admin.SoforAtama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header"><h4>Şöför Atama</h4></div>  
    <div class="row">
        <div class="col-lg-12">
            <table class="table">
                <tr>
                    <td>Sefer No</td>
                    <td>
                        <asp:DropDownList ID="drpSeferler" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="SeferNo" DataValueField="SeferNo">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" DeleteCommand="DELETE FROM [Seferler] WHERE [SeferNo] = @SeferNo" InsertCommand="INSERT INTO [Seferler] ([OtobusNo], [GuzergahNo], [SeferTarihi]) VALUES (@OtobusNo, @GuzergahNo, @SeferTarihi)" SelectCommand="SELECT * FROM [Seferler]" UpdateCommand="UPDATE [Seferler] SET [OtobusNo] = @OtobusNo, [GuzergahNo] = @GuzergahNo, [SeferTarihi] = @SeferTarihi WHERE [SeferNo] = @SeferNo">
                            <DeleteParameters>
                                <asp:Parameter Name="SeferNo" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="OtobusNo" Type="Int32" />
                                <asp:Parameter Name="GuzergahNo" Type="Int32" />
                                <asp:Parameter Name="SeferTarihi" Type="DateTime" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="OtobusNo" Type="Int32" />
                                <asp:Parameter Name="GuzergahNo" Type="Int32" />
                                <asp:Parameter Name="SeferTarihi" Type="DateTime" />
                                <asp:Parameter Name="SeferNo" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>Şöför Adı</td>
                    <td>
                        <asp:DropDownList ID="drpSoforler" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Sofor" DataValueField="SoforNo">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT Ad + ' ' + Soyad AS Sofor, SoforNo FROM Soforler"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnSoforler" runat="server" Text="ATAMA YAP" CssClass="btn bg-green" OnClick="btnSoforAta_Click"></asp:Button></td>
                </tr>
            </table>
        </div>
    </div>
        </div>
</asp:Content>
