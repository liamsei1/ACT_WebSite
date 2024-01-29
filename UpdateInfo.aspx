<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateInfo.aspx.cs" Inherits="UpdateInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
            <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <div class="w3-container"> 
        <form id="form1" runat="server">
        <h1 style="color:greenyellow; font-size:500%; text-align:center; margin:auto; padding-top:40px;">עדכון מידע</h1>
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowUpdating="GridView1_RowUpdating">
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
                 <Columns>
                        <asp:BoundField DataField="fldName" HeaderText="Name"/>
                        <asp:BoundField DataField="fldLastName" HeaderText="Last name"/>
                        <asp:BoundField DataField='fldTrainingYears' HeaderText='Trainging Years'/>
                        <asp:BoundField DataField="fldGender" HeaderText="Gender"/>
                        <asp:BoundField DataField='fldBirthday' HeaderText='Birthday'/>
                        <asp:ButtonField ButtonType="Button" Text="הצג" CommandName="Select" HeaderText="הצג"/>    
                        <asp:CommandField ButtonType="Button" ShowEditButton="true" EditText="עריכה" HeaderText="עריכה" />
                 </Columns>
            </asp:GridView>
        </form>
              </div>
</asp:Content>

