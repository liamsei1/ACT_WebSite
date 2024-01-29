<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserRequestedProgram.aspx.cs" Inherits="UserRequestedProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
            <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="w3-container"> 
               <h1 style="text-align:center; padding-top:30px;"> בקשות לתוכניות </h1>
    <form id="form1" runat="server"  style="padding-top:10px; padding-left:10px;">      
        <table>
            <tr><td>
        <asp:ListView ID="ListView1" runat="server" OnItemDeleting="ListView1_ItemDeleting" onItemEditing="ListView1_EditCommand" onItemCanceling="ListView1_ItemCanceling" onItemUpdating="ListView1_ItemUpdating" onItemInserting="ListView1_ItemInserting" insertitemposition="LastItem">
                          <LayoutTemplate>
                    <table runat="server" id="table1" cellpadding="2" width="500px" style="padding-left:450px;">
                            <tr id="tr1" runat="server" style="Background:green; width:500px;"  width="500px">  
                                <th id="th1" runat="server" style="Color:white; width:500px;">username</th>
                                <th id="th2" runat="server" style="Color:white; width:500px;">date</th>
                                <th id="th3" runat="server" style="Color:white; width:500px;">is taken care of</th>
                                <th id="th6" runat="server" style="Color:white; width:500px;">Edit</th>
                                <th id="th7" runat="server" style="Color:white; width:500px;">Delete</th>
                          </tr>
                         <tr runat="server" id="itemPlaceholder" />
                    </table>
                             </LayoutTemplate> 
                       <ItemTemplate>
                      <tr id="tr2" runat="server" style="background:#D9D8E0">
                     <td> <asp:Label ID="Label1" runat="Server" Text='<%#Eval("fldUsername") %>' /></td>
                     <td> <asp:Label ID="Label2" runat="Server" Text='<%#Eval("fldDate") %>' /></td>
                     <td> <asp:Label ID="Label3" runat="Server" Text='<%#Eval("fldTakenCare") %>' /></td>
                     <td> <asp:Button ID="button1" runat="Server" Text="Edit" CommandName="edit" /> </td>  
                    <td> <asp:Button ID="button2" runat="Server" Text="Delete" CommandName="Delete" /></td>
                     </tr>
                        </ItemTemplate>                       

            <InsertItemTemplate>
                     <tr style="background-color:aqua">
                          
                         <td>
                             <asp:TextBox ID="inUsername" runat="server" Text='<%# Bind("fldUsername") %>' placeholder="must insert user" ToolTip="must insert the username" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inUsername" ErrorMessage="Username is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^\w[^א-ת]{1,50}" ControlToValidate="inUsername" ErrorMessage="משתמש לא יכול להכיל עברית וקטן מ-50" Display="Dynamic" ValidationGroup="InsertValidate"></asp:RegularExpressionValidator>
                         </td>
					<td>
						<asp:TextBox ID="inDate" runat="server" Text='<%# Bind("fldDate") %>' placeholder="type is: max 15 chars" maxlength="15" title="Max 15 chars" ToolTip="max 15 chars"/>
					    <asp:RequiredFieldValidator ID="RequiredDate" runat="server" ControlToValidate="inDate" ErrorMessage="date is required field." Display="None" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                    </td>
					<td>
						<asp:TextBox ID="inTakenCare" runat="server" Text='<%# Bind("fldTakenCare") %>' placeholder="level: must insert number" ToolTip="must insert the level" />
					    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="inTakenCare" ErrorMessage="taken care of is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                         <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="inTakenCare" 
                          Type="Integer" MinimumValue="0" MaximumValue="1" Display="Dynamic"
                          ErrorMessage="אם הבקשה טופלה הקש 1 אחרת 0" ForeColor="White" 
                           ValidationGroup="InsertValidate">
                         </asp:RangeValidator>
                    </td>
                    <td>
						<asp:TextBox ID="inInfo" runat="server" Text='<%# Bind("fldProgram") %>'/>
					    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inInfo" ErrorMessage="Program info is required field." Display="None" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="Label1" runat="Server" Text='<%#Eval("fldUsername") %>' />
                    </td>
					<td>
						<asp:TextBox ID="upDate" runat="server" Text='<%# Bind("fldDate") %>' placeholder="type is: max 15 chars" maxlength="15" title="Max 15 chars" ToolTip="max 15 chars"/>
					    <asp:RequiredFieldValidator ID="RequiredDate" runat="server" ControlToValidate="upDate" ErrorMessage="date is required field." Display="None" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                    </td>
					<td>
						<asp:TextBox ID="upTakenCare" runat="server" Text='<%# Bind("fldTakenCare") %>' placeholder="level: must insert number" ToolTip="must insert the level" />
					    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="upTakenCare" ErrorMessage="taken care of is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                         <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="upTakenCare" 
                          Type="Integer" MinimumValue="0" MaximumValue="1" Display="Dynamic"
                          ErrorMessage="אם הבקשה טופלה הקש 1 אחרת 0" ForeColor="White" 
                           ValidationGroup="InsertValidate">
                         </asp:RangeValidator>
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

