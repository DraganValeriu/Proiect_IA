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
            buttonCreateArc = new Button();
            richTextBox = new RichTextBox();
            buttonRemoveArc = new Button();
            buttonRemoveNode = new Button();
            menuStrip2 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonCreateNode
            // 
            buttonCreateNode.Location = new Point(35, 83);
            buttonCreateNode.Name = "buttonCreateNode";
            buttonCreateNode.Size = new Size(141, 62);
            buttonCreateNode.TabIndex = 0;
            buttonCreateNode.Text = "Create Node";
            buttonCreateNode.UseVisualStyleBackColor = true;
            buttonCreateNode.Click += buttonCreateNode_Click;
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Location = new Point(35, 223);
            panel1.Name = "panel1";
            panel1.Size = new Size(1390, 711);
            panel1.TabIndex = 1;
            // 
            // buttonCreateArc
            // 
            buttonCreateArc.Location = new Point(182, 83);
            buttonCreateArc.Name = "buttonCreateArc";
            buttonCreateArc.Size = new Size(141, 62);
            buttonCreateArc.TabIndex = 2;
            buttonCreateArc.Text = "Create Arc";
            buttonCreateArc.UseVisualStyleBackColor = true;
            buttonCreateArc.Click += buttonCreateArc_Click;
            // 
            // richTextBox
            // 
            richTextBox.BackColor = SystemColors.Window;
            richTextBox.Font = new Font("Segoe UI", 15F);
            richTextBox.Location = new Point(824, 73);
            richTextBox.Name = "richTextBox";
            richTextBox.ReadOnly = true;
            richTextBox.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox.Size = new Size(601, 144);
            richTextBox.TabIndex = 3;
            richTextBox.Text = "";
            // 
            // buttonRemoveArc
            // 
            buttonRemoveArc.Location = new Point(182, 151);
            buttonRemoveArc.Name = "buttonRemoveArc";
            buttonRemoveArc.Size = new Size(141, 62);
            buttonRemoveArc.TabIndex = 4;
            buttonRemoveArc.Text = "Remove Arc";
            buttonRemoveArc.UseVisualStyleBackColor = true;
            buttonRemoveArc.Click += buttonRemoveArc_Click;
            // 
            // buttonRemoveNode
            // 
            buttonRemoveNode.Location = new Point(35, 151);
            buttonRemoveNode.Name = "buttonRemoveNode";
            buttonRemoveNode.Size = new Size(141, 62);
            buttonRemoveNode.TabIndex = 5;
            buttonRemoveNode.Text = "Remove Node";
            buttonRemoveNode.UseVisualStyleBackColor = true;
            buttonRemoveNode.Click += buttonRemoveNode_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.ImageScalingSize = new Size(24, 24);
            menuStrip2.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1452, 33);
            menuStrip2.TabIndex = 7;
            menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(153, 34);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(153, 34);
            saveToolStripMenuItem.Text = "Save";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1452, 958);
            Controls.Add(buttonRemoveNode);
            Controls.Add(buttonRemoveArc);
            Controls.Add(richTextBox);
            Controls.Add(buttonCreateArc);
            Controls.Add(panel1);
            Controls.Add(buttonCreateNode);
            Controls.Add(menuStrip2);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
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
    }
}
