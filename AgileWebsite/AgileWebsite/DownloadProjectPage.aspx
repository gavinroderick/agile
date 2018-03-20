<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadProjectPage.aspx.cs" Inherits="AgileWebsite.DownloadProjectPage" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Upload Files</title>

    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="Content/cover.css" rel="stylesheet">
</head>
 <body class="text-center">
      <form id="form1" runat="server">
  
       <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br /> <br />
    
      <h3>Download a Project</h3>
      <br />
      <asp:Label ID="Label1" runat="server" Text="Please enter the associated file to the Project you would like to download."  />    <br />
      <asp:Label ID="Label2" runat="server" Text="This can be found on at the menu page if unknown. "  /> <br /><br />
      <asp:TextBox id="fileName" runat="server" type="text" Width="300"  />
      <asp:Label ID="xlsxlabel" runat="server" Text=".xlsx"  />    <br />
      <br />        
      
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Download File" />&nbsp;
          <br /><br />
      <asp:Button ID="returnButton" runat="server" OnClick="returnButton_Click" Text="Return to Menu" />&nbsp;<br />
      <br />
          
      <br />
     
</form>
</body>
</html>







