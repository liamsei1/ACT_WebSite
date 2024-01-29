using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Security.AccessControl;

/// <summary>
/// Summary description for MyAdoHelper
/// פעולות עזר לשימוש במסד נתונים  מסוג 
/// SQL SERVER
///  App_Data המסד ממוקם בתקיה 
/// </summary>

public class MyAdoHelper
{

    public MyAdoHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static SqlConnection ConnectToDb(string fileName)
    {
        string path = HttpContext.Current.Server.MapPath("App_Data/" + fileName);//מאתר את מיקום מסד הנתונים מהשורש ועד התקייה בה ממוקם המסד
        string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + path + "; Integrated Security = True";

        SqlConnection conn = new SqlConnection(connString);
        return conn;
    }

    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומבצעת את הפעולה על המסד
    /// </summary>

    //      הפעולה מקבלת שם מסד נתונים ומחרוזת מחיקה/ הוספה/ עדכוו ומבצעת את הפקודה על המסד הפיזי
    public static void DoQuery(string fileName, string sql)
    {
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        com.ExecuteNonQuery();
        com.Dispose();
        conn.Close();
    }

    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומחזירה את מספר השורות שהושפעו מביצוע הפעולה
    /// </summary>

    // הפעולה מקבלת מסלול אל מסד הנתונים ושאילתת העדכון, מבצעת עדכון במסד הנתונים
    public static int RowsAffected(string fileName, string sql)
    {
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        int rowsA = com.ExecuteNonQuery();
        conn.Close();
        return rowsA;
    }

    /// <summary>
    /// הפעולה מקבלת שם קובץ ומשפט לחיפוש ערך - מחזירה אמת אם הערך נמצא ושקר אחרת
    /// </summary>

    //הפעולה מקבלת שם קובץ ומשפט בחירת נתון ומחזירה אמת אם הנתונים קיימים ושקר אחרת
    public static bool IsExist(string fileName, string sql)
    {
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        SqlDataReader data = com.ExecuteReader();
        bool found;
        found = (bool)data.Read();// אם יש נתונים לקריאה יושם אמת אחרת שקר - הערך קיים במסד הנתונים
        conn.Close();
        return found;
    }


    public static DataTable ExecuteDataTable(string fileName, string sql)
    {
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlDataAdapter tableAdapter = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        tableAdapter.Fill(dt);
        return dt;
    }


    public void ExecuteNonQuery(string fileName, string sql)
    {
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand command = new SqlCommand(sql, conn);
        command.ExecuteNonQuery();
        conn.Close();
    }


    public static string printDataTable(string fileName, string sql)
    {
        DataTable dt = ExecuteDataTable(fileName, sql);
        string printStr = "<table border='1'>";

        foreach (DataRow row in dt.Rows)
        {
            printStr += "<tr>";
            foreach (object myItemArray in row.ItemArray)
            {
                printStr += "<td>" + myItemArray.ToString() + "</td>";
            }
            printStr += "</tr>";
        }
        printStr += "</table>";
        return printStr;
    }

    //הפעולה מקבלת שם קובץ ומשפט בחירת נתון ומחזירה אמת אם הנתונים קיימים ושקר אחרת
    public static string printDataTable2(string fileName, string sql)
    {
        DataTable dt = ExecuteDataTable(fileName, sql);
        string printStr = "<table class='dataTable'>";
        printStr += "<thead class = 'table-head'><th>First name</th><th>Last name</th><th>Username</th><th>Email adress</th><th>Phone number</th><th>Password</th><th>Is Admin?</th></thead><tbody>";

        foreach (DataRow row in dt.Rows)
        {
            printStr += "<tr class='cell'>";
            foreach (object myItemArray in row.ItemArray)
            {
                printStr += "<td>" + myItemArray.ToString() + "</td>";
            }
            printStr += "</tr>";
        }
        printStr += "</tbody></table>";
        return printStr;
    }
    // פעולה המחזירה  DATASET
    public static DataSet GetDataSet(string cmd)
    {
        SqlConnection myConnection = ConnectToDb("Database.mdf");
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand(cmd, myConnection);
        DataSet ds = new DataSet();
        try
        {
            adapter.Fill(ds, "dtsorting");
        }
        catch (Exception exp) { ds = null; }
        finally{}
        return ds;
    }
    // פעולה המחזירה טבלה מ DATATALBE
    public static string getStringFromDataTable(DataTable dt)
    {
        string result = "<table border='1'>";
        foreach (DataRow row in dt.Rows)
        {
            result += "<tr>";
            foreach (object myItemArray in row.ItemArray)
                result += "<td>" + myItemArray.ToString() + "</td>";
            result += "</tr>";
        }
        result += "</table>";
        return result;
    }

