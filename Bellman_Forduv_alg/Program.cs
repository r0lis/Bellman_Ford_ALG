namespace Bellman_Forduv_alg
{
    internal class Program
    {
        public struct Edge
        {
            public int From;
            public int To;
            public int Weight;
        }
        
        public struct Graph
        {
            public int VerticesCount;
            public int EdgesCount;
            public Edge[] Edges;
        }

        public static Graph CreateGraph(int verticesCount, int edgesCount)
        {
            Graph graph = new Graph();
            graph.VerticesCount = verticesCount;
            graph.EdgesCount = edgesCount;
            graph.Edges = new Edge[graph.EdgesCount];

            return graph;
        }

        private static void PrintDistances(int[] distance, int count)
        {
            Console.WriteLine("Vrchol\tVzdálenost");
            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine("{0}\t{1}", i, distance[i]);
            }
        }

        public static void BellmanFord(Graph graph, int source)
        {
            int verticesCount = graph.VerticesCount;
            int edgesCount = graph.EdgesCount;
            int[] distance = new int[verticesCount];

           

            //Inicializace vzdáleností na nekonečno
            for (int i = 0; i < verticesCount; i++)
            {
                distance[i] = int.MaxValue;
            }

            // Nastavení vzdálenosti ke zdrojovému vrcholu na 0
            distance[source] = 0;

            // Aktualizace vzdálenosti mezi uzly tak, aby se našly nejkratší cesty.
            for (int i = 1; i <= verticesCount - 1; ++i)
            {
                
                for (int j = 0; j < edgesCount; ++j)
                {
                    int from = graph.Edges[j].From;
                    int to = graph.Edges[j].To;
                    int weight = graph.Edges[j].Weight;

                    //PrintDistances(distance, verticesCount);

                    //  Pokud je nová vzdálenost menší než aktuální, aktualizujte ji.
                    if (distance[from] != int.MaxValue && distance[from] + weight < distance[to])
                    {
                        distance[to] = distance[from] + weight;
                    }
                }
            }
            PrintDistances(distance, verticesCount);

            // Detekce záporných hmotnostních cyklů
            for (int i = 0; i < edgesCount; ++i)
            {
                int from = graph.Edges[i].From;
                int to = graph.Edges[i].To;
                int weight = graph.Edges[i].Weight;

                if (distance[from] != int.MaxValue && distance[from] + weight < distance[to])
                {
                    Console.WriteLine("Graf obsahuje záporný váhový cyklus.");
                    return;
                }
            }

        }
        public static void Main()
        {
            int verticesCount = 5;
            int edgesCount = 8;
            Graph graph = CreateGraph(verticesCount, edgesCount);

           
            //graph.Edges[0].From = 0;
            //graph.Edges[0].To = 1;
            //graph.Edges[0].Weight = 4;

            //graph.Edges[1].From = 0;
            //graph.Edges[1].To = 2;
            //graph.Edges[1].Weight = 1;

            //graph.Edges[2].From = 1;
            //graph.Edges[2].To = 2;
            //graph.Edges[2].Weight = -2;

            //graph.Edges[3].From = 1;
            //graph.Edges[3].To = 3;
            //graph.Edges[3].Weight = 7;

            //graph.Edges[4].From = 2;
            //graph.Edges[4].To = 3;
            //graph.Edges[4].Weight = -3;

            //graph.Edges[5].From = 2;
            //graph.Edges[5].To = 4;
            //graph.Edges[5].Weight = 5;

            //graph.Edges[6].From = 3;
            //graph.Edges[6].To = 4;
            //graph.Edges[6].Weight = 2;

            //graph.Edges[7].From = 4;
            //graph.Edges[7].To = 1;
            //graph.Edges[7].Weight = 1;


            graph.Edges[0].From = 0;
            graph.Edges[0].To = 1;
            graph.Edges[0].Weight = -1;

            graph.Edges[1].From = 0;
            graph.Edges[1].To = 2;
            graph.Edges[1].Weight = 4;

            graph.Edges[2].From = 1;
            graph.Edges[2].To = 2;
            graph.Edges[2].Weight = 3;

            graph.Edges[3].From = 1;
            graph.Edges[3].To = 3;
            graph.Edges[3].Weight = 2;

            graph.Edges[4].From = 1;
            graph.Edges[4].To = 4;
            graph.Edges[4].Weight = -2;

            graph.Edges[5].From = 3;
            graph.Edges[5].To = 2;
            graph.Edges[5].Weight = 5;

            graph.Edges[6].From = 3;
            graph.Edges[6].To = 1;
            graph.Edges[6].Weight = 1;

            graph.Edges[7].From = 4;
            graph.Edges[7].To = 3;
            graph.Edges[7].Weight = -3;

            BellmanFord(graph, 0);
        }
    }
}
