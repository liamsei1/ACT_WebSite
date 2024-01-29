<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="programToMember.aspx.cs" Inherits="programToMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
            <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       
       <form id="form1" runat="server"> 
               <div class="w3-container" style="margin-top:40px;"> 
                     <h1 style="text-align:center; padding-top:30px;">התאמת תוכניות למתאמנים</h1>
           <asp:ListView ID="ListView1" runat="server" onItemEditing="ListView1_EditCommand" OnItemDeleting="ListView1_ItemDeleting" onItemCanceling="ListView1_ItemCanceling" onItemUpdating="ListView1_ItemUpdating" onItemInserting="ListView1_ItemInserting" insertitemposition="LastItem"> 
               <LayoutTemplate> 
                   <table runat="server" id="table1" cellpadding="2" width="500px" style="padding-left:500px;"> 
                       <tr id="tr1" runat="server" style="Background:green; width:500px;"  width="500px"> 
                           <th id="th1" runat="server" style="Color:white; width:500px;">programId</th> 
                           <th id="th2" runat="server" style="Color:white; width:500px;">memberId</th> 
                           <th id="th3" runat="server" style="Color:white; width:500px;">isFinished</th> 
                           <th id="th4" runat="server" style="Color:white; width:500px;">Edit</th> 
                           <th id="th5" runat="server" style="Color:white; width:500px;">Delete</th> 

                       </tr> 
                       <tr runat="server" id="itemPlaceholder" /> 

                   </table> 

               </LayoutTemplate> 

               <ItemTemplate> 
                   <tr id="tr2" runat="server" style="background:#D9D8E0"> 
                       <td> <asp:Label ID="Label1" runat="Server" Text='<%#Eval("fldProgramId") %>' /></td> 
                       <td> <asp:Label ID="Label2" runat="Server" Text='<%#Eval("fldMemberId") %>' /></td> 
                       <td> <asp:Label ID="Label3" runat="Server" Text='<%#Eval("fldIsFinished") %>' /></td>          
                       <td> <asp:Button ID="button1" runat="Server" Text="Edit" CommandName="edit" /> </td> 
                       <td> <asp:Button ID="button2" runat="Server" Text="Delete" CommandName="Delete" /></td> 
                   </tr> 
               </ItemTemplate> 

               <InsertItemTemplate>
                     <tr style="background-color:aqua">
                         
					<td>
                       <asp:TextBox ID="inProgramId" runat="server" Text='<%# Bind("fldProgramId") %>' placeholder="level: must insert number" ToolTip="must insert the duration" />
						 </td>
					<td>
						<asp:TextBox ID="inMemberId" runat="server" Text='<%# Bind("fldMemberId") %>' placeholder="type is: max 15 chars" maxlength="15" title="Max 15 chars" ToolTip="max 15 chars"/>
                    </td>
					<td>
						<asp:TextBox ID="inIsfinished" runat="server" Text='<%# Bind("fldIsFinished") %>' placeholder="level: must insert number" ToolTip="must insert the level" />
                    </td>  
                          <td>
						<asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" ValidationGroup="InsertValidate"/>
						<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
					</td>
				</tr>
                     </InsertItemTemplate>



                 <EditItemTemplate>
				<tr style="background-color:yellow">
					<td>
                       <asp:TextBox ID="upProgramId" runat="server" Text='<%# Bind("fldProgramId") %>' placeholder="ProgramId" ToolTip="must insert the ProgramId" />
					    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="upProgramId" ErrorMessage="Duration is required field." Display="Dynamic" ValidationGroup="UpdateValidate"></asp:RequiredFieldValidator>                    
						 </td>
					<td>
						<asp:TextBox ID="upMemberId" runat="server" Text='<%# Bind("fldMemberId") %>' placeholder="type is: max 15 chars" maxlength="15" title="Max 15 chars" ToolTip="max 15 chars"/>
					    <asp:RequiredFieldValidator ID="RequiredFLname" runat="server" ControlToValidate="upMemberId" ErrorMessage="Program type is required field." Display="None" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                    </td>
					<td>
						<asp:TextBox ID="upIsFinished" runat="server" Text='<%# Bind("fldIsFinished") %>' placeholder="level: must insert number" ToolTip="must insert the level" />
					    <asp:RequiredFieldValidator ID="RequiredUname" runat="server" ControlToValidate="upIsFinished" ErrorMessage="Level is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                    </td>
                    <td>
						<asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ValidationGroup="EditValidate"/>
						<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
					</td>

				</tr>         
			</EditItemTemplate>    
           </asp:ListView> 
               </div>
           <h1 style="text-align:center">מציאת תוכנית שיכולה להתאים למתאמן</h1><br>
           <h2 style="text-align:center">:שם מתאמן</h2><br>
           <asp:DropDownList ID="DropDownList1" runat="server" style="margin: 1px 920px; text-align:center; padding: 5px 5px;"></asp:DropDownList>
           <asp:Button Text="Submit" runat="server" ID="btnSubmit"  OnClick="btnSubmit_Click2"  style="margin: 1px 920px; text-align:center; padding: 5px 5px;" />
        <input type="reset" style="margin: 1px 920px; text-align:center; padding: 5px 5px;">
       </form> 
     <h1 style="text-align:center"><%=msgSuggestedProgramId%></h1><br>
</asp:Content>

