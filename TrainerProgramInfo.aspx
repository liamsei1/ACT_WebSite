<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrainerProgramInfo.aspx.cs" Inherits="TrainerProgramInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">

    ::placeholder {
    margin: auto;
    color: red;
}

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form" runat="server" method="post" action="" style="margin-top: 100px;">
        <div class="w3-container">
            <input type="text" name="inDuration" ID="inDuration" runat="server" placeholder="duration: must insert number" ToolTip="must insert the duration" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="inDuration" ErrorMessage="Duration is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="inDuration"
                Type="Integer" MinimumValue="14" MaximumValue="365" Display="Dynamic"
                ErrorMessage="זמן התוכנית חייב להיות בין 14 ל 365" ForeColor="red"
                ValidationGroup="InsertValidate">
            </asp:RangeValidator>
            <input type="text" name="inType" ID="inType" runat="server" placeholder="type is: max 15 chars" MaxLength="15" title="Max 15 chars" ToolTip="max 15 chars" />
            <asp:RequiredFieldValidator ID="RequiredFLname" runat="server" ControlToValidate="inType" ErrorMessage="Program type is required field." Display="None" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularELname" runat="server" ValidationExpression="^[^!-/:-@[-`{-~^]{4,15}$" ControlToValidate="inType" ErrorMessage="Program type can't contain special characters and must be between 4-15 chars" Display="Dynamic" ValidationGroup="InsertValidate"></asp:RegularExpressionValidator>
            <input type="text" name="inLevel" ID="inLevel" runat="server" placeholder="level: must insert number" ToolTip="must insert the level" />
            <asp:RequiredFieldValidator ID="RequiredUname" runat="server" ControlToValidate="inLevel" ErrorMessage="Level is required field." Display="Dynamic" ValidationGroup="InsertValidate"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="inLevel"
                Type="Integer" MinimumValue="1" MaximumValue="4" Display="Dynamic"
                ErrorMessage="הרמה חייבת להיות בין 1 ל 4" ForeColor="red"
                ValidationGroup="InsertValidate">
            </asp:RangeValidator>

            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="addnewworkout1_Click" Width="150px" ValidationGroup="InsertValidate"/>
            <asp:Button ID="submitworkout" runat="server" Text="Submit" OnClick="submitworkout_Click" Width="150px" />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <h1>Workout:</h1>
                <br />
            </asp:PlaceHolder>

        </div>
    </form>
</asp:Content>

