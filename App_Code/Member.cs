using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Member
/// </summary>
public class Member: User
{
    private string name;
    private string lastName;
    private float trainingYears;
    private bool gender;
    private string birhDay;
    private string joiningDay;
    private string membershipExpire;

    public Member()
    {
    }

    public Member(string name, string lastName, float trainingYears, bool gender, string birhDay, string joiningDay, string membershipExpire, string username, string password, string mail, int key) : base(username, password, mail, key)
    {
        this.name = name;
        this.lastName = lastName;
        this.trainingYears = trainingYears;
        this.gender = gender;
        this.birhDay = birhDay;
        this.joiningDay = joiningDay;
        this.membershipExpire = membershipExpire;
    }

    public string Name { get => name; set => name = value; }
    public string LastName { get => lastName; set => lastName = value; }
    public float TrainingYears { get => trainingYears; set => trainingYears = value>50?0:value; }
    public bool Gender { get => gender; set => gender = value; }
    public string JoiningDay { get => joiningDay; set => joiningDay = value; }
    public string MembershipExpire { get => membershipExpire; set => membershipExpire = value; }
    public string BirhDay { get => birhDay; set => birhDay = value; }
}