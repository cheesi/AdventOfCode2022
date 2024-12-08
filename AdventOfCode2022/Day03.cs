using System.Diagnostics;
using System.Globalization;
using System.Text;
using AoCHelper;

namespace AdventOfCode2022;

public class Day03 : BaseDay
{
    private readonly string _input;

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day03(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var priorities = new List<int>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (string.IsNullOrEmpty(line)) continue;

            if (line.Length % 2 != 0)
            {
                throw new Exception($"Invalid line: {line}");
            }

            var compartment1 = line[0..(line.Length / 2)].ToCharArray();
            var compartment2 = line[(line.Length / 2)..].ToCharArray();

            var both = compartment1.Intersect(compartment2);

            foreach (var item in both)
            {
                if (item >= 'a' && item <= 'z')
                {
                    priorities.Add(item - 96);
                }
                else if (item >= 'A' && item <= 'Z')
                {
                    priorities.Add(item - 38);
                }
                else
                {
                    throw new Exception($"Invalid line: {line}");
                }
            }
        }

        return new ValueTask<string>(priorities.Sum().ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var priorities = new List<int>();

        var lines = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < lines.Length - 2; i += 3)
        {
            var group1 = lines[i].ToCharArray();
            var group2 = lines[i + 1].ToCharArray();
            var group3 = lines[i + 2].ToCharArray();

            var inAllThree = group1.Intersect(group2).Intersect(group3);

            foreach (var item in inAllThree)
            {
                if (item >= 'a' && item <= 'z')
                {
                    priorities.Add(item - 96);
                }
                else if (item >= 'A' && item <= 'Z')
                {
                    priorities.Add(item - 38);
                }
                else
                {
                    throw new Exception($"Invalid line: {inAllThree}");
                }
            }
        }

        return new ValueTask<string>(priorities.Sum().ToString());
    }
}
