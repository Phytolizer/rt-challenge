using System.Diagnostics.CodeAnalysis;

namespace RtChallenge;

public class FloatComparer : IEqualityComparer<double>
{
    public const double EPSILON = 0.000001;

    public bool Equals(double x, double y)
    {
        return Math.Abs(x - y) < EPSILON;
    }

    public int GetHashCode([DisallowNull] double obj)
    {
        return obj.GetHashCode();
    }
}
