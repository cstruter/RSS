Imports System.Collections.Generic
Imports System.ServiceModel.Syndication
Imports System.Xml

Public Structure RSSItem
    Private _title As String
    Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

    Private _link As String
    Public Property link() As String
        Get
            Return _link
        End Get
        Set(ByVal value As String)
            _link = value
        End Set
    End Property

    Private _description As String
    Public Property description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property
End Structure

Public Class RSSReader

    Public title As String
    Public link As String
    Public description As String
    Public items As List(Of RSSItem) = New List(Of RSSItem)()

    Public Sub New(ByVal url As String)

        Dim doc As New XmlDocument()
        doc.Load(url)

        Dim channel As XmlElement = doc("rss")("channel")
        Dim items As XmlNodeList = channel.GetElementsByTagName("item")
        Me.title = channel("title").InnerText
        Me.link = channel("link").InnerText
        Me.description = channel("description").InnerText

        For Each item As XmlNode In items
            Dim rss As New RSSItem()
            rss.title = item("title").InnerText
            rss.description = item("description").InnerText
            rss.link = item("link").InnerText
            Me.items.Add(rss)
        Next

    End Sub
End Class
