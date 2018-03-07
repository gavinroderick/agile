<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="NewRequest.aspx.cs" Inherits="AgileWebsite.NewRequest" %>

<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="favicon.ico">

    <title>New Request</title>

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
        <main class="NewRequest-form">
                    <h1 id="title">New Request</h1>
                    <form class="input-data" action="NewRequestMethod"  runat="server">

                            <div id="form-title">
                                <label for="inputTitle">Title</label>
                                <input type="text" class="form-control" id="inputTitle" placeholder="Title" required autofocus>
                            </div>

                            <div id="form-explanation">
                                <label for="inputExplanation">Explanation</label>
                                <input type="text" class="form-control" id="inputExplanation" placeholder="Explanation" required autofocus>
                            </div>
                        
                        <div id="form-funding">
                            <label for="inputFunding">Expected funding</label>
                            <input type="number" id="inputFunding" class="form-control" placeholder="Expected funding" required autofocus />
                        </div>

                         <div id="form-other">
                            <label for="inputOther">Other</label>
                            <input type="text" id="inputOther" class="form-control" placeholder="Other" />
                        </div>

                        <br /><br />
                        <button class="btn btn-lg btn-success btn-block" type="submit">Submit</button>

                    </form>

        </main>

        <footer class="mastfoot mt-auto">
            <div class="inner">
                <p>&copy; University of Dundee - Agile Team 6 - AC31007<br /><a href="https://github.com/gavinroderick/agile">Check out our source code!</a></p>
            </div>
        </footer>

        </div>
</body>
</html>
