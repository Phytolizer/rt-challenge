using RtChallenge;

using Xunit;

namespace RtTest;

public class MatrixTest
{
    [Fact]
    public void ConstructingAndInspectingA4x4Matrix()
    {
        var m = new Matrix(new[]
        {
            new[] { 1.0, 2.0, 3.0, 4.0 },
            new[] { 5.5, 6.5, 7.5, 8.5 },
            new[] { 9.0, 10.0, 11.0, 12.0 },
            new[] { 13.5, 14.5, 15.5, 16.5 }
        });
        var c = new FloatComparer();
        Assert.Equal(1, m.Get(0, 0), c);
        Assert.Equal(4, m.Get(0, 3), c);
        Assert.Equal(5.5, m.Get(1, 0), c);
        Assert.Equal(7.5, m.Get(1, 2), c);
        Assert.Equal(11, m.Get(2, 2), c);
        Assert.Equal(13.5, m.Get(3, 0), c);
        Assert.Equal(15.5, m.Get(3, 2), c);
    }

    [Fact]
    public void A2x2MatrixOughtToBeRepresentable()
    {
        var m = new Matrix(new[]
        {
            new[] { -3.0, 5.0 },
            new[] { 1.0, -2.0 }
        });
        var c = new FloatComparer();
        Assert.Equal(-3, m.Get(0, 0), c);
        Assert.Equal(5, m.Get(0, 1), c);
        Assert.Equal(1, m.Get(1, 0), c);
        Assert.Equal(-2, m.Get(1, 1), c);
    }

    [Fact]
    public void A3x3MatrixOughtToBeRepresentable()
    {
        var m = new Matrix(new[]
        {
            new[] { -3.0, 5.0, 0.0 },
            new[] { 1.0, -2.0, -7.0 },
            new[] { 0.0, 1.0, 1.0 }
        });
        var c = new FloatComparer();
        Assert.Equal(-3, m.Get(0, 0), c);
        Assert.Equal(-2, m.Get(1, 1), c);
        Assert.Equal(1, m.Get(2, 2), c);
    }

    [Fact]
    public void MatrixEqualityWithIdenticalMatrices()
    {
        var a = new Matrix(new[]
        {
            new[] { 1.0, 2.0, 3.0, 4.0 },
            new[] { 5.0, 6.0, 7.0, 8.0 },
            new[] { 9.0, 8.0, 7.0, 6.0 },
            new[] { 5.0, 4.0, 3.0, 2.0 }
        });
        var b = new Matrix(new[]
        {
            new[] { 1.0, 2.0, 3.0, 4.0 },
            new[] { 5.0, 6.0, 7.0, 8.0 },
            new[] { 9.0, 8.0, 7.0, 6.0 },
            new[] { 5.0, 4.0, 3.0, 2.0 }
        });
        Assert.Equal(a, b);
    }

    [Fact]
    public void MatrixEqualityWithDifferentMatrices()
    {
        var a = new Matrix(new[]
        {
            new[] { 1.0, 2.0, 3.0, 4.0 },
            new[] { 5.0, 6.0, 7.0, 8.0 },
            new[] { 9.0, 8.0, 7.0, 6.0 },
            new[] { 5.0, 4.0, 3.0, 2.0 }
        });
        var b = new Matrix(new[]
        {
            new[] { 2.0, 3.0, 4.0, 5.0 },
            new[] { 6.0, 7.0, 8.0, 9.0 },
            new[] { 8.0, 7.0, 6.0, 5.0 },
            new[] { 4.0, 3.0, 2.0, 1.0 }
        });
        Assert.NotEqual(a, b);
    }
}
