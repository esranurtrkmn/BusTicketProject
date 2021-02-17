<%@ Page Title="Seferler" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Seferler.aspx.cs" Inherits="BiletOtomasyon.Seferler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:GridView ID="GridViewSeferler" runat="server" CssClass="table size20 table-bordered text-center text-uppercase" AutoGenerateColumns="false" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-red" NavigateUrl='<%# "BiletSecim.aspx?SeferNo="+ Eval("SeferNo")+"&FiyatNo=" +Eval("FiyatNo") %>'>SEÇ</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>              
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" Font-Bold="True"/>
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"  />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" Font-Bold="True" />
                <RowStyle BackColor="White" ForeColor="#003399" Font-Bold="True"/>
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
