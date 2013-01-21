<%@ WebHandler Language="C#" Class="rssremote" %>

using System;
using System.Web;
using System.Xml;
using System.IO;

public class rssremote : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/xml";
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(context.Request.QueryString["url"]);
        context.Response.Write(xdoc.OuterXml);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}