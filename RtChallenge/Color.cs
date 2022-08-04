namespace RtChallenge;

public class Color : Tuple
{
    public double Red => X;
    public double Green => Y;
    public double Blue => Z;

    public Color(double red, double green, double blue)
        : base(red, green, blue, 0)
    {
    }

    public static Color operator*(Color c1, Color c2)
    {
        return new Color(
            c1.Red * c2.Red,
            c1.Green * c2.Green,
            c1.Blue * c2.Blue
        );
    }
}
