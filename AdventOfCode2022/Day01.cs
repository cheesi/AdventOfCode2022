using AoCHelper;

namespace AdventOfCode2022;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day01(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        int maxCalories = 0;
        int caloriesCounter = 0;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (string.IsNullOrEmpty(line))
            {
                maxCalories = Math.Max(maxCalories, caloriesCounter);
                caloriesCounter = 0;
                continue;
            }

            var calories = int.Parse(line);
            caloriesCounter += calories;
        }

        maxCalories = Math.Max(maxCalories, caloriesCounter);

        return new ValueTask<string>(maxCalories.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        List<int> allCalories = new List<int>();
        int caloriesCounter = 0;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (string.IsNullOrEmpty(line))
            {
                allCalories.Add(caloriesCounter);
                caloriesCounter = 0;
                continue;
            }

            var calories = int.Parse(line);
            caloriesCounter += calories;
        }

        allCalories.Add(caloriesCounter);

        var sumTopThree = allCalories.OrderDescending().Take(3).Sum();
        return new ValueTask<string>(sumTopThree.ToString());
    }
}
