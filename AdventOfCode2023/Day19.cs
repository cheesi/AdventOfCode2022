using AoCHelper;

namespace AdventOfCode2022;

public class Day19 : BaseDay
{
    private string _input;

    public Day19()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day19(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>(_input);
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>(_input);
    }
}
