<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TraineePrograms.aspx.cs" Inherits="TraineePrograms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <title>MemberPrograms</title>
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700" rel="stylesheet">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous">
    <style>
      html, body {
      display: flex;
      justify-content: center;
      height: 100%;
      }
      body, div, h1, form, input, p { 
      padding: 0;
      margin: 0;
      outline: none;
      font-family: Roboto, Arial, sans-serif;
      font-size: 16px;
      color: #666;
      }
      h1 {
      padding: 10px 0;
      font-size: 32px;
      font-weight: 300;
      text-align: center;
      }
      p {
      font-size: 12px;
      }
      hr {
      color: #a9a9a9;
      opacity: 0.3;
      }
      .main-block {
      max-width: 340px; 
      min-height: 340px; 
      padding: 10px 0;
      margin: auto;
      border-radius: 5px; 
      border: solid 1px #ccc;
      box-shadow: 1px 2px 5px rgba(0,0,0,.31); 
      background: #ebebeb; 
      }
      form {
      margin: 0 30px;
      }

      label#icon {
      margin: 0;
      border-radius: 5px 0 0 5px;
      }

      input[type=text], input[type=password] {
      width: calc(100% - 57px);
      height: 36px;
      margin: 13px 0 0 -5px;
      padding-left: 10px; 
      border-radius: 0 5px 5px 0;
      border: solid 1px #cbc9c9; 
      box-shadow: 1px 2px 5px rgba(0,0,0,.09); 
      background: #fff; 
      }
      input[type=password] {
      margin-bottom: 15px;
      }
      #icon {
      display: inline-block;
      padding: 9.3px 15px;
      box-shadow: 1px 2px 5px rgba(0,0,0,.09); 
      background: #1c87c9;
      color: #fff;
      text-align: center;
      }
      .btn-block {
      margin-top: 10px;
      text-align: center;
      }
      button {
      width: 100%;
      padding: 10px 0;
      margin: 10px auto;
      border-radius: 5px; 
      border: none;
      background: #1c87c9; 
      font-size: 14px;
      font-weight: 600;
      color: #fff;
      }
      button:hover {
      background: #26a9e0;
      }
      .Button{
      width: 100%;
      padding: 10px 0;
      margin: 10px auto;
      border-radius: 5px; 
      border: none;
      background: #1c87c9; 
      font-size: 14px;
      font-weight: 600;
      color: #fff;
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div dir="rtl" style="font-size:large; margin-top:100px;">
        <h1>התוכניות שלך</h1>
         <%=msg%>
        <br>
         <%=msg2%>
    </div>

          <form id="form" runat="server" action="">     
    <div class="main-block" style="margin-top:30px">
      <h1>Preferences</h1>
        <hr>
        <label id="icon" for="programDuration"><i class="fas fa-stopwatch"></i></label>
        <input type="text" name="programDuration" id="programDuration" runat="server" placeholder="Program Duration" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="programDuration" ErrorMessage="Duration is required field." Display="Dynamic" ValidationGroup="PreferencesValidate"></asp:RequiredFieldValidator>
              <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="programDuration" 
                         Type="Integer" MinimumValue="14" MaximumValue="365" Display="Dynamic"
                         ErrorMessage ="זמן התוכנית חייב להיות בין 14 ל 365" ForeColor="Black" 
                         ValidationGroup="PreferencesValidate">
              </asp:RangeValidator>
        <label id="icon" for="programType"><i class="fas fa-weight-hanging"></i></label>
        <input type="text" name="programType" id="programType" runat="server" placeholder="Program Type" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="programType" ErrorMessage="Program type is required field." Display="None" ValidationGroup="PreferencesValidate"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[^!-/:-@[-`{-~^]{4,15}$" ControlToValidate="programType" ErrorMessage="Program type can't contain special characters and must be between 4-15 chars" Display="Dynamic" ValidationGroup="PreferencesValidate"></asp:RegularExpressionValidator>
        <hr>
        <div class="btn-block">
          <p>By Submitting, you agree on our <a href="">Privacy Policy for Act</a>.</p>
          <asp:Button Text="Submit" runat="server" CssClass="Button" ID="btnSubmit" ValidationGroup="PreferencesValidate" OnClick="btnSubmit_Click" />
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText=":סיכום שגיאות הקלט"
            ValidationGroup="PreferencesValidate" ForeColor="Red" DisplayMode="List" 
            ShowMessageBox="true" Font-Bold="True" Font-Size="Large"/>
        </div>
    </div>
       <asp:Button Text="Request Program" runat="server" CssClass="Button" ID="askFor"  OnClick="btnAskFor_Click" style="margin-top:30px"/>
    </form>

    <%=msgRequest%>
</asp:Content>

