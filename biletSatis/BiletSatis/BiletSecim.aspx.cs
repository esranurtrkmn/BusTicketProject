using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BiletOtomasyon
{
    public partial class BiletSecim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BiletSecim1.Visible = false;
                BiletSecim2.Visible = false;
                BiletSecim3.Visible = false;
                Odeme.Visible = false;
                KoltuklarıListele();
            }
        }
        public void KoltuklarıListele()
        {
            VeriTabani vt = new VeriTabani();
            DataTable dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet, dbo.Biletler.FiyatNo, dbo.Biletler.KoltukNumarasi FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where AktifMi=1 and dbo.Biletler.SeferNo=" + Convert.ToInt32(Request.QueryString["SeferNo"]));
            DataTable dt2 = new DataTable();
            dt2 = vt.SorguCalistir("select * from Seferler where SeferNo = " + Convert.ToInt32(Request.QueryString["SeferNo"]));
            int GuzergahNo = Convert.ToInt32(dt2.Rows[0]["GuzergahNo"]);
            dt2 = vt.SorguCalistir("SELECT BaslamaTerminali, BitisTerminali FROM dbo.Fiyatlar where FiyatNo=" + Convert.ToInt32(Request.QueryString["FiyatNo"]));
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
                            btnK1.CssClass = "btn btn-red";
                        else
                            btnK1.CssClass = "btn btn-blue";
                        btnK1.Enabled = false;
                    }
                    else if (btnK2.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK2.CssClass = "btn btn-red";
                        else
                            btnK2.CssClass = "btn btn-blue";
                        btnK2.Enabled = false;
                    }
                    else if (btnK3.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK3.CssClass = "btn btn-red";
                        else
                            btnK3.CssClass = "btn btn-blue";
                        btnK3.Enabled = false;
                    }
                    else if (btnK4.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK4.CssClass = "btn btn-red";
                        else
                            btnK4.CssClass = "btn btn-blue";
                        btnK4.Enabled = false;
                    }
                    else if (btnK5.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK5.CssClass = "btn btn-red";
                        else
                            btnK5.CssClass = "btn btn-blue";
                        btnK5.Enabled = false;
                    }
                    else if (btnK6.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK6.CssClass = "btn btn-red";
                        else
                            btnK6.CssClass = "btn btn-blue";
                        btnK6.Enabled = false;
                    }
                    else if (btnK7.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK7.CssClass = "btn btn-red";
                        else
                            btnK7.CssClass = "btn btn-blue";
                        btnK7.Enabled = false;
                    }
                    else if (btnK8.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK8.CssClass = "btn btn-red";
                        else
                            btnK8.CssClass = "btn btn-blue";
                        btnK8.Enabled = false;
                    }
                    else if (btnK9.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK9.CssClass = "btn btn-red";
                        else
                            btnK9.CssClass = "btn btn-blue";
                        btnK9.Enabled = false;
                    }
                    else if (btnK10.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK10.CssClass = "btn btn-red";
                        else
                            btnK10.CssClass = "btn btn-blue";
                        btnK10.Enabled = false;
                    }
                    else if (btnK11.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK11.CssClass = "btn btn-red";
                        else
                            btnK11.CssClass = "btn btn-blue";
                        btnK11.Enabled = false;
                    }
                    else if (btnK12.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK12.CssClass = "btn btn-red";
                        else
                            btnK12.CssClass = "btn btn-blue";
                        btnK12.Enabled = false;
                    }
                    else if (btnK13.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK13.CssClass = "btn btn-red";
                        else
                            btnK13.CssClass = "btn btn-blue";
                        btnK13.Enabled = false;
                    }
                    else if (btnK14.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK14.CssClass = "btn btn-red";
                        else
                            btnK14.CssClass = "btn btn-blue";
                        btnK14.Enabled = false;
                    }
                    else if (btnK15.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK15.CssClass = "btn btn-red";
                        else
                            btnK15.CssClass = "btn btn-blue";
                        btnK15.Enabled = false;
                    }
                    else if (btnK16.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK16.CssClass = "btn btn-red";
                        else
                            btnK16.CssClass = "btn btn-blue";
                        btnK16.Enabled = false;
                    }
                    else if (btnK17.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK17.CssClass = "btn btn-red";
                        else
                            btnK17.CssClass = "btn btn-blue";
                        btnK17.Enabled = false;
                    }
                    else if (btnK18.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK18.CssClass = "btn btn-red";
                        else
                            btnK18.CssClass = "btn btn-blue";
                        btnK18.Enabled = false;
                    }
                    else if (btnK19.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK19.CssClass = "btn btn-red";
                        else
                            btnK19.CssClass = "btn btn-blue";
                        btnK19.Enabled = false;
                    }
                    else if (btnK20.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK20.CssClass = "btn btn-red";
                        else
                            btnK20.CssClass = "btn btn-blue";
                        btnK20.Enabled = false;
                    }
                    else if (btnK21.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK21.CssClass = "btn btn-red";
                        else
                            btnK21.CssClass = "btn btn-blue";
                        btnK21.Enabled = false;
                    }
                    else if (btnK22.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK22.CssClass = "btn btn-red";
                        else
                            btnK22.CssClass = "btn btn-blue";
                        btnK22.Enabled = false;
                    }
                    else if (btnK23.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK23.CssClass = "btn btn-red";
                        else
                            btnK23.CssClass = "btn btn-blue";
                        btnK23.Enabled = false;
                    }
                    else if (btnK24.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK24.CssClass = "btn btn-red";
                        else
                            btnK24.CssClass = "btn btn-blue";
                        btnK24.Enabled = false;
                    }
                    else if (btnK25.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK25.CssClass = "btn btn-red";
                        else
                            btnK25.CssClass = "btn btn-blue";
                        btnK25.Enabled = false;
                    }
                    else if (btnK26.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK26.CssClass = "btn btn-red";
                        else
                            btnK26.CssClass = "btn btn-blue";
                        btnK26.Enabled = false;
                    }
                    else if (btnK27.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK27.CssClass = "btn btn-red";
                        else
                            btnK27.CssClass = "btn btn-blue";

                        btnK27.Enabled = false;
                    }
                    else if (btnK28.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK28.CssClass = "btn btn-red";
                        else
                            btnK28.CssClass = "btn btn-blue";
                        btnK28.Enabled = false;
                    }
                    else if (btnK29.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK29.CssClass = "btn btn-red";
                        else
                            btnK29.CssClass = "btn btn-blue";
                        btnK29.Enabled = false;
                    }
                    else if (btnK30.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK30.CssClass = "btn btn-red";
                        else
                            btnK30.CssClass = "btn btn-blue";
                        btnK30.Enabled = false;
                    }
                    else if (btnK31.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK31.CssClass = "btn btn-red";
                        else
                            btnK31.CssClass = "btn btn-blue";
                        btnK31.Enabled = false;
                    }
                    else if (btnK32.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK32.CssClass = "btn btn-red";
                        else
                            btnK32.CssClass = "btn btn-blue";
                        btnK32.Enabled = false;
                    }
                    else if (btnK33.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK33.CssClass = "btn btn-red";
                        else
                            btnK33.CssClass = "btn btn-blue";
                        btnK33.Enabled = false;
                    }
                    else if (btnK34.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK34.CssClass = "btn btn-red";
                        else
                            btnK34.CssClass = "btn btn-blue";
                        btnK34.Enabled = false;
                    }
                    else if (btnK35.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK35.CssClass = "btn btn-red";
                        else
                            btnK35.CssClass = "btn btn-blue";
                        btnK35.Enabled = false;
                    }
                    else if (btnK36.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK36.CssClass = "btn btn-red";
                        else
                            btnK36.CssClass = "btn btn-blue";
                        btnK36.Enabled = false;
                    }
                    else if (btnK37.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK37.CssClass = "btn btn-red";
                        else
                            btnK37.CssClass = "btn btn-blue";
                        btnK37.Enabled = false;
                    }
                    else if (btnK38.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK38.CssClass = "btn btn-red";
                        else
                            btnK38.CssClass = "btn btn-blue";
                        btnK38.Enabled = false;
                    }
                    else if (btnK39.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK39.CssClass = "btn btn-red";
                        else
                            btnK39.CssClass = "btn btn-blue";
                        btnK39.Enabled = false;
                    }
                    else if (btnK40.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK40.CssClass = "btn btn-red";
                        else
                            btnK40.CssClass = "btn btn-blue";
                        btnK40.Enabled = false;
                    }
                    else if (btnK41.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK41.CssClass = "btn btn-red";
                        else
                            btnK41.CssClass = "btn btn-blue";
                        btnK41.Enabled = false;
                    }
                    else if (btnK42.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK42.CssClass = "btn btn-red";
                        else
                            btnK42.CssClass = "btn btn-blue";
                        btnK42.Enabled = false;
                    }
                    else if (btnK43.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK43.CssClass = "btn btn-red";
                        else
                            btnK43.CssClass = "btn btn-blue";
                        btnK43.Enabled = false;
                    }
                    else if (btnK44.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK44.CssClass = "btn btn-red";
                        else
                            btnK44.CssClass = "btn btn-blue";
                        btnK44.Enabled = false;
                    }
                    else if (btnK45.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK45.CssClass = "btn btn-red";
                        else
                            btnK45.CssClass = "btn btn-blue";
                        btnK45.Enabled = false;
                    }
                    else if (btnK46.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK46.CssClass = "btn btn-red";
                        else
                            btnK46.CssClass = "btn btn-blue";
                        btnK46.Enabled = false;
                    }
                    else if (btnK47.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK47.CssClass = "btn btn-red";
                        else
                            btnK47.CssClass = "btn btn-blue";
                        btnK47.Enabled = false;
                    }
                    else if (btnK48.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK48.CssClass = "btn btn-red";
                        else
                            btnK48.CssClass = "btn btn-blue";
                        btnK48.Enabled = false;
                    }
                    else if (btnK49.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK49.CssClass = "btn btn-red";
                        else
                            btnK49.CssClass = "btn btn-blue";
                        btnK49.Enabled = false;
                    }
                    else if (btnK50.Text == dt.Rows[i]["KoltukNumarasi"].ToString())
                    {
                        if (Convert.ToInt32(dt.Rows[i]["Cinsiyet"]) == 0)
                            btnK50.CssClass = "btn btn-red";
                        else
                            btnK50.CssClass = "btn btn-blue";
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
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk1.Text) - 1) + " and dbo.Biletler.SeferNo=" + Convert.ToInt32(Request.QueryString["SeferNo"]));
                    else
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk1.Text) + 1) + " and dbo.Biletler.SeferNo=" + Convert.ToInt32(Request.QueryString["SeferNo"]));

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
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk2.Text) - 1) + " and dbo.Biletler.SeferNo=" + Convert.ToInt32(Request.QueryString["SeferNo"]));
                    else
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk2.Text) + 1) + " and dbo.Biletler.SeferNo=" + Convert.ToInt32(Request.QueryString["SeferNo"]));

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
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk3.Text) - 1) + " and dbo.Biletler.SeferNo=" + Convert.ToInt32(Request.QueryString["SeferNo"]));
                    else
                        dt = vt.SorguCalistir(" SELECT dbo.Yolcular.Cinsiyet FROM dbo.Yolcular INNER JOIN dbo.Biletler ON dbo.Yolcular.YolcuNo = dbo.Biletler.YolcuNo where  dbo.Biletler.KoltukNumarasi =" + (Convert.ToInt32(txtSecilenKoltuk3.Text) + 1) + " and dbo.Biletler.SeferNo=" + Convert.ToInt32(Request.QueryString["SeferNo"]));

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
        protected void btnBiletSatinAl_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string Metin = "";
                VeriTabani vt = new VeriTabani();
                int YeniYolcu1, YeniYolcu2, YeniYolcu3;
                int Sonuc1, Sonuc2, Sonuc3;
                DataTable dw = vt.SorguCalistir("select TerminalAdi from Terminaller where TerminalNo in  (SELECT  BaslamaTerminali  FROM dbo.Fiyatlar WHERE (FiyatNo = "+ Convert.ToInt32(Request.QueryString["FiyatNo"])+")) UNION select TerminalAdi from Terminaller where TerminalNo in  (SELECT  BitisTerminali  FROM dbo.Fiyatlar WHERE (FiyatNo = " + Convert.ToInt32(Request.QueryString["FiyatNo"]) + "))");
                Metin = Request.QueryString["SeferNo"].ToString() + " SeferNolu ";
                if (txtSecilenKoltuk1.Text != "")
                {
                    if (cinsiyet1 != -1)
                        YeniYolcu1 = vt.YolcuEkleDuzenle(0, txtYolcuTC1.Text, txtYolcuAdi1.Text, txtYolcuSoyadi1.Text, txtTelefon1.Text, txtEposta1.Text, Convert.ToBoolean(drpCinsiyet1.SelectedIndex));
                    else
                        YeniYolcu1 = vt.YolcuEkleDuzenle(0, txtYolcuTC1.Text, txtYolcuAdi1.Text, txtYolcuSoyadi1.Text, txtTelefon1.Text, txtEposta1.Text, Convert.ToBoolean(cinsiyet1));

                    Sonuc1 = vt.BiletEkleDuzenle(0, Convert.ToInt32((Request.QueryString["SeferNo"])), YeniYolcu1, DateTime.Now.Date, Convert.ToInt32(Request.QueryString["FiyatNo"]), 1, true, Convert.ToInt32(txtSecilenKoltuk1.Text), 1);
                    Metin += "\\n" + txtSecilenKoltuk1.Text + "  Koltuk Numaralı " + txtYolcuAdi1.Text + " " + txtYolcuSoyadi1.Text + " ";
                }
                if (txtSecilenKoltuk2.Text != "")
                {
                    if (cinsiyet2 != -1)
                        YeniYolcu2 = vt.YolcuEkleDuzenle(0, txtYolcuTC2.Text, txtYolcuAdi2.Text, txtYolcuSoyadi2.Text, txtTelefon2.Text, txtEposta2.Text, Convert.ToBoolean(drpCinsiyet2.SelectedIndex));
                    else
                        YeniYolcu2 = vt.YolcuEkleDuzenle(0, txtYolcuTC2.Text, txtYolcuAdi2.Text, txtYolcuSoyadi2.Text, txtTelefon2.Text, txtEposta2.Text, Convert.ToBoolean(cinsiyet2));

                    Sonuc2 = vt.BiletEkleDuzenle(0, Convert.ToInt32(Request.QueryString["SeferNo"]), YeniYolcu2, DateTime.Now.Date, Convert.ToInt32(Request.QueryString["FiyatNo"]), 1, true, Convert.ToInt32(txtSecilenKoltuk2.Text), 1);
                    Metin += "\\n" + txtSecilenKoltuk2.Text + "  Koltuk Numaralı " + txtYolcuAdi2.Text + " " + txtYolcuSoyadi2.Text + " ";

                }
                if (txtSecilenKoltuk3.Text != "")
                {
                    if (cinsiyet3 != -1)
                        YeniYolcu3 = vt.YolcuEkleDuzenle(0, txtYolcuTC3.Text, txtYolcuAdi3.Text, txtYolcuSoyadi3.Text, txtTelefon3.Text, txtEposta3.Text, Convert.ToBoolean(drpCinsiyet3.SelectedIndex));
                    else
                        YeniYolcu3 = vt.YolcuEkleDuzenle(0, txtYolcuTC3.Text, txtYolcuAdi3.Text, txtYolcuSoyadi3.Text, txtTelefon3.Text, txtEposta3.Text, Convert.ToBoolean(drpCinsiyet3));
                    Sonuc3 = vt.BiletEkleDuzenle(0, Convert.ToInt32(Request.QueryString["SeferNo"]), YeniYolcu3, DateTime.Now.Date, Convert.ToInt32(Request.QueryString["FiyatNo"]), 1, true, Convert.ToInt32(txtSecilenKoltuk3.Text), 1);
                    Metin += "\\n" + txtSecilenKoltuk3.Text + " Koltuk Numaralı  " + txtYolcuAdi3.Text + " " + txtYolcuSoyadi3.Text + " ";

                }
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + Metin + "')", true);
            }
            else
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Biletiniz İptal Ettiniz')", true);
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
