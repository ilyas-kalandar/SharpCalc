using System.Numerics;

namespace SharpCalc
{
    public class Program
    {
        // for calculating
        private static Calculator calc = new();

        // for result
        private static BigInteger result;
        public static void Main(string[] args)
        {
            Console.WriteLine("SharpCalc, just calculator :D");
            
            while(true)
            {
                Console.Write("SharpCalc>> ");

                string? expression = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(expression))
                {
                    Console.WriteLine("Good bye");
                    return;
                }

                try
                {
                    result = calc.Evalulate(expression);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }

                Console.WriteLine(result);
            }
        }
    }
}