using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletOtomasyon.Admin
{
    public partial class SoforAtama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSoforAta_Click(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            vt.SoforAtama(Convert.ToInt32(drpSeferler.SelectedValue), Convert.ToInt32(drpSoforler.SelectedValue));
            drpSoforler.SelectedValue = null;
            drpSeferler.SelectedValue = null;
        }
    }
}