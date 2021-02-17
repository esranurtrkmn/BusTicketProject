using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletOtomasyon.Admin
{
    public partial class MuavinAtama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMuavinAta_Click(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            vt.MuavinAtama(Convert.ToInt32(drpSeferler.SelectedValue), Convert.ToInt32(drpMuavinler.SelectedValue));
            drpMuavinler.SelectedValue = null;
            drpSeferler.SelectedValue = null;
        }
    }
}