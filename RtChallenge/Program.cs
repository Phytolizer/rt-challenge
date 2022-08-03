namespace RtChallenge;

internal static class Program
{
    private static void Main()
    {
        var p = new Projectile(Tuple.Point(0, 1, 0), Tuple.Vector(1, 1, 0).Normalize());
        var e = new Environment(Tuple.Vector(0, -0.1, 0), Tuple.Vector(-0.01, 0, 0));
        var ticksAlive = 0;
        while (p.Position.Y > 0)
        {
            Console.WriteLine($"{p.Position.X:0.0000} {p.Position.Y:0.0000} {p.Position.Z:0.0000}");
            p = e.Tick(p);
            ticksAlive++;
        }
        Console.WriteLine($"Landed in {ticksAlive} ticks");
    }
}
