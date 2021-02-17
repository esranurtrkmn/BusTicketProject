<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TerminalEkle.aspx.cs" Inherits="BiletOtomasyon.Admin.TerminalEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Terminal Ekle</h4>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <table class="table">
                <tr>
                    <td>Terminal Adı</td>
                    <td><asp:TextBox ID="txtTerminalAdi" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>İl Kodu</td>
                    <td><asp:TextBox ID="txtIlkodu" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnTerminalEkle" runat="server" Text="EKLE" CssClass="btn bg-green" OnClick="btnTerminalEkle_Click"></asp:Button></td>
                </tr>
            </table>
        </div>
    </div>
        </div>
</asp:Content>
