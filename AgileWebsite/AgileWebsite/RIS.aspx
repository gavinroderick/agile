﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RIS.aspx.cs" Inherits="AgileWebsite.RIS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        <%for (int i = 0; i < data[2].Length; i++) {  %>
            <div class="card">
                <div class="card-block">
                <h4 class="card-title"><%=projectID[i] %></h4>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <a href="#" class="card-link">Card link</a>
                <a href="#" class="card-link">Another link</a>
            </div>
                <%} %>
        </div>
            
            


        </div>
    </form>
</body>
</html>