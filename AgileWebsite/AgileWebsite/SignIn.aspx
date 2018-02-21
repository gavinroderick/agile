<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="AgileWebsite.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>
            Username:
            <asp:TextBox id="Username" runat="server" type="text" />
            Password:
            <asp:TextBox id="Password" runat="server" TextMode="Password" type="password" />
            <asp:Button id="login" runat="server" type="submit" Text="Login" onclick="SubmitEventMethod" />
        </div>
    </form>
</body>
</html>
