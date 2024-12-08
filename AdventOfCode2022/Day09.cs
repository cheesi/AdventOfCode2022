using AoCHelper;
using System.Drawing;

namespace AdventOfCode2022;

public class Day09 : BaseDay
{
    private readonly string _input;

    public Day09()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day09(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var visited = new HashSet<Point>();
        var head = new Point(0, 0);
        var tail = new Point(0, 0);
        visited.Add(tail);

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var parts = line.Split(' ');
            var direction = parts[0];
            var spacesToMove = int.Parse(parts[1]);
            for (var i = 1; i <= spacesToMove; i++)
            {
                head = MoveHead(head, direction);

                var dx = head.X - tail.X;
                var dy = head.Y - tail.Y;
                if (Math.Abs(dx) > 1
                    || Math.Abs(dy) > 1)
                {
                    tail = UpdateKnot(tail, dx, dy);
                    if (!visited.Contains(tail))
                    {
                        visited.Add(tail);
                    }
                }
            }
        }

        return new ValueTask<string>(visited.Count.ToString());
    }

    private static Point MoveHead(Point head, string direction)
    {
        if (direction == "R")
        {
            head.Y++;
        }
        else if (direction == "U")
        {
            head.X--;
        }
        else if (direction == "L")
        {
            head.Y--;
        }
        else if (direction == "D")
        {
            head.X++;
        }

        return head;
    }

    private static Point UpdateKnot(Point knot, int dx, int dy)
    {
        if (dx > 1)
        {
            knot.X++;
            if (dy == 1)
            {
                knot.Y++;
            }
            else if (dy == -1)
            {
                knot.Y--;
            }
        }
        else if (dx < -1)
        {
            knot.X--;
            if (dy == 1)
            {
                knot.Y++;
            }
            else if (dy == -1)
            {
                knot.Y--;
            }
        }
        if (dy > 1)
        {
            knot.Y++;
            if (dx == 1)
            {
                knot.X++;
            }
            else if (dx == -1)
            {
                knot.X--;
            }
        }
        else if (dy < -1)
        {
            knot.Y--;
            if (dx == 1)
            {
                knot.X++;
            }
            else if (dx == -1)
            {
                knot.X--;
            }
        }

        return knot;
    }

    public override ValueTask<string> Solve_2()
    {
        var visited = new HashSet<Point>();
        var knots = new Point[10];
        for (int i = 0; i < knots.Length; i++)
        {
            knots[i] = new Point(0, 0);
        }
        visited.Add(knots[9]);

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var parts = line.Split(' ');
            var direction = parts[0];
            var spacesToMove = int.Parse(parts[1]);
            for (var i = 1; i <= spacesToMove; i++)
            {
                knots[0] = MoveHead(knots[0], direction);

                for (var j = 1; j < knots.Length; j++)
                {
                    var dx = knots[j - 1].X - knots[j].X;
                    var dy = knots[j - 1].Y - knots[j].Y;
                    if (Math.Abs(dx) > 1
                        || Math.Abs(dy) > 1)
                    {
                        knots[j] = UpdateKnot(knots[j], dx, dy);
                        if ((j == knots.Length - 1)
                            && !visited.Contains(knots[j]))
                        {
                            visited.Add(knots[j]);
                        }
                    }
                }
            }
        }

        return new ValueTask<string>(visited.Count.ToString());
    }
}
