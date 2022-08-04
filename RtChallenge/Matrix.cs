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
}
