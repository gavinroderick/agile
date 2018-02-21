<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="AgileWebsite.NewProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="NewProject.aspx?MethodName=MyMethod" id="form1" runat="server">
        <div>
        <h1 >Create New Project</h1>
        <br />
        Project Name:        
        <asp:TextBox id="ProjectName" runat="server" type="text" />
        <br />
        <br />
        Project Info:        
        <asp:TextBox id="TextBox2" runat="server" type="text" TextMode="multiline"/>
        <br />
        <br />
        <input type="file" id="File1" name="File1" runat="server" />
        <br />
        <br />
        <input type="submit" id="Submit1" value="Upload" runat="server" />
        </div>
        <input type="submit" id="SubmitMeBoi" value="UploadMeBoi" runat="server" />
    </form>
</body>
</html>
