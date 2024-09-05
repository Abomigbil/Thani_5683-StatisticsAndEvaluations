using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
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
    public partial class myServerControl : System.Web.UI.Page
    {
        static string[] Scopes = { DriveService.Scope.DriveFile };
        static string ApplicationName = "Thani_5683 Demo";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
                {
                populdateddlCountry();
                }

            

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Required for exporting to Excel and Google Drive
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtfName.Text))
            {
                lblOutput.Text = "Please inter first name !";
                txtfName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtlName.Text))
            {
                lblOutput.Text = "Please inter last name !";
                txtlName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtCell.Text))
            {
                lblOutput.Text = "Please inter your phone number !";
                txtCell.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lblOutput.Text = "Please inter your Email !";
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ddlCountry.SelectedItem.Value))
            {
                lblOutput.Text = "Please chose your country !";
                ddlCountry.Focus();
                return;
            }


            /* string myName = txtfName.Text;
             lblOutput.Text = myName;*/


            // pass value to cmd for insert 
            string strfName = txtfName.Text;
            string strlName = txtlName.Text;
            string strcell = txtCell.Text;
            string strEmail = txtEmail.Text;
            string ddlCountryID = ddlCountry.SelectedItem.Value;

            CRUD myCrud = new CRUD();

            string mySql = @"insert contact (fName,lName,cell,Email,countryID)
                            values (@fName,@lName,@cell,@Email,@countryID )";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@fName", strfName);
            myPara.Add("@lName", strlName);
            myPara.Add("@cell", strcell);
            myPara.Add("@Email", strEmail);
            myPara.Add("@countryID", ddlCountryID);

            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = " Operation successfull "; }
            else
            { lblOutput.Text = " Operation faill ! "; }
            populdategvContact();
        }
        protected void populdateddlCountry()
        {
            // i will connect to database by CRUD
            CRUD myCrud = new CRUD();
            string mySql = @"select countryID , country from country";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlCountry.DataTextField = "country";
            ddlCountry.DataValueField = "countryID";
            ddlCountry.DataSource = dr;
            ddlCountry.DataBind();
        }

        protected void populdategvContact()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select contactID ,fName,lName,cell,Email,country
                from contact c inner join country co on c.countryID = co.countryID";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            
            gvContact.DataSource = dr;
            gvContact.DataBind();
        }

        protected void btnShowContactInf_Click(object sender, EventArgs e)
        {
            populdategvContact();
        }

        

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContactID.Text))
            {
                lblOutput.Text = "Please inter Contact ID to update !";
                txtContactID.Focus();
                return;
            }
            string strfName = txtfName.Text;
            string strlName = txtlName.Text;
            string strcell = txtCell.Text;
            string strEmail = txtEmail.Text;
            string ddlCountryID = ddlCountry.SelectedItem.Value;

            CRUD myCrud = new CRUD();

            string mySql = @"update contact
                            set fName = @fName ,lName = @lName, cell = @cell,Email = @Email,countryID = @countryID
                                where contactID = @contactID ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@contactID", int.Parse(txtContactID.Text));
            myPara.Add("@fName", strfName);
            myPara.Add("@lName", strlName);
            myPara.Add("@cell", strcell);
            myPara.Add("@Email", strEmail);
            myPara.Add("@countryID", ddlCountryID);

            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = " Operation successfull "; }
            else
            { lblOutput.Text = " Operation faill ! "; }
            populdategvContact();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContactID.Text))
            {
                lblOutput.Text = "Please inter Contact ID to delete !";
                txtContactID.Focus();
                return;
            }
            CRUD myCrud = new CRUD();

            string mySql = @"delete from contact 
                            where contactID = @contactID ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@contactID", int.Parse(txtContactID.Text));


            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = " Operation successfull "; }
            else
            { lblOutput.Text = " Operation faill ! "; }
            populdategvContact();
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(gvContact);

        }

        public static void ExportGridToExcel(GridView myGv) // working 1
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Charset = "";
            string FileName = "ExportedReport_" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            myGv.GridLines = GridLines.Both;
            myGv.HeaderStyle.Font.Bold = true;
            myGv.RenderControl(htmltextwrtter);
            HttpContext.Current.Response.Write(strwritter.ToString());
            HttpContext.Current.Response.End();
        }
        protected void btnExportGoogleDrive_Click(object sender, EventArgs e)
        {
            ExportGridToGoogleDrive(gvContact);
        }

        public static void ExportGridToGoogleDrive(GridView myGv)
        {
            UserCredential credential;
            using (var stream = new FileStream("path/to/credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var memoryStream = new MemoryStream();
            using (var writer = new StreamWriter(memoryStream))
            {
                HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
                myGv.RenderControl(htmlWriter);
                writer.Flush();
                memoryStream.Position = 0;
            }

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "ExportedReport_" + DateTime.Now + ".html",
                MimeType = "text/html"
            };
            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream("report.html", FileMode.Create, FileAccess.Write))
            {
                memoryStream.CopyTo(stream);
                stream.Position = 0;
                request = service.Files.Create(fileMetadata, stream, "text/html");
                request.Fields = "id";
                request.Upload();
            }

            //var file = request.ResponseBody;
            //if (file != null)
            //{
            //    lblOutput.Text = "File uploaded successfully. File ID: " + file.Id;
            //}
            //else
            //{
            //    lblOutput.Text = "File upload failed.";
            //}
        }
    }
}

       
   
