<%@ Page Title="Project List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewFinishedProjects.aspx.cs" Inherits="AgileWebsite.ViewFinishedProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <%for (int k = 0; k < data.Count()-1; k++) {  %>
              <%System.Diagnostics.Debug.WriteLine(data.Count()); %>

            <div class="card">
                
                <div class="card-block">
                    <div class="row">
                        <div class="col-8">
                            <h4 class="card-title"><%=projectName[k] %></h4>
                             <%System.Diagnostics.Debug.WriteLine(k); %>
                            <h6 class="card-subtitle mb-2 text-muted">Researcher: <%=firstName[k]%>  <%=lastName[k]%> - <%=department[k] %></h6>
                            <h6 class="card-subtitle mb-2 text-muted">Associated File: <%=fileName[k]%></h6>
                        </div>
                        <br />
                        <div class="col-4">
                            
                            <asp:Button ID="btn_download" runat="server" type="button" OnClick="download_method" class="btn btn-secondary" Text="Download" />&nbsp; </asp:Button>

                        </div>                       
                    </div>    
                </div>              
            </div>
            <br />
         <%} %>

        </div>
</asp:Content>
