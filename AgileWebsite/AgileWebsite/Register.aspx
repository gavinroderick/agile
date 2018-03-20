<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AgileWebsite.Register" %>

<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="favicon.ico">

    <title>Register | Online Research Funding Application</title>

    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="Content/cover.css" rel="stylesheet">
</head>

<body class="text-left">
    <div class="cover-container d-flex h-100 p-3 mx-auto flex-column">
        <header class="masthead mb-auto">
            <div class="inner">
            </div>
        </header>
        <br /><br />
        <main class="main carousel-inner cover">
                    <h1 class="display-4">Register your account</h1>
                    <form class="form-signin" runat="server">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="firstName">First Name</label>
                                <asp:TextBox ID="firstName" runat="server" AutoCompleteType="FirstName" CssClass="form-control" placeholder="First Name" required=true />
                            </div>
                            <div class="form-group col-md-6">
                                <label for="surname">Surname</label>
                                <asp:TextBox ID="surname" runat="server" AutoCompleteType="LastName" CssClass="form-control" placeholder="Surname" required=true />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="emailAddress">Email address</label>
                            <asp:TextBox ID="emailAddress" runat="server" AutoCompleteType="Email" CssClass="form-control" Placeholder="Email" required=true />
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-4">
                                <label for="staffNo">Staff No.</label>
                                <asp:TextBox ID="staffNo" runat="server" CssClass="form-control" Placeholder="Staff No" required=true />
                            </div>
                            <div class="form-group col-md-4">
                                <label for="department">Department</label>
                               
                                
                                <asp:DropDownList ID="dprtmnt" runat="server" CssClass="form-control" >
                                    <asp:ListItem>Choose...</asp:ListItem>
                                    <asp:ListItem Value="DJCAD">DJCAD</asp:ListItem>
                                    <asp:ListItem Value="Education-Social-Work">Education-Social-Work</asp:ListItem>
                                    <asp:ListItem Value="Humanities">Humanities</asp:ListItem>
                                    <asp:ListItem Value="Life-Sciences">Life-Sciences</asp:ListItem>
                                    <asp:ListItem Value="Medicine-Dentistry-Nursing">Medicine-Dentistry-Nursing</asp:ListItem>
                                    <asp:ListItem Value="Social-Sciences">Social-Sciences</asp:ListItem>
                                    <asp:ListItem Value="SSE">SSE</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-4">
                                <label for="inputRole">Role</label>
                                <asp:DropDownList ID="role" runat="server" CssClass="form-control" >
                                    <asp:ListItem>Choose...</asp:ListItem>
                                    <asp:ListItem Value="0">Research Applicant</asp:ListItem>
                                    <asp:ListItem Value="1">RIS Staff</asp:ListItem>
                                    <asp:ListItem Value="2">Associate Dean</asp:ListItem>
                                    <asp:ListItem Value="3">Dean</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputPassword" >Password</label>
                            <asp:TextBox ID="password" runat="server" type="password" CssClass="form-control" placeholder="Password" required="true"/>
                        </div>
                       
                        <%--<asp:Button ID="Submit" runat="server" CssClass="btn btn-lg btn-success btn-block" type="Submit" Text="Register" Value="Submit" OnClick="Submit"/>--%>
                        <asp:Button ID="approveButton" runat="server" class="btn btn-success btn-block"  OnClick="Accepted" Value="Approve" Text="Register"/>
                    </form>
                    <p class="text-center"><a href="Login.aspx">Or log in here</a></p>
        </main>
        <footer class="mastfoot mt-auto">
            <div class="inner">
                <p>&copy; University of Dundee - Agile Team 6 - AC31007<br /><a href="https://github.com/gavinroderick/agile">Check out our source code!</a></p>
            </div>
        </footer>
    </div>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script>window.jQuery || document.write('<script src="../../../../assets/js/vendor/jquery-slim.min.js"><\/script>')</script>
    <script src="../../../../assets/js/vendor/popper.min.js"></script>
    <script src="Content/bootstrap.min.js"></script>
  </body>
</html>
