using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA
{
    public partial class EditNodeForm : Form
    {
        public double ProbabilityTrue { get; set; }
        public double ProbabilityFalse { get; set; }

        public Node CurrentNode;
        public List<Node> Parents;
        public List<TextBox> CampuriProb;

        public EditNodeForm()
        {
            InitializeComponent();
        }

        private void buttonSaveEdit_Click(object sender, EventArgs e)
        {
        
            //se verifica pe linie 
            // MessageBox.Show("" + CampuriProb.Count);
            bool isValid = true;
            for (int i = 0; i <= CampuriProb.Count - 2; i = i + 2)
            {
                if (double.TryParse(CampuriProb[i].Text, out double probTrue) && double.TryParse(CampuriProb[i + 1].Text, out double probFalse) && textBoxName.Text.Length > 0)
                {
                    if (probTrue + probFalse == 1)
                    {
                        CurrentNode.Prob[i] = probTrue;
                        CurrentNode.Prob[i + 1] = probFalse;
                        isValid = true;
                    }
                    else
                    {
                        MessageBox.Show("Linia " + (i + 1) + ": Suma probabilitatilor trebuie sa fie 1", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                    }
                }
            }
            if(isValid)
            {
                CurrentNode.Name = textBoxName.Text;
                DialogResult = DialogResult.OK;
                MessageBox.Show("Datele au fost salvate!", "Salvare date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void EditNodeForm_Load(object sender, EventArgs e)
        {
            labelProbF.Text = "P(" + CurrentNode.Name + ")=F";
            labelProbT.Text = "P(" + CurrentNode.Name + ")=T";
            textBoxName.Text = CurrentNode.Name;
            int newRowCount = CampuriProb.Count()/2;
            int newColumnCount = 2;

            tableLayoutPanelAfisare2.AutoSize = false;

            tableLayoutPanelAfisare2.SuspendLayout();
            tableLayoutPanelAfisare2.Controls.Clear();
            tableLayoutPanelAfisare2.RowStyles.Clear();
            tableLayoutPanelAfisare2.ColumnStyles.Clear();

            tableLayoutPanelAfisare2.RowCount = newRowCount;
            tableLayoutPanelAfisare2.ColumnCount = newColumnCount;

            for (int i = 0; i < newRowCount; i++)
            {
                tableLayoutPanelAfisare2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / newRowCount));
            }

            for (int i = 0; i < newColumnCount; i++)
            {
                tableLayoutPanelAfisare2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / newColumnCount));
            }

            for (int row = 0; row < newRowCount; row++)
            {
                for (int col = 0; col < newColumnCount; col++)
                {
                    int index = row * newColumnCount + col;

                    if (index < CampuriProb.Count)
                    {
                        tableLayoutPanelAfisare2.Controls.Add(CampuriProb[index], col, row); 
                    }
                    else
                    {
                        TextBox textBox = new TextBox { Dock = DockStyle.Fill };
                        tableLayoutPanelAfisare2.Controls.Add(textBox, col, row);
                    }
                }
            }

            tableLayoutPanelAfisare2.Size = new Size(
                tableLayoutPanelAfisare2.ColumnCount * 100, 
                tableLayoutPanelAfisare2.RowCount * 30    
            );

            buttonSaveEdit.Location = new Point(tableLayoutPanelAfisare2.Bounds.Right + 20, buttonSaveEdit.Location.Y);
            int formPadding = 50; 
            this.Size = new Size(
                buttonSaveEdit.Bounds.Right + formPadding,
                Math.Max(buttonSaveEdit.Bounds.Bottom, tableLayoutPanelAfisare2.Bounds.Bottom) + formPadding // Înălțimea ferestrei
            );

            tableLayoutPanelAfisare2.ResumeLayout();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}
