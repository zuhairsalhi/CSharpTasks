using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

Console.WriteLine("Task 21 Text Analyzer");
Console.WriteLine();

string text = """
C# is a powerful programming language. 
C# is used to build web applications, desktop applications, and APIs.
Programming with C# is fun. 
Learning programming requires practice and patience.
C# programming becomes easier with practice.
""";

var result = AnalyzeText(text);

StringBuilder report = new StringBuilder();

report.AppendLine("Text Analysis Report");
report.AppendLine($"Words: {result.Words}");
report.AppendLine($"Characters: {result.Chars}");
report.AppendLine($"Most Frequent Word: {result.MostFrequent}");
report.AppendLine($"Longest Word: {result.Longest}");
report.AppendLine($"Sentences: {result.Sentences}");

Console.WriteLine(report);


Console.WriteLine(" Performance Comparison ");

const int iterations = 10_000;

Stopwatch stringWatch = Stopwatch.StartNew();

string stringResult = "";

for (int i = 0; i < iterations; i++)
{
    stringResult += "C# ";
}

stringWatch.Stop();

Stopwatch builderWatch = Stopwatch.StartNew();

StringBuilder builder = new StringBuilder();

for (int i = 0; i < iterations; i++)
{
    builder.Append("C# ");
}

string builderResult = builder.ToString();

builderWatch.Stop();

Console.WriteLine(
    $"String concatenation: {stringWatch.ElapsedTicks} ticks"
);

Console.WriteLine(
    $"StringBuilder: {builderWatch.ElapsedTicks} ticks"
);

Console.WriteLine();

Console.WriteLine("Task 21 completed successfully.");


(int Words, int Chars, string MostFrequent, string Longest, int Sentences)
    AnalyzeText(string input)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        return (0, 0, "", "", 0);
    }

    int chars = input.Length;

    string cleanedText = input
        .ToLower()
        .Replace(".", "")
        .Replace(",", "")
        .Replace("!", "")
        .Replace("?", "");

    string[] words = cleanedText
        .Split(
            new[] { ' ', '\n', '\r', '\t' },
            StringSplitOptions.RemoveEmptyEntries
        );

    int wordCount = words.Length;

    string mostFrequent = words
        .GroupBy(word => word)
        .OrderByDescending(group => group.Count())
        .First()
        .Key;

    string longestWord = words.OrderByDescending(word => word.Length).First();

    int sentenceCount = input.Count(
        character =>
            character == '.' ||
            character == '!' ||
            character == '?'
    );
    return (
        wordCount,
        chars,
        mostFrequent,
        longestWord,
        sentenceCount
    );
}