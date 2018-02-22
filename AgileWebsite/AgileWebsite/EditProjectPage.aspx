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
        
      
        

        if (System.IO.File.Exists(Server.MapPath("~/Projects/" + fileName.Text + ".xlsx")))
        {
             clickedButton.Text = "Downloading";
             Response.ContentType = "Application/.xlsx";
             Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName.Text + ".xlsx");
             Response.TransmitFile(Server.MapPath("~/Projects/" + fileName.Text + ".xlsx"));
             Response.Write("This file exists.");
        }
        else
        {
              Response.Write("This file doesnt exist.");
        }

        
       Response.End();


        /*
        if (System.IO.File.Exists(Server.MapPath("~/Projects/" + fileName.Text + ".xlsx")))
        {
            Response.Write("This file exists.");
            
        }
        {
            Response.Write("This file does not exist.");
        }
        */



    }

</script>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
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
</body>
</html>







