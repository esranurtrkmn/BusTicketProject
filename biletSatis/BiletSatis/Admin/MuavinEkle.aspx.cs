using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletOtomasyon.Admin
{
    public partial class MuaveSofEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnMuavinEkle_Click(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            vt.MuavinEkleGuncelle(0, txtTCNO.Text, txtAd.Text, txtSoyad.Text, txtTelefonNo.Text,txtAdres.Text, Convert.ToBoolean(drpCinsiyet.SelectedIndex));
            txtAd.Text = "";
            txtAdres.Text = "";
            txtSoyad.Text = "";
            txtTCNO.Text = "";
            txtTelefonNo.Text = "";
            drpCinsiyet.SelectedValue=null;
        }
    }
}