Public Class BrowserProxy

    Dim WebBrowser1 As System.Windows.Forms.WebBrowser
    Dim content As String

    Public Sub Decorate(browser As System.Windows.Forms.WebBrowser, content As String)
        Me.WebBrowser1 = browser
        Me.content = content

        Me.WebBrowser1.Navigate("about:blank")
        'Application.DoEvents()
        Me.WebBrowser1.Document.OpenNew(False).Write("<html><body><div id=""editable"">" & content & "</div></body></html>")

        'turns off document body editing
        For Each el As Windows.Forms.HtmlElement In Me.WebBrowser1.Document.All
            el.SetAttribute("unselectable", "on")
            el.SetAttribute("contenteditable", "false")
        Next

        'turns on editable div editing
        With Me.WebBrowser1.Document.Body.All("editable")
            .SetAttribute("width", "100%")
            .SetAttribute("height", "100%")
            .SetAttribute("contenteditable", "true")
        End With

        'turns on edit mode
        Me.WebBrowser1.ActiveXInstance.Document.DesignMode = "On"
        'stops right click->Browse View
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
    End Sub


End Class
