<%@ Page Title="RIS Options" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="risOptions.aspx.cs" Inherits="AgileWebsite.risOptions" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    Which list do you want to see? <br/>

     <asp:RadioButton runat="server" ID="all" GroupName="options" Text="All projects" /><br/>
     <asp:RadioButton runat="server" ID="finished" GroupName="options" Text="Finished projects" /><br/>
   
     <div class="col-4" >
         <asp:Button runat="server" ID="btn_options" class="btn btn-success" OnClick="btn_options_Click" Text="Continue" /><br/>
     </div>

</asp:Content>
