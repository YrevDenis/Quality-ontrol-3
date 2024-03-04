using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string testCasesFile = "tests.txt";
        string resultsFile = "results.txt";

        RunTestCases(testCasesFile, resultsFile);

        Console.WriteLine("Проверка завершена");
    }

    static void RunTestCases(string inputFileName, string outputFileName)
    {
        try
        {
            string[] lines = File.ReadAllLines(inputFileName);
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                    string[] parts = line.Split(' ');
                    if (parts.Length == 4)
                    {
                        string expected = parts[3].ToLower();
                        string result = RunTriangleApp(parts[0], parts[1], parts[2]);

                        Console.WriteLine(result.ToLower());
                        Console.WriteLine(expected);
                        if (result.ToLower() == expected)
                        {
                            writer.WriteLine("success;");
                        }
                        else
                        {
                            writer.WriteLine("error;");
                        }
                    }
                    else
                    {
                        if (parts[parts.Length - 1].ToLower() == "ошибка")
                        {
                            writer.WriteLine("success;");
                        }
                        else
                        {
                            writer.WriteLine("error;");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static string RunTriangleApp(string a, string b, string c)
    {
        try
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "triangle-app/triangle.exe";
                process.StartInfo.Arguments = $"{a} {b} {c}";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                string result = process.StandardOutput.ReadToEnd().Trim();
                process.WaitForExit();

                return result;
            }
        }
        catch (Exception ex)
        {
            return $"error: {ex.Message}";
        }
    }
}
