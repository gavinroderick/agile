<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
        clickedButton.Text = "Downloading";
        Response.ContentType = "Application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=tester1.pdf");
        Response.TransmitFile(Server.MapPath("~/Projects/tester1.pdf"));
        Response.End();
    }
    

</script>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h3>Download Button Example</h3>

      <asp:Button id="DownloadButton"
           Text="Click here to download"
           OnClick="DownloadButton_Click" 
           runat="server"/>
      <br />
      <br />
    </div>
    </form>
</body>
</html>







