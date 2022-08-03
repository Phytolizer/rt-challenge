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
}
