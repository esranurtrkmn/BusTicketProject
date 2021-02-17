<%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BiletOtomasyon.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container bg-white" style="margin-bottom: 20px;">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-6 text-uppercase">
                    <div class="card">
                        <div class="header blue">
                            <h3 class="title text-center"><span class="fa fa-ticket"></span>Online Bilet <span class="fa fa-ticket"></span></h3>
                        </div>
                        <div class="content">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="col-lg-12">
                                        <div class="form-group text-center">
                                            <span class="fa fa-dot-circle-o" style="color: black;"></span>
                                            <label>Nereden</label>
                                            <asp:DropDownList ID="drpNereden" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="TerminalAdi" DataValueField="TerminalNo">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT [TerminalNo], [TerminalAdi] FROM [Terminaller]"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="col-lg-12">
                                        <div class="form-group text-center">
                                            <span class="fa fa-dot-circle-o" style="color: black;"></span>
                                            <label>Nereye</label>
                                            <asp:DropDownList ID="drpNereye" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="TerminalAdi" DataValueField="TerminalNo">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="select TerminalAdi, TerminalNo from Terminaller where IlKodu not in (select IlKodu from Terminaller where TerminalNo=@TerminalNo)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="drpNereden" Name="TerminalNo" PropertyName="SelectedValue" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="col-lg-12">
                                        <div class="form-group text-center">
                                            <span class="fa fa-calendar" style="color: black;"></span>
                                            <label>Gidiş Tarih</label>

                                            <asp:Calendar ID="Calendar1" runat="server" SelectedDate="2017-12-13" Width="500px" Height="220px" Font-Bold="True" Font-Size="10pt" BackColor="White" BorderColor="White" DayNameFormat="Shortest" Font-Names="Times New Roman" ForeColor="Black" NextPrevFormat="FullMonth" TitleFormat="Month">
                                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="10pt" ForeColor="#333333" Height="10pt" />
                                                <DayStyle Width="15%" />
                                                <NextPrevStyle Font-Size="10pt" ForeColor="White" />
                                                <OtherMonthDayStyle ForeColor="#999999" />
                                                <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                                                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                                                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="15pt" ForeColor="White" Height="15pt" />
                                                <TodayDayStyle BackColor="#CCCC99" />                                           
                                            </asp:Calendar>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <asp:Button ID="btnListele" runat="server" Text="Listele" CssClass="btn btn-blue" OnClick="btnListele_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-6">
                    <div class="card">
                        <div class="header blue">
                            <h3 class="title">Sponsorluk</h3>
                        </div>
                        <div class="content">
                            <div class="row">
                                <div class="col-lg-12">
                                    <h4 class="text-uppercase" style="padding: 2%;">MAVİ TURİZM GENÇ TÜRKİYE ZİRVESİ’NE SPONSOR</h4>
                                    <p style="padding: 1%;">Türkiye’nin Geleceği Bilgi Gençliği’ne Altın Sponsor. Sponsorluk işlemleri için <a href="#">destek</a> sayfasına geçiş yapın.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="card">
                        <div class="header blue">
                            <h3 class="title">Kampanyalar</h3>
                        </div>
                        <div class="content">
                            <div class="row">
                                <div class="col-lg-12">
                                    <h4 class="text-uppercase" style="padding: 2%;">Bir gidişe bir dönüş bedava!</h4>
                                    <p style="padding: 1%;">Türkiye’nin Geleceği Bilgi Gençliği’ne Altın Sponsor Leyla Turizm Yılbaşına özel kampanyası hazır.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
