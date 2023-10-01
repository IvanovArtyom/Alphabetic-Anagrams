using System.Linq;

public class Kata
{
    public static void Main()
    {
        // Test
        var t = ListPosition("BOOKKEEPER");
        // ...should return 10743
    }

    public static long ListPosition(string value)
    {
        long position = 1;

        for (int i = 0; i < value.Length - 1; i++)
        {
            int count = value[(i + 1)..].Count(c => c < value[i]);

            if (count == 0)
                continue;

            int[] keyCount = value[(i + 1)..].Distinct().Select(c => value[i..].Count(x => x == c)).ToArray();
            position += count * CountPermutationsWithRepetitions(keyCount, value.Length - i - 1);
        }

        return position;
    }

    public static long Factorial(int value)
    {
        long factorial = 1;

        for (int i = 2; i <= value; i++)
            factorial *= i;

        return factorial;
    }

    public static long CountPermutationsWithRepetitions(int[] keyCount, int length)
    {
        long denominator = 1;

        foreach (int count in keyCount)
            denominator *= Factorial(count);

        return Factorial(length) / denominator;
    }
}