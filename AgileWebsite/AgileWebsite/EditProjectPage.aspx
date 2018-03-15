<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProjectPage.aspx.cs" Inherits="AgileWebsite.EditProjectPage" %>

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
    
      <h3>Download Button Example</h3>
      <br />
    
      <asp:TextBox id="fileName" runat="server" type="text" Width="300"  />
    
      <br />        
      
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Download File" />&nbsp;<br />
    

      <h3>Upload Button Example</h3>
      <br />

      <asp:FileUpload ID="FileUpload1" runat="server" />
      <br />
      <br />

      <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Upload File" />&nbsp;<br />
      <br />
     
      
     
</form>
</body>
</html>







