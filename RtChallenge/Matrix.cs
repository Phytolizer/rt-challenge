using System.Text;

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

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows)
        {
            throw new ArgumentException("Columns of A must match rows of B");
        }
        var c = new double[a.Rows][];
        for (var i = 0; i < a.Rows; i++)
        {
            c[i] = new double[b.Columns];
            for (var j = 0; j < b.Columns; j++)
            {
                c[i][j] = 0;
                for (var k = 0; k < a.Columns; k++)
                {
                    c[i][j] += a.Values[i][k] * b.Values[k][j];
                }
            }
        }
        return new Matrix(c);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                sb.Append(Values[i][j]);
                sb.Append(' ');
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
