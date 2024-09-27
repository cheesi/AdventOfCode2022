using AoCHelper;
using Spectre.Console;

namespace AdventOfCode2022;

public class Day17 : BaseDay
{
    private string _input;

    public Day17()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day17(string input)
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
