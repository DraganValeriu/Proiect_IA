using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace Proiect_IA
{
    public class Arc : Control
    {
        public Node? StartNode { get; set; }
        public Node? EndNode { get; set; }


        public Arc(Node? startNode, Node? endNode)
        {
            StartNode = startNode;
            EndNode = endNode;
            if(endNode != null)
            {
                EndNode.AddParent(startNode);
            }
            this.Width = 1;
            this.Height = 1;
        }

        public Arc() : this(null, null) { }

        public void Arc_Paint(object sender, PaintEventArgs e)
        {

            if (StartNode != null && EndNode != null)
            {

                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Pen pen = new Pen(Color.Black, 2);

                Point start = new Point(StartNode.Location.X + StartNode.Width / 2, StartNode.Location.Y + StartNode.Height / 2);
                Point end = new Point(EndNode.Location.X + EndNode.Width / 2, EndNode.Location.Y + EndNode.Height / 2);
                g.DrawLine(pen, start, end);
            }
        }

    }

}
