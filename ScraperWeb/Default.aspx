<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="90%">
        </asp:GridView>
        &nbsp;&nbsp;
        <br />
        <asp:Repeater ID="Repeater1" runat="server">
        </asp:Repeater>
        <br />
        <br />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="FileValidator"></asp:CustomValidator>&nbsp;<br />
        <asp:FileUpload ID="FileUpload1" runat="server" Width="544px" />
        <asp:Button ID="Button1" runat="server" Text="Add Project" /></div>
    </form>
</body>
</html>
