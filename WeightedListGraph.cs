using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstGraph
{
    class WeightedListGraph<dataType>
    {
        public List<Node<dataType>> Nodes;

        public WeightedListGraph()
        {
            Nodes = new List<Node<dataType>>();
        }

        public void AddNode(dataType name)
        {
            Nodes.Add(new Node<dataType>(name));
        }

        public void AddUndirectedConnection (dataType nodeAName, dataType nodeBName, int weight)
        {
            Node<dataType> nodeA = NodeLookup(nodeAName);
            Node<dataType> nodeB = NodeLookup(nodeBName);

            nodeA.AssignNeighbour(nodeB, weight);
            nodeB.AssignNeighbour(nodeA, weight);
        }

        public void AddDirectedConnection (dataType startNodeName, dataType endNodeName, int weight)
        {
            Node<dataType> startNode = NodeLookup(startNodeName);
            Node<dataType> endNode = NodeLookup(endNodeName);

            startNode.AssignNeighbour(endNode, weight);
        }

        private Node<dataType> NodeLookup (dataType name)
        {
            int index = int.MinValue;
            Comparer<dataType> comparer = Comparer<dataType>.Default;

            for (int i = 0; i < Nodes.Count; i++)
            {
                if (comparer.Compare(Nodes[i].GetName(), name) == 0)
                {
                    index = i;
                    i = int.MaxValue - 1;
                }
            }

            return Nodes[index];
        }
    }
}
