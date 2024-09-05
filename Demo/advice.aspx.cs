using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Thani_5683.App_Code;

namespace Thani_5683.Demo
{
    public partial class advice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateddlcity();
            }
        }

        protected void populateddlcity()
        {
            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @"SELECT cityID, city FROM city";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                ddlcity.DataTextField = "city";
                ddlcity.DataValueField = "cityID";
                ddlcity.DataSource = dr;
                ddlcity.DataBind();
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error populating cities: " + ex.Message;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtadvice.Text))
            {
                lblOutput.Text = "Please inter your Note !";
                txtadvice.Focus();
                return;
            }
            try
            {
                string myAdvice = "<PRE>" + txtadvice.Text + "</PRE>";
                CRUD myCrud = new CRUD();
                string mySql = @"INSERT INTO advice(cityID, adviceOrNots) VALUES (@cityID, @adviceOrNots)";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@cityID", ddlcity.SelectedItem.Value);
                myPara.Add("@adviceOrNots", myAdvice);

                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                lblOutput.Text = rtn >= 1 ? "Operation Successful!" : "Operation Failed!";
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error saving advice: " + ex.Message;
            }
        }

        protected void btnShowReview_Click(object sender, EventArgs e)
        {
            populateGvadvice();
        }

        protected void populateGvadvice()
        {
            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @" select adviceID,adviceOrNots,city
                        from advice a inner join city c on a.cityID = c.cityID";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                gvadvice.DataSource = dr;
                gvadvice.DataBind();
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error populating GridView: " + ex.Message;
            }
        }

        protected void gvadvice_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This can be implemented if there's a need to handle selected index change events.
        }
    }
}