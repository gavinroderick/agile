<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AgileWebsite.Login" %>

<!DOCTYPE html>
<%   %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>
            StaffNo:
            <asp:TextBox id="Username" runat="server" type="text" /><a href="Login.aspx">Login.aspx</a>
            Password:
            <asp:TextBox id="Password" runat="server" TextMode="Password" type="password" />
            <asp:Button id="login" runat="server" type="submit" Text="Login" onclick="SubmitEventMethod" />
            <% string failed = (string)(Session["failed"]);
                if (failed == "failed")
                { %>
            <p>Login failed, please try again</p>
            <% } %>
        </div>
    </form>
</body>
</html>
