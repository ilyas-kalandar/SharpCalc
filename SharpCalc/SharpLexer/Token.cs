namespace SharpCalc.SharLexer
{
    /// <summary>
    /// A class for representing Token
    /// </summary>
    public class Token
    {
        /// <summary>
        /// A default constructor
        /// </summary>
        /// <param name="type">Type of token</param>
        /// <param name="value">Value of token (may be null)</param>
        public Token(TokenType type, string? value)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// Get Type of token
        /// </summary>
        public TokenType Type { get; private set; }
        /// <summary>
        /// Get value (may be null!)
        /// </summary>
        public string? Value { get; private set; }

        /// <summary>
        /// Default override of object.ToString()
        /// </summary>
        /// <returns>A string representation of token</returns>
        public override string ToString()
        {
            return $"Token(Type={Type}, Value=({Value}))";
        }
    }
}