<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadProject.aspx.cs" Inherits="AgileWebsite.UploadProject" %>

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
  
      <br />
  
      <h3>Upload an Edited File</h3>
      <br />        

      <asp:Label ID="uploadLabel" runat="server" Text="Please upload an excel file which exists in a project:"  />    <br />     
      <asp:FileUpload ID="uploadFile" runat="server" />
      <br />
      <br />

      
      <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Upload File" />&nbsp;<br />
      <br />

      <asp:Button ID="returnButton" runat="server" OnClick="returnButton_Click" Text="Return to Menu" />&nbsp;<br />
      <br />
       
</form>
</body>
</html>







