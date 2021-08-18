using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DXSample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            ViewModel viewModel = new ViewModel();
            diagramDataBindingController1.GenerateItem += DiagramDataBindingController1_GenerateItem;
            diagramDataBindingController1.CustomLayoutItems += DiagramDataBindingController1_CustomLayoutItems;
            diagramDataBindingController1.DataSource = viewModel.Items;
            diagramDataBindingController1.KeyMember = "Id";
            diagramDataBindingController1.ConnectorsSource = viewModel.Connections;
            diagramDataBindingController1.ConnectorFromMember = "From";
            diagramDataBindingController1.ConnectorToMember = "To";
        }

        private void DiagramDataBindingController1_CustomLayoutItems(object sender, DiagramCustomLayoutItemsEventArgs e) {
            e.Handled = true;
        }

        private void DiagramDataBindingController1_GenerateItem(object sender, DiagramGenerateItemEventArgs e) {
            var item = new DiagramShape {
                X = 27,
                Width = 75,
                Height = 50,
                Shape = BasicShapes.Rectangle
            };
            item.Bindings.Add(new DiagramBinding("Content", "PositionString"));
            item.Bindings.Add(new DiagramBinding("Position", "Position", DiagramBindingMode.TwoWay));
            e.Item = item;
        }
    }
}
