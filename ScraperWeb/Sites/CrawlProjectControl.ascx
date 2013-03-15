<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CrawlProjectControl.ascx.vb" Inherits="Sites_CrawlProjectControl" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
    BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4"
    DataKeyNames="CrawlProjectID" DataSourceID="SqlDataSource1" GridLines="Horizontal"
    Height="144px" Width="200px">
    <FooterStyle BackColor="White" ForeColor="#333333" />
    <Columns>
        <asp:HyperLinkField DataNavigateUrlFields="CrawlProjectID" DataNavigateUrlFormatString="~/Project.aspx?id={0}"
            DataTextField="Name" DataTextFormatString="{0}" HeaderText="Crawl Projects" NavigateUrl="~/Project.aspx" />
    </Columns>
    <RowStyle BackColor="White" ForeColor="#333333" />
    <EmptyDataTemplate>
        No crawl projects.
    </EmptyDataTemplate>
    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ScraperDBConnectionString %>"
    SelectCommand="SELECT [CrawlProjectID], [Name] FROM [CrawlProject]"></asp:SqlDataSource>
<br />
