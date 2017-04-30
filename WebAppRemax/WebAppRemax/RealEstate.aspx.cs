using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebAppRemax
{
    public partial class RealEstate : System.Web.UI.Page
    {
        private static REntities dbRemax;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                dbRemax = new REntities();

                ddlBuilding.Items.Add(new ListItem("Select", "-1"));

                foreach(BuildingType b in dbRemax.BuildingType)
                    ddlBuilding.Items.Add(new ListItem(b.Building,b.refBuildingType.ToString()));


                ddlProperty.Items.Add(new ListItem("Select", "-1"));
                foreach(PropertyType p in dbRemax.PropertyType)
                    ddlProperty.Items.Add(new ListItem(p.Property,p.refPropertyType.ToString()));

                ddlBedroom.Items.Add(new ListItem("Select", "-1"));
                foreach(NumBedrooms b in dbRemax.NumBedrooms)
                    ddlBedroom.Items.Add(new ListItem(b.Bedrooms,b.refNumBedrooms.ToString()));

                ddlParking.Items.Add(new ListItem("Select", "-1"));
                foreach(NumParking p in dbRemax.NumParking)
                    ddlParking.Items.Add(new ListItem(p.Parking,p.refNumParking.ToString()));


                ddlLowerPrice.Items.Add(new ListItem("Lower Price Limit", "-1"));
                ddlUpperPrice.Items.Add(new ListItem("Upper Price Limit", "-1"));
                for (int price = 0; price < 10000001; price += 100000)
                    ddlLowerPrice.Items.Add(new ListItem(price.ToString(),price.ToString()));

                for (int price = 100000; price < 10000001; price += 100000)
                    ddlUpperPrice.Items.Add(new ListItem(price.ToString(), price.ToString()));

                ddlLowerNetArea.Items.Add(new ListItem("Lower Net Area","-1"));
                for (int netA = 0; netA < 100001; netA += 1000)
                    ddlLowerNetArea.Items.Add(new ListItem(netA.ToString(), netA.ToString()));

                ddlUpperNetArea.Items.Add(new ListItem("Upper Net Area", "-1"));
                for (int netA = 0; netA < 100001; netA += 1000)
                    ddlUpperNetArea.Items.Add(new ListItem(netA.ToString(), netA.ToString()));

                ddlLowerYear.Items.Add(new ListItem("Lower Year", "-1"));
                for (int year = 1800; year < DateTime.Now.Year + 10; year += 10)
                    ddlLowerYear.Items.Add(new ListItem(year.ToString(), year.ToString()));

                ddlUpperYear.Items.Add(new ListItem("Upper Year", "-1"));
                for (int year = 1800; year < DateTime.Now.Year + 10; year += 10)
                    ddlUpperYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                lblResult.Text = "";
            }
            
        }

        protected void ddlLowerPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ddlUpperPrice.SelectedValue;
            ddlUpperPrice.Items.Clear();
            ddlUpperPrice.Items.Add(new ListItem("Upper Price Limit", "-1"));
            for (int price = (Convert.ToInt32(value) !=-1 ) ? Convert.ToInt32(ddlLowerPrice.SelectedValue):0; price < 10000001; price += 100000)
                ddlUpperPrice.Items.Add(new ListItem(price.ToString(), price.ToString()));
            if (Convert.ToInt32(value) != -1)
                ddlUpperPrice.Items.FindByValue(value).Selected = true;
        }

        protected void ddlUpperPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ddlLowerPrice.SelectedValue;
            ddlLowerPrice.Items.Clear();
            ddlLowerPrice.Items.Add(new ListItem("Lower Price Limit", "-1"));
            int max = (Convert.ToInt32(ddlUpperPrice.SelectedValue) != -1) ? Convert.ToInt32(ddlUpperPrice.SelectedValue) : 10000001;
            for (int price=0; price < max; price+=100000)
                ddlLowerPrice.Items.Add(new ListItem(price.ToString(), price.ToString()));
            if (Convert.ToInt32(value) != -1)
                ddlLowerPrice.Items.FindByValue(value).Selected = true;
        }

        protected void ddlYearLower_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ddlUpperYear.SelectedValue;
            ddlUpperYear.Items.Clear();
            ddlUpperYear.Items.Add(new ListItem("Upper Year", "-1"));
            for (int year = (Convert.ToInt32(value) != -1) ? Convert.ToInt32(ddlLowerYear.SelectedValue) : 0; year < DateTime.Now.Year + 10; year += 10)
                ddlUpperYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            if (Convert.ToInt32(value) != -1)
                ddlUpperYear.Items.FindByValue(value).Selected = true;
        }

        protected void ddlYearUpper_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ddlLowerYear.SelectedValue;
            ddlLowerYear.Items.Clear();
            ddlLowerYear.Items.Add(new ListItem("Lower Year", "-1"));
            int max = (Convert.ToInt32(ddlUpperYear.SelectedValue) != -1) ? Convert.ToInt32(ddlUpperYear.SelectedValue) : DateTime.Now.Year + 10;
            for (int year = 0; year < max; year += 100000)
                ddlLowerYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            if (Convert.ToInt32(value) != -1)
                ddlLowerYear.Items.FindByValue(value).Selected = true;
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            string where = "WHERE 1=1 ";
            if(Convert.ToInt32(ddlBuilding.SelectedValue) > -1)
                where += " AND referBuildingType = " + ddlBuilding.SelectedValue;
            if (Convert.ToInt32(ddlProperty.SelectedValue) > -1)
                where += " AND referPropertyType = " + ddlProperty.SelectedValue;
            if (Convert.ToInt32(ddlBedroom.SelectedValue) > -1)
                where += " AND referNumBedrooms = " + ddlBedroom.SelectedValue;
            if (Convert.ToInt32(ddlParking.SelectedValue) > -1)
                where += " AND referNumParking = " + ddlParking.SelectedValue;
            if (cboPool.Checked)
                where += " AND Pool = 'true'";
            if (cboWaterFront.Checked)
                where += " AND Waterfront = 'true'";
            if (cboElevator.Checked)
                where += " AND Elevator = 'true'";
            if (cboMobility.Checked)
                where += " AND Reduced Mobility = 'true'";
            if (Convert.ToInt32(ddlLowerPrice.SelectedValue) > -1)
                where += " AND Price > " + ddlLowerPrice.SelectedValue;
            if (Convert.ToInt32(ddlUpperPrice.SelectedValue) > -1)
                where += " AND Price < " + ddlUpperPrice.SelectedValue;
            if (Convert.ToInt32(ddlLowerNetArea.SelectedValue) > -1)
                where += " AND NetArea > " + ddlLowerNetArea.SelectedValue;
            if (Convert.ToInt32(ddlUpperNetArea.SelectedValue) > -1)
                where += " AND NetArea < " + ddlUpperNetArea.SelectedValue;
            if (Convert.ToInt32(ddlLowerYear.SelectedValue) > -1)
                where += " AND YearBuilt > " + ddlLowerYear.SelectedValue;
            if (Convert.ToInt32(ddlUpperYear.SelectedValue) > -1)
                where += " AND YearBuilt < " + ddlUpperYear.SelectedValue;
            if(txtKeyWords.Text!="")
                where += " AND Name like '%"+ txtKeyWords.Text + "%' OR Description like '%" + txtKeyWords.Text + "%' OR  Address like '%" + txtKeyWords.Text + "%'";


            //string id = " ( ";
            //foreach (Houses house in dbRemax.Houses.SqlQuery("SELECT refHouse,referBuildingType,referNumBedrooms,referNumParking,referPropertyType,Price,referEmployee,referClient,Pool,Waterfront,Elevator,[Reduced mobility] as Reduced_mobility,NetArea,YearBuilt,Description,Name,Address FROM Houses " + where))
            //    id += house.refHouse + ",";

            //id=id.TrimEnd(',');
            //id += ")";

            List<string> id = new List<string>();
            foreach (Houses house in dbRemax.Houses.SqlQuery("SELECT refHouse,referBuildingType,referNumBedrooms,referNumParking,referPropertyType,Price,referEmployee,referClient,Pool,Waterfront,Elevator,[Reduced mobility] as Reduced_mobility,NetArea,YearBuilt,Description,Name,Address FROM Houses " + where))
                id.Add(house.refHouse.ToString());
            string info = "";

            var result = from h in dbRemax.ViewHouses
                         where id.Contains(h.Id.ToString())
                         select h;
            foreach (ViewHouses house in result)
            {
                info += "<div class='col-md-4'><h2>" + house.Name + "</h2><p>" + house.Description + "</p>";
                info += "<p> Year : " + house.Year + "</p>";
                info += "<p> Net Area : " + house.NetArea + "</p>";
                info += "<p> Price : " + house.Price + "</p>";
                info += "<p> Building Type : " + house.Building + "</p>";
                info += "<p> Property Type : " + house.Property + "</p>";
                info += "<p> Bedrooms : " + house.Bedrooms + "</p>";
                info += "<p> Parking : " + house.Parking + "</p>";
                info += (house.Pool == true) ? "<p>Pool</p>" : "";
                info += (house.Water == true) ? "<p>Waterfront</p>" : "";
                info += (house.Elevator == true) ? "<p>Elevator</p>" : "";
                info += (house.Mobility == true) ? "<p>Reduced Mobility</p>" : "";
                info += "<p> Address : " + house.Address + "</p>";
                foreach (Images img in dbRemax.Images)
                    if (img.referHouse == house.Id)
                        info += "<img src='/Images/Houses/" + img.image.Trim() + ".jpg' width='50px'/>";

                info += "<p style='margin-top:20px'><a class='btn btn-default' href='#'>See details&raquo;</a></p>";
                info += "</div>";
            }

            //grvResult.DataSource = result.ToList();
            //grvResult.DataBind();

            lblResult.Text = info ;
        }
    }
}