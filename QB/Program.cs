using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

//https://code.google.com/codejam/contest/6254486/dashboard#s=p1
class Program
{
    private static readonly DateTime StartTime = DateTime.Now;
    private static readonly StringBuilder Output = new StringBuilder();

    static void Main()
    {
        string[] lines = LoadFile();
        PrintTime("Loaded from file");

        int T = lines[0].ToInt(); //number of sets
        Console.WriteLine("Total sets: " + T);
        int lineNum = 1;
        for (int i = 1; i <= T; i++)
        {
            List<bool> stack = lines[lineNum].Select(x => x == '+').ToList();
            lineNum++;

            int count = 1;

            for (int j = 1; j < stack.Count; j++)
            {
                if (stack[j - 1] != stack[j])
                    count++;
            }

            if (stack.Last())
                count--;

            Output.AppendLine($"Case #{i}: {count}");
        }

        SaveFile();
        PrintTime("Done");
        Console.ReadKey();
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

    public static void Print(this object str)
    {
        Console.WriteLine(str.ToString());
    }
}
