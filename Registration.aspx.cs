using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    public string msg = "";
    public bool result;
    protected void Page_Load(object sender, EventArgs e) { }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string file_name = "Database.mdf";
        string table_name = "tblUser";

        // שולף את התשובות מהטופס
        if (Page.IsValid)
        {
            CreditCardServiceReference.CreditCardValidatorSoapClient creditChecker= new CreditCardServiceReference.CreditCardValidatorSoapClient();
            MyAdoHelper helper = new MyAdoHelper();
            string newUsername = UserName.Value;
            string newPassword = password.Value;
            string newEmail = email.Value;
            string newCreditNumber = creditNumber.Value;
            string newCreditCode = creditCode.Value;
            string sql_commannd = "SELECT * FROM " + table_name + " WHERE fldUserName=" + "'" + newUsername + "'";
            result = MyAdoHelper.IsExist(file_name, sql_commannd);
            // בודק אם יש משתמש כזה
            if (result == false)
            {
                //check if the credit card is not in the database already
                if (newCreditNumber==null || !MyAdoHelper.IsExist(file_name, "SELECT * FROM [tblCredit] WHERE fldCreditNumber='"+ newCreditNumber +"'"))
                {
                    //chech if the credit number is valid
                    if (newCreditNumber == null || creditChecker.ValidCardLength(newCreditNumber)) 
                    {
                        helper.addUserQuery(file_name, newUsername, newPassword, newEmail, "2");
                        // add card if needed
                        if (newCreditNumber == null) 
                        {
                            string cardCompany = creditChecker.GetCardType(newCreditNumber);
                            helper.addCreditCardQuery(newCreditNumber,newCreditCode,cardCompany,newUsername,file_name);
                        }
                        // יוצר עוגייה שהלקוח נרשם כבר
                        if (Request.Cookies["registrant"] == null)
                        {
                            HttpCookie registrant = new HttpCookie("registrant");
                            registrant.Value = "registrant";
                            registrant.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(registrant);
                        }
                        Response.Redirect("Login.aspx");
                    }
                    else
                        msg = "unvalidated credit card";
                }
                else
                    msg = "use other credit card";
            }
            else
                msg = "try other username";
        }
    }
}