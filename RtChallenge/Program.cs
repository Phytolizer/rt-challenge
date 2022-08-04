namespace RtChallenge;

internal static class Program
{
    private static void Main()
    {
        var start = Tuple.Point(0, 1, 0);
        var velocity = Tuple.Vector(1, 1.8, 0).Normalize() * 11.25;
        var p = new Projectile(start, velocity);
        var gravity = Tuple.Vector(0, -0.1, 0);
        var wind = Tuple.Vector(-0.01, 0, 0);
        var e = new Environment(gravity, wind);

        var c = new Canvas(900, 550);
        while (p.Position.Y > 0)
        {
            p = e.Tick(p);
            c.WritePixel(
                (int)p.Position.X,
                550 - (int)p.Position.Y,
                new Color(1, 1, 1)
            );
        }

        File.WriteAllText("output.ppm", c.ToPpm());
    }
}
