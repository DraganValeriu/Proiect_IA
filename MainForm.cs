using System.Globalization;
using System.Linq.Expressions;
using System.Windows.Forms.Design;
using System.Xml;
using System.Xml.Linq;

namespace Proiect_IA
{
    public partial class MainForm : Form
    {
        private bool isCreatingNode = false;
        public bool isCreatingArc { get; private set; } = false;
        public bool isRemovingNode { get; private set; } = false;
        public bool IsQueryingNode { get; private set; } = false;
        public List<int> Obs;  //0 - fara observatie, 1 - TRUE, 2 - FALSE


        List<Node> nodes = new List<Node>();
        List<Arc> arcs = new List<Arc>();

        List<BayesianDefinition> definitions = new List<BayesianDefinition>();
        List<BayesianVariable> variables = new List<BayesianVariable>();

        public Arc NewArc;

        public string filePath = "";
        public MainForm()
        {
            NewArc = new Arc();
            InitializeComponent();
            panel1.MouseDown += Panel1_MouseDown;
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // pentru a folosi '.' in loc de ','
            Obs = new List<int>();
            comboBoxProb.Items.Add("Undefined");
            comboBoxProb.Items.Add("True");
            comboBoxProb.Items.Add("False");

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
        }

        private void buttonCreateNode_Click(object sender, EventArgs e)
        {
            isCreatingNode = true;
            richTextBox.Text = "Click the canvas to create a node";
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isCreatingNode && e.Button == MouseButtons.Left)
            {
                // Create a new node
                Node node = new Node("Node " + nodes.Count, 0.5, 0.5,
                    new Point(e.Location.X - Node.NodeSize / 2, e.Location.Y - Node.NodeSize / 2),
                    this);

                // Add it to the list and panel
                nodes.Add(node);
                Obs.Add(0);
                panel1.Controls.Add(node);

                // Bring the new node to the front
                node.BringToFront();

                // Reset the creation state and message
                isCreatingNode = false;

            }
            richTextBox.Text = "";
            IsQueryingNode = false;
            comboBoxProb.Visible = false;
            comboBoxQ.Visible = false;
        }


        private void buttonCreateArc_Click(object sender, EventArgs e)
        {
            isCreatingArc = true;
            richTextBox.Text = "Chose 2 nodes to create an arc";
        }

        public void DrawNewArc()
        {
            Arc arc = new Arc(NewArc.StartNode, NewArc.EndNode);
            arcs.Add(arc);
            panel1.Paint += arc.Arc_Paint;
            panel1.Controls.Add(arc);
            richTextBox.Text = "";

            UpdatePanel();
        }
        public void ResetArcCreation()
        {
            isCreatingArc = false;
            NewArc.StartNode = null;
            NewArc.EndNode = null;
        }
        public void SetMessage(string message)
        {
            richTextBox.Text = message;
        }

        private void buttonRemoveArc_Click(object sender, EventArgs e)
        {
            if (arcs.Count > 0)
            {
                panel1.Paint -= arcs[arcs.Count - 1].Arc_Paint;
                panel1.Controls.Remove(arcs[arcs.Count - 1]);
                arcs[arcs.Count - 1].EndNode.RemoveParent(arcs[arcs.Count - 1].StartNode);
                arcs.RemoveAt(arcs.Count - 1);
                UpdatePanel();
            }
        }



        public void UpdatePanel()
        {
            panel1.Invalidate();
        }
        //felix
        private void buttonRemoveNode_Click(object sender, EventArgs e)
        {
            isRemovingNode = true;
            richTextBox.Text = "Click the canvas to remove a node";
        }

