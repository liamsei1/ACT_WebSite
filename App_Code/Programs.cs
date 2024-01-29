using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Programs
/// </summary>
public class Programs
{
    private int fldProgramId;
    private int fldProgramDuration;
    private string fldProgramType;
    private int fldProgramLevel;
    private string fldProgram;
    private string fldTrainerId;

    public Programs()
    {
    }

    public Programs(int fldProgramId, int fldProgramDuration, string fldProgramType, int fldProgramLevel, string fldProgram, string fldTrainerId)
    {
        this.fldProgramId = fldProgramId;
        this.fldProgramDuration = fldProgramDuration;
        this.fldProgramType = fldProgramType;
        this.fldProgramLevel = fldProgramLevel;
        this.fldProgram = fldProgram;
        this.fldTrainerId = fldTrainerId;
    }

    public int FldProgramId { get => fldProgramId; set => fldProgramId = value; }
    public int FldProgramDuration { get => fldProgramDuration; set => fldProgramDuration = value; }
    public string FldProgramType { get => fldProgramType; set => fldProgramType = value; }
    public int FldProgramLevel { get => fldProgramLevel; set => fldProgramLevel = value; }
    public string FldProgram { get => fldProgram; set => fldProgram = value; }
    public string FldTrainerId { get => fldTrainerId; set => fldTrainerId = value; }
}