using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletOtomasyon
{
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string adi = Request.Form["ad"].ToString();
            string sifre = Request.Form["sifre"].ToString();
            Response.Redirect("Default.aspx");
        }
    }
}