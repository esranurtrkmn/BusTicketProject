<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="GuzergahTerminal.aspx.cs" Inherits="BiletOtomasyon.Admin.GuzergahTerminal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
        <div class="header">
            <h4>Terminal-Güzergah</h4>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-8">
                    <asp:DropDownList ID="drpGuzergahlar" runat="server" DataSourceID="SqlDataSource2" DataTextField="GuzergahAdi" DataValueField="GuzergahNo" CssClass="form-control" OnSelectedIndexChanged="drpGuzergahlar_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT * FROM [Guzergahlar]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3">
                    <div class="card text-center bg-light-blue">
                        <div class="card-header">Terminaller</div>
                        <div class="card-body">
                            <asp:ListBox ID="lstTerminaller" runat="server" CssClass="list-group" Width="200px"></asp:ListBox>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT * FROM [Terminaller]"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 text-center" style="margin-top:30px;">                   
                    <asp:Button ID="btnTerminalEkle" runat="server" Text="SAĞ" CssClass="btn bg-grey" OnClick="btnTerminalEkle_Click" />
                    <asp:Button ID="btnTerminalSil" runat="server" Text="SOL" CssClass="btn bg-grey" OnClick="btnTerminalSil_Click" />
                </div>
                <div class="col-lg-3">
                    <div class="card text-center bg-light-blue">
                        <div class="card-header">Terminal Sırası</div>
                        <div class="card-body">
                            <asp:ListBox ID="lstTerminalSirasi" runat="server" CssClass="list-group" Width="200px">
                                <asp:ListItem></asp:ListItem>
                            </asp:ListBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 text-center"  style="margin-top:20px;">
                    <div class="row"><asp:Button ID="btnTerminalYukari" runat="server" Text="YUKARI" CssClass="btn bg-grey" OnClick="btnTerminalYukari_Click" /></div>                
                    <div class="row"><asp:Button ID="btnTerminalAsagi" runat="server" Text="AŞAĞI" CssClass="btn bg-grey" OnClick="btnTerminalAsagi_Click" /></div>                    
                </div>
            </div>
            <div class="row">
                <div class="col-lg-1">
                    <asp:Button ID="btnKaydet" runat="server" Text="KAYDET" CssClass="btn bg-blue" OnClick="btnKaydet_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
