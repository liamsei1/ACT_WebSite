<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InformationPage.aspx.cs" Inherits="InformationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <title>W3.CSS Template</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        <style>
        html,body,h1,h2,h3,h4,h5 {font-family: "Raleway", sans-serif}
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   

<!-- Overlay effect when opening sidebar on small screens -->
<div class="w3-overlay w3-hide-large w3-animate-opacity" onclick="w3_close()" style="cursor:pointer" title="close side menu" id="myOverlay"></div>

<!-- !PAGE CONTENT! -->
<div class="w3-main" style="margin-left:20px;margin-top:43px;">

  <!-- Header -->
  <header class="w3-container" style="padding-top:22px">
    <h5><b><i class="fa fa-dashboard"></i> Information Page</b></h5>
  </header>

    <div class="w3-quarter">
      <div class="w3-container w3-blue w3-padding-16">
        <div class="w3-left"><i class="fa fa-eye w3-xxxlarge"></i></div>
        <div class="w3-right">
          <h3>99</h3>
        </div>
        <div class="w3-clear"></div>
        <h4>Views</h4>
      </div>
    </div>
    <div class="w3-quarter">
      <div class="w3-container w3-orange w3-text-white w3-padding-16">
        <div class="w3-left"><i class="fa fa-users w3-xxxlarge"></i></div>
        <div class="w3-right">
          <h3><%=msgUserCount %></h3>
        </div>
        <div class="w3-clear"></div>
        <h4>Users</h4>
      </div>
    </div>
  </div>

  <div class="w3-panel">
    <div class="w3-row-padding" style="margin:0 -16px">
      <div class="w3-third">
        <h5>Area</h5>
        <img src="img/ACTPlace.JPG" style="width:100%" alt="Google Regional Map">
      </div>
      <div class="w3-twothird">
        <h5>Facts</h5>
        <table class="w3-table w3-striped w3-white">
          <tr>
            <td><i class="fa fa-user w3-text-blue w3-large"></i></td>
            <td>Act is a gym in Haifa</td>
          </tr>
          <tr>
            <td><i class="fa fa-bell w3-text-red w3-large"></i></td>
            <td><a href="TrainersInformation.aspx">Trainer Yossi</a></td>
          </tr>
        </table>
      </div>
    </div>
  </div>
  <hr>
  <div class="w3-container">
    

  
 
  
  <br>


  <!-- Footer -->
  <footer class="w3-container w3-padding-16 w3-light-grey">
    <h4 style="margin-left:800px;">ACT</h4>
  </footer>

  <!-- End page content -->
</div>

</asp:Content>

