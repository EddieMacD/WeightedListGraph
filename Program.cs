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

            const string A = "A";
            const string B = "B";
            const string C = "C";
            const string D = "D";
            const string E = "E";
            const string F = "F";
            const string G = "G";
            const string H = "H";
            const string I = "I";
            const string J = "J";
            const string K = "K";

            graph.AddNode(A);
            graph.AddNode(B);
            graph.AddNode(C);
            graph.AddNode(D);
            graph.AddNode(E);
            graph.AddNode(F);
            graph.AddNode(G);
            graph.AddNode(H);
            graph.AddNode(I);
            graph.AddNode(J);
            graph.AddNode(K);

            graph.AddUndirectedConnection(A, B, 29);
            graph.AddUndirectedConnection(A, E, 27);
            graph.AddUndirectedConnection(A, H, 30);
            graph.AddUndirectedConnection(B, C, 19);
            graph.AddUndirectedConnection(C, D, 9);
            graph.AddUndirectedConnection(C, F, 26);
            graph.AddUndirectedConnection(C, G, 17);
            graph.AddUndirectedConnection(D, G, 18);
            graph.AddUndirectedConnection(E, F, 8);
            graph.AddUndirectedConnection(E, J, 12);
            graph.AddUndirectedConnection(E, K, 24);
            graph.AddUndirectedConnection(F, I, 20);
            graph.AddUndirectedConnection(F, J, 14);
            graph.AddUndirectedConnection(G, I, 14);
            graph.AddUndirectedConnection(H, K, 22);
            graph.AddUndirectedConnection(J, K, 26);

            Console.WriteLine("Breadth first from " + A);

            List<string> nodes = graph.BreadthFirstSearch(A);
            for (int i = 0; i < nodes.Count(); i++)
            {
                Console.Write(nodes[i] + "    ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Depth first from " + A);


            nodes = graph.DepthFirst(A);
            for (int i = 0; i < nodes.Count(); i++)
            {
                Console.Write(nodes[i] + "    ");
            }

            Console.WriteLine();
            Console.WriteLine();

            graph.RemoveNode(B);

            Console.WriteLine("Breadth first from " + A);

            nodes = graph.BreadthFirstSearch(A);
            for (int i = 0; i < nodes.Count(); i++)
            {
                Console.Write(nodes[i] + "    ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Depth first from " + A);


            nodes = graph.DepthFirst(A);
            for (int i = 0; i < nodes.Count(); i++)
            {
                Console.Write(nodes[i] + "    ");
            }

            Console.ReadLine();
        }
    }
}
