using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Do you LOGOUT?", "Logout", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            //delete coockies if needed
            if (Request.Cookies["username"] != null)
            {
                HttpCookie cookie1 = HttpContext.Current.Request.Cookies["username"];
                HttpCookie cookie2 = HttpContext.Current.Request.Cookies["userPassword"];
                cookie1.Expires = DateTime.Now.AddYears(-1);
                cookie2.Expires = DateTime.UtcNow.AddYears(-1);
                HttpContext.Current.Response.Cookies.Add(cookie1);
                HttpContext.Current.Request.Cookies.Remove("username");
                HttpContext.Current.Response.Cookies.Add(cookie2);
                HttpContext.Current.Request.Cookies.Remove("userPassword");
            }

            Application.Lock();
            Application["usercount"] = (int)Application["usercount"] - 1;
            Application["userCountMsg"] = Application["usercount"] + " מספר המשתמשים המחוברים";
            Application.UnLock();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        Response.Redirect("HomePage.aspx");

    }
}