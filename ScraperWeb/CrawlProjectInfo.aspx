<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CrawlProjectInfo.aspx.vb" Inherits="CrawlProjectInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        <br />
        Project List:<br />
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Project Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# EvalProjectUrlPage(Eval("projectID")) %>'
                            Text='<%# Eval("Name") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
        <br />
        Datatables
        <br />
        <asp:GridView ID="GridView2" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Table Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataTableEval(Eval("Name")) %>'
                            Text='<%# Eval("Name") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
    </form>
</body>
</html>
