namespace RtChallenge;

internal class Environment
{
    public Tuple Gravity { get; }
    public Tuple Wind { get; }

    public Environment(Tuple gravity, Tuple wind)
    {
        Gravity = gravity;
        Wind = wind;
    }

    public Projectile Tick(Projectile proj)
    {
        var position = proj.Position + proj.Velocity;
        var velocity = proj.Velocity + Gravity + Wind;
        return new Projectile(position, velocity);
    }
}
