namespace RtChallenge;

public class Matrix
{
    public int Rows { get; }
    public int Columns { get; }
    public double[][] Values { get; }

    public Matrix(double[][] values)
    {
        Rows = values.Length;
        Columns = values[0].Length;
        Values = values;
    }

    public double Get(int row, int column)
    {
        return Values[row][column];
    }

    public override bool Equals(object? obj)
    {
        var c = new FloatComparer();
        return obj is Matrix m &&
            Rows == m.Rows &&
            Columns == m.Columns &&
            Values.Zip(
                m.Values,
                (a, b) => a.Zip(b).All(t => c.Equals(t.First, t.Second))
            ).All(x => x);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
