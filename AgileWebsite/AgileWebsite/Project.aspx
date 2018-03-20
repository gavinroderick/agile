<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="AgileWebsite.Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2 class="display-3" style="text-align: center;"><%=projectName %></h2>
        <h4 class="text-center"><%=researcherName %> - <%=department %></h4>
       
        <div class="row id-row input-group justify-content-center">
            <div class="col">
               <a id="createButton" role="button" class="btn btn-success btn-block" >New project</a>
            </div>
            <div class="col">
                <a id="editProject" role="button" class="btn btn-warning btn-block">Edit</a>
            </div>
            <div class="col">
                <a id="downloadingButton" role="button" class="btn btn-dark btn-block" >Download</a>
            </div>
            <% if(userRole == "1")
                { %>
            <div class="col">
                <a id="decline" role="button" class="btn btn-danger btn-block" >Decline</a>
            </div>
            <div class="col">
                <a id="approve" role="button" class="btn btn-success btn-block" >Approve</a>
            </div>
            <%} %>
        </div>
        <% if (stage == "3" && userRole == "0")
            { %>
        <div class="row id-row input-group justify-content-center">
            <div class="col">
                <a id="finalApprove" role="button" class="btn btn-success btn-block" >Final sign and approve your funding!</a>
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
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">First</th>
                    <th scope="col">Last</th>
                    <th scope="col">Handle</th>
                </tr>
            </thead>
            <tbody>
            <tr>
                <th scope="row">1</th>
                <td>Mark</td>
                <td>Otto</td>
                <td>@mdo</td>
            </tr>
            <tr>
                <th scope="row">2</th>
                <td>Jacob</td>
                <td>Thornton</td>
                <td>@fat</td>
            </tr>
            <tr>
                <th scope="row">3</th>
                <td>Larry</td>
                <td>the Bird</td>
                <td>@twitter</td>
            </tr>
            </tbody>
        </table>

     </div>


</asp:Content>