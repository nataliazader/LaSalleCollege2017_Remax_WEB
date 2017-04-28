using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppRemax
{
    public partial class RealEstate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                RemaxEntities dbRemax = new RemaxEntities();

                var builing = from b in dbRemax.BuildingType.AsEnumerable()
                              select new
                              {
                                  refB = b.refBuildingType,
                                  building = b.Building
                              };
                ddlBuilding.DataSource = builing.ToList();
                ddlBuilding.DataTextField = "building";
                ddlBuilding.DataValueField = "refB";
                ddlBuilding.DataBind();

                var property = from p in dbRemax.PropertyType.AsEnumerable()
                               select new
                               {
                                   refP = p.refPropertyType,
                                   property = p.Property
                               };
                ddlProperty.DataSource = property.ToList();
                ddlProperty.DataTextField = "property";
                ddlProperty.DataValueField = "refP";
                ddlProperty.DataBind();

                var bedroom = from b in dbRemax.NumBedrooms.AsEnumerable()
                              select new
                              {
                                  refB = b.refNumBedrooms,
                                  num = b.Bedrooms
                              };
                ddlBedroom.DataSource = bedroom.ToList();
                ddlBedroom.DataTextField = "num";
                ddlBedroom.DataValueField = "refB";
                ddlBedroom.DataBind();

                var parking = from p in dbRemax.NumParking.AsEnumerable()
                              select new
                              {
                                  refP = p.refNumParking,
                                  park = p.Parking
                              };
                ddlParking.DataSource = parking.ToList();
                ddlParking.DataTextField = "park";
                ddlParking.DataValueField = "refP";
                ddlParking.DataBind();

                ddlLowerPrice.Text = "Lower Price Limit";
                ddlUpperPrice.Text = "Upper Price Limit";
                for (int price = 0; price < 10000000; price += 100000)
                    ddlLowerPrice.Items.Add(price.ToString());

                for (int price = 0; price < 10000000; price += 100000)
                    ddlUpperPrice.Items.Add(price.ToString());
            }
        }
    }
}