<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AgileWebsite.Login" %>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="favicon.ico" />
    <title>Login | Online Research Funding Application</title>
    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="Content/cover.css" rel="stylesheet" />
</head>
<body class="text-left">
    <div class="cover-container d-flex h-100 p-3 mx-auto flex-column">
        <%--<header class="masthead mb-auto">
            <div class="inner">
            </div>
        </header>--%>
        <br /><br />
        <main class="main carousel-inner cover">
            <h1 class="display-4">Login</h1>
            <form class="form-signin" runat="server">
                <div class="form-row">
                    <div class="form-group col-12">
                        <label for="Username">StaffNo:</label>
                        <asp:TextBox id="Username" runat="server" CssClass="form-control" type="text" />
                        
                        <label for="Password">Password</label>
                        <asp:TextBox id="Password" runat="server" CssClass="form-control" TextMode="Password" type="password" />
                    </div>
                    <div class="form-group col-12">
                        <asp:Button id="login" runat="server" type="submit" Text="Login" CssClass="btn btn-success btn-block" onclick="SubmitEventMethod" />
                        <p class="text-center"><a href="register.aspx">...or register for an account here</a></p>
                        <% string failed = (string)(Session["failed"]);
                            if (failed == "failed")
                            { %>
                        <p>Login failed, please try again</p>
                        <% } %>
                    </div>
                </div>
            </form>
        </main>
    </div>
</body>
</html>
