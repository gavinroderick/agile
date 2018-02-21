<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="AgileWebsite.NewProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h1>NewProject</h1>
        ProjectName:
        <asp:TextBox id="ProjectName" runat="server" type="text" />
        <input type="file" id="File1" name="File1" runat="server" />
        <br />
        <input type="submit" id="Submit1" value="Upload" runat="server" />
        </div>
    </form>
</body>
</html>
