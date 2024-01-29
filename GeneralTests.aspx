<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GeneralTests.aspx.cs" Inherits="GeneralTests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <div class="w3-container"> 
    <form id="form1" runat="server"  style="padding-top:100px; padding-left:10px;">      
        <table>
            <tr><td>
        <asp:ListView ID="ListView1" runat="server" OnItemDeleting="ListView1_ItemDeleting" onItemEditing="ListView1_EditCommand" onItemCanceling="ListView1_ItemCanceling" onItemUpdating="ListView1_ItemUpdating" onItemInserting="ListView1_ItemInserting" insertitemposition="LastItem">
                          <LayoutTemplate>
                    <table runat="server" id="table1" cellpadding="2" width="500px">
                            <tr id="tr1" runat="server" style="Background:green; width:500px;"  width="500px">  
                                <th id="th1" runat="server" style="Color:white; width:500px;">programId</th>
                                <th id="th6" runat="server" style="Color:white; width:500px;">Edit</th>
                                <th id="th7" runat="server" style="Color:white; width:500px;">Delete</th>
                          </tr>
                         <tr runat="server" id="itemPlaceholder" />
                    </table>
                             </LayoutTemplate> 
                       <ItemTemplate>
                      <tr id="tr2" runat="server" style="background:#D9D8E0">
                     <td> <asp:Label ID="lblCountry" runat="Server" Text='<%#Eval("fldUsername") %>' /></td>>
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
                                        <asp:DropDownList ID="DropDownList1" runat="server"/>

                       <asp:TextBox ID="inDuration" runat="server" Text='<%# Bind("fldUsername") %>' placeholder="level: must insert number" ToolTip="must insert the duration" />
						 </td>       
				</tr>
                     </InsertItemTemplate>

              <EditItemTemplate>
				<tr style="background-color:yellow">
                    <asp:DropDownList ID="ddlCountries" runat="server">
            </asp:DropDownList>
            <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("fldUsername") %>' Visible="false"></asp:Label>
                    <td>
						<asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ValidationGroup="EditValidate"/>
						<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
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
</body>
</html>
