
Partial Class usercontrols_rss
    Inherits System.Web.UI.UserControl

    Public Property title() As String
        Get
            Return lblTitle.Text
        End Get
        Set(ByVal value As String)
            lblTitle.Text = value
        End Set
    End Property

    Public Property description() As String
        Get
            Return lblDescription.Text
        End Get
        Set(ByVal value As String)
            lblDescription.Text = value
        End Set
    End Property

    Public Property link() As String
        Get
            Return hlRss.NavigateUrl
        End Get
        Set(ByVal value As String)
            hlRss.NavigateUrl = value
        End Set
    End Property

    Public WriteOnly Property DataSource() As Object
        Set(ByVal value As Object)
            dlRSS.DataSource = value
            dlRSS.DataBind()
        End Set
    End Property
End Class
