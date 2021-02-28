using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Flexerator
{
    public partial class Flexerator : Form
    {
        private const string arrowNotationDefault = "[>][>]\n[>[v][v][v]] [v[>][>]]\n[v[>][>][>]]\n[^[<][<]] [<[^][^]]";
        private const string boxNotationDefault = "[][]\n[()()()()()]\n([][][][][])";

        public Flexerator()
        {
            InitializeComponent();
        }

        private void BtnConvert_OnClick(object sender, EventArgs e)
        {
            if(chNotation.Checked)
            {
                ParseArrowAnnotationToFlex(rtbInput.Text.Trim());
            }
            else
            {
                ParseBraceNotationToFlex(rtbInput.Text.Trim());
            }
        }

        private void ChLabels_OnCheckedChanged(object sender, EventArgs e)
        {
            chLabels.ForeColor = chLabels.Checked ? Color.Black : Color.White;
            if (chLabels.Checked)
            {
                chLabels.Text = "Row/Col Labels";
            }
            else
            {
                chLabels.Text = "No Labels";
            }
        }

        private void ChNotation_OnCheckedChanged(object sender, EventArgs e)
        {
            chNotation.ForeColor = chNotation.Checked ? Color.Black : Color.White;
            if (chNotation.Checked)
            {
                chNotation.Text = "Arrow Notation";
                if(rtbInput.Text == boxNotationDefault)
                {
                    rtbInput.Text = arrowNotationDefault;
                }
            }
            else
            {
                if (rtbInput.Text == arrowNotationDefault)
                {
                    rtbInput.Text = boxNotationDefault;
                }
                chNotation.Text = "Brace Notation";
            }
        }

        private void BtnClearStyles_ButtonOnClick(object sender, EventArgs e)
        {
            tbRowStyle.Clear();
            tbColStyle.Clear();
            tbWraStyle.Clear();
        }

        private void ParseArrowAnnotationToFlex(string input)
        {
            // Init
            FlexItem currentFlexItem = new FlexItem(className: $"{tbWraPre.Text}-1");
            var wraps = new List<FlexItem>() { currentFlexItem };
            var rows = new List<FlexItem>();
            var cols = new List<FlexItem>();
            var rowRevs = new List<FlexItem>();
            var colRevs = new List<FlexItem>();

            // Generate Structure
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '[':
                        currentFlexItem = currentFlexItem.SpawnFlexItem(className: "no-type");
                        break;
                    case ']':
                        currentFlexItem = currentFlexItem.Parent;
                        break;
                    case '\n':
                        if (currentFlexItem.Parent == null)
                        {
                            currentFlexItem = new FlexItem(className: $"{tbWraPre.Text}-{wraps.Count + 1}");
                            wraps.Add(currentFlexItem);
                        }
                        else
                        {
                            currentFlexItem = currentFlexItem.Parent;
                        }
                        break;
                    case '>':
                        rows.Add(currentFlexItem);
                        currentFlexItem.ClassName = $"{tbRowPre.Text}-{rows.Count}";
                        currentFlexItem.Direction = "row";
                        break;
                    case '<':
                        rowRevs.Add(currentFlexItem);
                        currentFlexItem.ClassName = $"{tbRowPre.Text}-rev-{rowRevs.Count}";
                        currentFlexItem.Direction = "row-reverse";
                        break;
                    case 'V':
                    case 'v':
                        cols.Add(currentFlexItem);
                        currentFlexItem.ClassName = $"{tbColPre.Text}-{cols.Count}";
                        currentFlexItem.Direction = "column";
                        break;
                    case '^':
                        colRevs.Add(currentFlexItem);
                        currentFlexItem.ClassName = $"{tbColPre.Text}-rev-{colRevs.Count}";
                        currentFlexItem.Direction = "column-reverse";
                        break;
                    default:
                        break;
                }
            }

            // HTML Output
            rtbOutputHtml.Text = String.Join("\n", wraps.Select(w => w.Report(chLabels.Checked))).Trim();

            // CSS Output
            string labelStyle = chLabels.Checked ? ".container-label {\n  position: absolute;\n top: 1px;\n left: 1px;\n padding: 2px;\n " +
                "border: 1px solid #000;\n border-radius: 3px;\n color: #59f9ff;\n text-shadow: 2px 2px #000;\n " +
                "background: #446;\n\n}\n\n" : "";

            string extraWrapStyle = string.Join(";\n  ", tbWraStyle.Text.Split(';').Select(e => e.Trim()));
            string wrapStyle = wraps.Count > 0 ? "." + String.Join(", .", wraps.Select(r => r.ClassName)) + " {\n  display: flex;\n  "
                                + $"{extraWrapStyle.Trim()}\n}}\n\n" : "";

            string extraRowStyle = string.Join(";\n  ", tbRowStyle.Text.Split(';').Select(e => e.Trim()));
            string rowStyle = rows.Count > 0 ? "." + String.Join(", .", rows.Select(r => r.ClassName))
                                + " {\n  "
                                + (chLabels.Checked ? "  position: relative;\n  " : "")
                                + "display: flex;\n  flex-direction: row;\n  flex-wrap: wrap;\n  flex: 1;\n  "
                                + $"{extraRowStyle.Trim()}\n}}\n\n" : "";
            string rowRevStyle = rowRevs.Count > 0 ? "." + String.Join(", .", rowRevs.Select(rr => rr.ClassName))
                                + " {\n  "
                                + (chLabels.Checked ? "  position: relative;\n  " : "")
                                + "display: flex;\n  flex-direction: row-reverse;\n  flex-wrap: wrap;\n  flex: 1;\n  "
                                + $"{extraRowStyle.Trim()}\n}}\n\n" : "";

            string extraColStyle = string.Join(";\n  ", tbColStyle.Text.Split(';').Select(e => e.Trim()));
            string colStyle = cols.Count > 0 ? "." + String.Join(", .", cols.Select(c => c.ClassName))
                                + " {\n  "
                                + (chLabels.Checked ? "  position: relative;\n  " : "")
                                + "display: flex;\n  flex-direction: column;\n  flex-wrap: wrap;\n  flex: 1;\n  "
                                + $"{extraColStyle.Trim()}\n}}\n\n" : "";
            string colRevStyle = colRevs.Count > 0 ? "." + String.Join(", .", colRevs.Select(cr => cr.ClassName))
                                + " {\n  "
                                + (chLabels.Checked ? "  position: relative;\n  " : "")
                                + "display: flex;\n  flex-direction: column-reverse;\n  flex-wrap: wrap;\n  flex: 1;\n  "
                                + $"{extraColStyle.Trim()}\n}}\n\n" : "";

            rtbOutputCss.Text = $"{labelStyle}{wrapStyle}{rowStyle}{rowRevStyle}{colStyle}{colRevStyle}".Trim();
        }

        private void ParseBraceNotationToFlex(string input)
        {
            // Init
            string[] htmlOut = input.Select(x => $"{x}").ToArray();
            int row = 1;
            int col = 1;
            int wrap = 2;
            int depth = 0;
            var openContainers = new List<string>();

            // HTML Output
            for (int i = 0; i < htmlOut.Length; i++)
            {
                switch (htmlOut[i])
                {
                    case "[":
                        depth += 1;
                        string rowLabel = chLabels.Checked ? $"<span style=\"position: absolute; margin: -21px 0 0 -21px\">row-{row}</span>" : "";

                        htmlOut[i] = new String(' ', depth * 2) + $"<div class=\"{tbRowPre.Text}-{row}\">" + rowLabel + "\n";
                        row += 1;
                        break;
                    case "(":
                        depth += 1;
                        string colLabel = chLabels.Checked ? $"<span style=\"position: absolute; margin: -21px 0 0 -21px\">col-{col}</span>" : "";

                        htmlOut[i] = new String(' ', depth * 2) + $"<div class=\"{tbColPre.Text}-{col}\">" + colLabel + "\n";
                        col += 1;
                        break;
                    case "]":
                    case ")":
                        htmlOut[i] = new String(' ', depth * 2) + "</div>\n";
                        depth -= 1;
                        break;
                    case "\n":
                        htmlOut[i] = new String(' ', depth * 2) + $"</div>\n<div class=\"{tbWraPre.Text}-{wrap}\">\n";
                        wrap++;
                        break;
                    default:
                        htmlOut[i] = "";
                        break;
                }
            }

            rtbOutputHtml.Text = "<div class=\"flap-1\">\n" + String.Join("", htmlOut) + "</div>";

            // CSS Output
            string cssOut = "";
            for (int i = 1; i < row; i++)
            {
                cssOut += $".{tbRowPre.Text}-{i}" + (i < row - 1 ? "," : "");
            }

            string extraRowStyle = string.Join(";\n  ", tbRowStyle.Text.Split(';').Select(e => e.Trim()));
            if (row > 1)
            {
                cssOut += " {\n  display: flex;\n  flex-direction: row;\n  flex-wrap: wrap;\n  flex: 1;\n  " + $"{extraRowStyle.Trim()}\n}}\n\n";
            }


            for (int i = 1; i < col; i++)
            {
                cssOut += $".{tbColPre.Text}-{i}" + (i < col - 1 ? "," : "");
            }

            string extraColStyle = string.Join(";\n  ", tbColStyle.Text.Split(';').Select(e => e.Trim()));
            if (col > 1)
            {
                cssOut += " {\n  display: flex;\n  flex-direction: column;\n  flex-wrap: wrap;\n  flex: 1;\n  " + $"{extraColStyle.Trim()}\n}}\n\n";
            }

            for (int i = 1; i < wrap; i++)
            {
                cssOut += $".{tbWraPre.Text}-{i}" + (i < col - 1 ? "," : "");
            }

            string extraWrapStyle = string.Join(";\n  ", tbWraStyle.Text.Split(';').Select(e => e.Trim()));
            cssOut += " {\n  display: flex;\n  " + $"{extraWrapStyle.Trim()}\n}}\n\n";

            rtbOutputCss.Text = cssOut;
        }
    }
}
