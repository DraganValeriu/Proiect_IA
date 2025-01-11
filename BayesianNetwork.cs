using System.Xml.Linq;

namespace Proiect_IA
{
    internal class BayesianNetwork
    {
        public List<BayesianVariable> Variables { get; set; } = new List<BayesianVariable>();
        public List<BayesianDefinition> Definitions { get; set; } = new List<BayesianDefinition>();

        public BayesianNetwork(List<BayesianVariable> variables, List<BayesianDefinition> definitions) { 
            Variables = variables;
            Definitions = definitions;
        }
    }
}