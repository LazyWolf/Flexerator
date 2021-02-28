
namespace Flexerator
{
    partial class Flexerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            this.rtbOutputHtml = new System.Windows.Forms.RichTextBox();
            this.rtbOutputCss = new System.Windows.Forms.RichTextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chLabels = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbInput
            // 
            this.rtbInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.rtbInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbInput.ForeColor = System.Drawing.Color.White;
            this.rtbInput.Location = new System.Drawing.Point(22, 23);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(626, 178);
            this.rtbInput.TabIndex = 0;
            this.rtbInput.Text = "[][]\n[()()()]([][])\n([][][][][])";
            // 
            // rtbOutputHtml
            // 
            this.rtbOutputHtml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.rtbOutputHtml.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOutputHtml.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutputHtml.ForeColor = System.Drawing.Color.White;
            this.rtbOutputHtml.Location = new System.Drawing.Point(10, 9);
            this.rtbOutputHtml.Margin = new System.Windows.Forms.Padding(5);
            this.rtbOutputHtml.Name = "rtbOutputHtml";
            this.rtbOutputHtml.Size = new System.Drawing.Size(300, 200);
            this.rtbOutputHtml.TabIndex = 3;
            this.rtbOutputHtml.Text = "";
            // 
            // rtbOutputCss
            // 
            this.rtbOutputCss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.rtbOutputCss.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOutputCss.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutputCss.ForeColor = System.Drawing.Color.White;
            this.rtbOutputCss.Location = new System.Drawing.Point(10, 10);
            this.rtbOutputCss.Margin = new System.Windows.Forms.Padding(5);
            this.rtbOutputCss.Name = "rtbOutputCss";
            this.rtbOutputCss.Size = new System.Drawing.Size(300, 200);
            this.rtbOutputCss.TabIndex = 4;
            this.rtbOutputCss.Text = "";
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnConvert.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConvert.FlatAppearance.BorderSize = 2;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.ForeColor = System.Drawing.Color.White;
            this.btnConvert.Location = new System.Drawing.Point(282, 254);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(104, 36);
            this.btnConvert.TabIndex = 5;
            this.btnConvert.Text = "▼";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 199);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.panel2.Controls.Add(this.rtbOutputHtml);
            this.panel2.Location = new System.Drawing.Point(12, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 220);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.panel3.Controls.Add(this.rtbOutputCss);
            this.panel3.Location = new System.Drawing.Point(338, 315);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 220);
            this.panel3.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "HTML";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(627, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "CSS";
            // 
            // chLabels
            // 
            this.chLabels.Appearance = System.Windows.Forms.Appearance.Button;
            this.chLabels.AutoSize = true;
            this.chLabels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.chLabels.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chLabels.Checked = true;
            this.chLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chLabels.FlatAppearance.CheckedBackColor = System.Drawing.Color.Aqua;
            this.chLabels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chLabels.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.chLabels.Location = new System.Drawing.Point(286, 228);
            this.chLabels.Name = "chLabels";
            this.chLabels.Size = new System.Drawing.Size(96, 23);
            this.chLabels.TabIndex = 11;
            this.chLabels.Text = "Container Labels";
            this.chLabels.UseVisualStyleBackColor = false;
            this.chLabels.CheckedChanged += new System.EventHandler(this.chLabels_CheckedChanged);
            // 
            // Flexerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(669, 546);
            this.Controls.Add(this.chLabels);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.rtbInput);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Flexerator";
            this.Text = "Flexerator";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.RichTextBox rtbOutputHtml;
        private System.Windows.Forms.RichTextBox rtbOutputCss;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chLabels;
    }
}

