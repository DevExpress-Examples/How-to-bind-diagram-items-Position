using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DXSample {
    public class ViewModel {
        public ViewModel() {
            Items = new List<Item>();
            for (int i = 0; i < 5; i++)
                Items.Add(new Item { Id = i, Name = "Item " + i, Position = new PointFloat(i * 100, i * 200) });
            Connections = new List<Link>();
            for (int i = 0; i < 4; i++)
                Connections.Add(new Link { From = Items[i].Id, To = Items[i + 1].Id });
            Connections.Add(new Link { From = Items[4].Id, To = Items[0].Id });
        }

        public List<Link> Connections { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item : INotifyPropertyChanged {
        PointFloat position;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
            PropertyChanged?.Invoke(sender, e);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public PointFloat Position {
            get => position; set {
                if (position == value) {
                    return;
                }

                position = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(Position)));
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(PositionString)));
            }
        }

        public string PositionString => Position.ToString();
    }

    public class Link {
        public object From { get; set; }
        public object To { get; set; }
    }
}
