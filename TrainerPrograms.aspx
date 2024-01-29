<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrainerPrograms.aspx.cs" Inherits="TrainerPrograms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="w3-container">
         
    <form id="form1" runat="server"  style="padding-top:100px; padding-left:10px;">      
    <h1 style="text-align:center; padding-top:30px;"> סידור תוכניות </h1>
        <table>
            <tr><td>

        <asp:ListView ID="ListView1" runat="server" OnItemDeleting="ListView1_ItemDeleting" onItemEditing="ListView1_EditCommand" onItemCanceling="ListView1_ItemCanceling" onItemUpdating="ListView1_ItemUpdating" onItemInserting="ListView1_ItemInserting" insertitemposition="LastItem">
                          <LayoutTemplate>
                    <table runat="server" id="table1" cellpadding="2" width="500px" style="padding-left:450px;">
                            <tr id="tr1" runat="server" style="Background:green; width:500px;"  width="500px">  
                                <th id="th1" runat="server" style="Color:white; width:500px;">programId</th>
                                <th id="th2" runat="server" style="Color:white; width:500px;"><asp:LinkButton id="link1" OnClick="link1_Click"
                                runat="server" style="Color:Blue">programDuration</asp:LinkButton></th>
                                <th id="th3" runat="server" style="Color:white; width:500px;">programType</th>
                                 <th id="th4" runat="server" style="Color:white; width:500px;">programLevel</th>
                                  <th id="th5" runat="server" style="Color:white; width:500px;"> <asp:LinkButton id="link2" OnClick="link2_Click"
                                 runat="server" style="Color:white">programInfo</asp:LinkButton> </th>
                                <th id="th6" runat="server" style="Color:white; width:500px;">Edit</th>
                                <th id="th7" runat="server" style="Color:white; width:500px;">Delete</th>
                          </tr>
                         <tr runat="server" id="itemPlaceholder" />
                    </table>
                             </LayoutTemplate> 
                       <ItemTemplate>
                      <tr id="tr2" runat="server" style="background:#D9D8E0">
                     <td> <asp:Label ID="Label1" runat="Server" Text='<%#Eval("fldProgramId") %>' /></td>
                     <td> <asp:Label ID="Label2" runat="Server" Text='<%#Eval("fldProgramDuration") %>' /></td>
                     <td> <asp:Label ID="Label3" runat="Server" Text='<%#Eval("fldProgramType") %>' /></td>
                     <td> <asp:Label ID="Label4" runat="Server" Text='<%#Eval("fldProgramLevel") %>' /></td>
                     <td> <asp:Label ID="Label5" runat="Server" Text='<%#Eval("fldProgram") %>' /></td>
                     <td> <asp:Button ID="button1" runat="Server" Text="Edit" CommandName="edit" /> </td>  
                    <td> <asp:Button ID="button2" runat="Server" Text="Delete" CommandName="Delete" /></td>
                     </tr>
                        </ItemTemplate>                       

            <InsertItemTemplate>
                     <tr style="background-color:aqua">
                          <td>
						<asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" ValidationGroup="InsertValidate"/>
						<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
					</td>
					<td>
                       <asp:TextBox ID="inDuration" runat="server" Text='<%# Bind("fldProgramDuration") %>' placeholder="level: must insert number" ToolTip="must insert the duration" />
					 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inDuration" ErrorMessage="Duration is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="inDuration" 
                             Type="Integer" MinimumValue="14" MaximumValue="365" Display="Dynamic"
                             ErrorMessage="זמן התוכנית חייב להיות בין 14 ל 365" ForeColor="White" 
                             ValidationGroup="InsertValidate">
                         </asp:RangeValidator>
						 </td>
					<td>
						<asp:TextBox ID="inType" runat="server" Text='<%# Bind("fldProgramType") %>' placeholder="type is: max 15 chars" maxlength="15" title="Max 15 chars" ToolTip="max 15 chars"/>
					    <asp:RequiredFieldValidator ID="RequiredFLname" runat="server" ControlToValidate="inType" ErrorMessage="Program type is required field." Display="None" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularELname" runat="server" ValidationExpression="^[^!-/:-@[-`{-~^]{4,15}$" ControlToValidate="inType" ErrorMessage="Program type can't contain special characters and must be between 4-15 chars" Display="Dynamic" ValidationGroup="InsertValidate"></asp:RegularExpressionValidator>
                    </td>
					<td>
						<asp:TextBox ID="inLevel" runat="server" Text='<%# Bind("fldProgramLevel") %>' placeholder="level: must insert number" ToolTip="must insert the level" />
					    <asp:RequiredFieldValidator ID="RequiredUname" runat="server" ControlToValidate="inLevel" ErrorMessage="Level is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="inLevel" 
                             Type="Integer" MinimumValue="1" MaximumValue="4" Display="Dynamic"
                             ErrorMessage="הרמה חייבת להיות בין 1 ל 4" ForeColor="White" 
                             ValidationGroup="InsertValidate">
                         </asp:RangeValidator>
                    </td>
                    <td>
						<asp:TextBox ID="inInfo" runat="server" Text='<%# Bind("fldProgram") %>'/>
					    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inInfo" ErrorMessage="Program info is required field." Display="None" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                    </td>        
				</tr>
                     </InsertItemTemplate>

              <EditItemTemplate>
				<tr style="background-color:yellow">
                    <td>
                    <asp:Label ID="Label1" runat="Server" Text='<%#Eval("fldProgramId") %>' />
                    </td>
					<td>
                       <asp:TextBox ID="upDuration" runat="server" Text='<%# Bind("fldProgramDuration") %>' placeholder="level: must insert number" ToolTip="must insert the duration" />
					    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="upDuration" ErrorMessage="Duration is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="upDuration" 
                             Type="Integer" MinimumValue="14" MaximumValue="365" Display="Dynamic"
                             ErrorMessage="זמן התוכנית חייב להיות בין 14 ל 365" ForeColor="White" 
                             ValidationGroup="InsertValidate">
                         </asp:RangeValidator>
						 </td>
					<td>
						<asp:TextBox ID="upType" runat="server" Text='<%# Bind("fldProgramType") %>' placeholder="type is: max 15 chars" maxlength="15" title="Max 15 chars" ToolTip="max 15 chars"/>
					    <asp:RequiredFieldValidator ID="RequiredFLname" runat="server" ControlToValidate="upType" ErrorMessage="Program type is required field." Display="None" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularELname" runat="server" ValidationExpression="^[^!-/:-@[-`{-~^]{4,15}$" ControlToValidate="upType" ErrorMessage="Program type can't contain special characters and must be between 4-15 chars" Display="Dynamic" ValidationGroup="InsertValidate"></asp:RegularExpressionValidator>
                    </td>
					<td>
						<asp:TextBox ID="upLevel" runat="server" Text='<%# Bind("fldProgramLevel") %>' placeholder="level: must insert number" ToolTip="must insert the level" />
					    <asp:RequiredFieldValidator ID="RequiredUname" runat="server" ControlToValidate="upLevel" ErrorMessage="Level is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="upLevel" 
                             Type="Integer" MinimumValue="1" MaximumValue="4" Display="Dynamic"
                             ErrorMessage="הרמה חייבת להיות בין 1 ל 4" ForeColor="White" 
                             ValidationGroup="InsertValidate">
                         </asp:RangeValidator>
                    </td>
                    <td>
						<asp:TextBox ID="upInfo" runat="server" Text='<%# Bind("fldProgram") %>'/>
					    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="upInfo" ErrorMessage="Program info is required field." Display="None" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                    </td>
                    <td>
						<asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ValidationGroup="EditValidate"/>
						<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
					</td>

				</tr>         
			</EditItemTemplate>    

        </asp:ListView>
         <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="1" OnPreRender="DataPager1_PreRender" style="padding-left:450px;">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                <asp:NumericPagerField />
                <asp:TemplatePagerField> </asp:TemplatePagerField>
            </Fields>
        </asp:DataPager>

        </td>              
            </tr>
            </table>

    </form> </div>

     
        


    
</asp:Content>
