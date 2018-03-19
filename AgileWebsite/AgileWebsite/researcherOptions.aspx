<%@ Page Title="Researcher Options" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="researcherOptions.aspx.cs" Inherits="AgileWebsite.researcherOptions" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    What do you want to do? <br/>

     <asp:RadioButton runat="server" ID="create" GroupName="options" Text="Create new project" /><br/>
     <asp:RadioButton runat="server" ID="finished" GroupName="options" Text="View list of finished projects" /><br/>
   
     <div class="col-4" >
         <asp:Button runat="server" ID="btn_options" class="btn btn-success" OnClick="btn_options_Click" Text="Continue" /><br/>
     </div>

</asp:Content>
