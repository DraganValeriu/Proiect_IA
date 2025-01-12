namespace Proiect_IA
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonCreateNode = new Button();
            panel1 = new Panel();
            comboBoxProb = new ComboBox();
            comboBoxQ = new ComboBox();
            buttonCreateArc = new Button();
            richTextBox = new RichTextBox();
            buttonRemoveArc = new Button();
            buttonRemoveNode = new Button();
            menuStrip2 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            buttonMakeObs = new Button();
            buttonQuery = new Button();
            panel1.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonCreateNode
            // 
            buttonCreateNode.Location = new Point(24, 31);
            buttonCreateNode.Margin = new Padding(2);
            buttonCreateNode.Name = "buttonCreateNode";
            buttonCreateNode.Size = new Size(99, 37);
            buttonCreateNode.TabIndex = 0;
            buttonCreateNode.Text = "Create Node";
            buttonCreateNode.UseVisualStyleBackColor = true;
            buttonCreateNode.Click += buttonCreateNode_Click;
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(comboBoxProb);
            panel1.Controls.Add(comboBoxQ);
            panel1.Location = new Point(20, 79);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(917, 354);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // comboBoxProb
            // 
            comboBoxProb.FormattingEnabled = true;
            comboBoxProb.Location = new Point(519, 0);
            comboBoxProb.Name = "comboBoxProb";
            comboBoxProb.Size = new Size(99, 23);
            comboBoxProb.TabIndex = 10;
            comboBoxProb.Visible = false;
            comboBoxProb.SelectedIndexChanged += comboBoxProb_SelectedIndexChanged;
            // 
            // comboBoxQ
            // 
            comboBoxQ.FormattingEnabled = true;
            comboBoxQ.Location = new Point(416, 0);
            comboBoxQ.Name = "comboBoxQ";
            comboBoxQ.Size = new Size(99, 23);
            comboBoxQ.TabIndex = 9;
            comboBoxQ.Visible = false;
            comboBoxQ.SelectedIndexChanged += comboBoxQ_SelectedIndexChanged;
            // 
            // buttonCreateArc
            // 
            buttonCreateArc.Location = new Point(127, 31);
            buttonCreateArc.Margin = new Padding(2);
            buttonCreateArc.Name = "buttonCreateArc";
            buttonCreateArc.Size = new Size(99, 37);
            buttonCreateArc.TabIndex = 2;
            buttonCreateArc.Text = "Create Arc";
            buttonCreateArc.UseVisualStyleBackColor = true;
            buttonCreateArc.Click += buttonCreateArc_Click;
            // 
            // richTextBox
            // 
            richTextBox.BackColor = SystemColors.Menu;
            richTextBox.BorderStyle = BorderStyle.None;
            richTextBox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            richTextBox.ForeColor = SystemColors.MenuHighlight;
            richTextBox.Location = new Point(709, 26);
            richTextBox.Margin = new Padding(2);
            richTextBox.Name = "richTextBox";
            richTextBox.ReadOnly = true;
            richTextBox.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox.Size = new Size(250, 48);
            richTextBox.TabIndex = 3;
            richTextBox.Text = "";
            // 
            // buttonRemoveArc
            // 
            buttonRemoveArc.Location = new Point(230, 32);
            buttonRemoveArc.Margin = new Padding(2);
            buttonRemoveArc.Name = "buttonRemoveArc";
            buttonRemoveArc.Size = new Size(99, 37);
            buttonRemoveArc.TabIndex = 4;
            buttonRemoveArc.Text = "Remove Arc";
            buttonRemoveArc.UseVisualStyleBackColor = true;
            buttonRemoveArc.Click += buttonRemoveArc_Click;
            // 
            // buttonRemoveNode
            // 
            buttonRemoveNode.Location = new Point(333, 32);
            buttonRemoveNode.Margin = new Padding(2);
            buttonRemoveNode.Name = "buttonRemoveNode";
            buttonRemoveNode.Size = new Size(99, 37);
            buttonRemoveNode.TabIndex = 5;
            buttonRemoveNode.Text = "Remove Node";
            buttonRemoveNode.UseVisualStyleBackColor = true;
            buttonRemoveNode.Click += buttonRemoveNode_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.BackColor = SystemColors.ButtonHighlight;
            menuStrip2.ImageScalingSize = new Size(24, 24);
            menuStrip2.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Padding = new Padding(4, 1, 0, 1);
            menuStrip2.Size = new Size(959, 24);
            menuStrip2.TabIndex = 7;
            menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 22);
            fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(100, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(100, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonMakeObs
            // 
            buttonMakeObs.Location = new Point(436, 30);
            buttonMakeObs.Margin = new Padding(2);
            buttonMakeObs.Name = "buttonMakeObs";
            buttonMakeObs.Size = new Size(99, 39);
            buttonMakeObs.TabIndex = 8;
            buttonMakeObs.Text = "Make Observations";
            buttonMakeObs.UseVisualStyleBackColor = true;
            buttonMakeObs.Click += buttonMakeObs_Click;
            // 
            // buttonQuery
            // 
            buttonQuery.Location = new Point(539, 33);
            buttonQuery.Margin = new Padding(2);
            buttonQuery.Name = "buttonQuery";
            buttonQuery.Size = new Size(99, 36);
            buttonQuery.TabIndex = 10;
            buttonQuery.Text = "Query";
            buttonQuery.UseVisualStyleBackColor = true;
            buttonQuery.Click += buttonQuery_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 449);
            Controls.Add(buttonQuery);
            Controls.Add(buttonMakeObs);
            Controls.Add(buttonRemoveNode);
            Controls.Add(buttonRemoveArc);
            Controls.Add(richTextBox);
            Controls.Add(buttonCreateArc);
            Controls.Add(panel1);
            Controls.Add(buttonCreateNode);
            Controls.Add(menuStrip2);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "Form1";
            panel1.ResumeLayout(false);
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCreateNode;
        public Panel panel1;
        private Button buttonCreateArc;
        private RichTextBox richTextBox;
        private Button buttonRemoveArc;
        private Button buttonRemoveNode;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private Button buttonMakeObs;
        private ComboBox comboBoxQ;
        private ComboBox comboBoxProb;
        private Button buttonQuery;
    }
}
