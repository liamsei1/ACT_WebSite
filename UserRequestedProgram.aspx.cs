using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRequestedProgram : System.Web.UI.Page
{
    string sqlSelect;
    public DataSet ds;
    MyAdoHelper helper;
    public string filename = "Database.mdf";
    public string cmdString;
    public string Label1;
    string Oldusername = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DELETE all old requested from members that were treated
            string endDate = DateTime.UtcNow.AddDays(-90).ToString("MM-dd-yyyy");
            string startDate = DateTime.UtcNow.AddDays(-365).ToString("MM-dd-yyyy");
            string updateRequestscmd = "DELETE FROM tblUserProgramRequest WHERE fldDate between '"+ startDate + "' and '" + endDate + "' AND fldTakenCare='1'"; 
            getRequests();
        }
    }
    public void getRequests()
    {
        helper = new MyAdoHelper();
        sqlSelect = "SELECT * FROM tblUserProgramRequest";
        ds = helper.getDataSet(sqlSelect);
        //DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
        ListView1.DataSource = ds.Tables[0];
        ListView1.DataBind();
    }
    // מחיקת רשימה
    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        ListViewItem delItem = ListView1.Items[e.ItemIndex];
        string struserId = ((Label)delItem.FindControl("Label1")).Text;
        string cmdString = "DELETE FROM tblUserProgramRequest WHERE fldUsername='" + struserId + "'";
        helper = new MyAdoHelper();
        helper.ExecuteNonQuery(filename, cmdString);
        ListView1.EditIndex = -1;
        getRequests(); // קישור מחדש למקור המידע
    }
    // תבנית עריכה
    protected void ListView1_EditCommand(object source, ListViewEditEventArgs e)
    {
        ListView1.EditIndex = e.NewEditIndex;
        getRequests();
    }
    // ביטול העריכה
    protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        ListView1.EditIndex = -1;
        getRequests();
    }
    // עדכון הפרטים
    protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        ListViewDataItem changedItem = ListView1.Items[e.ItemIndex];
        string struserId = ((Label)changedItem.FindControl("Label1")).Text;
        string strdate = ((TextBox)changedItem.FindControl("upDate")).Text;
        string strtakencareof = ((TextBox)changedItem.FindControl("upTakenCare")).Text;
        cmdString = "UPDATE tblUserProgramRequest Set fldDate= '" + strdate + "' , fldTakenCare='" + strtakencareof + "' WHERE fldUsername = '" + struserId + "'";
        MyAdoHelper.DoQuery(filename, cmdString); // run the query
        ListView1.EditIndex = -1;
        getRequests();
    }
    // הוספת יוסר
    protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        ListViewItem newItem = e.Item;
        string struserId = ((TextBox)newItem.FindControl("inUsername")).Text;
        string strdate = ((TextBox)newItem.FindControl("inDate")).Text;
        string strtakencareof = ((TextBox)newItem.FindControl("inTakenCare")).Text;
        cmdString = "INSERT INTO tblUserProgramRequest (fldUsername,fldDate,fldTakenCare)";
        cmdString += " VALUES('" + struserId + "','" + strdate + "','" + strtakencareof + "')";
        MyAdoHelper.DoQuery(filename, cmdString); // run the query
        ListView1.EditIndex = -1;
        getRequests();
    }



    //paging
    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        getRequests();
    }




}



