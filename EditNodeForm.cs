using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA
{
    public partial class EditNodeForm : Form
    {
        public double[] ProbTable;
        public int nrGiven;
        public Node node;
        public string NodeName { get; set; }

        public EditNodeForm(string name,double[] probTable, int nr, Node n)
        {
            NodeName = name;
            nrGiven = nr;
            ProbTable = probTable;
            node = n;
            
            InitializeComponent();
            Show();
        }

        private void buttonSaveEdit_Click(object sender, EventArgs e)
        {
            //if (double.TryParse(textBoxTrue.Text, out double probTrue) && double.TryParse(textBoxFalse.Text, out double probFalse) && textBoxName.Text.Length > 0)
            //{

            //    if (probTrue + probFalse == 1)
            //    {
            //        ProbabilityTrue = probTrue;
            //        ProbabilityFalse = probFalse;
            //        NodeName = textBoxName.Text;
            //        DialogResult = DialogResult.OK;
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Suma probabilitatilor trebuie sa fie 1", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Datele introduse nu sunt valide", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void EditNodeForm_Load(object sender, EventArgs e)
        {
            
        }
        public void Show()
        {
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
                    Text = $"{this.node.GivenList[i].Name}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, i, 0);
            }

            tableLayoutPanel.Controls.Add(new Label()
            {
                Text = $"P({this.NodeName}) = T",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            }, nrGiven, 0);

            tableLayoutPanel.Controls.Add(new Label()
            {
                Text = $"P({this.NodeName}) = F",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            }, nrGiven + 1, 0);

            this.Controls.Add(tableLayoutPanel);

            var permutations = GeneratePermutationsInReverseOrder(nrGiven);
            int r = 1;
            if (nrGiven < 1)
            {
                tableLayoutPanel.Controls.Add(new TextBox()
                {
                    Text = $"{this.ProbTable[(r - 1) * 2 ]}",
                    Dock = DockStyle.Fill
                }, 0, r);
                tableLayoutPanel.Controls.Add(new TextBox()
                {
                    Text = $"{this.ProbTable[(r - 1) * 2 + 1]}",
                    Dock = DockStyle.Fill
                }, 1, r);
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
                    tableLayoutPanel.Controls.Add(new TextBox()
                    {
                        Text = $"{this.ProbTable[(r - 1) * 2 + i]}",
                        Dock = DockStyle.Fill
                    }, nrGiven + i, r);
                }

                r++;
            }
        }

        //private List<string[]> GeneratePermutationsInReverseOrder(int k)
        //{
            
        //    var result = new List<string[]>();
        //    int totalPermutations = 1 << k;

        //    for (int i = totalPermutations - 1; i >= 0; i--)
        //    {
        //        var permutation = new bool[k];
        //        for (int j = 0; j < k; j++)
        //        {
        //            permutation[j] = (i & (1 << j)) != 0;
        //        }
        //        var str = string.Join(" ", permutation.Select(p => p ? "T" : "F")).Split(" ");
        //        result.Add(str);
                 
        //    }
        //    return result;
        //}
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

                // Afișează combinația curentă
                foreach (string s in str)
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            }
            return result;
        }

    }

}
