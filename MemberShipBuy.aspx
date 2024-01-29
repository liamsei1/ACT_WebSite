<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MemberShipBuy.aspx.cs" Inherits="MemberShipBuy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <title>Educational registration form</title>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700" rel="stylesheet">
    <style>
      .mainToThis{
      min-height: 100%;
        padding: 0;
      margin: 0;
      outline: none;
      font-family: Roboto, Arial, sans-serif;
      font-size: 16px;
      color: #eee;
      background: url("/uploads/media/default/0001/01/b5edc1bad4dc8c20291c8394527cb2c5b43ee13c.jpeg") no-repeat center;
      background-size: cover;
      }
      body, div, form, input, select, p { 
      padding: 0;
      margin: 0;
      outline: none;
      font-family: Roboto, Arial, sans-serif;
      font-size: 16px;
      color: #eee;
      }
      body {
      background: url("/uploads/media/default/0001/01/b5edc1bad4dc8c20291c8394527cb2c5b43ee13c.jpeg") no-repeat center;
      background-size: cover;
      }
      h1, h2 {
      text-transform: uppercase;
      font-weight: 400;
      }
      h2 {
      margin: 0 0 0 8px;
      }
      .main-block {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      height: 100%;
      padding: 25px;
      background: rgba(0, 0, 0, 0.5); 
      }
      .left-part, form {
      padding: 25px;
      }
      .left-part {
      text-align: center;
      }
      .fa-graduation-cap {
      font-size: 72px;
      }
      form {
      background: rgba(0, 0, 0, 0.7); 
      }
      .title {
      display: flex;
      align-items: center;
      margin-bottom: 20px;
      }
      .info {
      display: flex;
      flex-direction: column;
      }
      input, select {
      padding: 5px;
      margin-bottom: 30px;
      background: transparent;
      border: none;
      border-bottom: 1px solid #eee;
      }
      input::placeholder {
      color: #eee;
      }
      option:focus {
      border: none;
      }
      option {
      background: black; 
      border: none;
      }
      .checkbox input {
      margin: 0 10px 0 0;
      vertical-align: middle;
      }
      .checkbox a {
      color: #26a9e0;
      }
      .checkbox a:hover {
      color: #85d6de;
      }
      .btn-item, .button {
      padding: 10px 5px;
      margin-top: 20px;
      border-radius: 5px; 
      border: none;
      background: #26a9e0; 
      text-decoration: none;
      font-size: 15px;
      font-weight: 400;
      color: #fff;
      }
      .btn-item {
      display: inline-block;
      margin: 20px 5px 0;
      }
      .button {
      width: 100%;
      }
      .button:hover, .btn-item:hover {
      background: #85d6de;
      }
      @media (min-width: 568px) {
      html, body {
      height: 100%;
      }
      .main-block {
      flex-direction: row;
      height: calc(100% - 50px);
      }
      .left-part, form {
      flex: 1;
      height: auto;
      }
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <h1 style="text-align:center; color:red; padding-top:30px;">קניית מנוי</h1>
    <div class="mainToThis">
    <div class="main-block">
      <div class="left-part">
        <i class="fas fa-graduation-cap"></i>
        <h1>Register to our Gym</h1>
        <p>Act gym memebership provides you the right to train in the gym, and you get more surprises!</p>
      </div>
      <form id="form" runat="server" method="post" action="">
        <div class="title">
          <i class="fas fa-pencil-alt"></i> 
          <h2>Add MemberShip here</h2>
        </div>
        <div class="info">
          <input class="fname" type="text" name="firstName" id="firstName" placeholder="First Name" runat="server">
          
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
               ControlToValidate="firstName" Display="Dynamic" ValidationGroup="MemberShipValidate"
               ErrorMessage="must fill a name" ForeColor="Red">
         </asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="firstName" ValidationGroup="MemberShipValidate"
                ValidationExpression="^\w[^א-ת]{1,50}" 
                ErrorMessage="משתמש לא יכול להכיל עברית וקטן מ-50" ForeColor="Red" Display="Dynamic">
         </asp:RegularExpressionValidator> 

          <input type="text" name="lastName" id="lastName" placeholder="Last Name" runat="server">
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
               ControlToValidate="lastName" Display="Dynamic" ValidationGroup="MemberShipValidate"
               ErrorMessage="must fill a last name" ForeColor="Red">
         </asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ControlToValidate="lastName" ValidationGroup="MemberShipValidate"
                ValidationExpression="^\w[^א-ת]{1,50}" 
                ErrorMessage="משתמש לא יכול להכיל עברית וקטן מ-50" ForeColor="Red" Display="Dynamic">
         </asp:RegularExpressionValidator> 
       

          <input type="text" name="trainingYears" id="trainingYears" placeholder="Training Years" runat="server">

            <select name="gender" id="gender" runat="server"> 
            <option value="course-type" selected>Male</option>
            <option value="short-courses">Femael</option>
           </select>

            <p>Birhday</p><input type="date" name="birthday" id="birthday"  runat="server"/>
        </div>
        <div class="checkbox">
          <input type="checkbox" name="checkbox2" id="checkbox2" runat="server"><span>I agree to the <a href="https://www.w3docs.com/privacy-policy">Privacy Poalicy for MemberShip.</a></span>
        </div>
        <asp:Button Text="Submit" CssClass="button" ID="btnSubmit" runat="server" ValidationGroup="MemberShipValidate" OnClick="btnSubmit_Click"/>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText=":סיכום שגיאות הקלט"
         ValidationGroup="UserRegisterValidate" ForeColor="Red" DisplayMode="List" 
         ShowMessageBox="true" Font-Bold="True" Font-Size="X-Large"/>
         </form>
    </div>
   </div>
</asp:Content>

