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
        public List<double> Table { get; set; }
     
        public BayesianDefinition(Node node, List<Node> nodes, List<double> table)
        {
            For = new Node(node.Name, node.Prob[0], node.Prob[1],  node.Location, node._parentForm);
            Given = new List<Node?>(nodes);
            Table = new List<double>(table);
        }

        public BayesianDefinition()
        {
            For = null;
            Given = new List<Node?>();
            Table = new List<double>();
        }

        public BayesianDefinition(BayesianDefinition other)
        {
            For = new Node(other.For.Name, other.For.Prob[0], other.For.Prob[1], other.For.Location, other.For._parentForm);
            Given = new List<Node?>(other.Given);
            Table = new List<double>(other.Table);
        }
        public void Reset()
        {
            For = null;
            Given.Clear();
            Table.Clear();
        }
    }
}
