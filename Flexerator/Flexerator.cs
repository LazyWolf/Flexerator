using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flexerator
{
    public partial class Flexerator : Form
    {
        public Flexerator()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            parseToFlex(rtbInput.Text);
        }

        //private Dictionary<string, BoxItem> containers;
        //private List<string> openContainers;

        private void parseFlexItems(string input)
        {
            string[] htmlOut = input.Select(x => $"{x}").ToArray();
            FlexItem currentFlexItem = new FlexItem(type: "flap");

            for (int i = 0; i < htmlOut.Length; i++)
            {
                switch (htmlOut[i])
                {
                    case "[":
                        currentFlexItem = currentFlexItem.SpawnFlexItem(type: "row");
                        break;
                    case "]":
                        currentFlexItem = currentFlexItem.Parent;
                        break;
                    case "\n":
                        currentFlexItem = currentFlexItem.Parent == null ? new FlexItem() : currentFlexItem.Parent;
                        break;
                    case ">":
                        currentFlexItem.Type = "row";
                        currentFlexItem.Direction = "row";
                        break;
                    case "<":
                        currentFlexItem.Type = "row-rev";
                        currentFlexItem.Direction = "row-reverse";
                        break;
                    case "v":
                        currentFlexItem.Type = "col";
                        currentFlexItem.Direction = "column";
                        break;
                    case "^":
                        currentFlexItem.Type = "col-rev";
                        currentFlexItem.Direction = "column-reverse";
                        break;
                    default:
                        break;
                }
            }
        }

        private void parseToFlex(string input)
        {
            
            //containers = new Dictionary<string, BoxItem>();
            //openContainers = new List<string>();

            string[] htmlOut = input.Select(x => $"{x}").ToArray();
            int row = 1;
            int col = 1;
            int flap = 2;
            int depth = 0;
            var openContainers = new List<string>();

            for (int i = 0; i < htmlOut.Length; i++)
            {
                switch (htmlOut[i])
                {
                    case "[":
                        depth += 1;
                        //var containerName = $"row-{row}";
                        //openContainers.Add(containerName);
                        string rowLabel = chLabels.Checked ? $"<span style=\"position: absolute; margin: -21px 0 0 -21px\">row-{row}</span>" : "";

                        htmlOut[i] = new String(' ', depth * 2) + $"<div class=\"row-{row}\">" + rowLabel + "\n";
                        row += 1;
                        break;
                    case "(":
                        depth += 1;
                        string colLabel = chLabels.Checked ? $"<span style=\"position: absolute; margin: -21px 0 0 -21px\">col-{col}</span>" : "";

                        htmlOut[i] = new String(' ', depth * 2) + $"<div class=\"col-{col}\">" + colLabel + "\n";
                        col += 1;
                        break;
                    case "]":
                    case ")":
                        htmlOut[i] = new String(' ', depth * 2) + "</div>\n";
                        depth -= 1;
                        break;
                    case "\n":
                        htmlOut[i] = new String(' ', depth * 2) + $"</div>\n<div class=\"flap-{flap}\">\n";
                        flap++;
                        break;
                    default:
                        htmlOut[i] = "";
                        break;
                }
            }
            rtbOutputHtml.Text = "<div class=\"flap-1\">\n" + String.Join("", htmlOut) + "</div>";

            string cssOut = "";
            for (int i = 1; i < row; i++)
            {
                cssOut += $".row-{i}" + (i < row-1 ? "," : "");
            }

            cssOut += " {\n  display: flex;\n  flex-direction: row;\n  flex-wrap: wrap;\n  flex: 1;\n  padding: 25px;\n  background-color: #141414;\n  color: #fff;\n  border: 1px solid white;\n}\n\n";

            for (int i = 1; i < col; i++)
            {
                cssOut += $".col-{i}" + (i < col-1 ? "," : "");
            }

            cssOut += " {\n  display: flex;\n  flex-direction: column;\n  flex-wrap: wrap;\n  flex: 1;\n  padding: 25px;\n  background-color: #eee;\n  color: #000;\n  border: 1px solid black;\n}\n\n";

            for (int i = 1; i < flap; i++)
            {
                cssOut += $".flap-{i}" + (i < col - 1 ? "," : "");
            }

            cssOut += " {\n  display: flex;\n}\n";

            rtbOutputCss.Text = cssOut;
        }

        //private void openContainer(string containerName)
        //{
        //    containers[containerName] = new BoxItem();
        //}

        //private void addToContainer(string containerName)
        //{
        //    if(containers.ContainsKey(containerName) && containers[containerName].Open)
        //    {
        //        containers[containerName].Count += 1;
        //    }
        //}
        //private void closeContainer(string containerName)
        //{
        //    if (containers.ContainsKey(containerName) && containers[containerName].Open)
        //    {
        //        containers[containerName].Open = false;
        //    }
        //}

        private void chLabels_CheckedChanged(object sender, EventArgs e)
        {
            chLabels.ForeColor = chLabels.Checked ? Color.Black : Color.White;
        }
    }
}
