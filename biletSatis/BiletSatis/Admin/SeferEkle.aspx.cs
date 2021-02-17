using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletOtomasyon.Admin
{
    public partial class SeferEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSeferTarih.Text = DateTime.Today.ToShortDateString();
        }
        protected void DateChange(object sender, EventArgs e)
        {
            txtSeferTarih.Text = clnSeferTarih.SelectedDate.ToShortDateString();
        }
    }
}