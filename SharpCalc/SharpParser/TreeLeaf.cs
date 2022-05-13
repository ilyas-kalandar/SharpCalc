using System.Numerics;

namespace SharpCalc.SharpParser
{
    /// <summary>
    /// Class for representing a leaf of AST
    /// </summary>
    public class TreeLeaf : IAbstractSyntaxTree
    {
        private BigInteger _value;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="val">An integer represented as string</param>
        public TreeLeaf(string? val)
        { 
            if (!BigInteger.TryParse(val, out _value))
            {
                throw new ArgumentException($"Invalid argument for BigInteger provided! {val}");
            }
        }
        /// <summary>
        /// Returns a value of Leaf
        /// </summary>
        /// <returns></returns>
        public BigInteger Evalulate()
        {
            return _value;
        }
    }
}
