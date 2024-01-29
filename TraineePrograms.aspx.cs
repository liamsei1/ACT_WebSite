using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TraineePrograms : System.Web.UI.Page
{
    public string msg;
    public string msg2;
    public string msgRequest;
    public string fileName = "Database.mdf";

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
        {
            // שם ערכים הטופס העדופות אם קיימים
            if (Request.Cookies["preferences"] != null)
            {
                programDuration.Value = Request.Cookies["program_duration"].Value;
                programType.Value = Request.Cookies["program_type"].Value;
            }

            MyAdoHelper helper = new MyAdoHelper();
            // string cmdProgramFind = "SELECT fldProgramId FROM tblTrainee WHERE fldTraineeId=" + Session["TraineeId"];
            // string traineeProgramId = helper.getDataSet(cmdProgramFind).Tables[0].Rows[0].ItemArray[0].ToString();
            string cmdGetCurrentProgram = "SELECT P.fldProgramDuration,P.fldProgramType,P.fldProgramLevel,fldProgram,fldTrainerId FROM tblPrograms P WHERE P.fldProgramId in (Select NEWP.fldProgramId from tblProgramToTrainee NEWP where NEWP.fldMemberId ='" + Session["username"] + "' AND NEWP.fldIsFinished ='0')";
            DataSet ds = helper.getDataSet(cmdGetCurrentProgram);


            DataTable dt = ds.Tables[0];
            dt.TableName = "program"; //set name of each element
            ds.DataSetName = "PROGRAMS";

            ds.WriteXml(Server.MapPath(@"FileFromDB.xml"));
            string path = "FileFromDB.xml";
            msg = "<a href =" + path + "> קישור לקובץ התוכנית החדשה </a>";


            string cmdGetOldProgram = "SELECT P.fldProgramDuration,P.fldProgramType,P.fldProgramLevel,fldProgram,fldTrainerId FROM tblPrograms P WHERE P.fldProgramId in (Select NEWP.fldProgramId from tblProgramToTrainee NEWP where NEWP.fldMemberId ='" + Session["username"] + "' AND NEWP.fldIsFinished ='1')";
            DataSet ds2 = helper.getDataSet(cmdGetOldProgram);
            DataTable dt2 = ds.Tables[0];
            dt2.TableName = "program"; //set name of each element
            ds2.DataSetName = "PROGRAMS";

            ds.WriteXml(Server.MapPath(@"FileFromDB.xml"));
            string path2 = "FileFromDB.xml";
            msg2 = "<a href =" + path2 + "> קישור לקובץ התוכנית הישנה </a>";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string program_duration = programDuration.Value;
            string program_type = programType.Value;
            // שומר את העדפות של הלקוח בעוגייה
            if (Request.Cookies["preferences"] == null) // בודק שאין לו כבר העדפות ולכן יוצר עוגייה
            {
                HttpCookie preferences = new HttpCookie("preferences");
                HttpCookie duration = new HttpCookie("program_duration");
                duration.Value = program_duration;
                duration.Expires = DateTime.Now.AddDays(60);
                HttpCookie type = new HttpCookie("program_type");
                type.Value = program_type;
                type.Expires = DateTime.Now.AddDays(60);
                Response.Cookies.Add(preferences);
                Response.Cookies.Add(duration);
                Response.Cookies.Add(type);
            }
            else   // יש לו העדפות כבר, רק משנה את הערך שלהם
            {
                HttpCookie duration = Request.Cookies["program_duration"];
                duration.Value = program_duration;
                HttpCookie type = Request.Cookies["program_type"];
                duration.Value = program_type;
            }
            // add or change preferences in database
            Preferences memberPreferences = new Preferences(int.Parse(program_duration), program_type, Session["username"].ToString());
            MyAdoHelper helper = new MyAdoHelper();
            helper.addOrChangePreferences(memberPreferences, fileName);
        }
    }

    protected void btnAskFor_Click(object sender, EventArgs e)
    {
        if (!MyAdoHelper.IsExist("Database.mdf", "Select * from tblUserProgramRequest where fldUsername='" + Session["username"] + "'")) // בודק שאין לו כבר בקשה לתוכנית ב-90 ימים האחרונים
        {
            MyAdoHelper helper=new MyAdoHelper();
            helper.ExecuteNonQuery("Database.mdf", "Insert Into tblUserProgramRequest VALUES ('" + Session["username"] + "','" + DateTime.Today.ToString() + "','0')" );
            msgRequest = "your request is accepted we will deal with is as soon as possible";
            /*
                
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
                    if (suggestedProgramId == -1){
                         helper.ExecuteNonQuery("Database.mdf", "Insert Into tblUserProgramRequest VALUES ('" + Session["username"] + "','" + DateTime.Today.ToString() + "','0')" );
                         msgRequest = "your request is accepted we will deal with is as soon as possible";
                         }
                    else{   //auto match program to member
                         helper.ExecuteNonQuery("Database.mdf", "Insert Into tblUserProgramRequest VALUES ('" + Session["username"] + "','" + DateTime.Today.ToString() + "','1')" );
                         string cmdString = "INSERT INTO tblProgramToTrainee (fldProgramId,fldMemberId,fldIsFinished)";
                         cmdString += " VALUES('" + suggestedProgramId.ToString() + "','" + Session["username"].ToString() + "','" + "0" + "')";
                         MyAdoHelper.DoQuery(filename, cmdString); // run the query
                         }
            */
        }
        else   // הוא ביקש כבר תוכנית ב-3 חודשים האחרונים
        {
            msgRequest = "you already requested program in the past 3 months";
        }

    }
}