using AoCHelper;
using System.Drawing;

namespace AdventOfCode2022;

public class Day14 : BaseDay
{
    private readonly string _input;
    private readonly int maxX;
    private readonly int maxY;

    public Day14()
    {
        _input = File.ReadAllText(InputFilePath);
        maxX = 159;
        maxY = 509;
    }

    public Day14(string input)
    {
        _input = input;
        maxX = 9;
        maxY = 503;
    }

    public override ValueTask<string> Solve_1()
    {
        var map = new char[maxX + 1, maxY + 1]; // hard coded value to input
        FillMapWithAir(map);

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            ParseRocks(map, line);
        }

        var sandCounter = 0;

        while (!MoveSandAbyss(map, 0, 500))
        {
            sandCounter++;
        }

        return new ValueTask<string>(sandCounter.ToString());
    }

    private static void ParseRocks(char[,] map, string line)
    {
        var rockPaths = line.Split(" -> ")
            .Select(x => x.Split(',')
                .Select(int.Parse))
            .Select(x => new Point(x.Last(), x.First()))
            .ToArray();

        for (int i = 0; i < rockPaths.Length - 1; i++)
        {
            var start = rockPaths[i];
            var end = rockPaths[i + 1];

            if (start.X == end.X)
            {
                var startY = Math.Min(start.Y, end.Y);
                var endY = Math.Max(start.Y, end.Y);
                for (int j = startY; j <= endY; j++)
                {
                    map[start.X, j] = '#';
                }
            }
            else if (start.Y == end.Y)
            {
                var startX = Math.Min(start.X, end.X);
                var endX = Math.Max(start.X, end.X);
                for (int j = startX; j <= endX; j++)
                {
                    map[j, start.Y] = '#';
                }
            }
        }
    }

    private static void FillMapWithAir(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = '.';
            }
        }
    }

    private bool MoveSandAbyss(char[,] map, int x, int y)
    {
        var downX = x + 1;
        if (downX < map.GetLength(0) && map[downX, y] == '.')
        {
            return MoveSandAbyss(map, downX, y);
        }
        else
        {
            var leftY = y - 1;
            if (downX < map.GetLength(0) && leftY >= 0 && map[downX, leftY] == '.')
            {
                return MoveSandAbyss(map, downX, leftY);
            }
            else
            {
                var rightY = y + 1;
                if (downX < map.GetLength(0) && rightY < map.GetLength(1) && map[downX, rightY] == '.')
                {
                    return MoveSandAbyss(map, downX, rightY);
                }
                else
                {
                    if (x == maxX)
                    {
                        return true;
                    }
                    map[x, y] = 'O';
                    return false;
                }
            }
        }
    }

    public override ValueTask<string> Solve_2()
    {
        var map = new char[maxX + 2, 1000];  // 1000 should be infinite enough
        FillMapWithAir(map);

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            ParseRocks(map, line);
        }

        var sandCounter = 0;

        while (map[0, 500] != 'O')
        {
            MoveSand(map, 0, 500);
            sandCounter++;
        }

        return new ValueTask<string>(sandCounter.ToString());
    }

    private void MoveSand(char[,] map, int x, int y)
    {
        var downX = x + 1;
        if (downX < map.GetLength(0) && map[downX, y] == '.')
        {
            MoveSand(map, downX, y);
        }
        else
        {
            var leftY = y - 1;
            if (downX < map.GetLength(0) && leftY >= 0 && map[downX, leftY] == '.')
            {
                MoveSand(map, downX, leftY);
            }
            else
            {
                var rightY = y + 1;
                if (downX < map.GetLength(0) && rightY < map.GetLength(1) && map[downX, rightY] == '.')
                {
                    MoveSand(map, downX, rightY);
                }
                else
                {
                    map[x, y] = 'O';
                }
            }
        }
    }
}