        public void RemoveNode(Node node)
        {
            nodes.Remove(node);
            arcs.RemoveAll(arc => arc.StartNode == node || arc.EndNode == node);
            panel1.Controls.Remove(node);
            panel1.Invalidate();
        }
        //

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                ReadXMLFile(filePath);
                DrawGraph();
                UpdatePanel();
            }

        }

        private void ReadXMLFile(string fileName)
        {
            string xml = File.ReadAllText(fileName);
            Console.WriteLine(xml);

            var settings = new XmlReaderSettings
            {
                IgnoreWhitespace = true
            };
            using var reader = XmlReader.Create(new StringReader(xml), settings);
            {
                BayesianVariable tempVariable = new BayesianVariable("", null);
                BayesianDefinition tempDefinition = new BayesianDefinition();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "VARIABLE")
                        {
                            tempVariable.Reset();
                        }
                        if (reader.Name == "NAME")
                        {
                            tempVariable.Name = reader.ReadElementContentAsString();
                        }
                        if (reader.Name == "PROPERTY")
                        {
                            tempVariable.Position = parsePosition(reader.ReadElementContentAsString());
                        }
                    }
                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == "VARIABLE")
                        {
                            var v = new BayesianVariable(tempVariable.Name, tempVariable.Position);
                            variables.Add(v);
                            Node node = new Node(v.Name, 0.5, 0.5, v.Position ?? new Point(1, 1), this);
                            nodes.Add(node);
                        }

                    }
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "DEFINITION")
                        {
                            tempDefinition.Reset();
                        }
                        if (reader.Name == "FOR")
                        {
                            string str = reader.ReadElementContentAsString();
                            tempDefinition.For = nodes.Find(n => n.Name == str);
                        }
                        if (reader.Name == "GIVEN")
                        {
                            while (reader.Name == "GIVEN" && reader.NodeType == XmlNodeType.Element)
                            {
                                string str = reader.ReadElementContentAsString();
                                tempDefinition.Given.Add(nodes.Find(n => n.Name == str));
                            }
                        }
                    }

                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == "DEFINITION")
                        {
                            var x = new BayesianDefinition(tempDefinition);
                            definitions.Add(x);
                            foreach (var node in x.Given)
                            {
                                Console.WriteLine($"{node.Name} -> {x.For.Name}");
                                arcs.Add(new Arc(node, x.For));
                            }
                        }
                    }

                }
            }
        }

        private void DrawGraph()
        {
            foreach (var node in nodes)
            {
                panel1.Controls.Add(node);
            }

            foreach (var arc in arcs)
            {
                panel1.Controls.Add(arc);
                panel1.Paint += arc.Arc_Paint;
                UpdatePanel();
            }
        }
        private Point parsePosition(string pos)
        {
            var s = pos.Substring(pos.IndexOf('('));
            s = s.Remove(s.Length - 1);
            s = s.Remove(0, 1);
            s = s.Remove(s.IndexOf(','), 1);

            var sp = s.Split(' ');
            (string x, string y) = (sp[0], sp[1]);

            int xPos = ((int)Convert.ToDouble(x)) % 1000;
            int yPos = ((int)Convert.ToDouble(y)) % 1000;

            return new Point(xPos, yPos);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonMakeObs_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "Select the node from ComboBox \n to create an observation";
            comboBoxQ.Items.Clear();
            foreach (Node node in nodes)
            {
                comboBoxQ.Items.Add(node.Name);
            }
            comboBoxQ.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxQ.Visible = true;
        }

        private void comboBoxQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxProb.SelectedIndex = Obs[comboBoxQ.SelectedIndex];
            comboBoxProb.Visible = true;
        }

        private void comboBoxProb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Obs[comboBoxQ.SelectedIndex] = comboBoxProb.SelectedIndex;
            nodes[comboBoxQ.SelectedIndex].Observatie = comboBoxProb.SelectedIndex == 1 ? "Obs: A" : comboBoxProb.SelectedIndex == 2 ? "Obs: F" : "";
            nodes[comboBoxQ.SelectedIndex].ReDrawNode();
        }


        public double EnumerateAll(List<Node> bn, List<Node> vars, Node X, List<int> obs)
        {
            if (vars.Count == 0)
            {
                return 1.0;
            }

            Node Y = vars.First();
            int nodeIndex = bn.FindIndex(node => node.Name.Equals(Y.Name));
            if (nodeIndex == -1)
                throw new InvalidOperationException($"Node {Y.Name} not found in Bayesian Network.");

            int y = obs[nodeIndex];
            List<Node> new_vars = new List<Node>(vars);
            new_vars.RemoveAt(0);

            if (y != 0)
            {
                int index = CalculateIndex(Y, bn, obs, y);
                if (index < 0 || index >= Y.Prob.Count)
                    throw new IndexOutOfRangeException($"Index {index} is out of bounds for Y.Prob.");

                return Y.Prob[index] * EnumerateAll(bn, new_vars, X, obs);
            }
            else
            {
                List<int> newObs = new List<int>(obs);
                double sum = 0;

                foreach (int i in new int[] { 1, 2 })
                {
                    newObs[nodeIndex] = i;
                    int index = CalculateIndex(Y, bn, newObs, i);
                    if (index < 0 || index >= Y.Prob.Count)
                        throw new IndexOutOfRangeException($"Index {index} is out of bounds for Y.Prob.");

                    sum += Y.Prob[index] * EnumerateAll(bn, new_vars, X, newObs);
                }
                return sum;
            }
        }

        private int CalculateIndex(Node Y, List<Node> bn, List<int> obs, int val)
        {
            int index = 0;
            foreach (Node parent in Y.Parents)
            {
                int parentIndex = bn.FindIndex(node => node.Name.Equals(parent.Name));
                if (obs[parentIndex] == 0)
                {
                    throw new InvalidOperationException($"Node {Y.Name} not found in Bayesian Network.");
                }
                index = (index << 1) | (obs[parentIndex] - 1);
            }
            index = (index << 1) | (val - 1);
            return index;
        }

        static List<Node> TopologicalSort(List<Node> noduri)
        {
            var gradIntrare = new Dictionary<Node, int>();
            var copii = new Dictionary<Node, List<Node>>();

            foreach (var nod in noduri)
            {

                gradIntrare[nod] = nod.Parents.Count;
                foreach (var parinte in nod.Parents)
                {
                    if (!copii.ContainsKey(parinte))
                    {
                        copii[parinte] = new List<Node>();
                    }
                    copii[parinte].Add(nod);
                }
            }

            var coada = new Queue<Node>(gradIntrare.Where(kv => kv.Value == 0).Select(kv => kv.Key));
            var rezultat = new List<Node>();

            while (coada.Count > 0)
            {
                var curent = coada.Dequeue();
                rezultat.Add(curent);

                if (copii.ContainsKey(curent))
                {
                    foreach (var copil in copii[curent])
                    {
                        gradIntrare[copil]--;
                        if (gradIntrare[copil] == 0)
                        {
                            coada.Enqueue(copil);
                        }
                    }
                }
            }

            if (rezultat.Count != noduri.Count)
            {
                return null;
            }

            return rezultat;
        }

        public List<double> EnumerationAsk(Node X)
        {
            List<Node> bn = nodes;
            List<Node> sortedNodes = TopologicalSort(bn);
            List<double> Q = new List<double> { 0, 0 };

            List<int> obsTrue = new List<int>(Obs);
            List<int> obsFalse = new List<int>(Obs);

            int xIndex = bn.FindIndex(node => node.Name.Equals(X.Name));
            if (xIndex == -1)
                throw new InvalidOperationException($"Node {X.Name} not found in Bayesian Network.");

            obsTrue[xIndex] = 1;  // T = 1
            obsFalse[xIndex] = 2; // F = 2

            Q[0] = EnumerateAll(bn, sortedNodes, X, obsTrue);
            Q[1] = EnumerateAll(bn, sortedNodes, X, obsFalse);

            double sum = Q[0] + Q[1];
            Q[0] /= sum;
            Q[1] /= sum;
            return Q;
        }


        private void buttonQuery_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "Click the query a node";
            IsQueryingNode = true;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }

}
