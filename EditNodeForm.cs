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
            CampuriProb = new List<TextBox>();
            
            //functie de afisare veche - pentru test
            //Gabriel
            /*
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
            */
            
            //functia de afisare preluata din commit-ul lui Valeriu
            Afisare();
        }

        public void Afisare()
        {
            textBoxName.Text = CurrentNode.Name;
            int nrGiven = CurrentNode.Parents.Count;
            //int nrGiven = CurrentNode.Prob.Count / 2 - 1;
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {

                ColumnCount = 3 + nrGiven - 1,
                RowCount = (1 << nrGiven) + 1,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Location = new Point(50, 50)

            };
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170));
            }

            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            }

            for (int i = 0; i < nrGiven; i++)
            {
                tableLayoutPanel.Controls.Add(new Label()
                {
                    Text = $"{this.CurrentNode.Parents[i].Name}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, i, 0);
            }

            tableLayoutPanel.Controls.Add(new Label()
            {
                Text = $"P({this.CurrentNode.Name}) = T",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            }, nrGiven, 0);

            tableLayoutPanel.Controls.Add(new Label()
            {
                Text = $"P({this.CurrentNode.Name}) = F",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            }, nrGiven + 1, 0);

            this.Controls.Add(tableLayoutPanel);

            var permutations = GeneratePermutationsInReverseOrder(nrGiven);
            int r = 1;
            if (nrGiven < 1)
            {
                TextBox a;
                tableLayoutPanel.Controls.Add(a = new TextBox()
                {
                    Text = $"{this.CurrentNode.Prob[(r - 1) * 2]}",
                    Dock = DockStyle.Fill
                }, 0, r);
                CampuriProb.Add(a);
                tableLayoutPanel.Controls.Add(a = new TextBox()
                {
                    Text = $"{this.CurrentNode.Prob[(r - 1) * 2 + 1]}",
                    Dock = DockStyle.Fill
                }, 1, r);
                CampuriProb.Add(a);

                return;
            }


            foreach (var permutation in permutations)
            {

                for (int i = 0; i < permutation.Length; i++)
                {
                    tableLayoutPanel.Controls.Add(new Label()
                    {
                        Text = permutation[i],
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill
                    }, i, r);

                }
                for (int i = 0; i < 2; i++)
                {
                    TextBox a;
                    tableLayoutPanel.Controls.Add(a = new TextBox()
                    {
                        Text = $"{this.CurrentNode.Prob[(r - 1) * 2 + i]}",
                        Dock = DockStyle.Fill
                    }, nrGiven + i, r);
                    CampuriProb.Add(a);
                }
                r++;
            }
            buttonSaveEdit.Location = new Point(tableLayoutPanel.Bounds.Right + 20, buttonSaveEdit.Location.Y);
            int formPadding = 50;
            this.Size = new Size(
                buttonSaveEdit.Bounds.Right + formPadding,
                Math.Max(buttonSaveEdit.Bounds.Bottom, tableLayoutPanel.Bounds.Bottom) + formPadding
            );
            tableLayoutPanel.ResumeLayout();
        }
        private List<string[]> GeneratePermutationsInReverseOrder(int k)
        {
            var result = new List<string[]>();
            int totalPermutations = 1 << k;

            for (int i = 0; i < totalPermutations; i++)
            {
                var permutation = new bool[k];
                for (int j = 0; j < k; j++)
                {
                    permutation[j] = (i & (1 << (k - j - 1))) != 0;
                }
                var str = string.Join(" ", permutation.Select(p => p ? "F" : "T")).Split(" ");
                result.Add(str);
            }
            
            return result;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}
