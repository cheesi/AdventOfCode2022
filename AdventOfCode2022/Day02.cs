using System.Diagnostics;
using AoCHelper;

namespace AdventOfCode2022;

public class Day02 : BaseDay
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day02(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var points = new List<int>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var input = line.Split(' ');
            var opponent = GetRPSForABC(input[0].First());
            var me = GetRPSForXYZ(input[1].First());

            var pointsResult = 0;
            if (opponent == me)
            {
                pointsResult = 3;
            }
            else if (
                (me == RPS.Paper && opponent == RPS.Rock)
                || (me == RPS.Rock && opponent == RPS.Scissors)
                || (me == RPS.Scissors && opponent == RPS.Paper))
            {
                pointsResult = 6;
            }

            points.Add(pointsResult + (int)me);
        }

        return new ValueTask<string>(points.Sum().ToString());
    }

    private RPS GetRPSForABC(char opponent) =>
        opponent switch
        {
            'A' => RPS.Rock,
            'B' => RPS.Paper,
            'C' => RPS.Scissors
        };

    private RPS GetRPSForXYZ(char me) =>
        me switch
        {
            'X' => RPS.Rock,
            'Y' => RPS.Paper,
            'Z' => RPS.Scissors
        };

    public override ValueTask<string> Solve_2()
    {
        var points = new List<int>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var input = line.Split(' ');
            var opponent = GetRPSForABC(input[0].First());
            var result = GetResultForXYZ(input[1].First());
            RPS me;

            if (result == Result.Draw)
            {
                me = opponent;
            }
            else if (result == Result.Win)
            {
                if (opponent == RPS.Rock)
                {
                    me = RPS.Paper;
                }
                else if (opponent == RPS.Paper)
                {
                    me = RPS.Scissors;
                }
                else
                {
                    me = RPS.Rock;
                }
            }
            else
            {
                if (opponent == RPS.Rock)
                {
                    me = RPS.Scissors;
                }
                else if (opponent == RPS.Paper)
                {
                    me = RPS.Rock;
                }
                else
                {
                    me = RPS.Paper;
                }
            }


            var pointsResult = 0;
            if (opponent == me)
            {
                pointsResult = 3;
            }
            else if (
                (me == RPS.Paper && opponent == RPS.Rock)
                || (me == RPS.Rock && opponent == RPS.Scissors)
                || (me == RPS.Scissors && opponent == RPS.Paper))
            {
                pointsResult = 6;
            }

            points.Add(pointsResult + (int)me);
        }

        return new ValueTask<string>(points.Sum().ToString());
    }

    private Result GetResultForXYZ(char me) =>
        me switch
        {
            'X' => Result.Lose,
            'Y' => Result.Draw,
            'Z' => Result.Win
        };

    enum RPS
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    enum Result
    {
        Lose,
        Draw,
        Win
    }
}
