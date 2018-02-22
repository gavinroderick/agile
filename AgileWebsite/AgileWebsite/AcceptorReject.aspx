<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcceptorReject.aspx.cs" Inherits="AgileWebsite.AcceptorReject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button id="Accept" runat="server" type="submit" Text="Accept" onclick="SubmitEventMethod" />
            <asp:Button id="Reject" runat="server" type="submit" Text="Reject" onclick="SubmitEventMethod" />
        </div>
    </form>
</body>
</html>
