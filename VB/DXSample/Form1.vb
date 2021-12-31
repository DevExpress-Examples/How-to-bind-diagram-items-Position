Imports DevExpress.Diagram.Core
Imports DevExpress.XtraDiagram
Imports System.Windows.Forms

Namespace DXSample

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            Dim viewModel As ViewModel = New ViewModel()
            AddHandler diagramDataBindingController1.GenerateItem, AddressOf DiagramDataBindingController1_GenerateItem
            AddHandler diagramDataBindingController1.CustomLayoutItems, AddressOf Me.DiagramDataBindingController1_CustomLayoutItems
            diagramDataBindingController1.DataSource = viewModel.Items
            diagramDataBindingController1.KeyMember = "Id"
            diagramDataBindingController1.ConnectorsSource = viewModel.Connections
            diagramDataBindingController1.ConnectorFromMember = "From"
            diagramDataBindingController1.ConnectorToMember = "To"
        End Sub

        Private Sub DiagramDataBindingController1_CustomLayoutItems(ByVal sender As Object, ByVal e As DiagramCustomLayoutItemsEventArgs)
            e.Handled = True
        End Sub

        Private Sub DiagramDataBindingController1_GenerateItem(ByVal sender As Object, ByVal e As DiagramGenerateItemEventArgs)
            Dim item = New DiagramShape With {.X = 27, .Width = 75, .Height = 50, .Shape = BasicShapes.Rectangle}
            item.Bindings.Add(New DiagramBinding("Content", "PositionString"))
            item.Bindings.Add(New DiagramBinding("Position", "Position", DiagramBindingMode.TwoWay))
            e.Item = item
        End Sub
    End Class
End Namespace
