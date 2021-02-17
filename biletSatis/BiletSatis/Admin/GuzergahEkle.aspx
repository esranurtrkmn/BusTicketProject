<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="GuzergahEkle.aspx.cs" Inherits="BiletOtomasyon.Admin.GuzergahEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Güzergah Ekle</h4>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <table class="table">
                <tr>
                    <td>Güzergah No</td>
                    <td><asp:TextBox ID="txtGuzergahNo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Güzergah Adı</td>
                    <td><asp:TextBox ID="txtGuzergahAdi" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnGuzergahEkle" runat="server" Text="EKLE" CssClass="btn bg-green" OnClick="btnGuzergahEkle_Click"></asp:Button></td>
                </tr>
            </table>
        </div>
    </div>
        </div>
</asp:Content>
