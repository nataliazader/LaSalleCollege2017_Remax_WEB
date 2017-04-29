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
            if (txtCity.Text != "")
                where += " AND  Address like '%" + txtCity.Text + "%'";
            if (radGender.SelectedValue == "f")
                where += " AND Gender = 'f'";
            if (radGender.SelectedValue == "m")
                where += " AND Gender = 'm'";
            if (cboLanguages.Items.Count > 0)
                foreach (ListItem item in cboLanguages.Items)
                    where += "AND language = " + item.Value;
            //grvResult.DataSource = dbRemax.Employees.ToList();
            //grvResult.DataBind();
            lblWhere.Text = where;
        }
    }
}