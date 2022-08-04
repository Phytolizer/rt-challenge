using System.Linq;

using RtChallenge;

using Xunit;

namespace RtTest;

public class CanvasTest
{
    [Fact]
    public void CreatingACanvas()
    {
        var c = new Canvas(10, 20);
        Assert.Equal(10, c.Width);
        Assert.Equal(20, c.Height);
        foreach (var row in c.Pixels)
        {
            foreach (var pixel in row)
            {
                Assert.Equal(new Color(0, 0, 0), pixel);
            }
        }
    }

    [Fact]
    public void WritingPixelsToACanvas()
    {
        var c = new Canvas(10, 20);
        var red = new Color(1, 0, 0);
        c.WritePixel(2, 3, red);
        Assert.Equal(red, c.PixelAt(2, 3));
    }

    [Fact]
    public void ConstructingThePpmHeader()
    {
        var c = new Canvas(5, 3);
        var ppm = c.ToPpm();
        Assert.StartsWith("P3\n5 3\n255\n", ppm);
    }

    [Fact]
    public void ConstructingThePpmPixelData()
    {
        var c = new Canvas(5, 3);
        var c1 = new Color(1.5, 0, 0);
        var c2 = new Color(0, 0.5, 0);
        var c3 = new Color(-0.5, 0, 1);
        c.WritePixel(0, 0, c1);
        c.WritePixel(2, 1, c2);
        c.WritePixel(4, 2, c3);
        var ppm = c.ToPpm();
        var lines = ppm.Split("\n", System.StringSplitOptions.RemoveEmptyEntries);
        Assert.Equal(
            new[] {
                "255 0 0", "0 0 0", "0 0 0", "0 0 0", "0 0 0",
                "0 0 0", "0 0 0", "0 128 0", "0 0 0", "0 0 0",
                "0 0 0", "0 0 0", "0 0 0", "0 0 0", "0 0 255"
            },
            lines.Skip(3)
        );
    }

    [Fact]
    public void SplittingLongLinesInPpmFiles()
    {
        var c = new Canvas(10, 2);
        for (int i = 0; i < c.Width; i++)
        {
            for (int j = 0; j < c.Height; j++)
            {
                c.WritePixel(i, j, new Color(1, 0.8, 0.6));
            }
        }
        var ppm = c.ToPpm();
        var lines = ppm.Split("\n", System.StringSplitOptions.RemoveEmptyEntries);
        Assert.Equal(
            Enumerable.Repeat("255 204 153", 20),
            lines.Skip(3)
        );
    }
}
