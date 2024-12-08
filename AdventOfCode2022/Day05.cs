using System.Text;
using System.Text.RegularExpressions;
using AoCHelper;

namespace AdventOfCode2022;

public class Day05 : BaseDay
{
    private readonly string _input;

    public Day05()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day05(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var stacks = new List<Stack<string>>();

        var lineOfStackDefinition = -1;
        var inputParts = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < inputParts.Length; i++)
        {
            if (Regex.IsMatch(inputParts[i], @"\s+\d+"))
            {
                lineOfStackDefinition = i;
                var stackNumbers = inputParts[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse);
                foreach (var stackNumber in stackNumbers)
                {
                    stacks.Add(new Stack<string>());
                }
                break;
            }
        }

        for (int i = lineOfStackDefinition - 1; i >= 0; i--)
        {
            var line = inputParts[i].ToCharArray();
            var stackIndex = 0;
            for (int j = 1; j < line.Length; j += 4)
            {
                var crate = line[j].ToString();
                if (!string.IsNullOrWhiteSpace(crate))
                {
                    stacks[stackIndex].Push(crate);
                }
                stackIndex++;
            }
        }

        for (int i = lineOfStackDefinition + 1; i < inputParts.Length; i++)
        {
            var line = inputParts[i]
                .Replace("move", "")
                .Replace("from", "")
                .Replace("to", "")
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var amount = line[0];
            var stackIdFrom = line[1] - 1;
            var stackIdTo = line[2] - 1;

            var stackFrom = stacks[stackIdFrom];
            var stackTo = stacks[stackIdTo];

            for (int j = 1; j <= amount; j++)
            {
                stackTo.Push(stackFrom.Pop());
            }
        }

        var stringBuilder = new StringBuilder();
        foreach (var stack in stacks)
        {
            stringBuilder.Append(stack.Pop());
        }

        return new ValueTask<string>(stringBuilder.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var stacks = new List<Stack<string>>();

        var lineOfStackDefinition = -1;
        var inputParts = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < inputParts.Length; i++)
        {
            if (Regex.IsMatch(inputParts[i], @"\s+\d+"))
            {
                lineOfStackDefinition = i;
                var stackNumbers = inputParts[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse);
                foreach (var stackNumber in stackNumbers)
                {
                    stacks.Add(new Stack<string>());
                }
                break;
            }
        }

        for (int i = lineOfStackDefinition - 1; i >= 0; i--)
        {
            var line = inputParts[i].ToCharArray();
            var stackIndex = 0;
            for (int j = 1; j < line.Length; j += 4)
            {
                var crate = line[j].ToString();
                if (!string.IsNullOrWhiteSpace(crate))
                {
                    stacks[stackIndex].Push(crate);
                }
                stackIndex++;
            }
        }

        for (int i = lineOfStackDefinition + 1; i < inputParts.Length; i++)
        {
            var line = inputParts[i]
                .Replace("move", "")
                .Replace("from", "")
                .Replace("to", "")
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var amount = line[0];
            var stackIdFrom = line[1] - 1;
            var stackIdTo = line[2] - 1;

            var stackFrom = stacks[stackIdFrom];
            var stackTo = stacks[stackIdTo];

            var tempStack = new Stack<string>();
            for (int j = 1; j <= amount; j++)
            {
                tempStack.Push(stackFrom.Pop());
            }
            for (int j = 1; j <= amount; j++)
            {
                stackTo.Push(tempStack.Pop());
            }
        }

        var stringBuilder = new StringBuilder();
        foreach (var stack in stacks)
        {
            stringBuilder.Append(stack.Pop());
        }

        return new ValueTask<string>(stringBuilder.ToString());
    }
}
