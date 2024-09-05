using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Thani_5683.App_Code;

namespace Thani_5683.Demo
{
    public partial class questionnaire2 : System.Web.UI.Page
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
            string selectedValuesBy = string.Join(", ", chkTravelBy.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value));
            string selectedValuesWith = string.Join(", ", chkTravelWith.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value));
            string selectedValuesWhen = string.Join(", ", chkTravelWhen.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value));
            Response.Write("You selected: " + selectedValuesBy + " , " + selectedValuesWith + " , " + selectedValuesWhen);
        }
    }
}