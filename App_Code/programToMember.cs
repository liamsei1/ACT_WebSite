using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for programToMember
/// </summary>
public class programToMember
{
    private Programs program;
    private Member member;

    public programToMember()
    {
    }

    public programToMember(Programs program, Member member)
    {
        this.program = program;
        this.member = member;
    }

    public Programs Program { get => program; set => program = value; }
    public Member Member { get => member; set => member = value; }
}