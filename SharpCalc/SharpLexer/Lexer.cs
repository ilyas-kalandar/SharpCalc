namespace SharpCalc.SharLexer
{
    /// <summary>Class for splitting source code into tokens</summary>
    /// <example>
    /// Use default constructor for providing source code
    /// <code>Lexer lex = new("source code here");</code>
    /// Also use <c>.Tokens</c> for getting an array with tokens 
    /// </example>
    public class Lexer
    {
        private string _source;
        private int _currentIndex = 0;

        List<Token> _tokens = new();
        /// <summary>
        /// Get tokens
        /// </summary>
        public Token[] Tokens { get { return _tokens.ToArray(); } }

        /// <summary>
        /// Pushes a Token to <c>this._tokens</c>
        /// </summary>
        /// <param name="type">A type of token</param>
        /// <param name="val">A value of token (null by default)</param>
        private void PushToken(TokenType type, string? val = null)
        {
            _tokens.Add(new Token(type, val));
        }

        /// <summary>
        /// A default constructor
        /// </summary>
        /// <param name="source">Your source code</param>
        public Lexer(string source)
        {
            _source = source;
        }

        /// <summary>
        /// Parse a Value (integer) from <c>_currentIndex</c>
        /// </summary>
        /// <returns>A string with value</returns>
        private string GetValue()
        {
            int toIndex = _currentIndex;
            while (toIndex < _source.Length && char.IsDigit(_source[toIndex]))
            {
                toIndex++;
            }
            string result = _source.Substring(_currentIndex, toIndex - _currentIndex);
            _currentIndex = toIndex;
            return result;
        }

        /// <summary>
        /// Parses tokens from given source code
        /// </summary>
        /// <exception cref="FormatException">Thrown when invalid character given</exception>
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
                    case ')':
                        PushToken(TokenType.RIGHT_PAREN);
                        break;
                    case '(':
                        PushToken(TokenType.LEFT_PAREN);
                        break;
                    default:
                        throw new FormatException($"Invalid character given: {current} ({_currentIndex} symbol)");
                }
                _currentIndex++;
            }
        }

    }
}
