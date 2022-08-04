namespace RtChallenge;

internal class Projectile
{
    public Tuple Position { get; }
    public Tuple Velocity { get; }

    public Projectile(Tuple position, Tuple velocity)
    {
        Position = position;
        Velocity = velocity;
    }
}
