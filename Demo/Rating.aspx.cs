using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Thani_5683.App_Code;

namespace Thani_5683.Demo
{
    public partial class Raiting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    populateCity();
                    populateDdlVisitor();
                    populateRepeaterControl();
                }
                catch (Exception ex)
                {
                    lblOutput.Text = "Error during Page Load: " + ex.Message;
                }
            }
        }

        protected void populateCity()
        {
            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @"SELECT cityID, city FROM city";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                ddlHotel.DataTextField = "city";
                ddlHotel.DataValueField = "cityID";
                ddlHotel.DataSource = dr;
                ddlHotel.DataBind();
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error populating city: " + ex.Message;
            }
        }

        protected void populateDdlVisitor()
        {
            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @"SELECT contactID, fName + ' ' + lName AS visitorName FROM contact";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                ddlVisitor.DataTextField = "visitorName";
                ddlVisitor.DataValueField = "contactID";
                ddlVisitor.DataSource = dr;
                ddlVisitor.DataBind();
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error populating visitors: " + ex.Message;
            }
        }

        protected void populateRepeaterControl()
        {
            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @"SELECT cityRatingCID, cityRatingC FROM cityRating";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                repeaterRating.DataSource = dr;
                repeaterRating.DataBind();
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error populating repeater: " + ex.Message;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string userInput = "";
                int intHotelId = int.Parse(ddlHotel.SelectedValue); // capture city id from the ddl
                int intVisitorId = int.Parse(ddlVisitor.SelectedValue); // capture city id from the ddl
                HiddenField ratingCriteriaId;
                int selectedCriteriaPoint = 0;
                foreach (RepeaterItem ri in repeaterRating.Items)
                {
                    ratingCriteriaId = (HiddenField)ri.FindControl("hdnCityRatingCID");
                    Label myLblHotelRatingCriteria = (Label)ri.FindControl("lblCityRatingC");
                    RadioButtonList myRbl = (RadioButtonList)ri.FindControl("rblcityRatingCriteriaPoint");
                    for (int i = 0; i <= myRbl.Items.Count - 1; i++)
                    {
                        if (myRbl.Items[i].Selected)
                        {
                            selectedCriteriaPoint = int.Parse(myRbl.Items[i].Value);
                            userInput += ratingCriteriaId.Value.ToString() + " " + myLblHotelRatingCriteria.Text + " " + myRbl.Items[i].Value.ToString();
                            userInput += "</BR>";
                            insertUserRating(intVisitorId, intHotelId, int.Parse(ratingCriteriaId.Value), selectedCriteriaPoint);
                        }
                    }
                }
                lblOutput.Text = userInput.ToString();
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error submitting rating: " + ex.Message;
            }
        }

        protected void insertUserRating(int visitorId, int hotelId, int ratingCriteriaId, int ratingCriteriaPoint)
        {
            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @"INSERT INTO userCityRating(contactID, cityID, cityRatingCID, cityRatingCriteriaPoint) 
                                 VALUES(@contactID, @cityID, @cityRatingCID, @cityRatingCriteriaPoint)";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@contactID", visitorId);
                myPara.Add("@cityID", hotelId);
                myPara.Add("@cityRatingCID", ratingCriteriaId);
                myPara.Add("@cityRatingCriteriaPoint", ratingCriteriaPoint);
                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error inserting user rating: " + ex.Message;
            }
        }

        protected void btnClearn_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem ri in repeaterRating.Items)
            {
                RadioButtonList myRbl = (RadioButtonList)ri.FindControl("rblcityRatingCriteriaPoint");
                for (int i = 0; i <= myRbl.Items.Count - 1; i++)
                {
                    if (myRbl.Items[i].Selected)
                    {
                        myRbl.Items[i].Selected = false;
                    }
                }
            }
        }

        protected void populateGvRating()
        {
            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @"SELECT userCityRatingID, fName + ' ' + lName AS visitorName, city, cityRatingC, cityRatingCriteriaPoint
                                 FROM city c 
                                 INNER JOIN userCityRating uhr ON c.cityID = uhr.cityID
                                 INNER JOIN cityRating hrc ON uhr.cityRatingCID = hrc.cityRatingCID
                                 INNER JOIN contact v ON uhr.contactID = v.contactID";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                gvRating.DataSource = dr;
                gvRating.DataBind();
                
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error populating GridView: " + ex.Message;
            }
        }

        protected void btnGetExistingRating_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Hello, World!");
                string inf = "enter ";
                populateGvRating();
                

            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error fetching data: " + ex.Message;
            }
        }

        protected void gvRating_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @"SELECT userCityRatingID, fName + ' ' + lName AS visitorName, city, cityRatingC, cityRatingCriteriaPoint
                                 FROM city c 
                                 INNER JOIN userCityRating uhr ON c.cityID = uhr.cityID
                                 INNER JOIN cityRating hrc ON uhr.cityRatingCID = hrc.cityRatingCID
                                 INNER JOIN contact v ON uhr.contactID = v.contactID";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                gvRating.DataSource = dr;
                gvRating.DataBind();
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error populating GridView: " + ex.Message;
            }
        }
    }
}
