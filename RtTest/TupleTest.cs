using Xunit;
using RtChallenge;

namespace RtTest;

public class TupleTest
{
    [Fact]
    public void IsAPointWhenWIs1()
    {
        var a = new Tuple(4.3, -4.2, 3.1, 1.0);
        Assert.Equal(4.3, a.X);
        Assert.Equal(-4.2, a.Y);
        Assert.Equal(3.1, a.Z);
        Assert.Equal(1.0, a.W);
        Assert.True(a.IsPoint);
        Assert.False(a.IsVector);
    }

    [Fact]
    public void IsAVectorWhenWIs0()
    {
        var a = new Tuple(4.3, -4.2, 3.1, 0.0);
        var comparer = new FloatComparer();
        Assert.Equal(4.3, a.X, comparer);
        Assert.Equal(-4.2, a.Y, comparer);
        Assert.Equal(3.1, a.Z, comparer);
        Assert.Equal(0.0, a.W, comparer);
        Assert.False(a.IsPoint);
        Assert.True(a.IsVector);
    }

    [Fact]
    public void PointCreatesTuplesWithW1()
    {
        var p = Tuple.Point(4, -4, 3);
        Assert.Equal(new Tuple(4, -4, 3, 1), p);
    }

    [Fact]
    public void VectorCreatesTuplesWithW0()
    {
        var v = Tuple.Vector(4, -4, 3);
        Assert.Equal(new Tuple(4, -4, 3, 0), v);
    }
}