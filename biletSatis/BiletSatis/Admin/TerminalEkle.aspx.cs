using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletOtomasyon.Admin
{
    public partial class TerminalEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTerminalEkle_Click(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            vt.TerminalEkleGuncelle(0, txtTerminalAdi.Text, Convert.ToInt32(txtIlkodu.Text));
            txtTerminalAdi.Text = "";
            txtIlkodu.Text = "";
            Response.Write("<script>alert('Yeni Terminal eklendi!')</script>");
        }
    }
}