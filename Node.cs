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
        private bool SearchFlag;


        public Node(dataType name)
        {
            Name = name;
            Neighbours = new List<Edge<dataType>>();
            SearchFlag = false;
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

        public bool GetSearchFlag ()
        {
            return SearchFlag;
        }

        public void ChangeSearchFlag (bool state)
        {
            SearchFlag = state;
        }

        public void BreadthFirstSearch(Queue<Node<dataType>> queue, List<dataType> nodeOrder)
        {
            if (Neighbours.Count != 0)
            {
                for (int i = 0; i < Neighbours.Count; i++)
                {
                    bool newNode = true;

                    if (Neighbours[i].GetDestination().GetSearchFlag())
                    {
                        newNode = false;
                    }

                    if (newNode)
                    {
                        queue.Enqueue(Neighbours[i].GetDestination());
                        Neighbours[i].GetDestination().ChangeSearchFlag(true);
                    }
                }
            }
        }

        public void DepthFirst (List<dataType> nodes)
        {
            ChangeSearchFlag(true);
            nodes.Add(Name);

            foreach (Edge<dataType> edge in Neighbours)
            {
                Node<dataType> neighbour = edge.GetDestination();

                if(!neighbour.GetSearchFlag())
                {
                    neighbour.DepthFirst(nodes);
                }
            }
        }
    }
}
