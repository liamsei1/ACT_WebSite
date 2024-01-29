using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class programToMember : System.Web.UI.Page
{
    string sqlSelect;
    public DataSet ds;
    MyAdoHelper helper;
    public string filename = "Database.mdf";
    public string cmdString;
    public string msgSuggestedProgramId="";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getPrograms();
            DropDownList1.DataSource = MyAdoHelper.GetDataSet("Select * from tblMember");
            DropDownList1.DataTextField = "fldName";
            DropDownList1.DataValueField = "fldMemberId";
            DropDownList1.DataBind();
        }
    }
    public void getPrograms()
    {
        helper = new MyAdoHelper();
        sqlSelect = "SELECT P.fldProgramId,P.fldMemberId,P.fldIsFinished FROM tblProgramToTrainee P WHERE P.fldProgramId in (Select NEWP.fldProgramId from tblPrograms NEWP where NEWP.fldTrainerId='TRAINER')";
        ds = helper.getDataSet(sqlSelect);
        //DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
        ListView1.DataSource = ds.Tables[0];
        ListView1.DataBind();
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
    protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        helper = new MyAdoHelper();
        ListViewItem newItem = e.Item;
        string strProgram = ((TextBox)newItem.FindControl("inProgramId")).Text;
        string strMember = ((TextBox)newItem.FindControl("inMemberId")).Text;
        string strFinished = ((TextBox)newItem.FindControl("inIsfinished")).Text;
        if (MyAdoHelper.IsExist(filename, "Select * from tblMember where fldMemberId='" + strMember + "'") == true && MyAdoHelper.IsExist(filename, "Select * from tblPrograms where fldProgramId='" + strProgram + "'") == true)
        {
            cmdString = "INSERT INTO tblProgramToTrainee (fldProgramId,fldMemberId,fldIsFinished)";
            cmdString += " VALUES('" + strProgram + "','" + strMember + "','" + strFinished + "')";
            MyAdoHelper.DoQuery(filename, cmdString); // run the query
            //update member requset if needed
            if (MyAdoHelper.IsExist(filename, "Select * from tblUserProgramRequest where fldUsername='" + strMember + "' AND fldTakenCare='0'") == true)
            {
                cmdString = "UPDATE tblUserProgramRequest Set fldTakenCare='1' WHERE fldUsername = '" + strMember + "'";
                MyAdoHelper.DoQuery(filename, cmdString); // run the query
            }
        }
        ListView1.EditIndex = -1;
        getPrograms();
    }
    // עדכון הפרטים
    protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        ListViewDataItem changedItem = ListView1.Items[e.ItemIndex];
        string strProgramId = ((TextBox)changedItem.FindControl("upProgramId")).Text;
        string strMember = ((TextBox)changedItem.FindControl("upMemberId")).Text;
        string strFinished = ((TextBox)changedItem.FindControl("upIsFinished")).Text;
        cmdString = "UPDATE tblProgramToTrainee Set fldProgramId= '" + strProgramId + "' , fldMemberId='" + strMember +
                                    "', fldIsFinished= '" + strFinished + "'";
        MyAdoHelper.DoQuery(filename, cmdString); // run the query
        ListView1.EditIndex = -1;
        getPrograms();
    }
    // מחיקת רשימה
    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        ListViewItem delItem = ListView1.Items[e.ItemIndex];
        string strProgramId = ((TextBox)delItem.FindControl("upProgramId")).Text;
        string cmdString = "DELETE FROM tblProgramToTrainee WHERE fldProgramId='" + strProgramId + "'";
        helper = new MyAdoHelper();
        helper.ExecuteNonQuery(filename, cmdString);
        ListView1.EditIndex = -1;
        getPrograms(); // קישור מחדש למקור המידע
    }


    //get a suggestion for program
    protected void btnSubmit_Click2(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string memberUsername = DropDownList1.SelectedValue;
            string sqlSelectMemberExist = "Select fldMemberId from tblMember where fldMemberId='" + memberUsername + "'";
            if (MyAdoHelper.IsExist(filename, sqlSelectMemberExist) == false)
            {
                msgSuggestedProgramId = "Please Try diffrent MemberId";
            }
            else
            {
                string sqlSelect = "Select * from tblMemberPreferences where fldMemberId='" + memberUsername + "'";
                // בודק האם קיימות העדפות למשתמש
                if (MyAdoHelper.IsExist(filename, sqlSelect) == false)
                {
                    msgSuggestedProgramId = "This member does not have preferences";
                }
                else
                {
                    ActServiceReference.WebServiceSoapClient client = new ActServiceReference.WebServiceSoapClient();
                    DataTable dt = MyAdoHelper.ExecuteDataTable(filename, "Select fldProgramDuration,fldProgramType from tblMemberPreferences Where fldMemberId='" + memberUsername + "'");
                    Preferences preferences = new Preferences(int.Parse(dt.Rows[0].ItemArray[0].ToString()), dt.Rows[0].ItemArray[1].ToString(), memberUsername);
                    float memberTrainingYears = float.Parse(MyAdoHelper.ExecuteDataTable(filename, "Select fldTrainingYears from tblMember Where fldMemberId='" + memberUsername + "'").Rows[0].ItemArray[0].ToString());
                    DateTime birthdate = DateTime.Parse(MyAdoHelper.ExecuteDataTable(filename, "Select fldBirthday from tblMember Where fldMemberId='" + memberUsername + "'").Rows[0].ItemArray[0].ToString());
                    //calculating age
                    int age = 0;
                    age = DateTime.Now.Subtract(birthdate).Days;
                    age = age / 365;

                    int suggestedProgramId = Algorithems.suggestedProgramToMember(preferences, Session["username"].ToString(), memberTrainingYears, age);
                    if (suggestedProgramId == -1)
                        msgSuggestedProgramId = "Did not find program for this member";
                    else
                        msgSuggestedProgramId = "Suggested program for this member: " + suggestedProgramId.ToString();
                }
            }
        }
    }
}