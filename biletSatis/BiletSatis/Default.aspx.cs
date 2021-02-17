using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletOtomasyon
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnListele_Click(object sender, EventArgs e)
        {
            Response.Redirect("Seferler.aspx?nereden=" + drpNereden.SelectedValue + "&nereye=" + drpNereye.SelectedValue + "&Tarih=" + Calendar1.SelectedDate.ToString("yyyy-MM-dd"));
        }
    }
}