    // הפעולה מוסיפה משתמש חדש
    public void addUserQuery(string fileName,string username, string password, string email, string key)
    {
        SqlConnection myConnection = ConnectToDb(fileName);
        string cmdString = "INSERT INTO tblUser (fldUsername,fldPassword,fldMail,fldKey) VALUES (@UserName,@password,@email,@key)";
        SqlCommand myCommand = new SqlCommand(cmdString, myConnection);
        myCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
        myCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
        myCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
        myCommand.Parameters.Add("@key", SqlDbType.Int).Value = key;
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception exp) { }
        finally { myConnection.Close(); }
    }


    // הפעולה מוסיפה אשראי חדש
    public void addCreditCardQuery(string creditNumber, string creditCode, string creditCompany, string username, string fileName)
    {
        SqlConnection myConnection = ConnectToDb(fileName);
        string cmdString = "INSERT INTO [tblCredit] (fldCreditNumber,fldCreditCode,fldCreditCompany,fldUserName) VALUES (@CreditNumber,@CreditCode,@CreditCompany,@UserName)";
        SqlCommand myCommand = new SqlCommand(cmdString, myConnection);
        myCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
        myCommand.Parameters.Add("@CreditNumber", SqlDbType.VarChar).Value = creditNumber;
        myCommand.Parameters.Add("@CreditCode", SqlDbType.VarChar).Value = creditCode;
        myCommand.Parameters.Add("@CreditCompany", SqlDbType.Int).Value = creditCompany;
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception exp) { }
        finally { myConnection.Close(); }
    }


    // בודק בהתחברות את המשתמש והרשאה שלו
    public static string getUserAccessKey(string username, string password)
    {
        string key = null;
        string cmdString = "SELECT fldKey From tblUser WHERE fldUserName=@username AND fldPassword=@password";
        SqlConnection myConnection = ConnectToDb("Database.mdf");
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand= new SqlCommand(cmdString, myConnection);
        adapter.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
        adapter.SelectCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
        DataSet ds=new DataSet();
        try
        {
            myConnection.Open();
            adapter.Fill(ds, "dtKey");
            key = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        catch (Exception exp) { key = null; }
        finally
        {
            myConnection.Close();
        }
        return key;                             
    }

    // טבלה של סטסטיסטיקה של המשתמש 
    public DataSet getDataSet(string SP)
    {
        SqlConnection Connection = ConnectToDb("Database.mdf");
        SqlDataAdapter adapter = new SqlDataAdapter(SP, Connection);
        DataSet ds = new DataSet();
        try
        {
            adapter.Fill(ds , "dtStatistic");
        }
        catch (Exception exp) {}
        finally   { }
        return ds;
    }
    // פעולת עדכון לדף אדמין
    public void adminchangeUser(string username, string password,string email, string key)
    {
        SqlConnection myConnection = ConnectToDb("Database.mdf");
        SqlCommand myCommand = new SqlCommand("AdminUpdate", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;
        //string cmdString = "UPDATE tblUser SET fldPassword = @password, fldMail = @gmail, fldKey = @key WHERE fldUserName = @username";
        //SqlCommand myCommand = new SqlCommand(cmdString, myConnection);
        myCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
        myCommand.Parameters.Add("@gmail", SqlDbType.VarChar).Value = email;
        myCommand.Parameters.Add("@key", SqlDbType.Int).Value = key;
        myCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception exp) {}
        finally { myConnection.Close(); }
    }


    // פעולה הבודקת אם יש למשתמש מספיק כסף ל MEMBERSHIP
    public void addMemberShip(string username ,string dataBase)
    {
        SqlConnection myConnection = ConnectToDb(dataBase);
        SqlCommand myCommand = new SqlCommand("AddMembership", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception exp) { }
        finally { myConnection.Close(); }
    }

    // פעולה להוספת MEMBERSHIP
    public void addMemberShip(string username, string membername, string memberLastName, float membertrainingYears, int memberGender, string memberBirthday, string memberJoiningDate, string memberEndMembershipDate, string dataBase)
    {
        SqlConnection myConnection = ConnectToDb(dataBase);
        SqlCommand myCommand = new SqlCommand("AddMembership", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
        myCommand.Parameters.Add("@membername", SqlDbType.NVarChar).Value = membername;
        myCommand.Parameters.Add("@memberLastName", SqlDbType.NVarChar).Value = memberLastName;
        myCommand.Parameters.Add("@membertrainingYears", SqlDbType.Float).Value = membertrainingYears;
        myCommand.Parameters.Add("@memberGender", SqlDbType.Bit).Value = memberGender;
        myCommand.Parameters.Add("@memberBirthday", SqlDbType.Date).Value = memberBirthday;
        myCommand.Parameters.Add("@memberJoiningDate", SqlDbType.Date).Value = memberJoiningDate;
        myCommand.Parameters.Add("@memberEndMembershipDate", SqlDbType.Date).Value = memberEndMembershipDate;
        SqlTransaction trans = null;
        try
        {
            myConnection.Open();
            trans = myConnection.BeginTransaction();
            myCommand.Transaction = trans;
            if (upgradeToMembership(username, dataBase) == false) throw new Exception();
            myCommand.ExecuteNonQuery();
            trans.Commit();
        }
        catch (Exception exp) { trans.Rollback(); }
        finally { myConnection.Close(); }
    }
    //פעולה המטפלת בקנייה

    private bool upgradeToMembership(string username, string dataBase)
    {
        string sqlSelect = "Select fldCreditNumber from tblCredit where fldUserName='" + username + "'";
        return IsExist(dataBase, sqlSelect);
    }


    // פעולה המטפלת בהוספה או עדכון של העדפות למתאמן
    public void addOrChangePreferences(Preferences memberPreferences, string dataBase)
    {
        string sqlSelect = "Select * from tblMemberPreferences where fldMemberId='" + memberPreferences.MemberId + "'";
        SqlConnection myConnection = ConnectToDb(dataBase);
        SqlCommand myCommand;
        // בודק אם כבר קיים לו העדפות
        if (IsExist(dataBase, sqlSelect) == false)
        {
            myCommand = new SqlCommand("AddPreferences", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
        }
        else
        {
            myCommand = new SqlCommand("ChangePreferences", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
        }
        myCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = memberPreferences.MemberId;
        myCommand.Parameters.Add("@programDuration", SqlDbType.Int).Value = memberPreferences.ProgramDuration;
        myCommand.Parameters.Add("@programType", SqlDbType.VarChar).Value = memberPreferences.ProgramType;

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception exp) { }
        finally { myConnection.Close(); }
    }





    // פעולה להוספת program info
    public static void addProgramInfo(string fldProgramDuration, string fldProgramType, string fldProgramLevel, string fldProgram, string username, string dataBase)
    {
        //get max program id
        string newMaxProgramId;
        string sqlSelect = "SELECT MAX(fldProgramId) FROM tblPrograms WHERE fldTrainerId='" + username + "'";
        DataSet ds = GetDataSet(sqlSelect);
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            newMaxProgramId = "1";
        }
        else
        {
            string maxProgramId = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            newMaxProgramId = (int.Parse(maxProgramId) + 1).ToString();
        }
        SqlConnection myConnection = ConnectToDb(dataBase);
        SqlCommand myCommand = new SqlCommand("AddProgramInfo", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
        myCommand.Parameters.Add("@ProgramDuration", SqlDbType.Int).Value = fldProgramDuration;
        myCommand.Parameters.Add("@ProgramType", SqlDbType.VarChar).Value = fldProgramType;
        myCommand.Parameters.Add("@ProgramLevel", SqlDbType.Int).Value = fldProgramLevel;
        myCommand.Parameters.Add("@Program", SqlDbType.NVarChar).Value = fldProgram;
        myCommand.Parameters.Add("@ProgramId", SqlDbType.Int).Value = newMaxProgramId;
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception exp) { }
        finally { myConnection.Close(); }
    }
}