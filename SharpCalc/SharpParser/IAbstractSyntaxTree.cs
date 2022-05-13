using System.Numerics;

namespace SharpCalc.SharpParser
{
    public interface IAbstractSyntaxTree
    {
        public BigInteger Evalulate();
    }
}
