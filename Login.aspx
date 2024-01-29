<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="NewLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
         <h1 style="color:greenyellow; font-size:500%; text-align:center;">התחברות</h1>
       
    <form id="form" runat="server" method="post" action="">
		<h2 style="text-align:center">:שם משתמש</h2><br>
        <input type="text" name="UserName2"  id="UserName2"  runat="server" style="margin: 1px 860px; text-align:center; padding: 5px 5px;">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
               ControlToValidate="UserName2" Display="Dynamic" ValidationGroup="UserLoginValidate"
               ErrorMessage="must fill a username" ForeColor="Red">
         </asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="UserName2" ValidationGroup="UserLoginValidate"
                ValidationExpression="^\w[^א-ת]{1,50}" 
                ErrorMessage="משתמש לא יכול להכיל עברית וקטן מ-50" ForeColor="Red" Display="Dynamic">
         </asp:RegularExpressionValidator> 
        <br>
        <h2 style="text-align:center">:ססמא</h2><br>
        <input type="password" name="password2"  id="password2"  runat="server" style="margin: 1px 860px; text-align:center; padding: 5px 5px;">	
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
               ControlToValidate="password2" Display="Dynamic" ValidationGroup="UserLoginValidate"
               ErrorMessage="must fill a password" ForeColor="Red">
         </asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ControlToValidate="password2" ValidationGroup="UserLoginValidate"
                ValidationExpression="^\w[^א-ת]{5,50}" 
                ErrorMessage="ססמא לא יכולה להכיל עברית והיא לפחות 6עד 50" ForeColor="Red" Display="Dynamic">
         </asp:RegularExpressionValidator>
         <br>
        
        <asp:Button Text="Submit" runat="server" ID="btnSubmit" ValidationGroup="UserLoginValidate" OnClick="btnSubmit_Click" style="margin: 1px 920px; text-align:center; padding: 5px 5px; margin-top:20px;" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText=":סיכום שגיאות הקלט"
            ValidationGroup="UserLoginValidate" ForeColor="Red" DisplayMode="List" 
            ShowMessageBox="true" Font-Bold="True" Font-Size="X-Large"/>
        <input type="reset" style="margin: 1px 920px; text-align:center; padding: 5px 5px;">
    </form>

    <p style="text-align:center; color:brown; font-size:500%;"><%=msg %> </p>
</asp:Content>

