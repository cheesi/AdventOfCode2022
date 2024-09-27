using System.Collections.Concurrent;
using System.Text;
using AoCHelper;
using Spectre.Console;

namespace AdventOfCode2022;

public class Day16 : BaseDay
{
    private string _input;

    public Day16()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day16(string input)
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
