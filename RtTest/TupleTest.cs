using System.Collections.Generic;

using RtChallenge;

using Xunit;

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

    [Fact]
    public void AddingTwoTuples()
    {
        var a1 = new Tuple(3, -2, 5, 1);
        var a2 = new Tuple(-2, 3, 1, 0);
        var expected = new Tuple(1, 1, 6, 1);
        Assert.Equal(expected, a1 + a2);
    }

    [Fact]
    public void SubtractingTwoPoints()
    {
        var p1 = Tuple.Point(3, 2, 1);
        var p2 = Tuple.Point(5, 6, 7);
        var expected = Tuple.Vector(-2, -4, -6);
        Assert.Equal(expected, p1 - p2);
    }

    [Fact]
    public void SubtractingAVectorFromAPoint()
    {
        var p = Tuple.Point(3, 2, 1);
        var v = Tuple.Vector(5, 6, 7);
        var expected = Tuple.Point(-2, -4, -6);
        Assert.Equal(expected, p - v);
    }

    [Fact]
    public void SubtractingTwoVectors()
    {
        var v1 = Tuple.Vector(3, 2, 1);
        var v2 = Tuple.Vector(5, 6, 7);
        var expected = Tuple.Vector(-2, -4, -6);
        Assert.Equal(expected, v1 - v2);
    }

    [Fact]
    public void SubtractingAVectorFromTheZeroVector()
    {
        var zero = Tuple.Vector(0, 0, 0);
        var v = Tuple.Vector(1, -2, 3);
        var expected = Tuple.Vector(-1, 2, -3);
        Assert.Equal(expected, zero - v);
    }

    [Fact]
    public void NegatingATuple()
    {
        var a = new Tuple(1, -2, 3, -4);
        var expected = new Tuple(-1, 2, -3, 4);
        Assert.Equal(expected, -a);
    }

    [Fact]
    public void MultiplyingATupleByAScalar()
    {
        var a = new Tuple(1, -2, 3, -4);
        var expected = new Tuple(3.5, -7, 10.5, -14);
        Assert.Equal(expected, a * 3.5);
    }

    [Fact]
    public void MultiplyingATupleByAFraction()
    {
        var a = new Tuple(1, -2, 3, -4);
        var expected = new Tuple(0.5, -1, 1.5, -2);
        Assert.Equal(expected, a * 0.5);
    }

    [Fact]
    public void DividingATupleByAScalar()
    {
        var a = new Tuple(1, -2, 3, -4);
        var expected = new Tuple(0.5, -1, 1.5, -2);
        Assert.Equal(expected, a / 2);
    }

    private static IEnumerable<(Tuple v, double m)> GetMagnitudes()
    {
        yield return (Tuple.Vector(1, 0, 0), 1);
        yield return (Tuple.Vector(0, 1, 0), 1);
        yield return (Tuple.Vector(0, 0, 1), 1);
        yield return (Tuple.Vector(1, 2, 3), System.Math.Sqrt(14));
        yield return (Tuple.Vector(-1, -2, -3), System.Math.Sqrt(14));
    }

    private static IEnumerable<object[]> GetMagnitudeData()
    {
        foreach (var (v, m) in GetMagnitudes())
        {
            yield return new object[] { v, m };
        }
    }

    [Theory]
    [MemberData(nameof(GetMagnitudeData))]
    public void MagnitudeOfAVector(Tuple v, double m)
    {
        Assert.Equal(m, v.Magnitude());
    }

    private static IEnumerable<(Tuple v, Tuple expected)> GetNormalizedVectors()
    {
        yield return (
            Tuple.Vector(4, 0, 0), 
            Tuple.Vector(1, 0, 0)
        );
        yield return (
            Tuple.Vector(1, 2, 3), 
            Tuple.Vector(
                1 / System.Math.Sqrt(14), 
                2 / System.Math.Sqrt(14), 
                3 / System.Math.Sqrt(14)
            )
        );
    }

    private static IEnumerable<object[]> GetNormalizedVectorData()
    {
        foreach (var (v, expected) in GetNormalizedVectors())
        {
            yield return new object[] { v, expected };
        }
    }

    [Theory]
    [MemberData(nameof(GetNormalizedVectorData))]
    public void NormalizingAVector(Tuple v, Tuple expected)
    {
        Assert.Equal(expected, v.Normalize());
    }

    [Fact]
    public void DotProductOfTwoTuples()
    {
        var a = Tuple.Vector(1, 2, 3);
        var b = Tuple.Vector(2, 3, 4);
        Assert.Equal(20, a.Dot(b), new FloatComparer());
    }
}