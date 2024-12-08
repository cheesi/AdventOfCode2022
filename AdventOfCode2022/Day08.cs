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
        var lines = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var map = new int[lines.Length, lines[0].Length];

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (int j = 0; j < line.Length; j++)
            {
                map[i, j] = int.Parse(line[j].ToString());
            }
        }

        var counterVisible = 0;
        var counterEdge = 0;
        var maxX = lines.Length - 1;
        var maxY = lines[0].Length - 1;
        for (int x = 0; x <= maxX; x++)
        {
            for (int y = 0; y <= maxY; y++)
            {
                if (x == 0 || x == maxX || y == 0 || y == maxY)
                {
                    counterEdge++;
                }
                else
                {
                    if (SearchUp(map, x, y)
                        || SearchRight(map, x, y)
                        || SearchDown(map, x, y)
                        || SearchLeft(map, x, y))
                    {
                        counterVisible++;
                    }
                }
            }
        }

        counterVisible += counterEdge;

        return new ValueTask<string>(counterVisible.ToString());
    }

    private static bool SearchUp(int[,] map, int x, int y)
    {
        var currentTreeValue = map[x, y];
        for (int newX = x - 1; newX >= 0; newX--)
        {
            if (map[newX, y] >= currentTreeValue)
            {
                return false;
            }
        }
        return true;
    }

    private static bool SearchRight(int[,] map, int x, int y)
    {
        var currentTreeValue = map[x, y];
        var maxY = map.GetLength(1) - 1;
        for (int newY = y + 1; newY <= maxY; newY++)
        {
            if (map[x, newY] >= currentTreeValue)
            {
                return false;
            }
        }
        return true;
    }

    private static bool SearchDown(int[,] map, int x, int y)
    {
        var currentTreeValue = map[x, y];
        var maxX = map.GetLength(0) - 1;
        for (int newX = x + 1; newX <= maxX; newX++)
        {
            if (map[newX, y] >= currentTreeValue)
            {
                return false;
            }
        }
        return true;
    }

    private static bool SearchLeft(int[,] map, int x, int y)
    {
        var currentTreeValue = map[x, y];
        for (int newY = y - 1; newY >= 0; newY--)
        {
            if (map[x, newY] >= currentTreeValue)
            {
                return false;
            }
        }
        return true;
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var map = new int[lines.Length, lines[0].Length];

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (int j = 0; j < line.Length; j++)
            {
                map[i, j] = int.Parse(line[j].ToString());
            }
        }

        var maxTreeValue = 0L;
        var maxX = lines.Length - 1;
        var maxY = lines[0].Length - 1;
        for (int x = 0; x <= maxX; x++)
        {
            for (int y = 0; y <= maxY; y++)
            {
                var treeValue = CalcUp(map, x, y)
                    * CalcRight(map, x, y)
                    * CalcDown(map, x, y)
                    * CalcLeft(map, x, y);
                maxTreeValue = Math.Max(maxTreeValue, treeValue);
            }
        }

        return new ValueTask<string>(maxTreeValue.ToString());
    }

    private static long CalcUp(int[,] map, int x, int y)
    {
        var counter = 0;
        var currentTreeValue = map[x, y];
        for (int newX = x - 1; newX >= 0; newX--)
        {
            counter++;
            if (map[newX, y] >= currentTreeValue)
            {
                return counter;
            }
        }
        return counter;
    }

    private static long CalcRight(int[,] map, int x, int y)
    {
        var counter = 0;
        var currentTreeValue = map[x, y];
        var maxY = map.GetLength(1) - 1;
        for (int newY = y + 1; newY <= maxY; newY++)
        {
            counter++;
            if (map[x, newY] >= currentTreeValue)
            {
                return counter;
            }
        }
        return counter;
    }

    private static long CalcDown(int[,] map, int x, int y)
    {
        var counter = 0;
        var currentTreeValue = map[x, y];
        var maxX = map.GetLength(0) - 1;
        for (int newX = x + 1; newX <= maxX; newX++)
        {
            counter++;
            if (map[newX, y] >= currentTreeValue)
            {
                return counter;
            }
        }
        return counter;
    }

    private static long CalcLeft(int[,] map, int x, int y)
    {
        var counter = 0;
        var currentTreeValue = map[x, y];
        for (int newY = y - 1; newY >= 0; newY--)
        {
            counter++;
            if (map[x, newY] >= currentTreeValue)
            {
                return counter;
            }
        }
        return counter;
    }
}
