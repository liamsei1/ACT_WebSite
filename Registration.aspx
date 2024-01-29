<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container">
        <h1 style="color:greenyellow; font-size:500%; text-align:center;"> דף הירשמות  </h1>
    <form id="form1" runat="server" style="text-align:center" method="post">
        <h2 style="text-align:center">:שם משתמש</h2><br>
        <input type="text" name="UserName" id="UserName" runat="server" value="" style="margin: 1px 430px;">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
               ControlToValidate="UserName" Display="Dynamic" ValidationGroup="UserRegisterValidate"
               ErrorMessage="must fill a username" ForeColor="Red">
         </asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="UserName" ValidationGroup="UserRegisterValidate"
                ValidationExpression="^\w[^א-ת]{1,50}" 
                ErrorMessage="משתמש לא יכול להכיל עברית וקטן מ-50" ForeColor="Red" Display="Dynamic">
         </asp:RegularExpressionValidator> 
        <br>
        <h2 style="text-align:center">:ססמא</h2><br>
        <input type="password" name="password" id="password" runat="server" value="" style="margin: 1px 430px;">
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
               ControlToValidate="password" Display="Dynamic" ValidationGroup="UserRegisterValidate"
               ErrorMessage="must fill a password" ForeColor="Red">
         </asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ControlToValidate="password" ValidationGroup="UserRegisterValidate"
                ValidationExpression="^\w[^א-ת]{5,50}" 
                ErrorMessage="ססמא לא יכולה להכיל עברית והיא לפחות 6עד 50" ForeColor="Red" Display="Dynamic">
         </asp:RegularExpressionValidator>
        <br>
        <h2 style="text-align:center">:אימייל</h2><br>
        <input type="email" name="email" id="email" runat="server" value="" style="margin: 1px 430px;">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                 ControlToValidate="email" Display="Dynamic" ValidationGroup="UserRegisterValidate"
                 ErrorMessage="must fill email" ForeColor="Red">
         </asp:RequiredFieldValidator><br/>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                  ControlToValidate="email" ValidationGroup="UserRegisterValidate"
                  ValidationExpression="^\w+(\.?\w+)*\@\w+\.\w+(\.?\w+)*$"
                  ErrorMessage="כתובת אימייל לא תקנית" ForeColor="Red" Display="Dynamic">
         </asp:RegularExpressionValidator> 
        <br>
        <h2 style="text-align:center">:מספר אשראי</h2><br>
        <input type="text" name="creditNumber" id="creditNumber" runat="server" value="" style="margin: 1px 430px;">
         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                  ControlToValidate="email" ValidationGroup="UserRegisterValidate"
                  ValidationExpression="^\w+(\.?\w+)*\@\w+\.\w+(\.?\w+)*$"
                  ErrorMessage="כתובת אימייל לא תקנית" ForeColor="Red" Display="Dynamic">
         </asp:RegularExpressionValidator> 
        <br>
        <h2 style="text-align:center">:קוד אשראי</h2><br>
        <input type="text" name="creditCode" id="creditCode" runat="server" value="" style="margin: 1px 430px;">
        <br>
        <br><br>
        <asp:Button Text="Submit" runat="server" ID="btnSubmit" ValidationGroup="UserRegisterValidate" OnClick="btnSubmit_Click" style="margin: 1px 430px;"/>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText=":סיכום שגיאות הקלט"
         ValidationGroup="UserRegisterValidate" ForeColor="Red" DisplayMode="List" 
         ShowMessageBox="true" Font-Bold="True" Font-Size="X-Large"/>
        <input type="reset" style="margin: 1px 430px;">
    </form>
   <h1 style="color:greenyellow; text-align:center;"><%=msg %> </h1> 
        </div>
</asp:Content>

