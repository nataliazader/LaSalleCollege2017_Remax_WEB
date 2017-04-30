using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppRemax
{
    public partial class Agents : System.Web.UI.Page
    {
        private static REntities dbRemax;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResult.Text = "";
            dbRemax = new REntities();
        }

        protected void btnLanguages_Click(object sender, EventArgs e)
        {
            cboLanguages.DataSource = dbRemax.Languages.ToList();
            cboLanguages.DataTextField = "Language";
            cboLanguages.DataValueField = "refLanguage";
            cboLanguages.DataBind();
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            string where = " WHERE Role = 'Agent' ";
            string whereLang =" WHERE 1=1 ";
            string inRefEmp = "";
            if (txtCity.Text != "")
                where += " AND  Address like '%" + txtCity.Text + "%'";
            if (radGender.SelectedValue == "f")
                where += " AND Gender = 'f'";
            if (radGender.SelectedValue == "m")
                where += " AND Gender = 'm'";
            if (cboLanguages.Items.Count > 0)
            {
                inRefEmp = " ( ";
                foreach (ListItem item in cboLanguages.Items)
                    if (item.Selected)
                        whereLang += " AND referLanguage = " + item.Value;
                foreach (AgentLanguages agent in dbRemax.AgentLanguages.SqlQuery("SELECT * FROM AgentLanguages " + whereLang))
                    inRefEmp += agent.referEmployee + ",";
                inRefEmp = inRefEmp.TrimEnd(',');
                inRefEmp += " )";
                where += " AND refEmployee IN " + inRefEmp;
             }
            string info = "";
            foreach (Employees emp in dbRemax.Employees.SqlQuery("SELECT * FROM Employees " + where))
            {
                info += "<div class='col-md-4'>";

                foreach (Photos photo in dbRemax.Photos)
                    if (emp.refEmployee == photo.referAgent)
                        info += "<p><img src='/Images/Agents/" + photo.Photo + ".jpg' style='width:200px'/></p>";

                info += "<h2>" + emp.Name + "</h2>";
                info += "<p> Phone : " + emp.Phone + "</p>";
                info += "<p> Email : " + emp.Email + "</p>";
                info += "<p> Adress : " + emp.Address+ "</p>";
                foreach(AgentLanguages alang in dbRemax.AgentLanguages)
                    if(emp.refEmployee == alang.referEmployee)
                        foreach(Languages lang in dbRemax.Languages)
                            if(lang.refLanguage==alang.referLanguage)
                                info += "<p>" + lang.Language + "</p>";
                info += "<p style='margin-top:20px'><a class='btn btn-default' href='/Message?id="+emp.refEmployee+"'>Send a message &raquo;</a></p>";
                info += "</div>";
            }

            //grvResult.DataSource = dbRemax.Employees.SqlQuery("SELECT * FROM Employees " + where).ToList();
            //grvResult.DataBind();

            lblResult.Text = info;
        }
    }
}