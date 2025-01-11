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
            buttonSaveEdit = new Button();
            SuspendLayout();
            // 
            // buttonSaveEdit
            // 
            buttonSaveEdit.Location = new Point(283, 428);
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
            ClientSize = new Size(722, 517);
            Controls.Add(buttonSaveEdit);
            Name = "EditNodeForm";
            Text = "EditNode";
            Load += EditNodeForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button buttonSaveEdit;
    }
}