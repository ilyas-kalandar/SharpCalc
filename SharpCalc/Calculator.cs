using SharpCalc.SharLexer;
using SharpCalc.SharpParser;
using System.Numerics;

namespace SharpCalc
{
    /// <summary>
    /// Class for calculating mathematical expressions
    /// </summary>
    public class Calculator
    {
        private Parser? _parser = null;
        private Lexer? _lexer = null;
        
       
        /// <summary>
        /// Evalulates expression
        /// </summary>
        /// <param name="expression">Your mathematical expression</param>
        /// <returns>Computed value</returns>
        public BigInteger Evalulate(string expression)
        {
            // Split code into tokens
            _lexer = new(expression);
            _lexer.GetTokens();

            // Make AST from tokens.
            _parser = new (_lexer.Tokens);

            IAbstractSyntaxTree a = _parser.Parse();

            // Evalulate & Return.
            return a.Evalulate();
        }
    }
}
