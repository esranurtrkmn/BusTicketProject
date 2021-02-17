using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BiletOtomasyon.Admin
{
    public partial class Biletler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void BiletListele()
        {
            VeriTabani vt = new VeriTabani();
            string Sorgu = "SELECT dbo.Biletler.BiletNo, dbo.Seferler.SeferNo, dbo.Biletler.FiyatNo, dbo.Guzergahlar.GuzergahAdi, dbo.Seferler.SeferTarihi,  dbo.Yolcular.Ad +' '+ dbo.Yolcular.Soyad As [Ad Soyad], dbo.Biletler.KoltukNumarasi, dbo.Biletler.OdemeTipi,  dbo.Fiyatlar.Ucret, dbo.Duzenleyenler.Ad as Duzenleyen FROM dbo.Biletler INNER JOIN dbo.Fiyatlar ON dbo.Biletler.FiyatNo = dbo.Fiyatlar.FiyatNo INNER JOIN dbo.Seferler ON dbo.Biletler.SeferNo = dbo.Seferler.SeferNo INNER JOIN dbo.Guzergahlar ON dbo.Seferler.GuzergahNo = dbo.Guzergahlar.GuzergahNo INNER JOIN dbo.Yolcular ON dbo.Biletler.YolcuNo = dbo.Yolcular.YolcuNo INNER JOIN dbo.Duzenleyenler ON dbo.Biletler.DuzenleyenNo = dbo.Duzenleyenler.DuzenleyenNo where dbo.Seferler.SeferNo="+Convert.ToInt32(drpSefer.SelectedItem.Value);
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataSet dr1 = vt.SorguCalistirDataSet(Sorgu);
            dr1.Tables[0].Columns.Add("Nereden");
            dr1.Tables[0].Columns.Add("Nereye");
            string nereden, nereye;
            for (int i = 0; i < dr1.Tables[0].Rows.Count; i++)
            {
                dt2 = vt.SorguCalistir("select * from Fiyatlar");
                dt1 = vt.SorguCalistir("SELECT TerminalAdi FROM dbo.Terminaller where TerminalNo=" + Convert.ToInt32(dt2.Rows[0]["BaslamaTerminali"]));
                nereden = dt1.Rows[0]["TerminalAdi"].ToString();
                dt1 = vt.SorguCalistir("SELECT TerminalAdi FROM dbo.Terminaller where TerminalNo=" + Convert.ToInt32(dt2.Rows[0]["BitisTerminali"]));
                nereye = dt1.Rows[0]["TerminalAdi"].ToString();
                dr1.Tables[0].Rows[i]["Nereden"] = nereden;
                dr1.Tables[0].Rows[i]["Nereye"] = nereye;
            }
            BoundField sutun11 = new BoundField();
            sutun11.HeaderText = "BiletNo";
            sutun11.DataField = "BiletNo";
            GridViewBiletler.Columns.Add(sutun11);

            BoundField sutun1 = new BoundField();
            sutun1.HeaderText = "SeferNo";
            sutun1.DataField = "SeferNo";
            GridViewBiletler.Columns.Add(sutun1);

            BoundField sutun2 = new BoundField();
            sutun2.HeaderText = "GuzergahAdi";
            sutun2.DataField = "GuzergahAdi";
            GridViewBiletler.Columns.Add(sutun2);

            BoundField sutun3 = new BoundField();
            sutun3.HeaderText = "SeferTarihi";
            sutun3.DataField = "SeferTarihi";
            GridViewBiletler.Columns.Add(sutun3);
            BoundField sutun4 = new BoundField();
            sutun4.HeaderText = "Nereden";
            sutun4.DataField = "Nereden";
            GridViewBiletler.Columns.Add(sutun4);

            BoundField sutun5 = new BoundField();
            sutun5.HeaderText = "Nereye";
            sutun5.DataField = "Nereye";
            GridViewBiletler.Columns.Add(sutun5);

            BoundField sutun6 = new BoundField();
            sutun6.HeaderText = "Ad Soyad";
            sutun6.DataField = "Ad Soyad";
            GridViewBiletler.Columns.Add(sutun6);

            BoundField sutun7= new BoundField();
            sutun7.HeaderText = "KoltukNumarasi";
            sutun7.DataField = "KoltukNumarasi";
            GridViewBiletler.Columns.Add(sutun7);

            BoundField sutun8 = new BoundField();
            sutun8.HeaderText = "OdemeTipi";
            sutun8.DataField = "OdemeTipi";
            GridViewBiletler.Columns.Add(sutun8);

            BoundField sutun9 = new BoundField();
            sutun9.HeaderText = "Ucret";
            sutun9.DataField = "Ucret";
            GridViewBiletler.Columns.Add(sutun9);

            BoundField sutun10 = new BoundField();
            sutun10.HeaderText = "Duzenleyen";
            sutun10.DataField = "Duzenleyen";
            GridViewBiletler.Columns.Add(sutun10);


            dr1.Tables[0].DefaultView.Sort = "KoltukNumarasi";
            DataView dataView = dr1.Tables[0].DefaultView;
            dataView.Sort = "KoltukNumarasi";
            DataTable dtSortedAsc = dataView.ToTable();

            dataView.Sort = "KoltukNumarasi asc";
            DataTable dtSortedDesc = dataView.ToTable();
            GridViewBiletler.DataSource = dtSortedDesc;
            GridViewBiletler.DataBind();
        }

        protected void drpSefer_SelectedIndexChanged(object sender, EventArgs e)
        {
            BiletListele();
        }

        protected void drpSefer_DataBound(object sender, EventArgs e)
        {
            drpSefer.Items.Insert(0, new ListItem  ("Seçiniz" ,"-1"));
        }
    }
}