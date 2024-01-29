using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;

public partial class NewLogin : System.Web.UI.Page
{
    // מאפס הודעה
    public string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["username"] != null)
            {
                UserName2.Value = Request.Cookies["username"].Value;
                password2.Value = Request.Cookies["userPassword"].Value;
                string key = MyAdoHelper.getUserAccessKey(UserName2.Value.ToString(), password2.Value.ToString());
                login(UserName2.Value.ToString(), password2.Value.ToString(), key);
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            DataTable table = new DataTable();
            string UserName = UserName2.Value;
            string password = password2.Value;
            string key = MyAdoHelper.getUserAccessKey(UserName, password);        // בודק אם המשתמש והססמה נכונים או לא ופועל בהתאם
            if (key == null)
                msg = "False username or password please try again";
            else // מגדיר את האקסס קי ומוצא שם של יוסר
            {
                login(UserName, password, key);
            }

        }
    }
    protected void login(string other_UserName, string other_password, string other_key)
    {
        DataTable table = new DataTable();
        string UserName = other_UserName;
        string password = other_password;
        string key = other_key;
        // נעילת גישה למשתמשים אחרים
        Application.Lock();
        // שימוש ראשון במשתנה האפליקציה ואתחול מונה
        if (Application["usercount"] == null || (int)Application["usercount"] == 0)
        {
            Application["userCountMsg"] = "0 משתמשים מחוברים";
            Application["usercount"] = 0;
        }
        // מקדם כניסה של יוסר
        Application["usercount"] = (int)Application["usercount"] + 1;
        Application["userCountMsg"] = Application["usercount"] + " מספר המשתמשים המחוברים";
        // שיחרור נעילה
        Application.UnLock();

        // יוצר עוגייה שהלקוח התחבר כבר
        if (Request.Cookies["registrant"] == null)
        {
            HttpCookie registrant = new HttpCookie("registrant");
            registrant.Value = "registrant";
            registrant.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(registrant);
        }
        //  יוצר עוגייה ששומרת את המשתמש אם זה הפעם הראשונה ואם הוא מסכים
        if (Request.Cookies["username"] == null)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save your account?", "account saving", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HttpCookie username = new HttpCookie("username");
                username.Value = UserName;
                username.Expires = DateTime.Now.AddDays(30);
                HttpCookie userPassword = new HttpCookie("userPassword");
                userPassword.Value = password;
                userPassword.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(username);
                Response.Cookies.Add(userPassword);
            }
        }

        Session["username"] = UserName;
        Session["key"] = int.Parse(key);
        Response.Redirect("HomePage.aspx");
    }
}

