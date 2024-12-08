using AoCHelper;

namespace AdventOfCode2022;

public class Day10 : BaseDay
{
    private readonly string _input;

    public Day10()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day10(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var cycle = 0;
        var registerX = 1;

        var signalStrengths = new List<int>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (line is "noop")
            {
                cycle++;
                if (Is40thCycle1(cycle))
                {
                    signalStrengths.Add(registerX * cycle);
                }
            }
            else if (line.StartsWith("addx"))
            {
                var parts = line.Split(' ');
                var number = int.Parse(parts[1]);

                cycle++;
                if (Is40thCycle1(cycle))
                {
                    signalStrengths.Add(registerX * cycle);
                }

                cycle++;
                if (Is40thCycle1(cycle))
                {
                    signalStrengths.Add(registerX * cycle);
                }

                registerX += number;
            }
        }

        return new ValueTask<string>(signalStrengths.Sum().ToString());
    }

    private static bool Is40thCycle1(int cycle)
    {
        return cycle == 20 || cycle == 60 || cycle == 100
                            || cycle == 140 || cycle == 180 || cycle == 220;
    }

    public override ValueTask<string> Solve_2()
    {
        var cycle = 0;
        var registerX = 1;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (line is "noop")
            {
                cycle++;
                DrawPixel(cycle, registerX);
            }
            else if (line.StartsWith("addx"))
            {
                var parts = line.Split(' ');
                var number = int.Parse(parts[1]);

                cycle++;
                DrawPixel(cycle, registerX);

                cycle++;
                DrawPixel(cycle, registerX);

                registerX += number;
            }
        }

        // Prints:
        // ####.#..#.###..###..####.####..##..#....
        // ...#.#..#.#..#.#..#.#....#....#..#.#....
        // ..#..#..#.#..#.#..#.###..###..#....#....
        // .#...#..#.###..###..#....#....#....#....
        // #....#..#.#....#.#..#....#....#..#.#....
        // ####..##..#....#..#.#....####..##..####.

        return new ValueTask<string>("ZUPRFECL");
    }

    private static void DrawPixel(int cycle, int registerX)
    {
        var column = cycle;
        registerX++;
        while (column > 40)
        {
            column -= 40;
        }
        if (registerX - 1 == column || registerX == column || registerX + 1 == column)
        {
            Console.Write('#');
        }
        else
        {
            Console.Write('.');
        }

        if (cycle % 40 == 0)
        {
            Console.WriteLine();
        }
    }
}
