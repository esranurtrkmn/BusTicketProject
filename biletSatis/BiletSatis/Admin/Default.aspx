<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BiletOtomasyon.Admin.Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <div class="header"><h4> Admin Panel anasayfası, istatistikler, vs.</h4></div>  
    </div>
    <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" CssClass="ct-veritcal" >
        <Series>
            <asp:Series Name="Series1" XValueMember="GuzergahNo" YValueMembers="BiletSatilan"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisY Title="Satılan Bilet Sayısı">
                    </AxisY>
                    <AxisX Title="Guzergah No">
                    </AxisX>
            </asp:ChartArea>
        </ChartAreas>
        <Annotations>
            <asp:LineAnnotation Name="LineAnnotation1">
            </asp:LineAnnotation>
            <asp:LineAnnotation Name="LineAnnotation2">
            </asp:LineAnnotation>
        </Annotations>
    </asp:Chart>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT COUNT(Biletler.BiletNo) AS BiletSatilan, Seferler.GuzergahNo FROM Biletler INNER JOIN Seferler ON Biletler.SeferNo = Seferler.SeferNo INNER JOIN Guzergahlar ON Seferler.GuzergahNo = Guzergahlar.GuzergahNo GROUP BY Seferler.GuzergahNo"></asp:SqlDataSource>
</asp:Content>
