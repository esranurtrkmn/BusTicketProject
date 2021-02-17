using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace BiletOtomasyon.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DuzenleyenNo"] == null)
                Response.Redirect("~/Giris.aspx");
            else
            {
                VeriTabani vt = new VeriTabani();
                DataTable dt = vt.SorguCalistir("select * from Duzenleyenler where DuzenleyenNo=" + Convert.ToInt32(Session["DuzenleyenNo"]));
                HesapAdi.Text = dt.Rows[0]["Ad"].ToString();
            }
        }

        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session["DuzenleyenNo"] = null;
            Response.Redirect("~/Defaults.aspx");
        }
    }
}