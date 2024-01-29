<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrainersInformation.aspx.cs" Inherits="TrainersInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <title>W3.CSS Template</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
        <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto'>
         <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        <style>
        html,body,h1,h2,h3,h4,h5,h6 {font-family: "Roboto", sans-serif}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Page Container -->
<div class="w3-content" style="margin-top:80px;max-width:1400px;">

  <!-- The Grid -->
  <div class="w3-row-padding">
  
    <!-- Left Column -->
    <div class="w3-third">
    
      <div class="w3-white w3-text-grey w3-card-4">
        <div class="w3-display-container">
          <img src="img/YossiImg.jpg" style="width:100%" alt="Avatar">
          <div class="w3-display-bottomleft w3-container w3-text-black">
            <h2 style="color:white;">Yossi</h2>
          </div>
        </div>
        <div class="w3-container">
          <p><i class="fa fa-briefcase fa-fw w3-margin-right w3-large w3-text-teal"></i>Trainer And Manager</p>
          <p><i class="fa fa-home fa-fw w3-margin-right w3-large w3-text-teal"></i>Haifa, Israel</p>
          <p><i class="fa fa-envelope fa-fw w3-margin-right w3-large w3-text-teal"></i>Yossi@gmail.com</p>
          <p><i class="fa fa-phone fa-fw w3-margin-right w3-large w3-text-teal"></i>0510312151</p>
          <hr>

        
          
          <br>
        </div>
      </div><br>

    <!-- End Left Column -->
    </div>

    <!-- Right Column -->
    <div class="w3-twothird">
    
      <div class="w3-container w3-card w3-white w3-margin-bottom">
        <h2 class="w3-text-grey w3-padding-16"><i class="fa fa-suitcase fa-fw w3-margin-right w3-xxlarge w3-text-teal"></i>Work Experience</h2>      
        <div class="w3-container">
          <h5 class="w3-opacity"><b>Been Training since:</b></h5>
          <h6 class="w3-text-teal"><i class="fa fa-calendar fa-fw w3-margin-right"></i>Mar 1995 - Now</h6>
          <p>Thousands of Trainers.</p>
          <hr>
        </div>
      </div>

      <div class="w3-container w3-card w3-white">
        <h2 class="w3-text-grey w3-padding-16"><i class="fa fa-certificate fa-fw w3-margin-right w3-xxlarge w3-text-teal"></i>Education</h2>
      
        <div class="w3-container">
          <h5 class="w3-opacity"><b>School of Vingate</b></h5>
          <h6 class="w3-text-teal"><i class="fa fa-calendar fa-fw w3-margin-right"></i>1995 - 1995</h6>
          <p>Training Certification</p><br>
        </div>
      </div>

    <!-- End Right Column -->
    </div>
    
  <!-- End Grid -->
  </div>
  
  <!-- End Page Container -->
</div>

 <footer class="w3-container w3-padding-16 w3-light-grey">
    <h4 style="margin-left:800px;">ACT</h4>
  </footer>
</asp:Content>

