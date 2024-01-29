using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Trainer
/// </summary>
public class Trainer : Member
{
    private float fldSeniorityTeaching;
    private string weekWorkshift;
    private float currentPayment;

    public Trainer(float fldSeniorityTeaching, string weekWorkshift, float currentPayment, string name, string lastName, float trainingYears, bool gender, string phone, string joiningDay, string membershipExpire, string username, string password, string mail, int key) : base(name, lastName, trainingYears, gender, phone, joiningDay, membershipExpire,username, password, mail, key)
    {
        this.fldSeniorityTeaching = fldSeniorityTeaching;
        this.weekWorkshift = weekWorkshift;
        this.currentPayment = currentPayment;
    }

    public float FldSeniorityTeaching { get => fldSeniorityTeaching; set => fldSeniorityTeaching = value>50?0:value; }
    public string WeekWorkshift { get => weekWorkshift; set => weekWorkshift = value; }
    public float CurrentPayment { get => currentPayment; set => currentPayment = value; }
}