using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberShipBuy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e){ }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ActServiceReference.WebServiceSoapClient client = new ActServiceReference.WebServiceSoapClient();
        string currentDate = client.getDate2();
        string file_name = "Database.mdf";
        // שולף את התשובות מהטופס
        if (Page.IsValid)
        {
            if (!checkbox2.Checked)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please accept our policy to continue')", true);
            }
            else
            {
                MyAdoHelper helper = new MyAdoHelper();
                string membername = firstName.Value;
                string memberLastName = lastName.Value;
                float membertrainingYears = float.Parse(trainingYears.Value);
                int memberGender = gender.Value == "Female" ? 0 : 1;
                string memberBirthday = birthday.Value;
                string joiningDate = currentDate;
                string endMembershipDate = currentDate;
                string username = Session["username"].ToString();
                helper.addMemberShip(username, membername, memberLastName, membertrainingYears, memberGender, memberBirthday, joiningDate, endMembershipDate, file_name);
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}