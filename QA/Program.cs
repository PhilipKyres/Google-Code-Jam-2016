using System;
using System.IO;
using System.Linq;
using System.Text;

//https://code.google.com/codejam/contest/6254486/dashboard#s=p0
class Program
{
    private static readonly DateTime StartTime = DateTime.Now;
    private static string input = "";
    private static readonly StringBuilder Output = new StringBuilder();

    static void Main()
    {
        LoadFile();
        PrintTime("Loaded from file");

        string[] lines = input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        int T = lines[0].ToInt(); //number of sets
        Console.WriteLine("Total sets: " + T);
        int lineNum = 1;
        for (int i = 1; i <= T; i++)
        {
            string[] line = lines[lineNum].Split(' ');
            int N = line[0].ToInt();
            lineNum++;

            if (N == 0)
            {
                Output.AppendLine($"Case #{i}: INSOMNIA");
                continue;
            }

            bool[] seen = new bool[10];
            int count = 0;

            do
            {
                count++;

                int num = N * count;

                do
                {
                    seen[num % 10] = true;
                    num /= 10;
                } while (num != 0);
            } while (seen.Any(x => !x));

            Output.AppendLine($"Case #{i}: {N * count}");
        }

        SaveFile();
        PrintTime("Done");
        Console.ReadKey();
    }

    private static void PrintTime(string msg)
    {
        Console.WriteLine(msg + ": " + DateTime.Now.Subtract(StartTime));
    }

    private static void LoadFile()
    {
        input = File.ReadAllText(@"C:\Users\PHILIP\Desktop\i.txt");
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

    public static void Print(this object str)
    {
        Console.WriteLine(str.ToString());
    }
}
