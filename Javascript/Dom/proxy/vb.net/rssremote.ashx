<%@ WebHandler Language="VB" Class="rssremote" %>

Imports System
Imports System.Web
Imports System.Xml
Imports System.IO

Public Class rssremote : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/xml"
        Dim xdoc As New XmlDocument()
        xdoc.Load(context.Request.QueryString("url"))
        context.Response.Write(xdoc.OuterXml)
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class