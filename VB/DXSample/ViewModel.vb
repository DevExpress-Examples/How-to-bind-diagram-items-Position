Imports DevExpress.Utils
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace DXSample

    Public Class ViewModel

        Public Sub New()
            Items = New List(Of Item)()
            For i As Integer = 0 To 5 - 1
                Items.Add(New Item With {.Id = i, .Name = "Item " & i, .Position = New PointFloat(i * 100, i * 200)})
            Next

            Connections = New List(Of Link)()
            For i As Integer = 0 To 4 - 1
                Connections.Add(New Link With {.From = Items(i).Id, .[To] = Items(i + 1).Id})
            Next

            Connections.Add(New Link With {.From = Items(4).Id, .[To] = Items(0).Id})
        End Sub

        Public Property Connections As List(Of Link)

        Public Property Items As List(Of Item)
    End Class

    Public Class Item
        Implements INotifyPropertyChanged

        Private positionField As PointFloat

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Protected Overridable Sub OnPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            RaiseEvent PropertyChanged(sender, e)
        End Sub

        Public Property Id As Integer

        Public Property Name As String

        Public Property Position As PointFloat
            Get
                Return positionField
            End Get

            Set(ByVal value As PointFloat)
                If positionField Is value Then
                    Return
                End If

                positionField = value
                OnPropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Item.Position)))
                OnPropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Item.PositionString)))
            End Set
        End Property

        Public ReadOnly Property PositionString As String
            Get
                Return Position.ToString()
            End Get
        End Property
    End Class

    Public Class Link

        Public Property From As Object

        Public Property [To] As Object
    End Class
End Namespace
