using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Proiect_IA
{
    internal class Bayes
    {
    }

    public class BayesianVariable
    {
        public string Name { get; set; } = "";
        public Point? Position { get; set; }
        
        public BayesianVariable(string name, Point? position)
        {
            Name = name;
            Position = position;
        }
        
        public void Reset()
        {
            Name = "";
            Position = null;
        }
    }

    public class BayesianDefinition
    {
        public Node? For { get; set; } 
        public List<Node?> Given { get; set; }
        public double[] Table { get; set; }

        public BayesianDefinition(Node node, List<Node> nodes, double[] table)
        {
          
            Given = nodes;
            Table = new double[table.Length];
            Array.Copy(table, Table, Table.Length);
            For = new Node(node.Name, node.probTrue, node.probFalse, Table, Given.Count(), Given.ToArray(), node.Location, node._parentForm);
        }

        public BayesianDefinition()
        {
            For = null;
            Given = new List<Node?>();
            Table = Array.Empty<double>();
        }

        public BayesianDefinition(BayesianDefinition other) : this(other.For, other.Given , other.Table)
        {
        }
        public void Reset()
        {
            For = null;
            Given.Clear();
            Table = [];
        }
    }
}
