<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditCrawlProject.aspx.vb" Inherits="EditCrawlProject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
            DataKeyNames="CrawlProjectID" DataSourceID="EditCrawlProjectSqlDataSource" DefaultMode="Edit"
            ForeColor="#333333" GridLines="None" Height="50px" Width="560px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="#999999" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" VerticalAlign="Top" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:CheckBoxField DataField="IsSaveContent" HeaderText="Save Content" SortExpression="IsSaveContent" />
                <asp:BoundField DataField="Threads" HeaderText="Threads" SortExpression="Threads" />
                <asp:BoundField DataField="DownloadDelay" HeaderText="Download Delay (Seconds)" SortExpression="DownloadDelay" />
                <asp:BoundField DataField="ConnectionPerIP" HeaderText="Connection Per IP" SortExpression="ConnectionPerIP" />
                <asp:BoundField DataField="MaxUrl" HeaderText="Max Url" SortExpression="MaxUrl" />
                <asp:BoundField DataField="AssignTimeOutMinute" HeaderText="Assign TimeOut (Minutes)"
                    SortExpression="AssignTimeOutMinute" />
                <asp:TemplateField HeaderText="Web Agent" SortExpression="WebAgentName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Height="48px" Text='<%# Bind("WebAgentName") %>'
                            Width="400px"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WebAgentName") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("WebAgentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="WebTimeout" HeaderText="Web Timeout (Seconds)" SortExpression="WebTimeout" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="EditCrawlProjectSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ScraperDBConnectionString %>"
            SelectCommand="SELECT * FROM [CrawlProject] WHERE ([CrawlProjectID] = @CrawlProjectID)"
            UpdateCommand="UPDATE CrawlProject SET Name = @Name, IsSaveContent = @IsSaveContent, Threads = @Threads, DownloadDelay = @DownloadDelay, ConnectionPerIP = @ConnectionPerIP, DateRun = @DateRun, MaxUrl = @MaxUrl, AssignTimeOutMinute = @AssignTimeOutMinute, WebAgentName = @WebAgentName, WebTimeout = @WebTimeout WHERE (CrawlProjectID = @CrawlProjectID)">
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="IsSaveContent" Type="Boolean" />
                <asp:Parameter Name="Threads" Type="Int32" />
                <asp:Parameter Name="DownloadDelay" Type="Int32" />
                <asp:Parameter Name="ConnectionPerIP" Type="Int32" />
                <asp:Parameter Name="DateRun" Type="DateTime" />
                <asp:Parameter Name="MaxUrl" Type="Int32" />
                <asp:Parameter Name="AssignTimeOutMinute" Type="Int32" />
                <asp:Parameter Name="WebAgentName" Type="String" />
                <asp:Parameter Name="WebTimeout" Type="Int32" />
                <asp:Parameter Name="CrawlProjectID" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="-1" Name="CrawlProjectID" QueryStringField="CrawlProjectID"
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
