using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateInfo : System.Web.UI.Page
{
    string sqlSelect;
    public DataSet ds;
    MyAdoHelper helper;
    string filename = "Database.mdf";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            getUsers();
    }
    public void getUsers()
    {
        helper = new MyAdoHelper();
        sqlSelect = "SELECT fldName,fldLastName,fldTrainingYears,fldGender,fldBirthday FROM tblMember where fldMemberId='" + Session["username"]+"'";
        ds = helper.getDataSet(sqlSelect);
        //DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
    // עריכה
    protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        getUsers(); // קישור מחדש למקור המידע 
    }
    // ביטול עריכה
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        getUsers(); // קישור מחדש למקור המידע
    }
    // עדכון
    public void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string filename = "Database.mdf";
        GridViewRow changedRow = GridView1.Rows[e.RowIndex];
        GridViewRow row= GridView1.Rows[e.RowIndex];
        string Name = ((TextBox)row.Cells[0].Controls[0]).Text; // BoundField -גישה לנתון בעמודה המוגדרת כ
        string lastName = ((TextBox)changedRow.Cells[1].Controls[0]).Text;
        string trainingYears = ((TextBox)changedRow.Cells[2].Controls[0]).Text;
        string gender = ((TextBox)changedRow.Cells[3].Controls[0]).Text;
        string birthday = ((TextBox)changedRow.Cells[4].Controls[0]).Text;

        string cmdString = "UPDATE tblTrainer SET fldName=N'" + Name + "',fldLastName=N'" + lastName + "',fldTrainingYears='" + trainingYears + "',fldGender='" + gender + "',fldBirthday='" + birthday + "' WHERE fldMemberId='" + Session["username"] + "'";
        helper = new MyAdoHelper();
        helper.ExecuteNonQuery(filename,cmdString);
        GridView1.EditIndex = -1;
        getUsers(); // קישור מחדש למקור המידע
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string userName = GridView1.SelectedRow.Cells[1].Text;
    }

    /*
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow DeletedRow = GridView1.Rows[e.RowIndex];
        string strUser = DeletedRow.Cells[0].Text;
        string cmdString;
        cmdString = "DELETE FROM tblTrainer WHERE fldTrainerId='" + strUser + "'";
        helper = new MyAdoHelper();
        helper.ExecuteNonQuery(filename, cmdString);
        GridView1.EditIndex = -1; //משחרר את בחירת השורה
        getUsers();
    }
    */
}
