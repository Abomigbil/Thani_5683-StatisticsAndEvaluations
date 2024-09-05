using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Thani_5683.App_Code;

namespace Thani_5683.Demo
{
    public partial class questionnaire : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDdlVisitor();

            }
        }

        protected void populateDdlVisitor()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT contactID, fName + ' ' + lName AS visitorName FROM contact";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlVisitor.DataTextField = "visitorName";
            ddlVisitor.DataValueField = "contactID";
            ddlVisitor.DataSource = dr;
            ddlVisitor.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string selectedValuesBy = "";
            string selectedValuesWith = "";
            string selectedValuesWhen = "";

            for (int i = 0; i < chkTravelBy.Items.Count; i++)
            {
                if (chkTravelBy.Items[i].Selected)
                {
                    selectedValuesBy += chkTravelBy.Items[i].Text + " , ";
                }
            }
            for (int i = 0; i < chkTravelWith.Items.Count; i++)
            {
                if (chkTravelWith.Items[i].Selected)
                {
                    selectedValuesWith += chkTravelWith.Items[i].Text + " , ";
                }
            }
            for (int i = 0; i < chkTravelWhen.Items.Count; i++)
            {
                if (chkTravelWhen.Items[i].Selected)
                {
                    selectedValuesWhen += " , " + chkTravelWhen.Items[i].Text;
                }
            }
            insertTraveler(selectedValuesBy, selectedValuesWith, selectedValuesWhen);

        }

        protected void insertTraveler(string selectedValuesBy, string selectedValuesWith, string selectedValuesWhen)
        {
            int contactID = int.Parse(ddlVisitor.SelectedValue);
            CRUD myCrud = new CRUD();

            string mySql = @"insert travelDetail (contactID,travelBy,travelWith,travelWhen)
                            values (@contactID,@travelBy,@travelWith,@travelWhen)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@contactID", contactID);
            myPara.Add("@travelBy", selectedValuesBy);
            myPara.Add("@travelWith", selectedValuesWith);
            myPara.Add("@travelWhen", selectedValuesWhen);


            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = " Operation successfull "; }
            else
            { lblOutput.Text = " Operation faill ! "; }
        }

        protected void populdategvQuestionnaire()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT fName + ' ' + lName AS Traveler, travelBy, travelWith, travelWhen
                               FROM travelDetail d INNER JOIN contact c ON d.contactID = c.contactID ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvQuestionnaire.DataSource = dr;
            gvQuestionnaire.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            populdategvQuestionnaire();
        }


    }
}

