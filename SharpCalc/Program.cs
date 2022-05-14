using SharpCalc.SharLexer;
using SharpCalc.SharpParser;

namespace SharpCalc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Lexer lex;
            Parser parser;
            while(true)
            {
                Console.Write("SharpCalc>> ");
                string? line = Console.ReadLine();

                if (line == null || line.Length == 0)
                {
                    Environment.Exit(0);
                }

                lex = new Lexer(line);
                lex.GetTokens();
                parser = new Parser(lex.Tokens);
                IAbstractSyntaxTree ast;

                try
                {
                    ast = parser.Parse();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception occured: {e.Message}");
                    continue;
                }
                Console.WriteLine($"Ans: {ast.Evalulate()}");
            }
        }
    }
}