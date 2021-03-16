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

        public void RemoveNode(dataType name)
        {
            Node<dataType> node = NodeLookup(name);

            for (int i = 0; i < Nodes.Count; i++)
            {
                if(Nodes[i] == node)
                {
                    Nodes.RemoveAt(i);
                    i--;
                }
                else
                {
                    Nodes[i].RemoveNeighbour(node);
                }
            }
        }

        public List<dataType> BreadthFirstSearch (dataType seedNodeName)
        {
            //System.Collections.Generic.Queue<Node<dataType>> myQ = new System.Collections.Generic.Queue<Node<dataType>>();
            ///A possible alternative
            ///I wanted to write a queue instead to explore generics

            Queue<Node<dataType>> queue = new Queue<Node<dataType>>();
            List<dataType> nodeOrder = new List<dataType>();
            Node<dataType> seedNode = NodeLookup(seedNodeName);

            queue.Enqueue(seedNode);
            seedNode.ChangeBFSState(true);

            while (queue.GetCount() != 0)
            {
                Node<dataType> current = queue.Dequeue();

                nodeOrder.Add(current.GetName());

                current.BreadthFirstSearch(queue, nodeOrder);
            }

            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].ChangeBFSState(false);
            }

            return nodeOrder;
        }
    }
}
