Imports DevExpress.Web.ASPxDiagram
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Web

Namespace DiagramContainers
	Public Class Item
		Public Property ID() As Integer
		Public Property ContainerID() As Integer?
		Public Property Type() As String
		Public Property Text() As String
		Public Property X() As Double
		Public Property Y() As Double
		Public Property Width() As Double
		Public Property Height() As Double

		Public Sub New(ByVal id As Integer, ByVal containerId? As Integer, ByVal type As String, ByVal text As String, ByVal x As Double, ByVal y As Double, ByVal width As Double, ByVal height As Double)
			Me.ID = id
			Me.ContainerID = containerId
			Me.Type = type
			Me.Text = text
			Me.X = x
			Me.Y = y
			Me.Width = width
			Me.Height = height
		End Sub

		Public Sub New()
		End Sub
	End Class
	Public Module DiagramDataProvider
		Private ReadOnly Property Items() As List(Of Item)
			Get
				Dim data = TryCast(HttpContext.Current.Session("DiagramNodes"), List(Of Item))
				If data Is Nothing Then
					data = New List(Of Item) From {
						New Item(1, Nothing, DiagramShapeType.VerticalContainer.ToString(), "Development", 0.5, 0.5, 7.25, 5),
						New Item(2, 1, DiagramShapeType.VerticalContainer.ToString(), "ASP.NET Team", 0.75, 1, 1.5, 4),
						New Item(3, 1, DiagramShapeType.VerticalContainer.ToString(), "JavaScript Team", 2.5, 1, 1.5, 4),
						New Item(4, 1, DiagramShapeType.VerticalContainer.ToString(), "WPF Team", 4.25, 1, 1.5, 4),
						New Item(5, 1, DiagramShapeType.VerticalContainer.ToString(), "WinForms Team", 6, 1, 1.5, 4),
						New Item(6, 2, DiagramShapeType.Rectangle.ToString(), "Laurence Lebihan", 1, 1.5, 1, 0.75),
						New Item(7, 2, DiagramShapeType.Rectangle.ToString(), "Elizabeth Lincoln", 1, 2.5, 1, 0.75),
						New Item(8, 3, DiagramShapeType.Rectangle.ToString(), "Patricio Simpson", 2.75, 1.5, 1, 0.75),
						New Item(9, 3, DiagramShapeType.Rectangle.ToString(), "Francisco Chang", 2.75, 2.5, 1, 0.75),
						New Item(10, 4, DiagramShapeType.Rectangle.ToString(), "Christina Berglund", 4.5, 1.5, 1, 0.75),
						New Item(11, 4, DiagramShapeType.Rectangle.ToString(), "Hanna Moos", 4.5, 2.5, 1, 0.75),
						New Item(12, 4, DiagramShapeType.Rectangle.ToString(), "Frederique Citeaux", 4.5, 3.5, 1, 0.75),
						New Item(13, 5, DiagramShapeType.Rectangle.ToString(), "Ana Trujillo", 6.25, 1.5, 1, 0.75),
						New Item(14, 5, DiagramShapeType.Rectangle.ToString(), "Antonio Moreno", 6.25, 2.5, 1, 0.75)
					}
					HttpContext.Current.Session("DiagramNodes") = data
				End If
				Return data
			End Get
		End Property

		<DataObjectMethod(DataObjectMethodType.Select, True)>
		Public Function GetItems() As List(Of Item)
			Return Items
		End Function

		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Function InsertItem(ByVal item As Item) As Integer
			item.ID = If(Items.Count = 0, 1, Items.Max(Function(i) i.ID) + 1)
			Items.Add(item)
			Return item.ID
		End Function

		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Sub UpdateItem(ByVal item As Item)
			Dim itemToUpdate = Items.Find(Function(i) i.ID = item.ID)
			itemToUpdate.ContainerID = item.ContainerID
			itemToUpdate.Type = item.Type
			itemToUpdate.Text = item.Text
			itemToUpdate.X = item.X
			itemToUpdate.Y = item.Y
			itemToUpdate.Width = item.Width
			itemToUpdate.Height = item.Height
		End Sub

		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Sub DeleteItem(ByVal item As Item)
			Items.RemoveAll(Function(x) x.ID = item.ID)
		End Sub
	End Module
End Namespace