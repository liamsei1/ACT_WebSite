<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> <div class="container">
    <div class="w3-container"> 
    <form id="form1" runat="server"  style="padding-top:100px; padding-left:10px;">      
        <table>
            <tr><td>
        <asp:ListView ID="ListView1" runat="server" OnItemDeleting="ListView1_ItemDeleting" onItemEditing="ListView1_EditCommand" onItemCanceling="ListView1_ItemCanceling" onItemUpdating="ListView1_ItemUpdating" onItemInserting="ListView1_ItemInserting" insertitemposition="LastItem">
                          <LayoutTemplate>
                    <table runat="server" id="table1" cellpadding="2" width="500px">
                            <tr id="tr1" runat="server" style="Background:yellow; width:500px;"  width="500px">                             
                                <th id="th2" runat="server" style="Color:Blue; width:500px;"><asp:LinkButton id="link1" OnClick="link1_Click"
                                runat="server" style="Color:Blue">username</asp:LinkButton></th>
                                <th id="th3" runat="server" style="Color:Blue; width:500px;">password</th>
                                 <th id="th4" runat="server" style="Color:Blue; width:500px;">email</th>
                                  <th id="th5" runat="server" style="Color:Blue; width:500px;"> <asp:LinkButton id="link2" OnClick="link2_Click"
                                 runat="server" style="Color:Blue">key</asp:LinkButton> </th>
                                 <th id="th6" runat="server" style="Color:Blue; width:500px;">בחר</th>
                                <th id="th7" runat="server" style="Color:Blue; width:500px;">Edit</th>
                                <th id="th8" runat="server" style="Color:Blue; width:500px;">Delete</th>
                          </tr>
                         <tr runat="server" id="itemPlaceholder" />
                    </table>
                             </LayoutTemplate> 
                       <ItemTemplate>
                      <tr id="tr2" runat="server" style="background:#D9D8E0">
                     <td> <asp:Label ID="Label1" runat="Server" Text='<%#Eval("fldUsername") %>' /></td>
                     <td> <asp:Label ID="Label2" runat="Server" Text='<%#Eval("fldPassword") %>' /></td>
                     <td> <asp:Label ID="Label3" runat="Server" Text='<%#Eval("fldMail") %>' /></td>
                     <td> <asp:Label ID="Label4" runat="Server" Text='<%#Eval("fldKey") %>' /></td>    
                     <td> <asp:LinkButton ID="LinkButton1" runat="server" Text="בחר" CommandName="Select"></asp:LinkButton></td>
                     <td> <asp:Button ID="button1" runat="Server" Text="Edit" CommandName="edit" /> </td>  
                    <td> <asp:Button ID="button2" runat="Server" Text="Delete" CommandName="Delete" /></td>
                     </tr>
                     </ItemTemplate> 
            
                     <EditItemTemplate>
                     <tr id="tr2" runat="server" style="background:#D9D8E0">          
					 <td>
                     <asp:Label ID="Label1" runat="Server" Text='<%#Eval("fldUsername") %>' />
				      </td>
					  <td>
				      <asp:TextBox ID="upPassword" runat="server" Text='<%# Bind("fldPassword") %>' placeholder="insert password" ToolTip="insert password"/>
					  <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ControlToValidate="upPassword" ErrorMessage="password is required field." Display="Dynamic" ValidationGroup="EditValidate"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularPassword" runat="server" ValidationExpression="\w[^א-ת]{5,50}" ControlToValidate="upPassword" ErrorMessage="ססמא לא יכולה להכיל עברית והיא לפחות 6עד 50" Display="Dynamic" ValidationGroup="EditValidate"></asp:RegularExpressionValidator>
                      </td>
					  <td>
				      <asp:TextBox ID="upMail" runat="server" Text='<%# Bind("fldMail") %>' placeholder="level: must insert mail" ToolTip="must insert the mail" />
					  <asp:RequiredFieldValidator ID="RequiredMail" runat="server" ControlToValidate="upMail" ErrorMessage="Level is required field." Display="Dynamic" ValidationGroup="EditValidate"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularMail" runat="server" ValidationExpression="^\w+(\.?\w+)*\@\w+\.\w+(\.?\w+)*$" ControlToValidate="upMail" ErrorMessage="כתובת אימייל לא תקנית" Display="Dynamic" ValidationGroup="EditValidate"></asp:RegularExpressionValidator>
                       </td>
                       <td>
					   <asp:TextBox ID="upKey" runat="server" Text='<%# Bind("fldKey") %>'/>
					   <asp:RequiredFieldValidator ID="RequiredKey" runat="server" ControlToValidate="upKey" ErrorMessage="inKey is required field." Display="Dynamic" ValidationGroup="EditValidate"></asp:RequiredFieldValidator>
                         <asp:RangeValidator ID="RegularKey" runat="server" ControlToValidate="upKey" 
                          Type="Integer" MinimumValue="1" MaximumValue="6" Display="Dynamic"
                          ErrorMessage="מפתח חייב להיות בין 1 ל-6" ForeColor="White" 
                           ValidationGroup="EditValidate">
                         </asp:RangeValidator>
                       </td> 
                         <td>
				    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ValidationGroup="EditValidate"/>
				    <asp:Button ID="Button3" runat="server" CommandName="Cancel" Text="Cancel" />
					 </td>
                     </tr>
                     </EditItemTemplate>
            

                     <InsertItemTemplate>
                     <tr id="tr2" runat="server" style="background:#D9D8E0">
					 <td>
                     <asp:TextBox ID="inUsername" runat="server" Text='<%# Bind("fldUsername") %>' placeholder="must insert user" ToolTip="must insert the username" />
					 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inUsername" ErrorMessage="Username is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^\w[^א-ת]{1,50}" ControlToValidate="inUsername" ErrorMessage="משתמש לא יכול להכיל עברית וקטן מ-50" Display="Dynamic" ValidationGroup="InsertValidate"></asp:RegularExpressionValidator>
				      </td>
					  <td>
				      <asp:TextBox ID="inPassword" runat="server" Text='<%# Bind("fldPassword") %>' placeholder="insert password" ToolTip="insert password"/>
					  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inPassword" ErrorMessage="password is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="\w[^א-ת]{5,50}" ControlToValidate="inPassword" ErrorMessage="ססמא לא יכולה להכיל עברית והיא לפחות 6עד 50" Display="Dynamic" ValidationGroup="InsertValidate"></asp:RegularExpressionValidator>
                      </td>
					  <td>
				      <asp:TextBox ID="inMail" runat="server" Text='<%# Bind("fldMail") %>' placeholder="level: must insert mail" ToolTip="must insert the mail" />
					  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="inMail" ErrorMessage="Level is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="^\w+(\.?\w+)*\@\w+\.\w+(\.?\w+)*$" ControlToValidate="inMail" ErrorMessage="כתובת אימייל לא תקנית" Display="Dynamic" ValidationGroup="InsertValidate"></asp:RegularExpressionValidator>
                       </td>
                       <td>
					   <asp:TextBox ID="inKey" runat="server" Text='<%# Bind("fldKey") %>'/>
					   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="inKey" ErrorMessage="inKey is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                         <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="inKey" 
                          Type="Integer" MinimumValue="1" MaximumValue="6" Display="Dynamic"
                          ErrorMessage="מפתח חייב להיות בין 1 ל-6" ForeColor="White" 
                           ValidationGroup="InsertValidate">
                         </asp:RangeValidator>
                       </td>
                         <td>
				     <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" ValidationGroup="InsertValidate"/>
				     <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
					 </td>
                       </tr>
                       </InsertItemTemplate>
        </asp:ListView>           
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="1" OnPreRender="DataPager1_PreRender"> <Fields> <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" /> <asp:NumericPagerField /> <asp:TemplatePagerField> </asp:TemplatePagerField> </Fields> </asp:DataPager> 
                 </td>
                </tr>
            <tr>
                            <td colspan="6">
                                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" headterText="Credit Cards" AllowPaging="true" OnPageIndexChanging="DetailsView1_PageIndexChanging" AutoGenerateEditButton="true" AutoGenerateInsertButton="true" OnModeChanging="DetailsView1_ModeChanging" OnItemupdating="DetailsView1_ItemUpdating" DataKeyNames="fldCreditNumber" OnItemInserting="DetailsView1_ItemInserting">
                                </asp:DetailsView>
                            </td>
                </tr>
            </table>
    </form> </div>

</asp:Content>

