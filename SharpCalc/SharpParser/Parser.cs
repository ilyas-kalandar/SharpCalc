using SharpCalc.SharLexer;

namespace SharpCalc.SharpParser
{
    /// <summary>
    /// A Parser class, makes AST from IEnumerable with Tokens, use .Parse method!
    /// </summary>
    public class Parser
    {
        Token[] _tokens;
        private int _currentIndex = 0;

        /// <summary>
        /// Get next token
        /// </summary>
        /// <returns>Next token</returns>
        private Token NextToken()
        {
            if (_currentIndex < _tokens.Length)
            {
                return _tokens[_currentIndex++];
            }
            return new Token(TokenType.EOF, null);
        }   

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="tokens">An IEnumerable with tokens!</param>
        public Parser(IEnumerable<Token> tokens)
        {
            _tokens = tokens.ToArray();
        }

        /// <summary>
        /// Converts a TokenType to Operator
        /// </summary>
        /// <param name="type">A type of Token</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws if not operator was given</exception>
        private Operator ConvertTokenType(TokenType type)
        {
            switch (type)
            {
                case TokenType.PLUS:
                    return Operator.PLUS;
                case TokenType.MINUS:
                    return Operator.MINUS;
                case TokenType.MULTIPLY:
                    return Operator.MULTIPLY;
                case TokenType.DIVIDE:
                    return Operator.DIVIDE;
                default:
                    throw new ArgumentException($"Invalid type of token given, {type}");
            }
        }
        /// <summary>
        /// Returns an AST with LOW priority -, + etc...
        /// </summary>
        /// <returns></returns>
        public IAbstractSyntaxTree Parse()
        {
            IAbstractSyntaxTree result = GetMediumPriorityAst();
            while (_currentIndex < _tokens.Length && (_tokens[_currentIndex].Type == TokenType.PLUS || _tokens[_currentIndex].Type == TokenType.MINUS))
            {
                var tok = NextToken();
                result = new Tree(ConvertTokenType(tok.Type), result, GetMediumPriorityAst());
            }
            return result;
        }

        /// <summary>
        /// Returns an AST with Medium priority, *, / etc...
        /// </summary>
        /// <returns></returns>
        private IAbstractSyntaxTree GetMediumPriorityAst()
        {
            IAbstractSyntaxTree result = GetHighPriorityAst();
            while (_currentIndex < _tokens.Length && (_tokens[_currentIndex].Type == TokenType.DIVIDE || _tokens[_currentIndex].Type == TokenType.MULTIPLY))
            {
                var tok = NextToken();
                result = new Tree(ConvertTokenType(tok.Type), result, GetHighPriorityAst());
            }
            return result;
        }

        /// <summary>
        /// Returns a HIGH priority AST
        /// </summary>
        /// <exception cref="FormatException">Throws if unexpected token was given</exception>
        private IAbstractSyntaxTree GetHighPriorityAst()
        {
            Token token = NextToken();

            if (token.Type == TokenType.INT_VALUE)
            {
                return new TreeLeaf(token.Value);
            }
            else if (token.Type == TokenType.LEFT_PAREN)
            {
                IAbstractSyntaxTree res = Parse();
                Token tok = NextToken();

                if(tok.Type != TokenType.RIGHT_PAREN)
                {
                    throw new FormatException($"Expected ')' got {tok.Type}");
                }
                return res;
            }
            throw new FormatException($"Expected {TokenType.LEFT_PAREN} or {TokenType.INT_VALUE}, got {token.Type}");
        }
    }
}
