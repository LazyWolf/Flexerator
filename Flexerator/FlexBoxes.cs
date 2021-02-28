using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flexerator
{
    class FlexItem
    {
        public FlexItem Parent { get; set; }
        public List<FlexItem> Children { get; set; }
        public int Depth { get; set; }
        public string Direction { get; set; }
        public string Type { get; set; }

        public FlexItem(FlexItem parent = null, int depth = 0, string type = "wrap")
        {
            Parent = parent;
            Depth = depth;
            Direction = "row";
            Children = new List<FlexItem>();
            Type = type;
        }

        public FlexItem SpawnFlexItem(string type)
        {
            FlexItem newFlexItem = new FlexItem(this, this.Depth + 1, type);
            Children.Add(newFlexItem);
            return newFlexItem;
        }
    }
}
