using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebAppRemax
{
    public partial class _Default : Page
    {
        private static REntities dbRemax;
        protected void Page_Load(object sender, EventArgs e)
        {
            string info="";
            if (!IsPostBack)
            {
                lblHouses.Text = "";
                dbRemax = new REntities();
                foreach (ViewHouses house in dbRemax.ViewHouses)
                {
                    info += "<div class='col-md-4'><h2>" + house.Name + "</h2><p>" + house.Description + "</p>";
                    info += "<p> Year : "+house.Year+"</p>";
                    info += "<p> Net Area : " + house.NetArea + "</p>";
                    info += "<p> Price : " + house.Price + "</p>";
                    info += "<p> Building Type : " + house.Building + "</p>";
                    info += "<p> Property Type : " + house.Property + "</p>";
                    info += "<p> Bedrooms : " + house.Bedrooms + "</p>";
                    info += "<p> Parking : " + house.Parking + "</p>";
                    info += (house.Pool==true) ?"<p>Pool</p>" : "";
                    info += (house.Water == true) ? "<p>Waterfront</p>" : "";
                    info += (house.Elevator == true) ? "<p>Elevator</p>" : "";
                    info += (house.Mobility == true) ? "<p>Reduced Mobility</p>" : "";
                    foreach (Images img in dbRemax.Images)
                        if (img.referHouse == house.Id)
                            info += "<img src='/Images/Houses/"+img.image.Trim()+".jpg' width='50px'/>";

                    info += "<p style='margin-top:20px'><a class='btn btn-default' href='#'>Learn more &raquo;</a></p>";
                   info +="</div>";
                }


                lblHouses.Text = info;
            }
        }
 
    }
}