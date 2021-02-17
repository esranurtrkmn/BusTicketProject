<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="BiletSil.aspx.cs" Inherits="BiletOtomasyon.Admin.BiletSil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header"><h4>Bilet Ara/Sil</h4></div>   
    <div class="row">
        <div class="col-lg-9">
            <table>
                <tr>
                    <td> Bilet NO </td>
                    <td> <asp:TextBox ID="txtBiletNo" runat="server" CssClass="form-control"></asp:TextBox> </td>
                    <td> <asp:Button ID="btnAra" runat="server" CssClass="form-control btn-green bg-green" Text="Ara"></asp:Button> </td>
                    <td> <asp:Button ID="btnSil" runat="server" CssClass="form-control btn-red bg-red" Text="Sil"></asp:Button></td>
                </tr>
            </table>
        </div>
    </div>
        </div>
</asp:Content>
