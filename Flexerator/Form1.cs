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
    //public class BoxItem
    //{
    //    public int Count { get; set; }
    //    public bool Open { get; set; }
    //    public BoxItem()
    //    {
    //        Count = 0;
    //        Open = true;
    //    }
    //}
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            parseToFlex(rtbInput.Text);
        }

        //private Dictionary<string, BoxItem> containers;
        //private List<string> openContainers;

        private void parseToFlex(string input)
        {
            //containers = new Dictionary<string, BoxItem>();
            //openContainers = new List<string>();

            string[] htmlOut = input.Select(x => $"{x}").ToArray();
            int row = 1;
            int col = 1;
            int depth = -1;
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

                        htmlOut[i] = new String('\t', depth) + $"<div class=\"row-{row}\">" + rowLabel + "\n";
                        row += 1;
                        break;
                    case "]":
                        htmlOut[i] = new String('\t', depth) + "</div>\n";
                        depth -= 1;
                        break;
                    case "(":
                        depth += 1;
                        string colLabel = chLabels.Checked ? $"<span style=\"position: absolute; margin: -21px 0 0 -21px\">col-{col}</span>" : "";

                        htmlOut[i] = new String('\t', depth) + $"<div class=\"col-{col}\">" + colLabel + "\n";
                        col += 1;
                        break;
                    case ")":
                        htmlOut[i] = new String('\t', depth) + "</div>\n";
                        depth -= 1;
                        break;
                    default:
                        htmlOut[i] = "";
                        break;
                }
            }
            rtbOutputHtml.Text = String.Join("", htmlOut);

            string cssOut = "";
            for (int i = 1; i < row; i++)
            {
                cssOut += $".row-{i}" + (i < row-1 ? "," : "");
            }

            cssOut += " {\n  display: flex;\n  flex-direction: row;\n  flex-wrap: wrap;\n  padding: 25px;\n  background-color: #141414;\n  color: #fff;\n  border: 1px solid white;\n}\n\n";

            for (int i = 1; i < col; i++)
            {
                cssOut += $".col-{i}" + (i < col-1 ? "," : "");
            }

            cssOut += " {\n  display: flex;\n  flex-direction: column;\n  flex-wrap: wrap;\n  padding: 25px;\n  background-color: #eee;\n  color: #000;\n  border: 1px solid black;\n}\n";

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
