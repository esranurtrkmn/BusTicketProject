using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletOtomasyon.Admin
{
    public partial class KullaniciEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            vt.DuzenleyenEkleGuncelle(0, txtTCNO.Text, txtAd.Text, txtSoyad.Text, txtTelefonNo.Text, txtMail.Text, Convert.ToBoolean(drpCinsiyet.SelectedIndex));
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtMail.Text = "";
            txtTCNO.Text = "";
            txtTelefonNo.Text = "";
            drpCinsiyet.SelectedValue = null;
            Response.Write("<script>alert('Yeni Kullanıcı eklendi!')</script>");
        }
    }
}