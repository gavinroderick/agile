<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AgileWebsite._Default" %>

<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="favicon.ico">

    <title>Cover Template for Bootstrap</title>

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
                    <form class="form-signin">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="inputFirstName">First Name</label>
                                <input type="text" class="form-control" id="inputFirstName" placeholder="First name">
                            </div>
                            <div class="form-group col-md-6">
                                <label for="inputSurname">Surname</label>
                                <input type="text" class="form-control" id="inputSurname" placeholder="Surname">
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail">Email address</label>
                            <input type="email" id="inputEmail" class="form-control" placeholder="Email address" required autofocus />
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-4">
                                <label for="inputFirstName">Staff No.</label>
                                <input type="text" class="form-control" id="inputStaffNo" placeholder="Staff Number">
                            </div>
                            <div class="form-group col-md-4">
                                <label for="inputDepartment">Department</label>
                                <input type="text" class="form-control" id="inputDepartment" placeholder="Department">
                            </div>
                            <div class="form-group col-md-4">
                                <label for="inputRole">Role</label>
                                <select id="inputRole" class="form-control">
                                    <option selected>Choose...</option>
                                    <option>Research Applicant</option>
                                    <option>RIS Staff</option>
                                    <option>Associate Dean</option>
                                    <option>Dean</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputPassword" >Password</label>
                            <input type="password" id="inputPassword" class="form-control" placeholder="Password" required>
                        </div>
                       
                        <button class="btn btn-lg btn-success btn-block" type="submit">Register</button>
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
