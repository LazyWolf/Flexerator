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
        public string ClassName { get; set; }

        public FlexItem(FlexItem parent = null, int depth = 0, string className = "wrap")
        {
            Parent = parent;
            Depth = depth;
            Direction = "row";
            Children = new List<FlexItem>();
            ClassName = className;
        }

        public FlexItem SpawnFlexItem(string className)
        {
            FlexItem newFlexItem = new FlexItem(this, this.Depth + 1, className);
            Children.Add(newFlexItem);
            return newFlexItem;
        }

        public string Report(bool labels=false, string wrapPrefix = "wrap")
        {
            string indent = new string(' ', Depth * 2);
            string label = (labels && !ClassName.StartsWith(wrapPrefix) ? $"<span class=\"container-label\">{ClassName}</span>" : "");
            string output = indent + $"<div class=\"{ClassName}\">" + label + (Children.Count > 0 ? "\n" : "");
            foreach (FlexItem child in Children)
            {
                output += child.Report(labels);
            }
            return output + (Children.Count > 0 ? indent : "") + "</div>\n";
        }
    }
}
