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
        public double ProbabilityTrue { get; set; }
        public double ProbabilityFalse { get; set; }
        public string NodeName { get; set; }
        public EditNodeForm()
        {
            InitializeComponent();

        }

        private void buttonSaveEdit_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxTrue.Text, out double probTrue) && double.TryParse(textBoxFalse.Text, out double probFalse) && textBoxName.Text.Length > 0)
            {

                if (probTrue + probFalse == 1)
                {
                    ProbabilityTrue = probTrue;
                    ProbabilityFalse = probFalse;
                    NodeName = textBoxName.Text;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Suma probabilitatilor trebuie sa fie 1", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Datele introduse nu sunt valide", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EditNodeForm_Load(object sender, EventArgs e)
        {
            textBoxName.Text = NodeName;
            textBoxFalse.Text = ProbabilityFalse.ToString();
            textBoxTrue.Text = ProbabilityTrue.ToString();
        }
    }

}
