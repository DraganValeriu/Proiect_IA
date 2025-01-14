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
            contextMenuStrip1 = new ContextMenuStrip(components);
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // EditNodeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 247);
            Controls.Add(buttonSaveEdit);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "EditNodeForm";
            Text = "EditNode";
            Load += EditNodeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox textBoxName;
        private Button buttonSaveEdit;
        private ContextMenuStrip contextMenuStrip1;
    }
}