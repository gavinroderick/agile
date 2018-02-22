 <%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AgileWebsite._Default" %>


<script runat="server">



    void Page_Load(Object sender, EventArgs e)
    {
        // Manually register the event-handling method for
        // the Click event of the Button control.
        DownloadButton.Click += new EventHandler(this.DownloadButton_Click);
    }

    private void DownloadButton_Click(object sender, System.EventArgs e)
    {

        Button clickedButton = (Button)sender;
        string File = fileName.Text + ".xlsx";
        Download(clickedButton, File);
        /** REFACTORED, THIS CODE MADE INTO A FUNCTION OF ITS OWN, MAKES IT REUSABLE IN OTHER PLACES
        //THIS WAS PREVIOUSLY REFACTORED ALSO
        //if (System.IO.File.Exists(Server.MapPath("~/Projects/" + fileName.Text + ".xlsx")))
        if (System.IO.File.Exists(Server.MapPath("~/Projects/" + File)))
        {
            clickedButton.BackColor = System.Drawing.Color.AliceBlue;
            Response.ContentType = "Application/.xlsx";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + File);
            //REFACTORED CODE
            // Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName.Text + ".xlsx");
            // Response.TransmitFile(Server.MapPath("~/Projects/" + fileName.Text + ".xlsx"));
            Response.TransmitFile(Server.MapPath("~/Projects/" + File));
            Response.Write("This file exists.");
            Response.End();
        }
        else
        {
            Response.Write("This file doesnt exist.");
        }
        */

    }


    private void Download(Button clickedButton, string fileName)
    {
         if (System.IO.File.Exists(Server.MapPath("~/Projects/" + fileName)))
        {
            clickedButton.BackColor = System.Drawing.Color.AliceBlue;
            Response.ContentType = "Application/.xlsx";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            //REFACTORED CODE
            // Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName.Text + ".xlsx");
            // Response.TransmitFile(Server.MapPath("~/Projects/" + fileName.Text + ".xlsx"));
            Response.TransmitFile(Server.MapPath("~/Projects/" + fileName));
            Response.Write("This file exists.");
            Response.End();
        }
        else
        {
            Response.Write("This file doesnt exist.");
        }
    }




</script>


<html lang="en">
  <head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../../../favicon.ico">

    <title>Edit Project Page</title>
    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="Content/cover.css" rel="stylesheet">
  </head>

  <body class="text-center">

    <div class="cover-container d-flex h-100 p-3 mx-auto flex-column">
      <header class="masthead mb-auto">
        <div class="inner">
        </div>
      </header>

      <main role="main" class="inner cover"> 
        <form runat="server">
      <h3>Download Button Example</h3>
      <br />
    
      <asp:TextBox id="fileName" runat="server" type="text" />
    
      <br />        
      <asp:Button id="DownloadButton"
           Text="Click here to download"
           OnClick="DownloadButton_Click" 
           runat="server"/>
      <br />
      <br />
   </form>
      </main>

      <footer class="mastfoot mt-auto">
        <div class="inner">
          <p>&copy; University of Dundee - Agile Team 6 - AC31007<br /> <a href="https://github.com/gavinroderick/agile">Check out our source code!</a>
          </p>
        </div>
      </footer>
    </div>


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script>window.jQuery || document.write('<script src="../../../../assets/js/vendor/jquery-slim.min.js"><\/script>')</script>
    <script src="../../../../assets/js/vendor/popper.min.js"></script>
    <script src="../../../../dist/js/bootstrap.min.js"></script>
  </body>
</html>








