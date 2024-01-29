<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminWorkshifts1.aspx.cs" Inherits="AdminWorkshifts1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="w3-container">
         
    <form id="form1" runat="server"  style="padding-top:100px; padding-left:10px;">      
        <table>
            <tr><td>
        <asp:ListView ID="ListView1" runat="server" OnItemDeleting="ListView1_ItemDeleting" onItemEditing="ListView1_EditCommand" onItemCanceling="ListView1_ItemCanceling" onItemUpdating="ListView1_ItemUpdating" onItemInserting="ListView1_ItemInserting" insertitemposition="LastItem">
                          <LayoutTemplate>
                    <table runat="server" id="table1" cellpadding="2" width="500px">
                            <tr id="tr1" runat="server" style="Background:green; width:500px;"  width="500px">  
                                            <th id="th2" runat="server" style="Color:Blue; width:500px;"><asp:LinkButton id="link1" OnClick="link1_Click"
                                runat="server" style="Color:Blue">workshiftId</asp:LinkButton></th>
                                <th id="th3" runat="server" style="Color:Blue; width:500px;">workshiftDay</th>
                                 <th id="th4" runat="server" style="Color:Blue; width:500px;">workshiftHoures</th>
                                  <th id="th5" runat="server" style="Color:Blue; width:500px;"> <asp:LinkButton id="link2" OnClick="link2_Click"
                                 runat="server" style="Color:Blue">fldTrainerId</asp:LinkButton> </th>
                                 <th id="th6" runat="server" style="Color:Blue; width:500px;">בחר</th>
                                <th id="th7" runat="server" style="Color:Blue; width:500px;">Edit</th>
                                <th id="th8" runat="server" style="Color:Blue; width:500px;">Delete</th>
                          </tr>
                         <tr runat="server" id="itemPlaceholder" />
                    </table>
                             </LayoutTemplate> 
                       <ItemTemplate>
                      <tr id="tr2" runat="server" style="background:#D9D8E0">
                       <td> <asp:Label ID="Label1" runat="Server" Text='<%#Eval("fldworkshiftId") %>' /></td>
                     <td> <asp:Label ID="Label2" runat="Server" Text='<%#Eval("fldworkshiftDay") %>' /></td>
                     <td> <asp:Label ID="Label3" runat="Server" Text='<%#Eval("fldworkshiftHoures") %>' /></td>
                     <td> <asp:Label ID="Label4" runat="Server" Text='<%#Eval("fldTrainerId") %>' /></td>    
                     <td> <asp:Button ID="button1" runat="Server" Text="Edit" CommandName="edit" /> </td>  
                    <td> <asp:Button ID="button2" runat="Server" Text="Delete" CommandName="Delete" /></td>
                     </tr>
                        </ItemTemplate>                       

            <InsertItemTemplate>
                     <tr style="background-color:aqua">
                         <td>
                     <asp:TextBox ID="inWorkshiftId" runat="server" Text='<%# Bind("fldworkshiftId") %>'  Visible="false"/>
				      </td>
					  <td>
				      <asp:DropDownList ID="inWorkshiftDay" runat="server">
                          <asp:ListItem Text="Sunday" Value="sunday"></asp:ListItem>
                          <asp:ListItem Text="Monday" Value="monday"></asp:ListItem>
                          <asp:ListItem Text="Tuesday" Value="tuesday"></asp:ListItem>
                          <asp:ListItem Text="Wednesday" Value="wednesday"></asp:ListItem>
                          <asp:ListItem Text="Thursday" Value="thursday"></asp:ListItem>
                          </asp:DropDownList>
                      </td>
					  <td>
                          <asp:DropDownList ID="inWorkshiftHoures" runat="server">
                          <asp:ListItem Text="8:00-16:00" Value="8:00-16:00"></asp:ListItem>
                          <asp:ListItem Text="16:00-24:00" Value="16:00-24:00"></asp:ListItem>
                          </asp:DropDownList>
                      </td>
                       <td>
					   <asp:TextBox ID="inTrainer" runat="server" Text='<%# Bind("fldTrainerId") %>'/>
					   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inTrainer" ErrorMessage="Trainer is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                               ControlToValidate="inTrainer" ValidationGroup="inWorkShiftValidate"
                               ValidationExpression="^\w[^א-ת]{1,50}"
                               ErrorMessage="משתמש לא יכול להכיל עברית וקטן מ-50" ForeColor="Red" Display="Dynamic">
                           </asp:RegularExpressionValidator>
                       </td>
                         <td>
				     <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" ValidationGroup="inWorkShiftValidate"/>
				     <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
					 </td>
				</tr>
                     </InsertItemTemplate>

              <EditItemTemplate>
				<tr style="background-color:yellow">
                   <td>
                     <asp:Label ID="Label1" runat="Server" Text='<%#Eval("fldworkshiftId") %>' />
				      </td>
					  <td>
				     <asp:DropDownList ID="upWorkshiftDay" runat="server">
                          <asp:ListItem Text="Sunday" Value="sunday"></asp:ListItem>
                          <asp:ListItem Text="Monday" Value="monday"></asp:ListItem>
                          <asp:ListItem Text="Tuesday" Value="tuesday"></asp:ListItem>
                          <asp:ListItem Text="Wednesday" Value="wednesday"></asp:ListItem>
                          <asp:ListItem Text="Thursday" Value="thursday"></asp:ListItem>
                          </asp:DropDownList>
					  <td>
				          <asp:DropDownList ID="upWorkshiftHoures" runat="server">
                          <asp:ListItem Text="8:00-16:00" Value="8:00-16:00"></asp:ListItem>
                          <asp:ListItem Text="16:00-24:00" Value="16:00-24:00"></asp:ListItem>
                          </asp:DropDownList>
                       </td>
                       <td>
					   <asp:TextBox ID="upTrainer" runat="server" Text='<%# Bind("fldTrainerId") %>'/>
					   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="upTrainer" ErrorMessage="Trainer is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                               ControlToValidate="upTrainer" ValidationGroup="upWorkShiftValidate"
                               ValidationExpression="^\w[^א-ת]{1,50}"
                               ErrorMessage="משתמש לא יכול להכיל עברית וקטן מ-50" ForeColor="Red" Display="Dynamic">
                           </asp:RegularExpressionValidator>
                       </td> 
                         <td>
				    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ValidationGroup="upWorkShiftValidate"/>
				    <asp:Button ID="Button3" runat="server" CommandName="Cancel" Text="Cancel" />
					 </td>

				</tr>         
			</EditItemTemplate>    

        </asp:ListView>
         <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="1" OnPreRender="DataPager1_PreRender">
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

