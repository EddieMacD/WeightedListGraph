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
        private bool BFSState;

        public Node(dataType name)
        {
            Name = name;
            Neighbours = new List<Edge<dataType>>();
            BFSState = false;
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

        public bool GetBFSState ()
        {
            return BFSState;
        }

        public void ChangeBFSState (bool state)
        {
            BFSState = state;
        }

        public void BreadthFirstSearch(Queue<Node<dataType>> queue, List<dataType> nodeOrder)
        {
            if (Neighbours.Count != 0)
            {
                for (int i = 0; i < Neighbours.Count; i++)
                {
                    bool newNode = true;

                    if (Neighbours[i].GetDestination().GetBFSState())
                    {
                        newNode = false;
                    }

                    if (newNode)
                    {
                        queue.Enqueue(Neighbours[i].GetDestination());
                        Neighbours[i].GetDestination().ChangeBFSState(true);
                    }
                }
            }
        }
    }
}
