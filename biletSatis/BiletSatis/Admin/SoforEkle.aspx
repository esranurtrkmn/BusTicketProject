<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SoforEkle.aspx.cs" Inherits="BiletOtomasyon.Admin.SoforEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Şöför Ekle</h4>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <table class="table">
                <tr>
                    <td>TC NO</td>
                    <td><asp:TextBox ID="txtTCNO" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ad</td>
                    <td><asp:TextBox ID="txtAd" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Soyad</td>
                    <td><asp:TextBox ID="txtSoyad" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Telefon No</td>
                    <td><asp:TextBox ID="txtTelefonNo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Adres</td>
                    <td><asp:TextBox ID="txtMail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnSoforEkle" runat="server" Text="EKLE" CssClass="btn bg-green" OnClick="btnSoforEkle_Click"></asp:Button></td>
                </tr>
                
            </table>
            
        </div>
    </div>
        </div>
</asp:Content>
