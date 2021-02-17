<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="OtobusEkle.aspx.cs" Inherits="BiletOtomasyon.Admin.OtobusEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Otobüs Ekle</h4>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <table class="table">
                <tr>
                    <td>Model</td>
                    <td><asp:TextBox ID="txtModel" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Koltuk Sayısı</td>
                    <td><asp:TextBox ID="txtKoltukSayisi" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Koltuk Tipi</td>
                    <td>
                        <asp:DropDownList ID="drpKoltukTipi" runat="server">
                            <asp:ListItem>2+2</asp:ListItem>
                            <asp:ListItem>2+1</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Plaka Numarası</td>
                    <td><asp:TextBox ID="txtPlakaNo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnOtobusEkle" runat="server" Text="EKLE" CssClass="btn bg-green"></asp:Button></td>
                </tr>
            </table>
        </div>
    </div>
        </div>
</asp:Content>
