using System;

namespace pr1._1 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random;
            for (int j = 0; j<5; j++) {
                random = new Random(124);
                for (int i = 0; i < 5; i++)
                {
                    int rnd1 = random.Next(1, 20);
                    Console.Write(rnd1);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}