<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="BiletEkle.aspx.cs" Inherits="BiletOtomasyon.Admin.BiletEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Bileti satın almak istediğinize emin misiniz?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="header">
            <h4>Bilet Ekle</h4>
        </div>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="lblNereden" runat="server" Text="Nereden"></asp:Label>
                    <asp:DropDownList ID="drpNereden" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="TerminalAdi" DataValueField="TerminalNo">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT [TerminalNo], [TerminalAdi] FROM [Terminaller]"></asp:SqlDataSource>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblNereye" runat="server" Text="Nereye"></asp:Label>
                    <asp:DropDownList ID="drpNereye" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="TerminalAdi" DataValueField="TerminalNo">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="select TerminalAdi, TerminalNo from Terminaller where IlKodu not in (select IlKodu from Terminaller where TerminalNo=@TerminalNo)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drpNereden" Name="TerminalNo" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblTarih" runat="server" Text="Tarih"></asp:Label>
                    <asp:Table runat="server" CssClass="">
                        <asp:TableHeaderRow>
                            <asp:TableCell>
                                <asp:TextBox ID="txtGidisTarih" runat="server" TextMode="DateTime" ReadOnly="true" CssClass="form-control text-center"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:ImageButton ID="imgbtnCalendar" runat="server" ImageUrl="~/img/calendar.png" Width="16" Height="16" OnClick="imgbtnCalendar_Click" />
                            </asp:TableCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <asp:Calendar ID="Takvim" runat="server" BackColor="White" BorderColor="Black" Font-Names="Times New Roman" Font-Size="8pt" ForeColor="Black" Height="110px" NextPrevFormat="FullMonth" OnSelectionChanged="DateChange" Width="200px" DayNameFormat="Shortest" TitleFormat="Month">
                        <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" ForeColor="#333333" Height="10pt" />
                        <DayStyle Width="14%" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                        <TodayDayStyle BackColor="#CCCC99" />
                    </asp:Calendar>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:GridView ID="GridViewSeferler" runat="server" AutoGenerateSelectButton="true" CssClass="table size20 table-bordered text-center text-uppercase" AutoGenerateColumns="false" GridLines="None" OnSelectedIndexChanged="GridViewSeferler_SelectedIndexChanged">             
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
   
         <div class="container bg-white">
        <div class="row">
            <div class="nav text-center">KOLTUK SEÇİM PANELİ</div>
            <div class="col-lg-9">
                <hr />
                <asp:Table ID="tableOtobus" runat="server" CssClass="table size10" title="Otobüs">
                    <asp:TableRow>
                        <asp:TableCell CssClass="">GİRİŞ</asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK1" runat="server" Text="1" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK5" runat="server" Text="5" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK9" runat="server" Text="9" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK13" runat="server" Text="13" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK17" runat="server" Text="17" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK21" runat="server" Text="21" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">ORTA</asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK27" runat="server" Text="27" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK31" runat="server" Text="31" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK35" runat="server" Text="35" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK39" runat="server" Text="39" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK43" runat="server" Text="43" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK47" runat="server" Text="47" OnClick="btnK_Click" /></asp:TableCell>

                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass=""></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK2" runat="server" Text="2" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK6" runat="server" Text="6" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK10" runat="server" Text="10" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK14" runat="server" Text="14" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK18" runat="server" Text="18" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK22" runat="server" Text="22" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass=""></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK28" runat="server" Text="28" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK32" runat="server" Text="32" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK36" runat="server" Text="36" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK40" runat="server" Text="40" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK44" runat="server" Text="44" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK48" runat="server" Text="48" OnClick="btnK_Click" /></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="">KORİDOR <span class="black fa fa-arrow-right"></span></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass=""></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK3" runat="server" Text="3" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK7" runat="server" Text="7" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK11" runat="server" Text="11" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK15" runat="server" Text="15" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK19" runat="server" Text="19" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK23" runat="server" Text="23" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK25" runat="server" Text="25" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK29" runat="server" Text="29" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK33" runat="server" Text="33" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK37" runat="server" Text="37" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK41" runat="server" Text="41" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK45" runat="server" Text="45" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK49" runat="server" Text="49" OnClick="btnK_Click" /></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="">ŞÖFÖR </asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK4" runat="server" Text="4" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK8" runat="server" Text="8" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK12" runat="server" Text="12" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK16" runat="server" Text="16" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK20" runat="server" Text="20" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK24" runat="server" Text="24" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK26" runat="server" Text="26" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK30" runat="server" Text="30" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK34" runat="server" Text="34" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK38" runat="server" Text="38" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK42" runat="server" Text="42" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK46" runat="server" Text="46" OnClick="btnK_Click" /></asp:TableCell>
                        <asp:TableCell CssClass="">
                            <asp:Button CssClass="btn btn-outline-black" ID="btnK50" runat="server" Text="50" OnClick="btnK_Click" /></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <hr />
                <div class="col-lg-12 text-center">
                <div class="heading bg-red">Koltuk Tipi</div>
                <div class="col-lg-3 bg-orange">Seçili Koltuk</div>
                <div class="col-lg-3 bg-white">Boş Koltuk</div>
                <div class="col-lg-3 bg-blue">Erkek (Dolu)</div>
                <div class="col-lg-3 bg-pink">Bayan (Dolu)</div>
                </div>
                <hr />
                <asp:Literal ID="LiteralOdeme" runat="server" Visible="false"></asp:Literal>
                <div class="footer-bottom text-center" id="divOdeme"><span class="fa fa-arrow-down pull-left" style="color: black;"></span>ÖDEME <span class="fa fa-arrow-down pull-right" style="color: black;"></span></div>
                <div class="col-lg-12 size15">
                    <asp:Table class="col-lg-12" ID="BiletSecim1" runat="server" Visible="false">
                        <asp:TableRow>
                            <asp:TableCell><b>Yolcu Bilgileri</b></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Seçilen Koltuk</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSecilenKoltuk1" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Cinsiyet</asp:TableCell>
                            <asp:TableHeaderCell>
                                <asp:DropDownList ID="drpCinsiyet1" runat="server" CssClass="form-control">
                                    <asp:ListItem>Bayan</asp:ListItem>
                                    <asp:ListItem>Bay</asp:ListItem>
                                </asp:DropDownList>

                            </asp:TableHeaderCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>TC Numarası</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtYolcuTC1" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Yolcu Adı</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtYolcuAdi1" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Yolcu Soyadı</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtYolcuSoyadi1" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell><b>Müşteri Bilgileri</b></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Telefon</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtTelefon1" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>E-Posta</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtEposta1" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table class="col-lg-12" ID="BiletSecim2" runat="server"  Visible="false">
                        <asp:TableRow>
                            <asp:TableCell><b>Yolcu Bilgileri</b></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Seçilen Koltuk</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSecilenKoltuk2" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Cinsiyet</asp:TableCell>
                            <asp:TableHeaderCell>
                                <asp:DropDownList ID="drpCinsiyet2" runat="server" CssClass="form-control">
                                    <asp:ListItem>Bayan</asp:ListItem>
                                    <asp:ListItem>Bay</asp:ListItem>
                                </asp:DropDownList>

                            </asp:TableHeaderCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>TC Numarası</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtYolcuTC2" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Yolcu Adı</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtYolcuAdi2" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Yolcu Soyadı</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtYolcuSoyadi2" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell><b>Müşteri Bilgileri</b></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Telefon</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtTelefon2" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>E-Posta</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtEposta2" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>

                    </asp:Table>
                    <asp:Table class="col-lg-12" ID="BiletSecim3" runat="server"  Visible="false">
                        <asp:TableRow>
                            <asp:TableCell><b>Yolcu Bilgileri</b></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Seçilen Koltuk</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSecilenKoltuk3" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Cinsiyet</asp:TableCell>
                            <asp:TableHeaderCell>
                                <asp:DropDownList ID="drpCinsiyet3" runat="server" CssClass="form-control">
                                    <asp:ListItem>Bayan</asp:ListItem>
                                    <asp:ListItem>Bay</asp:ListItem>
                                </asp:DropDownList>

                            </asp:TableHeaderCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>TC Numarası</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtYolcuTC3" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Yolcu Adı</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtYolcuAdi3" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Yolcu Soyadı</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtYolcuSoyadi3" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell><b>Müşteri Bilgileri</b></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Telefon</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtTelefon3" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>E-Posta</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtEposta3" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table runat="server" ID="Odeme" Visible="false">
                        <asp:TableRow>
                            <asp:TableCell><b>Kredi Kartı İle Ödeme</b></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Kart Üzerindeki İsim</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtKartIsim" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Kredi Kartı Numarası</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtKartNo" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button ID="btnBiletIptal1" runat="server" Text="Iptal" CssClass="btn btn-green"></asp:Button></asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btnBiletSatinAl" runat="server" Text="Satın Al" CssClass="btn btn-green" OnClick="btnBiletSatinAl_Click" OnClientClick="Confirm()"></asp:Button></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
            
        </div>
        <hr />
    </div>
    <br />
    
</asp:Content>
