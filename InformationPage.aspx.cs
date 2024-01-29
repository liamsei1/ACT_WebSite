using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformationPage : System.Web.UI.Page
{
    public string msgUserCount="0";
    public string filename = "Database.mdf";

    protected void Page_Load(object sender, EventArgs e)
    {
        string sqlSelectCountMember = "Select COUNT(fldMemberId) from tblMember";
        msgUserCount = MyAdoHelper.ExecuteDataTable(filename, sqlSelectCountMember).Rows[0].ItemArray[0].ToString();
    }
}