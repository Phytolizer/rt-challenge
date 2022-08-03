namespace RtChallenge;

public class Tuple
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    public double W { get; }
    public bool IsPoint
    {
        get
        {
            return W == 1.0;
        }
    }
    public bool IsVector
    {
        get
        {
            return W == 0.0;
        }
    }
    public Tuple(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }
    public static Tuple Point(double x, double y, double z)
    {
        return new Tuple(x, y, z, 1.0);
    }
    public static Tuple Vector(double x, double y, double z)
    {
        return new Tuple(x, y, z, 0.0);
    }
    public override bool Equals(object? obj)
    {
        var comparer = new FloatComparer();
        return obj is Tuple t &&
            comparer.Equals(X, t.X) &&
            comparer.Equals(Y, t.Y) &&
            comparer.Equals(Z, t.Z) &&
            comparer.Equals(W, t.W);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(
            X.GetHashCode(),
            Y.GetHashCode(),
            Z.GetHashCode(),
            W.GetHashCode()
        );
    }
}
