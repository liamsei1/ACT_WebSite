using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DateTime getDate()
    {
        DateTime now = DateTime.UtcNow.Date;
        return now;
    }

    [WebMethod]
    public string getDate2()
    {
        DateTime now = DateTime.UtcNow.Date;
        return now.ToString();
    }

    [WebMethod]
    public int suggestedProgramToMember(Preferences preferences, string trainerUsername, float memberTrainingYears)
    {
        int dummy = -1; //prepare dummy program if we failed
        string sqlCommand1 = "select * from tblPrograms Where fldTrainerId='" + trainerUsername + "'";
        DataTable dt2 = MyAdoHelper.ExecuteDataTable("Database.mdf", sqlCommand1);
        DataSet dsPrograms = MyAdoHelper.GetDataSet(sqlCommand1);
        int programsCount = dsPrograms.Tables[0].Rows.Count;
        if (programsCount == 0) return dummy;   //if there are no programs, we failed
        Programs[] programs = new Programs[programsCount];
        int i = 0;
        foreach (DataRow program1 in dsPrograms.Tables[0].Rows)
        {
            int fldProgramId = int.Parse(program1.ItemArray[0].ToString());
            int fldProgramDuration = int.Parse(program1.ItemArray[1].ToString());
            string fldProgramType = program1.ItemArray[2].ToString();
            int fldProgramLevel = int.Parse(program1.ItemArray[3].ToString()); ;
            string fldProgram = program1.ItemArray[4].ToString();
            string fldTrainerId = program1.ItemArray[5].ToString();
            programs[i++] = new Programs(fldProgramId, fldProgramDuration, fldProgramType, fldProgramLevel, fldProgram, fldTrainerId);
        }
        Array.Sort(programs, delegate (Programs x, Programs y) { return x.FldProgramLevel.CompareTo(y.FldProgramLevel); });   //sort array by program level
        int memberLevel = 0; //assing level to member
        i = 0; //reset i
        if (memberTrainingYears < 2)
        {
            memberLevel = 1;
        }
        else if (memberTrainingYears < 4)
        {
            memberLevel = 2;
        }
        else
        {
            memberLevel = 3;
        }
        while (i < programsCount && memberLevel >= programs[i].FldProgramLevel) i++;
        if (i == 0) return dummy;   //if there are no programs in his level range, we failed
        Programs[] programs2 = new Programs[i];
        Array.ConstrainedCopy(programs, 0, programs2, 0, i);  //get all the programs that fits member level
        int counter = 0;
        for (int j = 0; j < programs2.Length; j++)              //count how many programs for member type there are
        {
            if (programs2[j].FldProgramType == preferences.ProgramType)
                counter++;
        }
        Programs[] programs3 = new Programs[counter];              //get all the prgrams that are the type the member wants
        i = 0;
        for (int j = 0; j < programs2.Length; j++)
        {
            if (programs2[j].FldProgramType == preferences.ProgramType)
                programs3[i++] = programs2[j];
        }
        if (i == 0) return dummy;   //if there are no programs that are his type, we failed
        Array.Sort(programs3, delegate (Programs x, Programs y) { return x.FldProgramDuration.CompareTo(y.FldProgramDuration); });   //sort array by durations
        //binary search, member program duration
        int minNum = 0;
        int maxNum = programs3.Length - 1;
        int key = preferences.ProgramDuration;
        bool found = false;
        int mid = 0;
        while (found == false && minNum <= maxNum)
        {
            mid = (minNum + maxNum) / 2;
            if (key == programs3[mid].FldProgramDuration)
            {
                ++mid;
                found = true;
            }
            else if (key < programs3[mid].FldProgramDuration)
            {
                maxNum = mid - 1;
            }
            else
            {
                minNum = mid + 1;
            }
        }
        return programs3[mid].FldProgramId; //best matching program for member
    }

    
    [WebMethod]
    public programToMember[] suggestedProgramsToMembers()
    {
        string sqlCommand = "select * from tblMember";
        DataSet dsUserAndTrainingyears= MyAdoHelper.GetDataSet(sqlCommand);
        int membersCount = dsUserAndTrainingyears.Tables[0].Rows.Count;
        Member[] members = new Member[membersCount];
        int i = 0;
        foreach(DataRow member in dsUserAndTrainingyears.Tables[0].Rows)
        {
            string username = member.ItemArray[0].ToString();
            string name=member.ItemArray[1].ToString();
            string lastNamemember=member.ItemArray[2].ToString();
            float trainingYears= float.Parse(member.ItemArray[3].ToString()); 
            bool gender= bool.Parse(member.ItemArray[4].ToString()); ;
            string birthDay= member.ItemArray[5].ToString();
            string joiningDay= member.ItemArray[6].ToString();
            string membershipExpire= member.ItemArray[7].ToString();
            members[i++] = new Member(name,lastNamemember,trainingYears,gender, birthDay, joiningDay,membershipExpire, username,"","",0); // we dont care about the password, mail and key 
        }
        Array.Sort(members, delegate (Member x, Member y) { return x.TrainingYears.CompareTo(y.TrainingYears);});   //sort array by training years

        string sqlCommand2 = "select * from tblPrograms";
        DataSet dsPrograms = MyAdoHelper.GetDataSet(sqlCommand2);
        int programsCount = dsPrograms.Tables[0].Rows.Count;
        Programs[] programs = new Programs[programsCount];
        i = 0;
        foreach (DataRow program in dsPrograms.Tables[0].Rows)
        {
            int fldProgramId = int.Parse(program.ItemArray[0].ToString());
            int fldProgramDuration = int.Parse(program.ItemArray[1].ToString());
            string fldProgramType = program.ItemArray[2].ToString();
            int fldProgramLevel = int.Parse(program.ItemArray[3].ToString()); ;
            string fldProgram = program.ItemArray[4].ToString();
            string fldTrainerId = program.ItemArray[5].ToString();
            programs[i++] = new Programs(fldProgramId, fldProgramDuration, fldProgramType, fldProgramLevel, fldProgram, fldTrainerId); 
        }
        Array.Sort(programs, delegate (Programs x, Programs y) { return x.FldProgramLevel.CompareTo(y.FldProgramLevel); });   //sort array by program level

        int[] levels = new int[3];  //save the last index in the sorted program array of every level (level1 index=levels[0] ...)
        i = 1;
        if (programs[0].FldProgramLevel > 1)
            i = 2;
        if (programs[0].FldProgramLevel > 2)
            i = 3;      
        for (int j=0; j < programsCount; j++)
        {
            if (programs[j].FldProgramLevel != i)
                levels[i - 1] = j - 1;
        }


        Random rnd = new Random();
        int ramdomNumber=0;
        programToMember[] programToMembers = new programToMember[membersCount]; //match all members a program base on level
        for (int j=0; j<membersCount; j++)
        {
            if (members[j].TrainingYears < 1)
            {
                ramdomNumber=rnd.Next(0, levels[0] + 1);
            }
            if (members[j].TrainingYears < 2)
            {
                ramdomNumber=rnd.Next(levels[0] + 1, levels[1] + 1);
            }
            if (members[j].TrainingYears < 3)
            {
                ramdomNumber=rnd.Next(levels[1] + 1, levels[2] + 1);
            }
            programToMembers[j] = new programToMember(programs[ramdomNumber], members[j]);
        }
        return programToMembers;
    }


    /*
    [WebMethod]
    //match to a specific member a program
    public int suggestedProgramToMember(string memberId, int programDuration, string programType, string trainerId)
    {
        Preferences preferences = new Preferences(programDuration, programType, memberId);
        int dummy = -1; //prepare dummy program if we failed
        string sqlCommand1 = "select * from tblPrograms Where fldTrainerId='" + trainerId + "'";
        DataTable dt = MyAdoHelper.ExecuteDataTable("Database.mdf", sqlCommand1);
        DataSet dsPrograms = MyAdoHelper.GetDataSet(sqlCommand1);
        int programsCount = dsPrograms.Tables[0].Rows.Count;
        if (programsCount == 0) return dummy;   //if there are no programs, we failed
        Programs[] programs = new Programs[programsCount];
        int i = 0;
        foreach (DataRow program in dsPrograms.Tables[0].Rows)
        {
            int fldProgramId = int.Parse(program.ItemArray[0].ToString());
            int fldProgramDuration = int.Parse(program.ItemArray[1].ToString());
            string fldProgramType = program.ItemArray[2].ToString();
            int fldProgramLevel = int.Parse(program.ItemArray[3].ToString()); ;
            string fldProgram = program.ItemArray[4].ToString();
            string fldTrainerId = program.ItemArray[5].ToString();
            programs[i++] = new Programs(fldProgramId, fldProgramDuration, fldProgramType, fldProgramLevel, fldProgram, fldTrainerId);
        }
        Array.Sort(programs, delegate (Programs x, Programs y) { return x.FldProgramLevel.CompareTo(y.FldProgramLevel); });   //sort array by program level
        sqlCommand1 = "select fldTrainingYears from tblMember Where fldMemberId='" + preferences.MemberId + "'";    // get member training years
        int memberTrainingYears = int.Parse(MyAdoHelper.GetDataSet(sqlCommand1).Tables[0].Rows[0].ItemArray[0].ToString());
        int memberLevel = 0; //assing level to member
        i = 0; //reset i
        if (memberTrainingYears < 2)
        {
            memberLevel = 1;
        }
        else if (memberTrainingYears < 4)
        {
            memberLevel = 2;
        }
        else
        {
            memberLevel = 3;
        }
        while (i < programsCount && memberLevel <= programs[i].FldProgramLevel) i++;
        if (i == 0) return dummy;   //if there are no programs in his level range, we failed
        Programs[] programs2 = new Programs[i];
        Array.ConstrainedCopy(programs, 0, programs2, 0, i);  //get all the programs that fits member level
        Programs[] programs3 = new Programs[i];              //get all the prgrams that are the type the member wants
        i = 0;
        for (int j = 0; j < programs2.Length; j++)
        {
            if (programs2[j].FldProgramType == preferences.ProgramType)
                programs3[i++] = programs2[j];
        }
        if (i == 0) return dummy;   //if there are no programs that are his type, we failed
        Array.Sort(programs3, delegate (Programs x, Programs y) { return x.FldProgramDuration.CompareTo(y.FldProgramDuration); });   //sort array by durations
        //binary search, member program duration
        int minNum = 0;
        int maxNum = programs3.Length - 1;
        int key = preferences.ProgramDuration;
        bool found = false;
        int mid = 0;
        while (found == false && minNum <= maxNum)
        {
            mid = (minNum + maxNum) / 2;
            if (key == programs3[mid].FldProgramDuration)
            {
                ++mid;
                found = true;
            }
            else if (key < programs3[mid].FldProgramDuration)
            {
                maxNum = mid - 1;
            }
            else
            {
                minNum = mid + 1;
            }
        }
        return programs3[mid].FldProgramId; //best matching program for member
    }

    */


}
