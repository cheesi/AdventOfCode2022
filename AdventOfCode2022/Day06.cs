using AoCHelper;

namespace AdventOfCode2022;

public class Day06 : BaseDay
{
    private readonly string _input;

    public Day06()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day06(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine().ToCharArray() is { } line)
        {
            for (int i = 0; i < line.Length - 4; i++)
            {
                var chars = line.Skip(i).Take(4);
                if (chars.Distinct().Count() == 4)
                {
                    return new ValueTask<string>((i + 4).ToString());
                }
            }
        }

        return new ValueTask<string>("");
    }

    public override ValueTask<string> Solve_2()
    {
        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine().ToCharArray() is { } line)
        {
            for (int i = 0; i < line.Length - 14; i++)
            {
                var chars = line.Skip(i).Take(14);
                if (chars.Distinct().Count() == 14)
                {
                    return new ValueTask<string>((i + 14).ToString());
                }
            }
        }

        return new ValueTask<string>("");
    }
}
