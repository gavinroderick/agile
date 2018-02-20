<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AgileWebsite.WebForm1" %>

<!DOCTYPE html>

<html>
<body>
    <p>hello </p>
<form action="WebForm1.aspx" method="post" enctype="multipart/form-data">
	<label for="file">Choose File:</label>
	<input type="file" name="Project1" />
	<input type="submit" value="Upload" />
</form>

</body>
</html>
