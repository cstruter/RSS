<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Example4.aspx.vb" Inherits="_Example4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RSS example using WCF</title>
    <link href="styles/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <div class="rssBlock">
        <asp:Label runat="server" ID="lblTitle" CssClass="rssParentTitle"></asp:Label><br />
        <asp:Label runat="server" ID="lblDescription"></asp:Label><br />
        <br />
        <asp:HyperLink runat="server" ID="hlRss">Read More</asp:HyperLink>
        <br />
        <br />
        <asp:ListView runat="server" ID="lvRSS" ItemPlaceholderID="rss">
            <LayoutTemplate>
                <div id="rss" runat="server">
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="rssTitle">
                    <%# Eval("title.Text")%>
                </div>
                <div>
                    <%# Eval("summary.Text")%>
                </div>
                <div>
                    <a href="<%# Eval("Links(0).Uri.AbsoluteUri")%>">Read More</a>
                    <br />
                    <br />
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
