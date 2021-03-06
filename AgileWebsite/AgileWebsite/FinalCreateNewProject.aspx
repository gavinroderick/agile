﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinalCreateNewProject.aspx.cs" Inherits="AgileWebsite.FinalCreateNewProject" %>

<script runat="server">
    
     //MySql.Data.MySqlClient.MySqlConnection conn;
     //MySql.Data.MySqlClient.MySqlCommand cmd;
     //MySql.Data.MySqlClient.MySqlDataReader reader;
     //string query;
     //DB Database = new DB();

    /* protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile)
            try
            {
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string SaveLocation = Server.MapPath("~/Projects/" + fn);

                
                query = "INSERT INTO 17agileteam6db.files (file_name, date_uploaded, file) VALUES (" + fn + ", " + DateTime.Now + ", " + FileUpload1.PostedFile + ")";

                //FileUpload1.SaveAs(SaveLocation);

                Label1.Text = "File name: " +
                     FileUpload1.PostedFile.FileName + "<br>" +
                     FileUpload1.PostedFile.ContentLength + " kb<br>" +
                     "Content type: " +
                     FileUpload1.PostedFile.ContentType;
            }
            catch (Exception ex)
            {
                Label1.Text = "ERROR: " + ex.Message.ToString();
            }
        else
        {
            Label1.Text = "You have not specified a file.";
        }
    }*/
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Upload Files</title>

    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="Content/cover.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">

     <br /><br /><br /><br /><br /><br /><br /><br />

     <div class="cover-container d-flex h-100 p-3 mx-auto flex-column">
        <h1 >Create New Project</h1>
        <br />
        Project Name:        
        <asp:TextBox id="ProjectName" runat="server" type="text" />
        <br />
        <br />
        Project Info:        
        <asp:TextBox id="ProjectInfo" runat="server" type="text" TextMode="multiline"/>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" 
         Text="Upload File" />&nbsp;<br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>

     </div>
        
        
        <div>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>