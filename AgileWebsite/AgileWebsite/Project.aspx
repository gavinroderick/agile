<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="AgileWebsite.Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <%  if(currentStage == "finished"){ %>
    <div style="width:100%;background-color:greenyellow;font-weight:bold;"><h1 class="text-center">YEAHHH BOII U GOT FUNDED</h1></div><% } %>
    <div class="container">
        <h2 class="display-3" style="text-align: center;"><%=projectName %></h2>
        <h4 class="text-center"><%=researcherName %> - <%=department %></h4>

        <div class="row id-row input-group justify-content-center">
            <div class="col">
                <a id="editProject" role="button" class="btn btn-warning btn-block" href="UploadProject.aspx">Edit</a>
            </div>
            <div class="col">
                <a id="downloadingButton" role="button" class="btn btn-primary btn-block" href="DownloadProjectPage.aspx" >Download</a>
            </div>
            <% if(userRole == 1 || userRole == 2 || userRole == 3)
                { %>
            <div class="col">
                <asp:Button ID="declineButton" runat="server" OnClick="Denied" Text="Decline" CssClass="btn btn-block btn-danger"/>
            </div>
            <div class="col">
                <asp:Button ID="approveButton" runat="server" OnClick="Accepted" Text="Approve" CssClass="btn btn-success btn-block"/>
            </div>
            <%} %>
        </div>
        <br />
        <% if (currentStage == "dean" && userRole == 0)
            { %>
             <div class="row id-row input-group justify-content-center">
            <div class="col">
                <asp:Button id="finalApprove" runat="server" CssClass="btn btn-success btn-block" Text="Final sign and approve your funding!" OnClick="finalFunded"/>
            </div>
        </div>
        <%} %>
        <hr />
        <h3>Project Information</h3>
        <br />
        <dl class="row">
            <dt class="col-sm-3">Date Submitted </dt>
            <dd class="col-sm-9"><%=dateSubmitted %></dd>

            <dt class="col-sm-3">Project Info</dt>
            <dd class="col-sm-9"><%=projectInfo %></dd>

            <dt class="col-sm-3">Current Stage: </dt>
            <dd class="col-sm-9"><%=currentStage %></dd>
        </dl>
        <hr />
        <h3>Project History</h3>
        <h6>There is no history for this project</h6>

     </div>


</asp:Content>