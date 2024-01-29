using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Users
/// </summary>
public class User
{
    protected string username;
    protected string password;
    protected string mail;
    protected int key;

    public User(string username, string password, string mail, int key)
    {
        this.username = username;
        this.password = password;
        this.mail = mail;
        this.key = key;
    }
    public User() { }

    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
    public string Mail { get => mail; set => mail = value; }
    public int Key { get => key; set => key = (value>6 || value<0 ? 0:value); }
} 