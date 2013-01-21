Imports System.Collections.Generic
Imports System.Linq
Imports System.ServiceModel.Syndication
Imports System.Xml
Imports System.Xml.Linq

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

Namespace Example1
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
End Namespace

Namespace Example2
    Public Class RSSReader

        Public title As String
        Public link As String
        Public description As String
        Public items As List(Of RSSItem)

        Public Sub New(ByVal url As String)

            Dim rssFeed As XElement = XElement.Load(url).Element("channel")
            Me.title = rssFeed.Element("title").Value
            Me.link = rssFeed.Element("link").Value
            Me.description = rssFeed.Element("description").Value

            items = (From Item In rssFeed.Elements("item") _
                     Select New RSSItem With { _
                        .title = Item.Element("title").Value, _
                        .description = Item.Element("description").Value, _
                        .link = Item.Element("link").Value}).ToList()

        End Sub

    End Class
End Namespace

Namespace Example3
    Public Class RSSReader

        Public title As String
        Public link As String
        Public description As String
        Public items As List(Of RSSItem) = New List(Of RSSItem)()

        Public Sub New(ByVal url As String)

            Dim reader As New XmlTextReader(url)

            While reader.Read()
                If reader.NodeType = XmlNodeType.Element Then
                    Select Case (reader.Name)
                        Case "title"
                            Me.title = reader.ReadString()
                        Case "link"
                            Me.link = reader.ReadString()
                        Case "description"
                            Me.description = reader.ReadString()
                        Case "image"
                            While (Not ((reader.Name = "image") And _
                                        (reader.NodeType = XmlNodeType.EndElement)) And _
                                                reader.Read())
                            End While
                    End Select
                End If

                If reader.Name = "item" Then

                    Dim item As New RSSItem()
                    While (Not ((reader.Name = "item") And _
                                (reader.NodeType = XmlNodeType.EndElement)) And _
                                    reader.Read())
                        If (reader.NodeType = XmlNodeType.Element) Then

                            Select Case (reader.Name.ToLower())
                                Case "title"
                                    item.title = reader.ReadString()
                                Case "description"
                                    item.description = reader.ReadString()
                                Case "link"
                                    item.link = reader.ReadString()
                            End Select
                        End If
                    End While
                    items.Add(item)
                End If
            End While
        End Sub
    End Class
End Namespace