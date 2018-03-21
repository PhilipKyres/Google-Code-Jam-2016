using System;
using System.Collections;
using System.IO;
using System.Numerics;
using System.Text;

//https://code.google.com/codejam/contest/6254486/dashboard#s=p2
class Program
{
    private static readonly DateTime StartTime = DateTime.Now;
    private static string input = "";
    private static readonly StringBuilder Output = new StringBuilder();

    static void Main()
    {
        string[] lines = LoadFile();
        PrintTime("Loaded from file");

        int T = lines[0].ToInt(); //number of sets
        Console.WriteLine("Total sets: " + T);
        string[] temp = lines[1].Split(' ');
        int N = temp[0].ToInt(); //jamcoin length
        int J = temp[1].ToInt(); //num jamcoins to produce

        int jamCtr = 0;

        Output.AppendLine("Case #1:");

        StringBuilder sb = new StringBuilder(N);
        sb.Append('1');
        sb.Append('0', N - 2);
        sb.Append('1');
        long b2 = (long)ConvertToBase(BigInteger.Parse(sb.ToString()), 2);

        while (true)
        {
            BigInteger[] bases = new BigInteger[9];
            BigInteger[] factors = new BigInteger[9];
            bases[0] = b2;

            BigInteger binary = BigInteger.Parse(Convert.ToString(b2, 2));
            for (int i = 3; i < 11; i++)
            {
                bases[i - 2] = ConvertToBase(binary, i);
            }

            for (int i = 2; i < 11; i++)
            {
                int index = i - 2;

                BigInteger factor = GetFactor(bases[index]);

                if (factor.IsZero)
                    break;

                factors[index] = factor;
            }

            if (!factors[8].IsZero)
            {
                jamCtr++;

                Output.AppendLine($"{Convert.ToString(b2, 2)} {String.Join(" ", factors)}");

                if (jamCtr == J)
                    break;
            }

            b2 += 2;
        }

        SaveFile();
        PrintTime("Done");
        Console.ReadKey();
    }

    static BigInteger ConvertToBase(BigInteger number, int radix)
    {
        BigInteger value = 0;
        var num = number.ToString();

        for (int i = 0; i < num.Length; i++)
            value += Convert.ToInt32(Char.GetNumericValue(num[num.Length - 1 - i])) * BigInteger.Pow(radix, i);

        return value;
    }

    public static BigInteger GetFactor(BigInteger number)
    {
        if (number % 2 == 0)
            return 2;
        for (BigInteger i = 3; i <= 11; i += 2)
        {
            if (number % i == 0)
                return i;
        }
        return 0;
    }

    private static void PrintTime(string msg)
    {
        Console.WriteLine(msg + ": " + DateTime.Now.Subtract(StartTime));
    }

    private static string[] LoadFile()
    {
        return File.ReadAllLines(@"C:\Users\PHILIP\Desktop\i.txt");
    }

    private static void SaveFile()
    {
        File.WriteAllText(@"C:\Users\PHILIP\Desktop\o.txt", Output.ToString());
    }
}

public static class StringExtension
{
    public static int ToInt(this string str)
    {
        return Convert.ToInt32(str);
    }

    public static void Print(this object obj)
    {
        Console.WriteLine(obj is IEnumerable enumerable 
            ? String.Join(" ", enumerable) 
            : obj.ToString());
    }
}
