using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BiletOtomasyon
{
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            DataTable dt = vt.SorguCalistir("select * from Duzenleyenler where TC ='" + txtKullaniciAdi.Text + "' AND Soyad='" + txtParola.Text + "'");
            if(dt.Rows.Count ==0 )
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Kullanıcı adı veya şifre Hatalı')", true);
            else if (Convert.ToInt32(dt.Rows[0]["DuzenleyenNo"]) < 2)
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Kullanıcı adı veya şifre Hatalı')", true);
            else
            {
                Session["DuzenleyenNo"] = Convert.ToInt32(Convert.ToInt32(dt.Rows[0]["DuzenleyenNo"]));
                Response.Redirect("~/admin/Default.aspx");
            }
        }
    }
}
