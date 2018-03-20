
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="historyTable.aspx.cs" Inherits="AgileWebsite.historyTable" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
table, td, th {    
    border: 1px solid #ddd;
    text-align: left;
}

table {
    border-collapse: collapse;
    width: 100%;
}

th, td {
    padding: 15px;
}
</style>

    <table >
        <tr >
            <td> ID </td>                        
            <td> Project ID </td>            
            <td>User</td> 
            <td>Date</td>
            <td>Action</td>
            <td>Comments</td>
        </tr>

        <%=getWhileLoopData()%>

    </table>
</asp:Content>
