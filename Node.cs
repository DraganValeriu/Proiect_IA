using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Proiect_IA
{
    public class Node : Control
    {
        public Point point { get; set; }
        public string Name { get; set; } = "Node";

        //public double probTrue { get; private set; } = 0.5;
        //public double probFalse { get; private set; } = 0.5;

        //se vor stoca parintii nodului
        public List<Node> Parents;

        public List<double> Prob;
        //se stocheaza prob ca

        // 0. daca nu are parinti (directi)
        ///   T               F
        //  prob[0]          prob[1]
        // 

        //1. daca nodul are doar un parinte
        ///                 T               F
        //node n-1 = T    prob[0]          prob[1]
        //node n-1 = F    prob[2]          prob[3]
        //size 2(linii) * 2

        //2. daca nodul are doi parinti 
        ///                             T               F
        //node n-1 = T  node n-2 = T  prob[0]          prob[1]
        //node n-1 = T  node n-2 = F  prob[2]          prob[3]
        //node n-2 = F  node n-2 = T  prob[4]          prob[5]
        //node n-3 = T  node n-2 = F  prob[6]          prob[7]
        //size 3(linii) * 2

        // k parinti directi
        //size k(linii) * 2

        public MainForm _parentForm = null;
        public void setProbability(double probTrue, double probFalse)
        {
            this.Prob[0] = probTrue;
            this.Prob[1] = probFalse;
        }

        public void setProbabilityFromList(List<double> nProb)
        {
            Prob = new(new List<double>(nProb));
        }

        public void AddParent(Node parent)
        {
            Parents.Add(parent);
            Prob = new List<double>(Enumerable.Repeat(0.5, Prob.Count() * 2));
        }

        public void RemoveParent(Node parent)
        {
            Parents.Remove(parent);
            Prob = new List<double>(Enumerable.Repeat(0.5, Prob.Count() / 2));
        }

        private ContextMenuStrip contextMenuEdit;
        private ContextMenuStrip contextMenuInfo;

        public static int NodeSize { get; set; } = 80;

        public Node(string name,double pTrue, double pFalse, Point location, MainForm form)
        {
            Name = name;

            //se initializeaza la inceput doar cu T F,
            //daca se va creea un arc unde nodul este end, se vor adauga mai multe
            Prob = new List<double>(Enumerable.Repeat(0.5, 2));
            Parents = new List<Node>();

            Prob[0] = pFalse;
            Prob[1] = pTrue;
            _parentForm = form;
            this.Width = NodeSize;
            this.Height = NodeSize;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            //this.Location = new Point(location.X - NodeSize / 2, location.Y - NodeSize / 2);
            this.Location = new Point(location.X, location.Y );

            this.Paint += Node_Paint;
            this.MouseClick += Node_MouseClick;

            contextMenuEdit = new ContextMenuStrip();
            contextMenuEdit.Items.Add("Edit", null, ChangeProbability);
            contextMenuEdit.Items.Add("Position: " + location.X + ", " + location.Y);
            

            contextMenuInfo = new ContextMenuStrip();
            contextMenuInfo.Items.Add("True:  " + Prob[0]);
            contextMenuInfo.Items.Add("False: " + Prob[1]);
        }

        private void Node_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            RectangleF r = new RectangleF(0, 0, NodeSize - 1, NodeSize - 1);
            g.FillEllipse(Brushes.LightBlue, r);
            g.DrawEllipse(Pens.Black, r);

            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            float centerX = NodeSize / 2;
            float centerY = NodeSize / 2;
            using (Font font = new Font(Font.FontFamily, 10))
            {
                g.DrawString(Name, font, Brushes.Black, centerX, centerY, format);
            }
        }

        private void ReDrawNode()
        {
            this.Invalidate();
        }

        private void Node_MouseClick(object sender, MouseEventArgs e)
        {
            if (_parentForm.isCreatingArc)
            {
                Node clickedNode = this;

                if (_parentForm.NewArc.StartNode == null)
                {
                    _parentForm.NewArc.StartNode = clickedNode;
                    _parentForm.SetMessage("Select second node");
                }
                else if (_parentForm.NewArc.EndNode == null)
                {
                    _parentForm.NewArc.EndNode = clickedNode;
                    _parentForm.DrawNewArc();
                    _parentForm.ResetArcCreation();
                    _parentForm.SetMessage("");
                }

                return;
            }

            if(_parentForm.isRemovingNode)
            {
                Node clickedNode = this;

                _parentForm.RemoveNode(clickedNode);
                return;

            }


            if (e.Button == MouseButtons.Right)
            {
                contextMenuEdit.Show(this, e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {
                contextMenuInfo.Show(this, e.Location);
            }

        }

        private void UpdateContext()
        {
            ReDrawNode();
            contextMenuInfo.Items.Clear();
            contextMenuInfo.Items.Add("True:  " + Prob[0]);
            contextMenuInfo.Items.Add("False: " + Prob[1]);
        }

        private void ChangeProbability(object sender,EventArgs e)
        {

            EditNodeForm probabilityForm = new EditNodeForm();
            probabilityForm.CurrentNode = this;
            //probabilityForm.NodeName = this.Name;
            probabilityForm.CampuriProb = new List<TextBox>(Prob.Count);
            //probabilityForm.ProbabilityTrue = prob[0];
            //probabilityForm.ProbabilityFalse = prob[1];
            for (int i = 0; i < Prob.Count; i++)
            {
                TextBox textBox = new TextBox
                {
                    Dock = DockStyle.Fill,
                    Text = Prob[i].ToString()
                };
                probabilityForm.CampuriProb.Add(textBox);
            }

            if (probabilityForm.ShowDialog() == DialogResult.OK)
            {
                 //Prob[0] = probabilityForm.ProbabilityTrue; 
                 //Prob[1] = probabilityForm.ProbabilityFalse;
                 UpdateContext();
            }
        }
    }
}
