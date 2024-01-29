using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateUserInfo : System.Web.UI.Page
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
        sqlSelect = "SELECT fldPassword,fldMail FROM tblUser where fldUsername='" + Session["username"] + "'";
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
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string strFldPassword = ((TextBox)row.Cells[0].Controls[0]).Text; // BoundField -גישה לנתון בעמודה המוגדרת כ
        string strFldMail = ((TextBox)changedRow.Cells[1].Controls[0]).Text;
        string cmdString = "UPDATE tblUser SET fldPassword='" + strFldPassword + "',fldMail='" + strFldMail + "' WHERE fldUsername=" + Session["username"] + "'";
        helper = new MyAdoHelper();
        helper.ExecuteNonQuery(filename, cmdString);
        GridView1.EditIndex = -1;
        getUsers(); // קישור מחדש למקור המידע
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string userName = GridView1.SelectedRow.Cells[0].Text;
        getCreditCards(userName);
    }

    public void getCreditCards(string username)
    {
        helper = new MyAdoHelper();
        sqlSelect = "SELECT * FROM tblCredit where fldUsername='" + Session["username"] + "'";
        ds = helper.getDataSet(sqlSelect);
        //DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
        DetailsView1.DataSource = ds.Tables[0];
        DetailsView1.DataBind();
    }

     protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        DetailsView1.PageIndex = e.NewPageIndex;
        string username = GridView1.SelectedRow.Cells[0].Text;
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
        string username  = GridView1.SelectedRow.Cells[0].Text;
        getCreditCards(username);
    }


}
