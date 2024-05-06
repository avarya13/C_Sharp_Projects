using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

   public class Polygon
    {
        public static double GetSquare(LinkedList<Vertex> vertices)
        {
                int i;
                double square = 0;
                Vertex endVertex = vertices.First.Value;
                vertices.AddLast(endVertex);
                LinkedListNode<Vertex> vertex = vertices.First;
           
                for (i = 0; i < vertices.Count - 1; i++)
                {
                    square += 0.5 * Math.Abs((vertex.Value.X + vertex.Next.Value.X) * (vertex.Value.Y - vertex.Next.Value.Y));
                    vertex = vertex.Next;
                }
                if (i < 3) return 0;
                else return square;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            LinkedList<Vertex> vertices = new LinkedList<Vertex>();
            int i = 0;int x = 0;int y = 0;
            while(i<n)
            {
                
                string[] l= Console.ReadLine().Split(',');
                x = Convert.ToInt32(l[0]);
                y = Convert.ToInt32(l[1]);
                vertices.AddLast(new Vertex(x, y));
                i++;
            }
            
            if (Polygon.GetSquare(vertices) == 0)
                Console.WriteLine("Не является многоугольником");
            else Console.WriteLine($"Площадь многоугольника: {Polygon.GetSquare(vertices)}");
            Console.ReadKey();

        }
    }
}