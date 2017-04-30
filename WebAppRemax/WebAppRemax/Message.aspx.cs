using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppRemax
{
    public partial class Message : System.Web.UI.Page
    {
        private static REntities dbRemax;
        private static string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAgent.Text = "";
            id = Request.QueryString["id"];
            dbRemax = new REntities();
            string info = "";
            string sql = "SELECT * FROM Employees WHERE refEmployee = " + id;
            Employees emp = dbRemax.Employees.SqlQuery(sql).Single();

            info += "<div class='col-md-4' style='margin-top:20px'>";

            foreach (Photos photo in dbRemax.Photos)
                if (emp.refEmployee == photo.referAgent)
                    info += "<p><img src='/Images/Agents/" + photo.Photo + ".jpg' style='width:200px'/></p>";

            info += "<h2>" + emp.Name + "</h2>";
            info += "<p> Phone : " + emp.Phone + "</p>";
            info += "<p> Email : " + emp.Email + "</p>";
            info += "<p> Adress : " + emp.Address + "</p>";
            foreach (AgentLanguages alang in dbRemax.AgentLanguages)
                if (emp.refEmployee == alang.referEmployee)
                    foreach (Languages lang in dbRemax.Languages)
                        if (lang.refLanguage == alang.referLanguage)
                            info += "<p>" + lang.Language + "</p>";
            info += "</div>";
            lblAgent.Text = info;
            lblMessage.Text = "";
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Messages msg = new Messages();
            msg.Message = txtMessage.Text;
            msg.SenderEmail = txtEmail.Text;
            msg.SenderPhone = txtPhone.Text;
            msg.SenderName = txtName.Text;
            msg.referAgent = Convert.ToInt32(id);

            dbRemax.Messages.Add(msg);
            dbRemax.SaveChanges();

            txtMessage.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtName.Text = "";

            lblMessage.Text = "*Message has been sent.";
        }
    }
}