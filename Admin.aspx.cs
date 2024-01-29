using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    string sqlSelect;
    public DataSet ds;
    MyAdoHelper helper;
    string filename = "Database.mdf";
    public string Label1;
    string Oldusername = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            getUsers();
    }
    public void getUsers()
    {
        helper = new MyAdoHelper();
        sqlSelect = "SELECT * FROM tblUser WHERE fldKey!=6";
        ds = helper.getDataSet(sqlSelect);
        //DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
        ListView1.DataSource = ds.Tables[0];
        ListView1.DataBind();
    }
    // מחיקת רשימה
    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        ListViewItem delItem = ListView1.Items[e.ItemIndex];
        string strUser = ((Label)delItem.FindControl("Label1")).Text;
        string cmdString = "DELETE FROM tblUser WHERE fldUserName='" + strUser + "'";
        helper = new MyAdoHelper();
        helper.ExecuteNonQuery(filename, cmdString);
        ListView1.EditIndex = -1;
        getUsers(); // קישור מחדש למקור המידע
    }
    // תבנית עריכה
    protected void ListView1_EditCommand(object source, ListViewEditEventArgs e)
    {
        ListView1.EditIndex = e.NewEditIndex;
        getUsers(); 
    }
    // ביטול העריכה
    protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        ListView1.EditIndex = -1;
        getUsers(); 
    }
    // עדכון הפרטים
    protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        ListViewDataItem changedItem = ListView1.Items[e.ItemIndex];
        string strUsername = ((Label)changedItem.FindControl("Label1")).Text;
        string strPassword = ((TextBox)changedItem.FindControl("upPassword")).Text;
        string strGmail = ((TextBox)changedItem.FindControl("upMail")).Text;
        string strKey = ((TextBox)changedItem.FindControl("upKey")).Text;
        helper = new MyAdoHelper();
        helper.adminchangeUser(strUsername, strPassword, strGmail, strKey);
        ListView1.EditIndex = -1;
        getUsers(); 
    }
    // הוספת יוסר
    protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        ListViewItem newItem = e.Item;
        string strUsername = ((TextBox)newItem.FindControl("inUsername")).Text;
        string strPassword = ((TextBox)newItem.FindControl("inPassword")).Text;
        string strGmail = ((TextBox)newItem.FindControl("inMail")).Text;
        string strKey = ((TextBox)newItem.FindControl("inKey")).Text;
        helper = new MyAdoHelper();
        helper.addUserQuery("Database.mdf", strUsername, strPassword,strGmail,strKey);
        ListView1.EditIndex = -1;
        getUsers(); // קישור מחדש למקור המידע
    }
    // מיון
    
    protected void link1_Click(object sender, EventArgs e)
    {/*
        helper = new MyAdoHelper();
        string cmdString = "SELECT * FROM tblUser WHERE fldKey!=6";
        if (Session["userSort"] == null)
            Session["userSort"] = 0;
        if ((int)Session["userSort"] % 2 == 0)
            cmdString = "SELECT * FROM tblUser WHERE fldKey!=6 ORDER BY fldUserName ASC";
        else
            cmdString = "SELECT * FROM tblUser WHERE fldKey!=6 ORDER BY fldUserName DESC";
        Session["userSort"] = (int)Session["userSort"] + 1;
        ds = helper.GetDataSet(cmdString);
        ListView1.DataSource = ds.Tables[0];
        ListView1.DataBind(); */
    }
    protected void link2_Click(object sender, EventArgs e)
    {/*
        helper = new MyAdoHelper();
        string cmdString = "SELECT * FROM tblUsers WHERE fldKey!=6";
        if (Session["lastnameSort"] == null)
            Session["lastnameSort"] = 0;
        if ((int)Session["lastnameSort"] % 2 == 0)
            cmdString = "SELECT * FROM tblUser WHERE fldKey!=6 ORDER BY fldKey ASC";
        else
            cmdString = "SELECT * FROM tblUser WHERE fldKey!=6 ORDER BY fldKey DESC";
        Session["lastnameSort"] = (int)Session["lastnameSort"] + 1;
        ds = helper.GetDataSet(cmdString);
        ListView1.DataSource = ds.Tables[0];
        ListView1.DataBind(); */
    }
    

        //paging
        protected void DataPager1_PreRender(object sender, EventArgs e) {
        getUsers();
    }





  
    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string username= ListView1.SelectedDataKey.ToString();
        getCreditCards(username);
    }


    //detailview



    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string creditNum = DetailsView1.Rows[0].Cells[1].Text;
        string creditCode = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text;
        string creditCompany = ((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]).Text;
        string creditUser = ((TextBox)DetailsView1.Rows[3].Cells[1].Controls[0]).Text;
        string cmdString = "UPDATE tblCredit SET fldCreditCode='" + creditCode + "', fldCreditCompany='" + creditCompany + "', fldUserName='" + creditUser + "' WHERE fldCreditNumber='"+ creditNum + "'";
        helper = new MyAdoHelper();
        helper.ExecuteNonQuery("DataBase.mdf",cmdString);
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        string username = ListView1.SelectedDataKey.ToString();
        getCreditCards(username);
    }


    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        string creditNum = ((TextBox)DetailsView1.Rows[0].Cells[1].Controls[0]).Text;
        string creditCode = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text;
        string creditCompany = ((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]).Text;
        string creditUser = ((TextBox)DetailsView1.Rows[3].Cells[1].Controls[0]).Text;
        string cmdString = "INSERT INTO tblCredit VALUES ('" + creditNum + "', '"+creditCode + "', '" + creditCompany + "','" + creditUser + "')";
        helper = new MyAdoHelper();
        helper.ExecuteNonQuery("DataBase.mdf", cmdString);
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        string username = ListView1.SelectedDataKey.ToString();
        getCreditCards(username);
    }



    public void getCreditCards(string username)
    {
        helper = new MyAdoHelper();
        sqlSelect = "SELECT * FROM tblCredit WHERE fldUserName='" + username+ "'";
        ds = helper.getDataSet(sqlSelect);
        //DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
        DetailsView1.DataSource = ds.Tables[0];
        DetailsView1.DataBind();
    }

    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        DetailsView1.PageIndex = e.NewPageIndex;
        string username = ListView1.SelectedDataKey.ToString();
        getCreditCards(username);
    }



    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        switch (e.NewMode)
        {
            case DetailsViewMode.Edit:
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                break;
            case DetailsViewMode.Insert:
                DetailsView1.ChangeMode(DetailsViewMode.Insert);
                break;
            case DetailsViewMode.ReadOnly:
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                break;
        }
        string username = ListView1.SelectedDataKey.ToString();
        getCreditCards(username);
    }
    

}