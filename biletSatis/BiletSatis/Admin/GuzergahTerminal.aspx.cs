using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BiletOtomasyon.Admin
{
    public partial class GuzergahTerminal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void drpGuzergahlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            SqlConnection baglan = vt.baglan();
            SqlCommand komut = new SqlCommand();
            SqlCommand komut1 = new SqlCommand();
            komut.Connection = baglan;

            komut.CommandText = "SELECT dbo.GuzergahTerminal.GuzergahNo, dbo.GuzergahTerminal.TerminalSirasi, dbo.Terminaller.TerminalAdi FROM dbo.GuzergahTerminal INNER JOIN dbo.Terminaller ON dbo.GuzergahTerminal.TerminalNo = dbo.Terminaller.TerminalNo WHERE (dbo.GuzergahTerminal.GuzergahNo =" + Convert.ToInt32(drpGuzergahlar.SelectedValue) + ")";
            komut1.CommandText = "select * from dbo.Terminaller where TerminalNo not in (select TerminalNo from dbo.GuzergahTerminal where GuzergahNo=" + Convert.ToInt32(drpGuzergahlar.SelectedValue) + ")";
            baglan.Open();
            SqlDataReader dr = komut.ExecuteReader();
            lstTerminalSirasi.Items.Clear();
            while (dr.Read())
            {
                lstTerminalSirasi.Items.Add(Convert.ToString(dr["TerminalAdi"]));
            }
            dr.Close();
            baglan.Close();
            baglan.Dispose();
            komut.Dispose();


            SqlConnection baglan1 = vt.baglan();
            komut1.Connection = baglan1;
            baglan1.Open();
            SqlDataReader dr1 = komut1.ExecuteReader();
            lstTerminaller.Items.Clear();
            while (dr1.Read())
            {
                lstTerminaller.Items.Add(Convert.ToString(dr1["TerminalAdi"]));
            }

            dr1.Close();
            baglan1.Close();
            baglan1.Dispose();
            komut1.Dispose();
        }

        protected void btnTerminalEkle_Click(object sender, EventArgs e)
        {
            if (lstTerminaller.SelectedIndex != -1)
            {
                string terminaller = "";
                terminaller = (lstTerminaller.SelectedItem).ToString();
                lstTerminaller.Items.Remove(lstTerminaller.SelectedItem);
                lstTerminalSirasi.Items.Add(terminaller);
            }
        }

        protected void btnTerminalSil_Click(object sender, EventArgs e)
        {
            if (lstTerminalSirasi.SelectedIndex != -1)
            {
                string terminalsira = "";
                terminalsira = (lstTerminalSirasi.SelectedItem).ToString();
                lstTerminalSirasi.Items.Remove(lstTerminalSirasi.SelectedItem);
                lstTerminaller.Items.Add(terminalsira);
            }
        }

        protected void btnTerminalYukari_Click(object sender, EventArgs e)
        {
            MoveListboxItem(-1, lstTerminalSirasi);
        }


        protected void btnTerminalAsagi_Click(object sender, EventArgs e)
        {
            MoveListboxItem(1, lstTerminalSirasi);
        }
        private void MoveListboxItem(int index, ListBox listBox)
        {
            if (listBox.SelectedIndex != -1) //is there an item selected?
            {
                //if it's moving up, the loop moves from first to last, otherwise, it moves from last to first
                for (int i = (index < 0 ? 0 : listBox.Items.Count - 1); index < 0 ? i < listBox.Items.Count : i > -1; i -= index)
                {
                    if (listBox.Items[i].Selected)
                    {
                        //if it's moving up, it should not be the first item, or, if it's moving down, it should not be the last
                        if ((index < 0 && i > 0) || (index > 0 && i < listBox.Items.Count - 1))
                        {
                            //if it's moving up, the previous item should not be selected, or, if it's moving down, the following item should not be selected
                            if ((index < 0 && !listBox.Items[i - 1].Selected) || (index > 0 && !listBox.Items[i + 1].Selected))
                            {
                                ListItem itemA = listBox.Items[i]; //the selected item

                                listBox.Items.Remove(itemA); //is removed

                                listBox.Items.Insert(i + index, itemA);//and swapped
                            }
                        }
                    }
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            VeriTabani vt = new VeriTabani();
            SqlConnection baglan = vt.baglan();
            SqlCommand komut = new SqlCommand();
            SqlCommand komut1 = new SqlCommand();
            komut.Connection = baglan;
           



            int Guzergahno = Convert.ToInt32(drpGuzergahlar.SelectedValue);

            string[] terminalsirasi = new string[lstTerminalSirasi.Items.Count+1];
            int[] terminalsirasino = new int[lstTerminalSirasi.Items.Count];
            for (int i = 1; i < lstTerminalSirasi.Items.Count+1; i++)
            {
                terminalsirasi[i] = lstTerminalSirasi.Items[i-1].ToString();
            }

            for (int i = 0; i < lstTerminalSirasi.Items.Count; i++)
            {
                terminalsirasino[i] = terminalnumarasi(terminalsirasi[i+1]);
            }
            komut.CommandText = "DELETE FROM dbo.GuzergahTerminal where GuzergahNo="+Guzergahno+"";
            baglan.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglan.Close();
            
            using (SqlConnection baglan1 = vt.baglan()) {
                komut1.CommandText = "";
                komut1.Connection = baglan1;
                baglan1.Open();
                for (int i = 1; i < lstTerminalSirasi.Items.Count + 1; i++)
                    komut1.CommandText += "insert into GuzergahTerminal(GuzergahNo, TerminalNo, TerminalSirasi) values (" + Guzergahno + ", " + terminalsirasino[i - 1] + ", " + i + ");";
                komut1.ExecuteNonQuery();
                komut1.Dispose();
                baglan1.Close();
                komut1.Dispose();
                baglan1.Close();

            }
              
        }
        private int terminalnumarasi(string terminalismi)
        {
            VeriTabani vt = new VeriTabani();
            SqlConnection baglan = vt.baglan();
            SqlCommand komut = new SqlCommand();
            
            komut.Connection = baglan;
            int terminalnosu=0;
           
            komut.CommandText = "SELECT TerminalNo, TerminalAdi FROM dbo.Terminaller";
            baglan.Open();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
               
                if (terminalismi==dr["TerminalAdi"].ToString())
                {
                    terminalnosu =Convert.ToInt32(dr["TerminalNo"]);
                    break;
                }
            }

            dr.Close();
            baglan.Close();
            baglan.Dispose();
            komut.Dispose();
            return terminalnosu;
        }

    }

}