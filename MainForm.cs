using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace Proiect_IA
{
    public partial class MainForm : Form
    {
        private bool isCreatingNode = false;
        public bool isCreatingArc { get; private set; } = false;

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
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
        }

        private void buttonCreateNode_Click(object sender, EventArgs e)
        {
            isCreatingNode = true;
            richTextBox.Text =  "Click the canvas to create a node";
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isCreatingNode && e.Button == MouseButtons.Left)
            {
                Node node = new Node("node", 0.5, 0.5, new Point(e.Location.X - Node.NodeSize, e.Location.Y - Node.NodeSize), this);
                nodes.Add(node);

                panel1.Controls.Add(node);
                isCreatingNode = false;
            }

        }

        private void buttonCreateArc_Click(object sender, EventArgs e)
        {
            isCreatingArc = true;
            richTextBox.Text =  "Chose 2 nodes to create an arc";
        }

        public void DrawNewArc()
        {
            Arc arc = new Arc(NewArc.StartNode, NewArc.EndNode);
            arcs.Add(arc);
            panel1.Paint += arc.Arc_Paint;
            panel1.Controls.Add(arc);
            UpdatePanel();
        }
        public void ResetArcCreation()
        {
            isCreatingArc = false;
            NewArc.StartNode= null;
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
                arcs.RemoveAt(arcs.Count - 1);
                UpdatePanel();
            }
        }

        public void UpdatePanel()
        {
            panel1.Invalidate();
        }

        private void buttonRemoveNode_Click(object sender, EventArgs e)
        {

        }

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
                            string str = reader.ReadElementContentAsString();
                            tempDefinition.Given.Add(nodes.Find(n => n.Name ==  str));
                        }
                    }

                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == "DEFINITION")
                        {
                            var x = new BayesianDefinition(tempDefinition);
                            definitions.Add(x);
                            foreach(var node in x.Given)
                            {
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
            (string x, string y) = (sp[0],sp[1]);

            int xPos = ((int)Convert.ToDouble(x)) % 1000;
            int yPos = ((int)Convert.ToDouble(y)) % 1000;

            return new Point(xPos, yPos);
        }
    }

}
