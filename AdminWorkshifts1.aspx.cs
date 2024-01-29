using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminWorkshifts1 : System.Web.UI.Page
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
        sqlSelect = "SELECT * FROM tblWorkshift";
        ds = helper.getDataSet(sqlSelect);
        //DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
        ListView1.DataSource = ds.Tables[0];
        ListView1.DataBind();
    }
    // מחיקת רשימה
    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        ListViewItem delItem = ListView1.Items[e.ItemIndex];
        string strWorkshiftId = ((Label)delItem.FindControl("Label1")).Text;
        string cmdString = "DELETE FROM tblWorkshift WHERE fldworkshiftId='" + strWorkshiftId + "'";
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
        string strWorkshiftId = ((Label)changedItem.FindControl("Label1")).Text;
        string strWorkshiftDay = ((DropDownList)changedItem.FindControl("upWorkshiftDay")).SelectedValue;
        string strWorkshiftHoures = ((DropDownList)changedItem.FindControl("upWorkshiftHoures")).SelectedValue;
        string strTrainer = ((TextBox)changedItem.FindControl("upTrainer")).Text;
        helper = new MyAdoHelper();
        string cmdString = "UPDATE tblWorkshift Set fldworkshiftDay= '" + strWorkshiftDay + "' , fldworkshiftHoures='" + strWorkshiftDay +
                                    "' , fldTrainerId= '" + strWorkshiftHoures + "' WHERE fldworkshiftId = '" + strWorkshiftId + "'";
        helper.ExecuteNonQuery(filename, cmdString);
        ListView1.EditIndex = -1;
        getUsers();
    }
    // הוספת 
    protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        //get max workshift id
        string newMaxWorkshiftId;
        helper = new MyAdoHelper();
        sqlSelect = "SELECT MAX(fldworkshiftId) FROM tblWorkshift";
        ds = helper.getDataSet(sqlSelect);
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            newMaxWorkshiftId = "1";
        }
        else
        {
            string maxWorkshiftId = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            newMaxWorkshiftId = (int.Parse(maxWorkshiftId) + 1).ToString();
        }
        ListViewItem newItem = e.Item;
        string strWorkshiftDay = ((DropDownList)newItem.FindControl("inWorkshiftDay")).SelectedValue;
        string strWorkshiftHoures = ((DropDownList)newItem.FindControl("inWorkshiftHoures")).SelectedValue;
        string strTrainer = ((TextBox)newItem.FindControl("inTrainer")).Text;
        helper = new MyAdoHelper();
        string cmdString = "INSERT INTO tblWorkshift (fldworkshiftId,fldworkshiftDay,fldworkshiftHoures, fldTrainerId)";
        cmdString += " VALUES('" + newMaxWorkshiftId + "','" + strWorkshiftDay + "','" + strWorkshiftHoures + "','" + strTrainer + "')";
        MyAdoHelper.DoQuery(filename, cmdString); // run the query

        ListView1.EditIndex = -1;
        getUsers(); // קישור מחדש למקור המידע
    }
  

    //paging
    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        getUsers();
    }
}