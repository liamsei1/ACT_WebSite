using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for Algorithems
/// </summary>
public class Algorithems
{
    public Algorithems()
    {
    }

    //match to a specific member a program
    public static int suggestedProgramToMember(Preferences preferences, string trainerUsername, float memberTrainingYears, int age)
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
        if (memberTrainingYears < 2 || age>70)
        {
            memberLevel = 1;
        }
        else if (memberTrainingYears < 4 || age>50)
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
}