using AoCHelper;

namespace AdventOfCode2022;

public class Day08 : BaseDay
{
    private readonly string _input;

    public Day08()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day08(string input)
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
