<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="FiyatEkle.aspx.cs" Inherits="BiletOtomasyon.Admin.FiyatEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Fiyat Ekle</h4>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <table>
                <tr>
                    <td>Başlama Terminali</td>
                    <td>
                        <asp:DropDownList ID="drpBaslamaTer" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="TerminalAdi" DataValueField="TerminalNo">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT [TerminalNo], [TerminalAdi] FROM [Terminaller]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>Bitiş Terminali</td>
                    <td>
                        <asp:DropDownList ID="drpBitisTer" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="TerminalAdi" DataValueField="TerminalNo">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT [TerminalNo], [TerminalAdi] FROM [Terminaller]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>Ücret</td>
                    <td>
                        <asp:TextBox ID="txtUcret" runat="server" TextMode="Number"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnFiyatEkle" runat="server" Text="EKLE" CssClass="btn bg-green"></asp:Button></td>
                </tr>
            </table>
        </div>
    </div>
        </div>
</asp:Content>
