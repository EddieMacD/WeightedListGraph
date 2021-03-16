using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstGraph
{
    class Node<dataType>
    {
        private dataType Name;
        private List<Edge<dataType>> Neighbours;

        public Node(dataType name)
        {
            Name = name;
            Neighbours = new List<Edge<dataType>>();
        }

        public void AssignNeighbour(Node<dataType> neighbour, int edgeWeight)
        {
            Neighbours.Add(new Edge<dataType>(neighbour, edgeWeight));
        }

        public void RemoveNeighbour(Node<dataType> neighbour)
        {
            if (Neighbours.Count != 0)
            {
                for (int i = 0; i < Neighbours.Count; i++)
                {
                    if (Neighbours[i].GetDestination() == neighbour)
                    {
                        Neighbours.RemoveAt(i);
                        i = int.MaxValue - 1;
                    }
                }
            }
        }

        public dataType GetName ()
        {
            return Name;
        }
    }
}
