using AoCHelper;

namespace AdventOfCode2022;

public class Day04 : BaseDay
{
    private readonly string _input;

    public Day04()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day04(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var counter = 0;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var pairs = line.Split(',');
            var assignments = pairs.Select(pair => pair.Split('-').Select(int.Parse))
                .Select(assignemntId => Enumerable.Range(assignemntId.First(), assignemntId.Last() - assignemntId.First() + 1));

            var firstElf = assignments.First();
            var secondElf = assignments.Skip(1).First();

            var intersection = firstElf.Intersect(secondElf);
            if (Enumerable.SequenceEqual(intersection, firstElf)
                || Enumerable.SequenceEqual(intersection, secondElf))
            {
                counter++;
            }
        }

        return new ValueTask<string>(counter.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var counter = 0;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var pairs = line.Split(',');
            var assignments = pairs.Select(pair => pair.Split('-').Select(int.Parse))
                .Select(assignemntId => Enumerable.Range(assignemntId.First(), assignemntId.Last() - assignemntId.First() + 1));

            var firstElf = assignments.First();
            var secondElf = assignments.Skip(1).First();

            var intersection = firstElf.Intersect(secondElf);
            if (intersection.Any())
            {
                counter++;
            }
        }

        return new ValueTask<string>(counter.ToString());
    }
}
