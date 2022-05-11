namespace SharpCalc;

public class Program
{
    public static List<Token> Tokenize(string str)
    {
        List<Token> tokens = new List<Token>();
        string valueBuffer = "";
        int index = 0;

        while (index < str.Length)
        {
            char ch = str[index];
            switch (ch)
            {
                case '+':
                    tokens.Add(new Token(TokenType.PLUS, "+"));
                    break;
                case '-':
                    tokens.Add(new Token(TokenType.MINUS, "-"));
                    break;
                case '*':
                    tokens.Add(new Token(TokenType.MULTIPLY, "*"));
                    break;
                case '/':
                    tokens.Add(new Token(TokenType.DIVIDE, "/"));
                    break;
                case '(':
                    tokens.Add(new Token(TokenType.LEFT_PAREN, "("));
                    break;
                case ')':
                    tokens.Add(new Token(TokenType.RIGHT_PAREN, ")"));
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    while (index < str.Length && char.IsDigit(str[index]))
                    {
                        valueBuffer += str[index];
                        index++;
                    }
                    tokens.Add(new Token(TokenType.INT_VALUE, valueBuffer));
                    valueBuffer = "";
                    break;
            }
            index++;
        }

        return tokens;
    }
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Write(">> ");
            string s = Console.ReadLine() ?? throw new ArgumentException();

            foreach (var tok in Tokenize(s))
            {
                Console.WriteLine(tok);
            }
        }
    }
}