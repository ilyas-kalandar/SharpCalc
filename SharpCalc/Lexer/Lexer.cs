namespace SharpCalc.Lexer
{
    public class Lexer
    {
        /*
        * This is a Lexer class
        * 
        * Use .LoadTokens() method to get List of Tokens
        * 
        */

        private string _source;
        private int _currentIndex = 0;

        List<Token> _tokens = new();
        public Token[] Tokens { get { return _tokens.ToArray(); } }

        private void PushToken(TokenType type, string? val = null)
        {
            _tokens.Add(new Token(type, val));
        }

        public Lexer(string source)
        {
            _source = source;
        }

        private string GetValue()
        {
            int toIndex = _currentIndex;
            while (toIndex < _source.Length && char.IsDigit(_source[toIndex])  )
            {
                toIndex++;
            }
            string result = _source.Substring(_currentIndex, toIndex - _currentIndex);
            _currentIndex = toIndex;
            return result;
        }

        public void GetTokens()
        {
            for (_currentIndex = 0; _currentIndex < _source.Length;)
            {
                char current = _source[_currentIndex];

                switch (current)
                {
                    case '+':
                        PushToken(TokenType.PLUS);
                        break;
                    case '-':
                        PushToken(TokenType.MINUS);
                        break;
                    case '*':
                        PushToken(TokenType.MULTIPLY);
                        break;
                    case '/':
                        PushToken(TokenType.DIVIDE);
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
                        PushToken(TokenType.INT_VALUE, GetValue());
                        continue;
                    case ' ':
                        // continue
                        break;
                    default:
                        throw new FormatException($"Invalid character given: {current} ({_currentIndex} symbol)");
                }
                _currentIndex++;
            }
        }

    }
}
