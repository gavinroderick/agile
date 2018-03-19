<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ris.aspx.cs" Inherits="AgileWebsite.ris_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2 class="display-3">RIS Homepage</h2>
        <hr />
        <div class="row id-row">
            <h6 class="text-muted">Please enter the project ID you wish to use: </h6>
            <asp:TextBox ID="projID" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="uploadButton" runat="server"  class="btn btn-warning" OnClick="Upload" Value="Upload" Text="Upload" />&nbsp;<br />
            <asp:Button ID="downloadButton" runat="server" class="btn btn-primary" OnClick="Download" Value="Download" Text="Download"/>&nbsp;<br />
            <asp:Button ID="approveButton" runat="server" class="btn btn-success"  OnClick="Accepted" Value="Approve" Text="Approve"/>
        </div>
        <br />
        <%for (int m = 0; m < data.Count()-1; m++) {  %>
              <%System.Diagnostics.Debug.WriteLine(data.Count()); %>

            <div class="card">
                <%string temp = "projID" + projectID[m]; %>
                <div class="card-block">
                    <div class="row">
                        <div class="col-8">
                            <h4 class="card-title"><%=projectName[m] %></h4>
                             <%System.Diagnostics.Debug.WriteLine(m); %>
                            <h6 class="card-subtitle mb-2 text-muted">Researcher: <%=firstName[m]%>  <%=lastName[m]%> - <%=department[m] %></h6>
                            <h6 class="card-subtitle mb-2 text-muted">Associated File: <%=fileName[m]%></h6>
                            <h6 class="card-subtitle mb-2 text-muted">Project ID: <%=projectID[m]%></h6>
                        </div>
                        <br />                
                    </div>
                    
                
                </div>
                
                
            </div>
            <br />
         <%} %>
      
            
            
            


        </div>
</asp:Content>
