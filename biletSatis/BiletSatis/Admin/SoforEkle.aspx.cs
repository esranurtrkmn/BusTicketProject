using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletOtomasyon.Admin
{
    public partial class SoforEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSoforEkle_Click(object sender, EventArgs e)
        {
            
            VeriTabani vt = new VeriTabani();
            vt.SoforEkleGuncelle(0, txtTCNO.Text, txtAd.Text, txtSoyad.Text, txtTelefonNo.Text,txtMail.Text);
            txtAd.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            txtTCNO.Text = "";
            txtTelefonNo.Text = "";
            Response.Write("<script>alert('Yeni şöför eklendi!')</script>");
        }
    }
}