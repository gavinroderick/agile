<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ris.aspx.cs" Inherits="AgileWebsite.ris_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <%for (int m = 0; m < data.Count()-1; m++) {  %>
              <%System.Diagnostics.Debug.WriteLine(data.Count()); %>

            <div class="card">
                
                <div class="card-block">
                    <div class="row">
                        <div class="col-8">
                            <h4 class="card-title"><%=projectName[m] %></h4>
                             <%System.Diagnostics.Debug.WriteLine(m); %>
                            <h6 class="card-subtitle mb-2 text-muted">Researcher: <%=firstName[m]%>  <%=lastName[m]%> - <%=department[m] %></h6>
                        </div>
                        <br />
                        <div class="col-4">
                            
                            <button type="button" class="btn btn-primary">Upload</button>
                            <button type="button" class="btn btn-secondary">Download</button>
                            <asp:Button ID="Button" runat="server" class="btn btn-success" Text="Approve" />
                        </div>                       
                    </div>
                    
                
                </div>
                
                
            </div>
            <br />
         <%} %>
      
            
            
            


        </div>
</asp:Content>
