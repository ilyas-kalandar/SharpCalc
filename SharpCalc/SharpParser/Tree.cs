using System.Numerics;

namespace SharpCalc.SharpParser
{
    /// <summary>
    /// Represents a complex AST
    /// </summary>
    public class Tree : IAbstractSyntaxTree
    {
        Operator _Op;
        IAbstractSyntaxTree _Left;
        IAbstractSyntaxTree _Right;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="op">An operator</param>
        /// <param name="left">Left subtree</param>
        /// <param name="right">Right subtree</param>
        public Tree(Operator op, IAbstractSyntaxTree left, IAbstractSyntaxTree right)
        {
            _Op = op;
            _Left = left;
            _Right = right;
        }

        /// <summary>
        /// Evalulate the tree
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FormatException">Throws when invalid operator was given</exception>
        public BigInteger Evalulate()
        {
            switch (_Op)
            {
                case Operator.PLUS:
                    return _Left.Evalulate() + _Right.Evalulate();
                case Operator.MINUS:
                    return _Left.Evalulate() - _Right.Evalulate();
                case Operator.DIVIDE:
                    return _Left.Evalulate() / _Right.Evalulate();
                case Operator.MULTIPLY:
                    return _Left.Evalulate() * _Right.Evalulate();
                default:
                    throw new FormatException("Invalid operator given!");
            }
        }
    }
}
