<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MuavinAtama.aspx.cs" Inherits="BiletOtomasyon.Admin.MuavinAtama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header"><h4>Muavin Atama</h4></div>  
        <div class="row">
        <div class="col-lg-12">
            <table class="table">
                <tr>
                    <td>Sefer No</td>
                    <td>
                        <asp:DropDownList ID="drpSeferler" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="SeferNo" DataValueField="SeferNo">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT * FROM [Seferler]"></asp:SqlDataSource>
                    </td>
                </tr>
                 <tr>
                    <td>Muavin Adı</td>
                    <td>
                        <asp:DropDownList ID="drpMuavinler" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Muavin" DataValueField="MuavinNo">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT  Ad + ' ' + Soyad as Muavin , MuavinNo FROM [Muavinler]"></asp:SqlDataSource>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td><asp:Button ID="btnMuavinAta" runat="server" Text="ATAMA YAP" CssClass="btn bg-green" OnClick="btnMuavinAta_Click"></asp:Button></td>
                </tr>
            </table>
        </div>
    </div>
        </div>
</asp:Content>
