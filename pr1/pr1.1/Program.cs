using System;

namespace pr1._1 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("No random numbers!");
            Random random;
            for (int j = 0; j<5; j++) {
                random = new Random(123);
                for (int i = 0; i < 5; i++)
                {
                    int rnd1 = random.Next(1, 20);
                    Console.Write(rnd1);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            //Console.WriteLine("Random numbers");
            //for (int i = 0; i < 5; i++)
            //{
            //    random = new Random(i);
            //    for (int j = 0; j < 5; j++)
            //    {
            //        int rnd = random.Next(1, 20);
            //        Console.Write(rnd);
            //        Console.Write(" ");
            //    }
            //    Console.WriteLine();
            }
        }
    }
}