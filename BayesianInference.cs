using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA
{
    internal class BayesianInference
    {
        private BayesianNetwork _network;

        public BayesianInference(BayesianNetwork network)
        {
            _network = network;
        }

        public double EnumerateAll(string queryVariable, string queryValue, Dictionary<string, string> evidence)
        {
            var variables = _network.Variables.Select(v => v.Name).ToList();
            evidence[queryVariable] = queryValue;

            return EnumerateAllRecursive(variables, evidence);
        }

        private double EnumerateAllRecursive(List<string> variables, Dictionary<string, string> evidence)
        {
            if (!variables.Any())
                return 1.0;

            var first = variables.First();
            var rest = variables.Skip(1).ToList();

            if (evidence.ContainsKey(first))
            {
                var probability = GetProbability(first, evidence);
                return probability * EnumerateAllRecursive(rest, evidence);
            }
            else
            {
                
                double sum = 0.0;
                foreach (var value in new[] { "T", "F" })
                {
                    var extendedEvidence = new Dictionary<string, string>(evidence)
                    {
                        [first] = value
                    };
                    sum += GetProbability(first, extendedEvidence) * EnumerateAllRecursive(rest, extendedEvidence);
                }
                return sum;
            }
        }

        private double GetProbability(string variable, Dictionary<string, string> evidence)
        {
            var definition = _network.Definitions.First(d => d.For.Name == variable);

            if (!definition.Given.Any())
            {
                 
                return definition.Table[0];  
            }
            else
            {
                // Probabilitate condiționată
                int index = 0;
                int multiplier = 1;

                // Calculăm indexul în tabel pe baza evidenței
                for (int i = definition.Given.Count - 1; i >= 0; i--)
                {
                    var givenVariable = definition.Given[i].Name;
                    if (evidence[givenVariable] == "T")
                        index += multiplier;
                    multiplier *= 2;
                }

                // Returnăm probabilitatea pe baza valorii cerute
                return evidence[variable] == "T" ? definition.Table[2 * index] : definition.Table[2 * index + 1];
            }
        }
     
    }
}
