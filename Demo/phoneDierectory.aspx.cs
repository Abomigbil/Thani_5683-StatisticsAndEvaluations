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
    public partial class phoneDierectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string myGustName = "Thani";
            
            
            populdategvContact();
            populdateDdlFName();
        }
            protected void populdategvContact()
        {
            // i will connect to database by CRUD
            CRUD myCrud = new CRUD();
            string mySql = @"select * from v_contactDirectory";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvContact.DataSource = dr;
            gvContact.DataBind();
        }
        protected void populdateDdlFName()
        {
            // i will connect to database by CRUD
            CRUD myCrud = new CRUD();
            string mySql = @"select contactID , fName from contact";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
          
        }
    }
}