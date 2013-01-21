<%@ Control Language="C#" AutoEventWireup="true" CodeFile="rss.ascx.cs" Inherits="usercontrols_rss" %>
<div class="rssBlock">
    <asp:Label runat="server" ID="lblTitle" CssClass="rssParentTitle"></asp:Label><br />
    <asp:Label runat="server" ID="lblDescription"></asp:Label><br />
    <br />
    <asp:HyperLink runat="server" ID="hlRss" Text="Read More"></asp:HyperLink>
    <br />
    <br />
    <asp:DataList runat="server" ID="dlRSS" RepeatLayout="Flow">
        <ItemTemplate>
            <div class="rssTitle">
                <%# Eval("title")%>
            </div>
            <div>
                <%# Eval("description")%>
            </div>
            <div>
                <a href="<%# Eval("link")%>">Read More</a>
                <br />
                <br />
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>
