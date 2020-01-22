Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace DiagramContainers
	Partial Public Class [Default]
		Inherits System.Web.UI.Page

		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			If Not IsPostBack Then
				Session.Clear()
			End If
		End Sub
	End Class
End Namespace