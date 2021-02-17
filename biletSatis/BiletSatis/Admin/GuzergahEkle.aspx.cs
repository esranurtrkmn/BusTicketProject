using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletOtomasyon.Admin
{
    public partial class GuzergahEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuzergahEkle_Click(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            vt.GuzergahEkleGuncelle(Convert.ToInt32(txtGuzergahNo.Text), txtGuzergahAdi.Text);
            txtGuzergahNo.Text = "";
            txtGuzergahAdi.Text = "";
            Response.Write("<script>alert('Yeni Güzergah eklendi!')</script>");
        }
    }
}