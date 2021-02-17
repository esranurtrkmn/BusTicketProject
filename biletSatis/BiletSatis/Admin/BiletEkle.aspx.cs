using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BiletOtomasyon.Admin
{
    public partial class BiletEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtGidisTarih.Text = DateTime.Today.ToShortDateString();
            Takvim.Visible = false;

        }
        public int SeferNo = 0;
        public void sefer(string tarih)
        {
            string Sorgu = "";
            int GuzergahNo = 0, TerminalSirasi = 0;
            VeriTabani vt = new VeriTabani();
            DataTable dr;
            dr = vt.SorguCalistir("select FiyatNo from Fiyatlar where (BaslamaTerminali =" + Convert.ToInt32(drpNereden.SelectedItem.Value)+ ") AND (BitisTerminali =" + Convert.ToInt32(drpNereye.SelectedItem.Value) +")");
            int FiyatNo = Convert.ToInt32(dr.Rows[0]["FiyatNo"]);
            int[] Guzergahlar = new int[10];
            int say = 0;
            dr = vt.tabloCagir("GuzergahTerminal");
            for (int i = 0; i < dr.Rows.Count; i++)
            {
                if (Convert.ToInt32(drpNereden.SelectedItem.Value) == Convert.ToInt32(dr.Rows[i][1]))
                {
                    GuzergahNo = Convert.ToInt32(dr.Rows[i][0]);
                    TerminalSirasi = Convert.ToInt32(dr.Rows[i][2]);
                    DataTable drSefer = vt.tabloCagir("GuzergahTerminal where GuzergahNo=" + GuzergahNo);
                    for (int k = 0; k < drSefer.Rows.Count; k++)
                    {
                        if (Convert.ToInt32(drpNereye.SelectedItem.Value) == Convert.ToInt32(drSefer.Rows[k][1]))
                        {
                            if (Convert.ToInt32(dr.Rows[i][2]) < Convert.ToInt32(drSefer.Rows[k][2]))
                            {
                                Guzergahlar[say] = GuzergahNo;
                                say++;
                            }
                        }
                    }
                    TerminalSirasi = 0;
                    GuzergahNo = 0;
                }
            }
            Sorgu = "SELECT dbo.Seferler.SeferNo, convert(varchar(5),dbo.Seferler.SeferTarihi, 108) As SeferSaati, dbo.Otobusler.KoltukTipi, Guzergahlar.GuzergahAdi, FORMAT(dbo.Fiyatlar.Ucret, 'c2', 'tr-TR') as Ucret, dbo.Fiyatlar.FiyatNo, Guzergahlar.GuzergahNo FROM dbo.Seferler INNER JOIN dbo.Otobusler ON dbo.Seferler.OtobusNo = dbo.Otobusler.OtobusNo INNER JOIN dbo.Guzergahlar ON dbo.Seferler.GuzergahNo = dbo.Guzergahlar.GuzergahNo CROSS JOIN dbo.Fiyatlar WHERE ";
            for (int J = 0; J < say; J++)
            {
                if ((J + 1) != say)
                    Sorgu += " (dbo.Fiyatlar.FiyatNo IN (SELECT FiyatNo FROM dbo.Fiyatlar AS Fiyatlar_1 WHERE (BaslamaTerminali =" + Convert.ToInt32(drpNereden.SelectedItem.Value) + ") AND (BitisTerminali =" + Convert.ToInt32(drpNereye.SelectedItem.Value) + "))) AND (dbo.Seferler.GuzergahNo = " + Guzergahlar[J] + ") AND (SeferTarihi BETWEEN '" + tarih + "' AND '" + tarih + "  23:59:59') OR";
                else                                                                                                                                                                                                                                                                                                                                                            
                    Sorgu += " (dbo.Fiyatlar.FiyatNo IN (SELECT FiyatNo FROM dbo.Fiyatlar AS Fiyatlar_1 WHERE (BaslamaTerminali =" + Convert.ToInt32(drpNereden.SelectedItem.Value) + ") AND (BitisTerminali =" + Convert.ToInt32(drpNereye.SelectedItem.Value) + "))) AND (dbo.Seferler.GuzergahNo = " + Guzergahlar[J] + ") AND (SeferTarihi BETWEEN '" + tarih + "' AND '" + tarih + "  23:59:59') order by SeferSaati asc";
            }
            DataTable dt1 = new DataTable();
            DataSet dr1 = vt.SorguCalistirDataSet(Sorgu);
            dr1.Tables[0].Columns.Add("nereden");
            dr1.Tables[0].Columns.Add("nereye");
            string nereden, nereye;
            dt1 = vt.SorguCalistir("SELECT TerminalAdi FROM dbo.Terminaller where TerminalNo=" + Convert.ToInt32(drpNereden.SelectedItem.Value));
            nereden = dt1.Rows[0]["TerminalAdi"].ToString();
            dt1 = vt.SorguCalistir("SELECT TerminalAdi FROM dbo.Terminaller where TerminalNo=" + Convert.ToInt32(drpNereye.SelectedItem.Value));
            nereye = dt1.Rows[0]["TerminalAdi"].ToString();

            for (int i = 0; i < dr1.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToInt32(drpNereden.SelectedItem.Value) == 11 && (Convert.ToInt32(dr1.Tables[0].Rows[i]["GuzergahNo"]) == 3428 || Convert.ToInt32(dr1.Tables[0].Rows[i]["GuzergahNo"]) == 3432))
                {
                    TimeSpan satt = Convert.ToDateTime(dr1.Tables[0].Rows[i]["SeferSaati"]).TimeOfDay;
                    TimeSpan ekleneceksaat = TimeSpan.FromHours(4);
                    dr1.Tables[0].Rows[i]["SeferSaati"] = string.Format("{0:hh\\:mm}", satt.Add(ekleneceksaat));
                }
                else if ((Convert.ToInt32(drpNereden.SelectedItem.Value) == 11 || Convert.ToInt32(drpNereden.SelectedItem.Value) == 14) && (Convert.ToInt32(dr1.Tables[0].Rows[i]["GuzergahNo"]) == 2834 || Convert.ToInt32(dr1.Tables[0].Rows[i]["GuzergahNo"]) == 3234))
                {
                    TimeSpan satt = Convert.ToDateTime(dr1.Tables[0].Rows[i]["SeferSaati"]).TimeOfDay;
                    TimeSpan ekleneceksaat = TimeSpan.FromHours(5);
                    dr1.Tables[0].Rows[i]["SeferSaati"] = string.Format("{0:hh\\:mm}", satt.Add(ekleneceksaat));
                }
                dr1.Tables[0].Rows[i]["nereden"] = nereden;
                dr1.Tables[0].Rows[i]["nereye"] = nereye;
            }

            BoundField sutun1 = new BoundField();
            sutun1.HeaderText = "SeferNo";
            sutun1.DataField = "SeferNo";
            GridViewSeferler.Columns.Add(sutun1);
            BoundField sutun2 = new BoundField();
            sutun2.HeaderText = "KoltukTipi";
            sutun2.DataField = "KoltukTipi";
            GridViewSeferler.Columns.Add(sutun2);

            BoundField sutun3 = new BoundField();
            sutun3.HeaderText = "SeferSaati";
            sutun3.DataField = "SeferSaati";
            GridViewSeferler.Columns.Add(sutun3);
            BoundField sutun4 = new BoundField();
            sutun4.HeaderText = "nereden";
            sutun4.DataField = "nereden";
            GridViewSeferler.Columns.Add(sutun4);

            BoundField sutun5 = new BoundField();
            sutun5.HeaderText = "nereye";
            sutun5.DataField = "nereye";
            GridViewSeferler.Columns.Add(sutun5);

            BoundField sutun6 = new BoundField();
            sutun6.HeaderText = "Ucret";
            sutun6.DataField = "Ucret";
            GridViewSeferler.Columns.Add(sutun6);
            dr1.Tables[0].DefaultView.Sort = "SeferSaati";
            DataView dataView = dr1.Tables[0].DefaultView;
            dataView.Sort = "SeferSaati";
            DataTable dtSortedAsc = dataView.ToTable();

            dataView.Sort = "SeferSaati asc";
            DataTable dtSortedDesc = dataView.ToTable();
            GridViewSeferler.DataSource = dtSortedDesc;
            GridViewSeferler.DataBind();
        }
        protected void DateChange(object sender, EventArgs e)
        {
            txtGidisTarih.Text = Takvim.SelectedDate.ToShortDateString();
            Takvim.Visible = false;
            imgbtnCalendar.Visible = true;
            string tarih = "";
            tarih = Takvim.SelectedDate.ToString("yyyy-MM-dd");
            sefer(tarih);
            GridViewSeferler.Visible = true;
        }
        

        protected void imgbtnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            txtGidisTarih.Focus();
            Takvim.Visible = true;
        }
        public void KoltuklarıListele()
        {
            VeriTabani vt = new VeriTabani();
            DataTable dr = vt.SorguCalistir("select FiyatNo from Fiyatlar where (BaslamaTerminali =" + Convert.ToInt32(drpNereden.SelectedItem.Value) + ") AND (BitisTerminali =" + Convert.ToInt32(drpNereye.SelectedItem.Value) + ")");
            int FiyatNo = Convert.ToInt32(dr.Rows[0]["FiyatNo"]);
            DataTable dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet, dbo.Biletler.FiyatNo, dbo.Biletler.KoltukNumarasi FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where AktifMi=1 and dbo.Biletler.SeferNo=" + SeferNo);
            DataTable dt2 = new DataTable();
            dt2 = vt.SorguCalistir("select * from Seferler where SeferNo = " +Convert.ToInt32( LiteralOdeme.Text));
            int GuzergahNo = Convert.ToInt32(dt2.Rows[0]["GuzergahNo"]);
            dt2 = vt.SorguCalistir("SELECT BaslamaTerminali, BitisTerminali FROM dbo.Fiyatlar where FiyatNo=" +FiyatNo);
            int BaslamaTerminali = Convert.ToInt32(dt2.Rows[0]["BaslamaTerminali"]);
            int BitisTerminali = Convert.ToInt32(dt2.Rows[0]["BitisTerminali"]);
            dt2 = vt.SorguCalistir("SELECT TerminalSirasi FROM dbo.GuzergahTerminal where GuzergahNo=" + GuzergahNo + " and TerminalNo=" + BaslamaTerminali);
            int BaslamaTerminaliSirasi = Convert.ToInt32(dt2.Rows[0]["TerminalSirasi"]);
            dt2 = vt.SorguCalistir("SELECT TerminalSirasi FROM dbo.GuzergahTerminal where GuzergahNo=" + GuzergahNo + " and TerminalNo=" + BitisTerminali);
            int BitisTerminaliSirasi = Convert.ToInt32(dt2.Rows[0]["TerminalSirasi"]);
            int BitisTerminaliSirasi2 = 0;
            int BaslamaTerminaliSirasi2 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt2 = vt.SorguCalistir("SELECT BaslamaTerminali, BitisTerminali FROM dbo.Fiyatlar where FiyatNo=" + Convert.ToInt32(dt.Rows[i]["FiyatNo"]));
                int BaslamaTerminali2 = Convert.ToInt32(dt2.Rows[0]["BaslamaTerminali"]);
                int BitisTerminali2 = Convert.ToInt32(dt2.Rows[0]["BitisTerminali"]);
                dt2 = vt.SorguCalistir("SELECT TerminalSirasi FROM dbo.GuzergahTerminal where GuzergahNo=" + GuzergahNo + "and TerminalNo=" + BaslamaTerminali2);
                BaslamaTerminaliSirasi2 = Convert.ToInt32(dt2.Rows[0]["TerminalSirasi"]);
                dt2 = vt.SorguCalistir("SELECT TerminalSirasi FROM dbo.GuzergahTerminal where GuzergahNo=" + GuzergahNo + " and TerminalNo=" + BitisTerminali2);
                BitisTerminaliSirasi2 = Convert.ToInt32(dt2.Rows[0]["TerminalSirasi"]);
                bool durum = true;
                if ((BaslamaTerminaliSirasi2 < BaslamaTerminaliSirasi) && (BitisTerminaliSirasi2 <= BaslamaTerminaliSirasi))
                    durum = false;
                else if ((BaslamaTerminaliSirasi2 > BaslamaTerminaliSirasi) && (BaslamaTerminaliSirasi2 <= BitisTerminaliSirasi))
                    durum = false;
                if (durum)
                {
                    if (btnK1.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK1.CssClass = "btn bg-red";
                        else
                            btnK1.CssClass = "btn bg-blue";
                        btnK1.Enabled = false;
                    }
                    else if (btnK2.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK2.CssClass = "btn bg-red";
                        else
                            btnK2.CssClass = "btn bg-blue";
                        btnK2.Enabled = false;
                    }
                    else if (btnK3.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK3.CssClass = "btn bg-red";
                        else
                            btnK3.CssClass = "btn bg-blue";
                        btnK3.Enabled = false;
                    }
                    else if (btnK4.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK4.CssClass = "btn bg-red";
                        else
                            btnK4.CssClass = "btn bg-blue";
                        btnK4.Enabled = false;
                    }
                    else if (btnK5.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK5.CssClass = "btn bg-red";
                        else
                            btnK5.CssClass = "btn bg-blue";
                        btnK5.Enabled = false;
                    }
                    else if (btnK6.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK6.CssClass = "btn bg-red";
                        else
                            btnK6.CssClass = "btn bg-blue";
                        btnK6.Enabled = false;
                    }
                    else if (btnK7.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK7.CssClass = "btn bg-red";
                        else
                            btnK7.CssClass = "btn bg-blue";
                        btnK7.Enabled = false;
                    }
                    else if (btnK8.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK8.CssClass = "btn bg-red";
                        else
                            btnK8.CssClass = "btn bg-blue";
                        btnK8.Enabled = false;
                    }
                    else if (btnK9.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK9.CssClass = "btn bg-red";
                        else
                            btnK9.CssClass = "btn bg-blue";
                        btnK9.Enabled = false;
                    }
                    else if (btnK10.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK10.CssClass = "btn bg-red";
                        else
                            btnK10.CssClass = "btn bg-blue";
                        btnK10.Enabled = false;
                    }
                    else if (btnK11.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK11.CssClass = "btn bg-red";
                        else
                            btnK11.CssClass = "btn bg-blue";
                        btnK11.Enabled = false;
                    }
                    else if (btnK12.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK12.CssClass = "btn bg-red";
                        else
                            btnK12.CssClass = "btn bg-blue";
                        btnK12.Enabled = false;
                    }
                    else if (btnK13.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK13.CssClass = "btn bg-red";
                        else
                            btnK13.CssClass = "btn bg-blue";
                        btnK13.Enabled = false;
                    }
                    else if (btnK14.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK14.CssClass = "btn bg-red";
                        else
                            btnK14.CssClass = "btn bg-blue";
                        btnK14.Enabled = false;
                    }
                    else if (btnK15.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK15.CssClass = "btn bg-red";
                        else
                            btnK15.CssClass = "btn bg-blue";
                        btnK15.Enabled = false;
                    }
                    else if (btnK16.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK16.CssClass = "btn bg-red";
                        else
                            btnK16.CssClass = "btn bg-blue";
                        btnK16.Enabled = false;
                    }
                    else if (btnK17.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK17.CssClass = "btn bg-red";
                        else
                            btnK17.CssClass = "btn bg-blue";
                        btnK17.Enabled = false;
                    }
                    else if (btnK18.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK18.CssClass = "btn bg-red";
                        else
                            btnK18.CssClass = "btn bg-blue";
                        btnK18.Enabled = false;
                    }
                    else if (btnK19.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK19.CssClass = "btn bg-red";
                        else
                            btnK19.CssClass = "btn bg-blue";
                        btnK19.Enabled = false;
                    }
                    else if (btnK20.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK20.CssClass = "btn bg-red";
                        else
                            btnK20.CssClass = "btn bg-blue";
                        btnK20.Enabled = false;
                    }
                    else if (btnK21.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK21.CssClass = "btn bg-red";
                        else
                            btnK21.CssClass = "btn bg-blue";
                        btnK21.Enabled = false;
                    }
                    else if (btnK22.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK22.CssClass = "btn bg-red";
                        else
                            btnK22.CssClass = "btn bg-blue";
                        btnK22.Enabled = false;
                    }
                    else if (btnK23.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK23.CssClass = "btn bg-red";
                        else
                            btnK23.CssClass = "btn bg-blue";
                        btnK23.Enabled = false;
                    }
                    else if (btnK24.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK24.CssClass = "btn bg-red";
                        else
                            btnK24.CssClass = "btn bg-blue";
                        btnK24.Enabled = false;
                    }
                    else if (btnK25.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK25.CssClass = "btn bg-red";
                        else
                            btnK25.CssClass = "btn bg-blue";
                        btnK25.Enabled = false;
                    }
                    else if (btnK26.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK26.CssClass = "btn bg-red";
                        else
                            btnK26.CssClass = "btn bg-blue";
                        btnK26.Enabled = false;
                    }
                    else if (btnK27.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK27.CssClass = "btn bg-red";
                        else
                            btnK27.CssClass = "btn bg-blue";

                        btnK27.Enabled = false;
                    }
                    else if (btnK28.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK28.CssClass = "btn bg-red";
                        else
                            btnK28.CssClass = "btn bg-blue";
                        btnK28.Enabled = false;
                    }
                    else if (btnK29.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK29.CssClass = "btn bg-red";
                        else
                            btnK29.CssClass = "btn bg-blue";
                        btnK29.Enabled = false;
                    }
                    else if (btnK30.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK30.CssClass = "btn bg-red";
                        else
                            btnK30.CssClass = "btn bg-blue";
                        btnK30.Enabled = false;
                    }
                    else if (btnK31.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK31.CssClass = "btn bg-red";
                        else
                            btnK31.CssClass = "btn bg-blue";
                        btnK31.Enabled = false;
                    }
                    else if (btnK32.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK32.CssClass = "btn bg-red";
                        else
                            btnK32.CssClass = "btn bg-blue";
                        btnK32.Enabled = false;
                    }
                    else if (btnK33.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK33.CssClass = "btn bg-red";
                        else
                            btnK33.CssClass = "btn bg-blue";
                        btnK33.Enabled = false;
                    }
                    else if (btnK34.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK34.CssClass = "btn bg-red";
                        else
                            btnK34.CssClass = "btn bg-blue";
                        btnK34.Enabled = false;
                    }
                    else if (btnK35.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK35.CssClass = "btn bg-red";
                        else
                            btnK35.CssClass = "btn bg-blue";
                        btnK35.Enabled = false;
                    }
                    else if (btnK36.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK36.CssClass = "btn bg-red";
                        else
                            btnK36.CssClass = "btn bg-blue";
                        btnK36.Enabled = false;
                    }
                    else if (btnK37.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK37.CssClass = "btn bg-red";
                        else
                            btnK37.CssClass = "btn bg-blue";
                        btnK37.Enabled = false;
                    }
                    else if (btnK38.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK38.CssClass = "btn bg-red";
                        else
                            btnK38.CssClass = "btn bg-blue";
                        btnK38.Enabled = false;
                    }
                    else if (btnK39.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK39.CssClass = "btn bg-red";
                        else
                            btnK39.CssClass = "btn bg-blue";
                        btnK39.Enabled = false;
                    }
                    else if (btnK40.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK40.CssClass = "btn bg-red";
                        else
                            btnK40.CssClass = "btn bg-blue";
                        btnK40.Enabled = false;
                    }
                    else if (btnK41.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK41.CssClass = "btn bg-red";
                        else
                            btnK41.CssClass = "btn bg-blue";
                        btnK41.Enabled = false;
                    }
                    else if (btnK42.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK42.CssClass = "btn bg-red";
                        else
                            btnK42.CssClass = "btn bg-blue";
                        btnK42.Enabled = false;
                    }
                    else if (btnK43.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK43.CssClass = "btn bg-red";
                        else
                            btnK43.CssClass = "btn bg-blue";
                        btnK43.Enabled = false;
                    }
                    else if (btnK44.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK44.CssClass = "btn bg-red";
                        else
                            btnK44.CssClass = "btn bg-blue";
                        btnK44.Enabled = false;
                    }
                    else if (btnK45.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK45.CssClass = "btn bg-red";
                        else
                            btnK45.CssClass = "btn btn-blue";
                        btnK45.Enabled = false;
                    }
                    else if (btnK46.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK46.CssClass = "btn bg-red";
                        else
                            btnK46.CssClass = "btn bg-blue";
                        btnK46.Enabled = false;
                    }
                    else if (btnK47.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK47.CssClass = "btn bg-red";
                        else
                            btnK47.CssClass = "btn bg-blue";
                        btnK47.Enabled = false;
                    }
                    else if (btnK48.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK48.CssClass = "btn bg-red";
                        else
                            btnK48.CssClass = "btn bg-blue";
                        btnK48.Enabled = false;
                    }
                    else if (btnK49.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK49.CssClass = "btn bg-red";
                        else
                            btnK49.CssClass = "btn bg-blue";
                        btnK49.Enabled = false;
                    }
                    else if (btnK50.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK50.CssClass = "btn bg-red";
                        else
                            btnK50.CssClass = "btn bg-blue";
                        btnK50.Enabled = false;
                    }
                }
            }
        }
        public void BiletSecimTemizle1()
        {
            txtSecilenKoltuk1.Text = "";
            drpCinsiyet1.SelectedValue = null;
            txtYolcuTC1.Text = "";
            txtYolcuAdi1.Text = "";
            txtYolcuSoyadi1.Text = "";
            txtTelefon1.Text = "";
            txtEposta1.Text = "";
        }
        public void BiletSecimTemizle2()
        {
            txtSecilenKoltuk2.Text = "";
            drpCinsiyet2.SelectedValue = null;
            txtYolcuTC2.Text = "";
            txtYolcuAdi2.Text = "";
            txtYolcuSoyadi2.Text = "";
            txtTelefon2.Text = "";
            txtEposta2.Text = "";
        }
        public void BiletSecimTemizle3()
        {
            txtSecilenKoltuk3.Text = "";
            drpCinsiyet3.SelectedValue = null;
            txtYolcuTC3.Text = "";
            txtYolcuAdi3.Text = "";
            txtYolcuSoyadi3.Text = "";
            txtTelefon3.Text = "";
            txtEposta3.Text = "";
        }
        public int cinsiyet1 = -1;
        public int cinsiyet2 = -1;
        public int cinsiyet3 = -1;
        protected void btnK_Click(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            DataTable dt;
            if (((System.Web.UI.WebControls.Button)sender).CssClass == "btn btn-outline-black")
            {
                Odeme.Visible = true;
                if (txtSecilenKoltuk1.Text == "")
                {
                    cinsiyet1 = -1;
                    txtSecilenKoltuk1.Text = ((System.Web.UI.WebControls.Button)sender).Text;
                    ((System.Web.UI.WebControls.Button)sender).CssClass = "btn btn-outline-orange";
                    if (Convert.ToInt32(txtSecilenKoltuk1.Text) % 2 == 0)
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk1.Text) - 1) + " and dbo.Biletler.SeferNo=" + SeferNo);
                    else
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk1.Text) + 1) + " and dbo.Biletler.SeferNo=" + SeferNo);

                    if (dt.Rows.Count != 0)
                    {
                        drpCinsiyet1.Items.Clear();
                        if (Convert.ToInt32(dt.Rows[0]["Cinsiyet"]) == 0)
                            drpCinsiyet1.Items.Insert(0, new ListItem("Bayan"));
                        else if (Convert.ToInt32(dt.Rows[0]["Cinsiyet"]) == 1)
                        {
                            drpCinsiyet1.Items.Add(new ListItem("Bay", "0"));
                            cinsiyet1 = 1;
                        }
                    }
                    else
                    {
                        drpCinsiyet1.Items.Clear();
                        drpCinsiyet1.Items.Insert(0, new ListItem("Bayan"));
                        drpCinsiyet1.Items.Insert(1, new ListItem("Bay"));
                    }

                    BiletSecim1.Visible = true;
                }
                else if (txtSecilenKoltuk2.Text == "")
                {
                    cinsiyet2 = -1;
                    txtSecilenKoltuk2.Text = ((System.Web.UI.WebControls.Button)sender).Text;
                    ((System.Web.UI.WebControls.Button)sender).CssClass = "btn btn-outline-orange";
                    if (Convert.ToInt32(txtSecilenKoltuk2.Text) % 2 == 0)
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk2.Text) - 1) + " and dbo.Biletler.SeferNo=" + SeferNo);
                    else
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk2.Text) + 1) + " and dbo.Biletler.SeferNo=" + SeferNo);

                    if (dt.Rows.Count != 0)
                    {
                        drpCinsiyet2.Items.Clear();
                        if (Convert.ToInt32(dt.Rows[0]["Cinsiyet"]) == 0)
                            drpCinsiyet2.Items.Insert(0, new ListItem("Bayan"));
                        else if (Convert.ToInt32(dt.Rows[0]["Cinsiyet"]) == 1)
                        {
                            drpCinsiyet2.Items.Add(new ListItem("Bay", "0"));
                            cinsiyet2 = 1;
                        }
                    }
                    else
                    {
                        drpCinsiyet2.Items.Clear();
                        drpCinsiyet2.Items.Insert(0, new ListItem("Bayan"));
                        drpCinsiyet2.Items.Insert(1, new ListItem("Bay"));
                    }
                    BiletSecim2.Visible = true;
                }
                else if (txtSecilenKoltuk3.Text == "")
                {
                    cinsiyet3 = -1;
                    txtSecilenKoltuk3.Text = ((System.Web.UI.WebControls.Button)sender).Text;
                    ((System.Web.UI.WebControls.Button)sender).CssClass = "btn btn-outline-orange";
                    if (Convert.ToInt32(txtSecilenKoltuk3.Text) % 2 == 0)
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk3.Text) - 1) + " and dbo.Biletler.SeferNo=" + SeferNo);
                    else
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk3.Text) + 1) + " and dbo.Biletler.SeferNo=" + SeferNo);

                    if (dt.Rows.Count != 0)
                    {
                        drpCinsiyet3.Items.Clear();
                        if (Convert.ToInt32(dt.Rows[0]["Cinsiyet"]) == 0)
                            drpCinsiyet3.Items.Insert(0, new ListItem("Bayan"));
                        else if (Convert.ToInt32(dt.Rows[0]["Cinsiyet"]) == 1)
                        {
                            drpCinsiyet3.Items.Add(new ListItem("Bay", "0"));
                            cinsiyet3 = 1;
                        }
                    }
                    else
                    {
                        drpCinsiyet3.Items.Clear();
                        drpCinsiyet3.Items.Insert(0, new ListItem("Bayan"));
                        drpCinsiyet3.Items.Insert(1, new ListItem("Bay"));
                    }
                    BiletSecim3.Visible = true;
                }
            }
            else
            {
                if (((System.Web.UI.WebControls.Button)sender).Text == txtSecilenKoltuk1.Text)
                {
                    ((System.Web.UI.WebControls.Button)sender).CssClass = "btn btn-outline-black";
                    BiletSecim1.Visible = false;
                    BiletSecimTemizle1();
                }
                else if (((System.Web.UI.WebControls.Button)sender).Text == txtSecilenKoltuk2.Text)
                {
                    ((System.Web.UI.WebControls.Button)sender).CssClass = "btn btn-outline-black";
                    BiletSecim2.Visible = false;
                    BiletSecimTemizle2();
                }
                else if (((System.Web.UI.WebControls.Button)sender).Text == txtSecilenKoltuk3.Text)
                {
                    ((System.Web.UI.WebControls.Button)sender).CssClass = "btn btn-outline-black";
                    BiletSecim3.Visible = false;
                    BiletSecimTemizle3();
                }
                if (txtSecilenKoltuk1.Text == "" && txtSecilenKoltuk2.Text == "" && txtSecilenKoltuk3.Text == "")
                    Odeme.Visible = false;
            }
        }

        protected void btnSec_Click(object sender, EventArgs e)
        {

        }
        

        protected void GridViewSeferler_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeferNo = Convert.ToInt32(GridViewSeferler.SelectedRow.Cells[1].Text);
            LiteralOdeme.Text = GridViewSeferler.SelectedRow.Cells[1].Text;
            KoltuklarıListele();
        }

        protected void btnBiletSatinAl_Click(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            DataTable dr;
            dr = vt.SorguCalistir("select FiyatNo from Fiyatlar where (BaslamaTerminali =" + Convert.ToInt32(drpNereden.SelectedItem.Value) + ") AND (BitisTerminali =" + Convert.ToInt32(drpNereye.SelectedItem.Value) + ")");
            int FiyatNo = Convert.ToInt32(dr.Rows[0]["FiyatNo"]);
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string Metin = "";
                int YeniYolcu1, YeniYolcu2, YeniYolcu3;
                int Sonuc1, Sonuc2, Sonuc3;
                DataTable dw = vt.SorguCalistir("select TerminalAdi from Terminaller where TerminalNo in  (SELECT  BaslamaTerminali  FROM dbo.Fiyatlar WHERE (FiyatNo = " + FiyatNo + ")) UNION select TerminalAdi from Terminaller where TerminalNo in  (SELECT  BitisTerminali  FROM dbo.Fiyatlar WHERE (FiyatNo = " + FiyatNo + "))");
                Metin = SeferNo.ToString() + " SeferNolu ";
                if (txtSecilenKoltuk1.Text != "")
                {
                    if (cinsiyet1 != -1)
                        YeniYolcu1 = vt.YolcuEkleDuzenle(0, txtYolcuTC1.Text, txtYolcuAdi1.Text, txtYolcuSoyadi1.Text, txtTelefon1.Text, txtEposta1.Text, Convert.ToBoolean(drpCinsiyet1.SelectedIndex));
                    else
                        YeniYolcu1 = vt.YolcuEkleDuzenle(0, txtYolcuTC1.Text, txtYolcuAdi1.Text, txtYolcuSoyadi1.Text, txtTelefon1.Text, txtEposta1.Text, Convert.ToBoolean(cinsiyet1));

                    Sonuc1 = vt.BiletEkleDuzenle(0, Convert.ToInt32(LiteralOdeme.Text), YeniYolcu1, DateTime.Now.Date, FiyatNo, 1, true, Convert.ToInt32(txtSecilenKoltuk1.Text), 1);
                    Metin += "\\n" + txtSecilenKoltuk1.Text + "  Koltuk Numaralı " + txtYolcuAdi1.Text + " " + txtYolcuSoyadi1.Text + " ";
                }
                if (txtSecilenKoltuk2.Text != "")
                {
                    if (cinsiyet2 != -1)
                        YeniYolcu2 = vt.YolcuEkleDuzenle(0, txtYolcuTC2.Text, txtYolcuAdi2.Text, txtYolcuSoyadi2.Text, txtTelefon2.Text, txtEposta2.Text, Convert.ToBoolean(drpCinsiyet2.SelectedIndex));
                    else
                        YeniYolcu2 = vt.YolcuEkleDuzenle(0, txtYolcuTC2.Text, txtYolcuAdi2.Text, txtYolcuSoyadi2.Text, txtTelefon2.Text, txtEposta2.Text, Convert.ToBoolean(cinsiyet2));

                    Sonuc2 = vt.BiletEkleDuzenle(0, Convert.ToInt32(LiteralOdeme.Text), YeniYolcu2, DateTime.Now.Date,FiyatNo, 1, true, Convert.ToInt32(txtSecilenKoltuk2.Text), 1);
                    Metin += "\\n" + txtSecilenKoltuk2.Text + "  Koltuk Numaralı " + txtYolcuAdi2.Text + " " + txtYolcuSoyadi2.Text + " ";

                }
                if (txtSecilenKoltuk3.Text != "")
                {
                    if (cinsiyet3 != -1)
                        YeniYolcu3 = vt.YolcuEkleDuzenle(0, txtYolcuTC3.Text, txtYolcuAdi3.Text, txtYolcuSoyadi3.Text, txtTelefon3.Text, txtEposta3.Text, Convert.ToBoolean(drpCinsiyet3.SelectedIndex));
                    else
                        YeniYolcu3 = vt.YolcuEkleDuzenle(0, txtYolcuTC3.Text, txtYolcuAdi3.Text, txtYolcuSoyadi3.Text, txtTelefon3.Text, txtEposta3.Text, Convert.ToBoolean(drpCinsiyet3));
                    Sonuc3 = vt.BiletEkleDuzenle(0,Convert.ToInt32(LiteralOdeme.Text), YeniYolcu3, DateTime.Now.Date, FiyatNo, 1, true, Convert.ToInt32(txtSecilenKoltuk3.Text), 1);
                    Metin += "\\n" + txtSecilenKoltuk3.Text + " Koltuk Numaralı  " + txtYolcuAdi3.Text + " " + txtYolcuSoyadi3.Text + " ";

                }
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + Metin + "')", true);
            }
            else
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Biletiniz İptal Ettiniz')", true);

            KoltuklarıListele();
            BiletSecim1.Visible = false;
            BiletSecimTemizle1();
            BiletSecim2.Visible = false;
            BiletSecimTemizle2();
            BiletSecim3.Visible = false;
            BiletSecimTemizle3();
            Odeme.Visible = false;
            KoltuklarıListele();
        }
    }
}