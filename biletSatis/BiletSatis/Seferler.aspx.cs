using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace BiletOtomasyon
{
    public partial class Seferler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sefer();

        }
        public void sefer()
        {
            string Sorgu = "";
            int GuzergahNo = 0, TerminalSirasi = 0;
            VeriTabani vt = new VeriTabani();
            DataTable dr;
            int[] Guzergahlar = new int[10];
            int say = 0;
            dr = vt.tabloCagir("GuzergahTerminal");
            for (int i = 0; i < dr.Rows.Count; i++)
            {
                if (Convert.ToInt32(Request.QueryString["nereden"]) == Convert.ToInt32(dr.Rows[i][1]))
                {
                    GuzergahNo = Convert.ToInt32(dr.Rows[i][0]);
                    TerminalSirasi = Convert.ToInt32(dr.Rows[i][2]);
                    DataTable drSefer = vt.tabloCagir("GuzergahTerminal where GuzergahNo=" + GuzergahNo);
                    for (int k = 0; k < drSefer.Rows.Count; k++)
                    {
                        if (Convert.ToInt32(Request.QueryString["nereye"]) == Convert.ToInt32(drSefer.Rows[k][1]))
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
                    Sorgu += " (dbo.Fiyatlar.FiyatNo IN (SELECT FiyatNo FROM dbo.Fiyatlar AS Fiyatlar_1 WHERE (BaslamaTerminali =" + Convert.ToInt32(Request.QueryString["nereden"]) + ") AND (BitisTerminali =" + Convert.ToInt32(Request.QueryString["nereye"]) + "))) AND (dbo.Seferler.GuzergahNo = " + Guzergahlar[J] + ") AND (SeferTarihi BETWEEN '" + Request.QueryString["Tarih"].ToString() + "' AND '" + Request.QueryString["Tarih"].ToString() + "  23:59:59') OR";
                else
                    Sorgu += " (dbo.Fiyatlar.FiyatNo IN (SELECT FiyatNo FROM dbo.Fiyatlar AS Fiyatlar_1 WHERE (BaslamaTerminali =" + Convert.ToInt32(Request.QueryString["nereden"]) + ") AND (BitisTerminali =" + Convert.ToInt32(Request.QueryString["nereye"]) + "))) AND (dbo.Seferler.GuzergahNo = " + Guzergahlar[J] + ") AND (SeferTarihi BETWEEN '" + Request.QueryString["Tarih"].ToString() + "' AND '" + Request.QueryString["Tarih"].ToString() + "  23:59:59') order by SeferSaati asc";
            }
            DataTable dt1 = new DataTable();
            DataSet dr1 = vt.SorguCalistirDataSet(Sorgu);
            dr1.Tables[0].Columns.Add("nereden");
            dr1.Tables[0].Columns.Add("nereye");
            string nereden, nereye;
            dt1 = vt.SorguCalistir("SELECT TerminalAdi FROM dbo.Terminaller where TerminalNo=" + Convert.ToInt32(Request.QueryString["nereden"]));
            nereden = dt1.Rows[0]["TerminalAdi"].ToString();
            dt1 = vt.SorguCalistir("SELECT TerminalAdi FROM dbo.Terminaller where TerminalNo=" + Convert.ToInt32(Request.QueryString["nereye"]));
            nereye = dt1.Rows[0]["TerminalAdi"].ToString();

            for (int i = 0; i < dr1.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToInt32(Request.QueryString["nereden"]) == 11 && (Convert.ToInt32(dr1.Tables[0].Rows[i]["GuzergahNo"]) == 3428 || Convert.ToInt32(dr1.Tables[0].Rows[i]["GuzergahNo"]) == 3432))
                {
                    TimeSpan satt = Convert.ToDateTime(dr1.Tables[0].Rows[i]["SeferSaati"]).TimeOfDay;
                    TimeSpan ekleneceksaat = TimeSpan.FromHours(4);
                    dr1.Tables[0].Rows[i]["SeferSaati"] = string.Format("{0:hh\\:mm}", satt.Add(ekleneceksaat));
                }
                else if ((Convert.ToInt32(Request.QueryString["nereden"]) == 11 || Convert.ToInt32(Request.QueryString["nereden"]) == 14) && (Convert.ToInt32(dr1.Tables[0].Rows[i]["GuzergahNo"]) == 2834 || Convert.ToInt32(dr1.Tables[0].Rows[i]["GuzergahNo"]) == 3234))
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
    }
}