using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class GeneralTests : System.Web.UI.Page
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
            getPrograms();
        }
    }
    public void getPrograms()
    {
        helper = new MyAdoHelper();
        sqlSelect = "SELECT fldUsername FROM tblUser";
        ds = helper.getDataSet(sqlSelect);
        //DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
        ListView1.DataSource = ds.Tables[0];
        ListView1.DataBind();
    }
    // מחיקת רשימה
    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        ListViewItem delItem = ListView1.Items[e.ItemIndex];
        string strProgramId = ((Label)delItem.FindControl("Label1")).Text;
        string cmdString = "DELETE FROM tblPrograms WHERE fldProgramId='" + strProgramId + "'";
        helper = new MyAdoHelper();
        helper.ExecuteNonQuery(filename, cmdString);
        ListView1.EditIndex = -1;
        getPrograms(); // קישור מחדש למקור המידע
    }
    // תבנית עריכה
    protected void ListView1_EditCommand(object source, ListViewEditEventArgs e)
    {
        ListView1.EditIndex = e.NewEditIndex;
        getPrograms();
    }
    // ביטול העריכה
    protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        ListView1.EditIndex = -1;
        getPrograms();
    }
    // עדכון הפרטים
    protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        ListViewDataItem changedItem = ListView1.Items[e.ItemIndex];
        string strProgramId = ((Label)changedItem.FindControl("Label1")).Text;
        string strProgramDuration = ((TextBox)changedItem.FindControl("upDuration")).Text;
        string strProgramType = ((TextBox)changedItem.FindControl("upType")).Text;
        string strProgramLevel = ((TextBox)changedItem.FindControl("upLevel")).Text;
        string strProgramInfo = ((TextBox)changedItem.FindControl("upInfo")).Text;
        cmdString = "UPDATE tblPrograms Set fldProgramDuration= '" + strProgramDuration + "' , fldProgramType='" + strProgramType +
                                    "' , fldProgramLevel= '" + strProgramLevel + "' , fldProgram=N'" + strProgramInfo +
                            "' WHERE fldProgramId = '" + strProgramId + "'";
        MyAdoHelper.DoQuery(filename, cmdString); // run the query
        ListView1.EditIndex = -1;
        getPrograms();
    }
    // הוספת יוסר
    protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        //get max program id
        string newMaxProgramId;
        helper = new MyAdoHelper();
        sqlSelect = "SELECT MAX(fldProgramId) FROM tblPrograms WHERE fldTrainerId='" + Session["username"] + "'";
        ds = helper.getDataSet(sqlSelect);
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            newMaxProgramId = "1";
        }
        else
        {
            string maxProgramId = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            newMaxProgramId = (int.Parse(maxProgramId) + 1).ToString();
        }
        ListViewItem newItem = e.Item;
        string strProgramDuration = ((TextBox)newItem.FindControl("inDuration")).Text;
        string strProgramType = ((TextBox)newItem.FindControl("inType")).Text;
        string strProgramLevel = ((TextBox)newItem.FindControl("inLevel")).Text;
        string strProgramInfo = ((TextBox)newItem.FindControl("inInfo")).Text;
        cmdString = "INSERT INTO tblPrograms (fldProgramId,fldProgramDuration,fldProgramType, fldProgramLevel,fldProgram,fldTrainerId)";
        cmdString += " VALUES('" + newMaxProgramId + "','" + strProgramDuration + "','" + strProgramType + "','" + strProgramLevel + "',N'" + strProgramInfo + "','" + Session["username"] + "')";
        MyAdoHelper.DoQuery(filename, cmdString); // run the query
        ListView1.EditIndex = -1;
        getPrograms();
    }
    // מיון
    protected void link1_Click(object sender, EventArgs e)
    {
        /*
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
        ListView1.DataBind();
        */
    }
    protected void link2_Click(object sender, EventArgs e)
    {
        /*
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
        ListView1.DataBind();
        */
    }


    //paging
    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        getPrograms();
    }




}


