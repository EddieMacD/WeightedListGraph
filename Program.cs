using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightedListGraph<string> graph = new WeightedListGraph<string>();

            const string A = "Bury St Edmonds";
            const string B = "Framlington";
            const string C = "Wickham Market";
            const string D = "Stowmarket";
            const string E = "Ipswitch";
            const string F = "Woodbridge";

            graph.AddNode(A);
            graph.AddNode(B);
            graph.AddNode(C);
            graph.AddNode(D);
            graph.AddNode(E);
            graph.AddNode(F);

            graph.AddUndirectedConnection(A, B, 57);
            graph.AddUndirectedConnection(B, C, 10);
            graph.AddUndirectedConnection(C, F, 9);
            graph.AddUndirectedConnection(F, E, 15);
            graph.AddUndirectedConnection(E, D, 21);
            graph.AddUndirectedConnection(A, D, 25);
            graph.AddUndirectedConnection(A, E, 45);
            graph.AddUndirectedConnection(A, F, 56);
            graph.AddUndirectedConnection(B, E, 31);

            Console.WriteLine("Breadth first from " + A);

            List<string> nodes = graph.BreadthFirstSearch(A);
            for (int i = 0; i < nodes.Count(); i++)
            {
                Console.Write(nodes[i] + "    ");
            }

            Console.WriteLine();
            Console.WriteLine();

            graph.RemoveNode(D);

            Console.WriteLine("Breadth first from " + A);

            nodes = graph.BreadthFirstSearch(A);
            for (int i = 0; i < nodes.Count(); i++)
            {
                Console.Write(nodes[i] + "    ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
