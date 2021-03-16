using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstGraph
{
    class Edge<dataType>
    {
        Node<dataType> Destination;
        int Weight;

        public Edge(Node<dataType> destination, int weight)
        {
            Destination = destination;
            Weight = weight;
        }

        public Node<dataType> GetDestination()
        {
            return Destination;
        }

        public int GetWeight()
        {
            return Weight;
        }
    }
}
