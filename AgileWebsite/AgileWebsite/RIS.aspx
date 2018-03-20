<%@ Page Title="RIS Homepage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ris.aspx.cs" Inherits="AgileWebsite.ris_home" %>
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
                <asp:Button ID="deniedButton" runat="server" class="btn btn-danger btn-block"  OnClick="Denied" Value="Deny" Text="Deny"/>
            </div>
        </div>
        
        <div class="row justify-content-center">
        <%for (int m = 0; m < data.Count()-1; m++) {  %>
            
             
            <div class="card" style="margin-left: 5px; margin-right: 5px;">
                <img class="card-img-top" src="data:image/svg+xml;charset=UTF-8,%3Csvg%20width%3D%22286%22%20height%3D%22180%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20viewBox%3D%220%200%20286%20180%22%20preserveAspectRatio%3D%22none%22%3E%3Cdefs%3E%3Cstyle%20type%3D%22text%2Fcss%22%3E%23holder_16240223432%20text%20%7B%20fill%3Argba(255%2C255%2C255%2C.75)%3Bfont-weight%3Anormal%3Bfont-family%3AHelvetica%2C%20monospace%3Bfont-size%3A14pt%20%7D%20%3C%2Fstyle%3E%3C%2Fdefs%3E%3Cg%20id%3D%22holder_16240223432%22%3E%3Crect%20width%3D%22286%22%20height%3D%22180%22%20fill%3D%22%23777%22%3E%3C%2Frect%3E%3Cg%3E%3Ctext%20x%3D%22107.203125%22%20y%3D%2296.3%22%3E286x180%3C%2Ftext%3E%3C%2Fg%3E%3C%2Fg%3E%3C%2Fsvg%3E" alt="test image pls ignore" >
                   

               
                <div class="card-body" >
                   
                        <div class="col">
                            <h4 class="card-title"><%=projectName[m] %></h4>
                            
                            <h6 class="card-subtitle mb-2 text-muted">Researcher: <%=firstName[m]%>  <%=lastName[m]%> - <%=department[m] %></h6>
                            <h6 class="card-subtitle mb-2 text-muted">Associated File: <%=fileName[m]%></h6>
                            <h6 class="card-subtitle mb-2 text-muted">Project ID: <%=projectID[m]%></h6>
                        </div>
                                 
                    </div>
                    
                
            
                
                </div>
            
            
         <%} %>
        </div>
      
            
            
            


        </div>
</asp:Content>
