using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for preferences
/// </summary>
public class Preferences
{
    private int programDuration;
    private string programType;
    private string memberId;

    public Preferences()
    {
    }

    public Preferences(int programDuration, string programType, string memberId)
    {
        this.programDuration = programDuration;
        this.programType = programType;
        this.memberId = memberId;
    }

    public int ProgramDuration { get => programDuration; set => programDuration = value; }
    public string ProgramType { get => programType; set => programType = value; }
    public string MemberId { get => memberId; set => memberId = value; }
}