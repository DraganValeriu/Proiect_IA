namespace Proiect_IA
{
    partial class EditNodeForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            textBoxName = new TextBox();
            buttonSaveEdit = new Button();
            tableLayoutPanelAfisare = new TableLayoutPanel();
            NodeX = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tableLayoutPanelAfisare2 = new TableLayoutPanel();
            labelProbT = new Label();
            labelProbF = new Label();
            tableLayoutPanelAfisare.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 9);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nume:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(68, 6);
            textBoxName.Margin = new Padding(2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(101, 23);
            textBoxName.TabIndex = 1;
            // 
            // buttonSaveEdit
            // 
            buttonSaveEdit.Location = new Point(200, 216);
            buttonSaveEdit.Margin = new Padding(2);
            buttonSaveEdit.Name = "buttonSaveEdit";
            buttonSaveEdit.Size = new Size(78, 20);
            buttonSaveEdit.TabIndex = 1;
            buttonSaveEdit.Text = "Salveaza";
            buttonSaveEdit.UseVisualStyleBackColor = true;
            buttonSaveEdit.Click += buttonSaveEdit_Click;
            // 
            // tableLayoutPanelAfisare
            // 
            tableLayoutPanelAfisare.ColumnCount = 1;
            tableLayoutPanelAfisare.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAfisare.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAfisare.Controls.Add(NodeX, 0, 0);
            tableLayoutPanelAfisare.Location = new Point(95, 45);
            tableLayoutPanelAfisare.Name = "tableLayoutPanelAfisare";
            tableLayoutPanelAfisare.RowCount = 1;
            tableLayoutPanelAfisare.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelAfisare.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelAfisare.Size = new Size(83, 23);
            tableLayoutPanelAfisare.TabIndex = 6;
            // 
            // NodeX
            // 
            NodeX.AutoSize = true;
            NodeX.Location = new Point(2, 0);
            NodeX.Margin = new Padding(2, 0, 2, 0);
            NodeX.Name = "NodeX";
            NodeX.Size = new Size(46, 15);
            NodeX.TabIndex = 1;
            NodeX.Text = "Node X";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // tableLayoutPanelAfisare2
            // 
            tableLayoutPanelAfisare2.ColumnCount = 2;
            tableLayoutPanelAfisare2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAfisare2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAfisare2.Location = new Point(210, 72);
            tableLayoutPanelAfisare2.Name = "tableLayoutPanelAfisare2";
            tableLayoutPanelAfisare2.RowCount = 1;
            tableLayoutPanelAfisare2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelAfisare2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelAfisare2.Size = new Size(166, 23);
            tableLayoutPanelAfisare2.TabIndex = 7;
            // 
            // labelProbT
            // 
            labelProbT.AutoSize = true;
            labelProbT.Location = new Point(210, 45);
            labelProbT.Margin = new Padding(2, 0, 2, 0);
            labelProbT.Name = "labelProbT";
            labelProbT.Size = new Size(83, 15);
            labelProbT.TabIndex = 8;
            labelProbT.Text = "P(current) = T:";
            // 
            // labelProbF
            // 
            labelProbF.AutoSize = true;
            labelProbF.Location = new Point(293, 45);
            labelProbF.Margin = new Padding(2, 0, 2, 0);
            labelProbF.Name = "labelProbF";
            labelProbF.Size = new Size(83, 15);
            labelProbF.TabIndex = 9;
            labelProbF.Text = "P(current) = F:";
            // 
            // EditNodeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 247);
            Controls.Add(labelProbF);
            Controls.Add(labelProbT);
            Controls.Add(tableLayoutPanelAfisare2);
            Controls.Add(tableLayoutPanelAfisare);
            Controls.Add(buttonSaveEdit);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "EditNodeForm";
            Text = "EditNode";
            Load += EditNodeForm_Load;
            tableLayoutPanelAfisare.ResumeLayout(false);
            tableLayoutPanelAfisare.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox textBoxName;
        private Button buttonSaveEdit;
        private TableLayoutPanel tableLayoutPanelAfisare;
        private Label NodeX;
        private ContextMenuStrip contextMenuStrip1;
        private TableLayoutPanel tableLayoutPanelAfisare2;
        private Label labelProbT;
        private Label labelProbF;
    }
}