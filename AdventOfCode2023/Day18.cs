using System.Text;
using AoCHelper;
using Spectre.Console;

namespace AdventOfCode2022;

public class Day18 : BaseDay
{
    private string _input;

    public Day18()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day18(string input)
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
