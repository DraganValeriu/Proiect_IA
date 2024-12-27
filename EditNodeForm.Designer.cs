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
            tableLayoutPanel1 = new TableLayoutPanel();
            textBoxFalse = new TextBox();
            textBoxTrue = new TextBox();
            textBoxName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            buttonSaveEdit = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(textBoxFalse, 1, 2);
            tableLayoutPanel1.Controls.Add(textBoxTrue, 1, 1);
            tableLayoutPanel1.Controls.Add(textBoxName, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.ImeMode = ImeMode.NoControl;
            tableLayoutPanel1.Location = new Point(185, 96);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(305, 153);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxFalse
            // 
            textBoxFalse.Location = new Point(155, 105);
            textBoxFalse.Name = "textBoxFalse";
            textBoxFalse.Size = new Size(147, 31);
            textBoxFalse.TabIndex = 5;
            // 
            // textBoxTrue
            // 
            textBoxTrue.Location = new Point(155, 54);
            textBoxTrue.Name = "textBoxTrue";
            textBoxTrue.Size = new Size(147, 31);
            textBoxTrue.TabIndex = 4;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(155, 3);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(147, 31);
            textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 0;
            label1.Text = "Nume:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 51);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 2;
            label2.Text = "True:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 102);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 3;
            label3.Text = "False:";
            // 
            // buttonSaveEdit
            // 
            buttonSaveEdit.Location = new Point(285, 288);
            buttonSaveEdit.Name = "buttonSaveEdit";
            buttonSaveEdit.Size = new Size(112, 34);
            buttonSaveEdit.TabIndex = 1;
            buttonSaveEdit.Text = "Salveaza";
            buttonSaveEdit.UseVisualStyleBackColor = true;
            buttonSaveEdit.Click += buttonSaveEdit_Click;
            // 
            // EditNodeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(696, 360);
            Controls.Add(buttonSaveEdit);
            Controls.Add(tableLayoutPanel1);
            Name = "EditNodeForm";
            Text = "EditNode";
            Load += EditNodeForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TextBox textBoxName;
        public TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label3;
        private TextBox textBoxFalse;
        private TextBox textBoxTrue;
        private Button buttonSaveEdit;
    }
}