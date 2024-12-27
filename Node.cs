using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA
{
    public class Node : Control
    {
        public Point point { get; set; }
        public string Name { get; set; } = "Node";
        public double probTrue { get; private set; } = 0.5;
        public double probFalse { get; private set; } = 0.5;

        public MainForm _parentForm = null;
        public void setProbability(double probTrue, double probFalse)
        {
            this.probTrue = probTrue;
            this.probFalse = probFalse;
        }

        private ContextMenuStrip contextMenuEdit;
        private ContextMenuStrip contextMenuInfo;

        public static int NodeSize { get; set; } = 80;

        public Node(string name,double pTrue, double pFalse, Point location, MainForm form)
        {
            Name = name;
            probFalse = pFalse;
            probTrue = pTrue;
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
            contextMenuInfo.Items.Add("True:  " + probTrue);
            contextMenuInfo.Items.Add("False: " + probFalse);
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
            contextMenuInfo.Items.Add("True:  " + probTrue);
            contextMenuInfo.Items.Add("False: " + probFalse);
        }

        private void ChangeProbability(object sender,EventArgs e)
        {
            EditNodeForm probabilityForm = new EditNodeForm();
            probabilityForm.NodeName = this.Name;
            probabilityForm.ProbabilityTrue = probTrue;
            probabilityForm.ProbabilityFalse = probFalse;

            if (probabilityForm.ShowDialog() == DialogResult.OK)
            {
                 this.Name = probabilityForm.NodeName;
                 probTrue = probabilityForm.ProbabilityTrue;
                 probFalse = probabilityForm.ProbabilityFalse;
                 UpdateContext();
            }
        }
    }
}
