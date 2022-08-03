namespace RtChallenge;

public class Canvas
{
    public int Width { get; }
    public int Height { get; }

    public Color[][] Pixels { get; }

    public Canvas(int width, int height)
    {
        Width = width;
        Height = height;
        Pixels = new Color[height][];
        for (var y = 0; y < height; y++)
        {
            Pixels[y] = new Color[width];
            for (var x = 0; x < width; x++)
            {
                Pixels[y][x] = new Color(0, 0, 0);
            }
        }
    }

    public void WritePixel(int x, int y, Color color)
    {
        Pixels[y][x] = color;
    }

    public Color PixelAt(int x, int y)
    {
        return Pixels[y][x];
    }
}
