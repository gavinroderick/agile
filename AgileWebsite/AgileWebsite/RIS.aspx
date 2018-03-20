﻿<%@ Page Title="RIS Homepage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ris.aspx.cs" Inherits="AgileWebsite.ris_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2 class="display-3" style="text-align: center;">RIS Homepage</h2>
        <hr />
        <div class="row id-row input-group justify-content-center">
            
            <label for="projID" class="text-muted">Please enter the project ID you wish to use:&nbsp; </label> <br />
            <asp:TextBox Class ="form-control" ID="projID" runat="server"></asp:TextBox> <br />
            
        </div>
        <br />
        <div class="row id-row input-group justify-content-center">
            <div class="col">
                <asp:Button ID="uploadButton" runat="server"  class="btn btn-warning btn-block" OnClick="Upload" Value="Upload" Text="Upload" />&nbsp;<br />
            </div>
            <div class="col">
                <asp:Button ID="downloadButton" runat="server" class="btn btn-primary btn-block" OnClick="Download" Value="Download" Text="Download"/>&nbsp;<br />
            </div>
            <div class="col">
                <asp:Button ID="approveButton" runat="server" class="btn btn-success btn-block"  OnClick="Accepted" Value="Approve" Text="Approve"/>
            </div>
            <div class="col">
                <asp:Button ID="deniedButton" runat="server" class="btn btn-danger btn-block"   Value="Deny" Text="Deny"/>
            </div>
        </div>
        
        <div class="row justify-content-center">
        <%for (int m = 0; m < data.Count()-1; m++) {  %>
            
             
            <div class="card" style="margin-left: 5px; margin-right: 5px;">

               <div class="container">
                    
                    <img class="card-img-top" src="/Content/img/<%=department[m]%>.png" style="width:100%" >
                    <div class="centered">Centered</div>
               </div>
                <div class="card-body" >
                   
                        <div class="col">
                            <h4 class="card-title"><%=projectName[m] %></h4>
                            
                            <h6 class="card-subtitle mb-2 text-muted">Researcher: <%=firstName[m]%>  <%=lastName[m]%> - <%=department[m] %></h6>
                            <h6 class="card-subtitle mb-2 text-muted">Associated File: <%=fileName[m]%></h6>
                            <h6 class="card-subtitle mb-2 text-muted">Project ID: <%=projectID[m]%></h6>
                        </div>
                                 
                    </div>
                    
                
            
                
                </div>
            </div>
            
         <%} %>
        </div>
      
            
            
            


        </div>
</asp:Content>
