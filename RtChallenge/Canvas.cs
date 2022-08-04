using System.Text;

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

    private static IEnumerable<string> PpmRow(IEnumerable<Color> row)
    {
        foreach (var color in row)
        {
            var red = (int)Math.Round(color.Red * 255);
            red = Math.Clamp(red, 0, 255);
            var green = (int)Math.Round(color.Green * 255);
            green = Math.Clamp(green, 0, 255);
            var blue = (int)Math.Round(color.Blue * 255);
            blue = Math.Clamp(blue, 0, 255);
            yield return $"{red} {green} {blue}";
        }
    }

    public string ToPpm()
    {
        var result = new StringBuilder();
        result.AppendLine("P3");
        result.AppendLine($"{Width} {Height}");
        result.AppendLine("255");
        foreach (var row in Pixels)
        {
            result.AppendJoin(' ', PpmRow(row));
            result.AppendLine();
        }
        return result.ToString();
    }
}
