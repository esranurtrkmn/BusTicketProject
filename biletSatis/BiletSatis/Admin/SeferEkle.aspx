<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SeferEkle.aspx.cs" Inherits="BiletOtomasyon.Admin.SeferEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container size18">
    <div class="header">
        <h4>Sefer Ekle</h4>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <table class="table">
                <tr>
                    <td>Otobüs NO</td>
                    <td>
                        <asp:DropDownList ID="drpOtobusler" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="PlakaNumarasi" DataValueField="OtobusNo">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" SelectCommand="SELECT [OtobusNo], [PlakaNumarasi] FROM [Otobusler]"></asp:SqlDataSource>

                    </td>
                </tr>
                <tr>
                    <td>Guzegah NO</td>
                    <td>
                        <asp:DropDownList ID="drpGuzergahlar" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="GuzergahAdi" DataValueField="GuzergahNo">
                        </asp:DropDownList>


                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BiletOtomasyonConnectionString %>" DeleteCommand="DELETE FROM [Guzergahlar] WHERE [GuzergahNo] = @GuzergahNo" InsertCommand="INSERT INTO [Guzergahlar] ([GuzergahNo], [GuzergahAdi]) VALUES (@GuzergahNo, @GuzergahAdi)" SelectCommand="SELECT * FROM [Guzergahlar]" UpdateCommand="UPDATE [Guzergahlar] SET [GuzergahAdi] = @GuzergahAdi WHERE [GuzergahNo] = @GuzergahNo">
                            <DeleteParameters>
                                <asp:Parameter Name="GuzergahNo" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="GuzergahNo" Type="Int32" />
                                <asp:Parameter Name="GuzergahAdi" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="GuzergahAdi" Type="String" />
                                <asp:Parameter Name="GuzergahNo" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>


                    </td>
                </tr>
                <tr>
                    <td>Sefer Tarihi</td>
                    <td>
                        <asp:Calendar ID="clnSeferTarih" runat="server" BackColor="White" BorderColor="White" BorderWidth="0px" Font-Names="Verdana" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" OnSelectionChanged="DateChange" Width="510px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#399399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                        <asp:TextBox ID="txtSeferTarih" runat="server" ReadOnly="true" TextMode="DateTime" CssClass="form-control text-center"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSeferEkle" runat="server" Text="EKLE" CssClass="btn bg-green"></asp:Button></td>
                </tr>
            </table>
        </div>
    </div>
        </div>
</asp:Content>
