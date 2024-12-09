using AoCHelper;

namespace AdventOfCode2022;

public class Day11 : BaseDay
{
    private readonly string _input;

    public Day11()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day11(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        ParseMonkeys();

        for (int round = 1; round <= 20; round++)
        {
            foreach (var monkey in Monkey.Monkeys)
            {
                for (var i = 0; i < monkey.Items.Count; i++)
                {
                    var originalWorryLevel = monkey.Items[i];
                    var newWorryLevel = monkey.Operation(originalWorryLevel);
                    monkey.Inspections++;
                    var boredWorryLevel = (int)(newWorryLevel / 3f);
                    var targetMonkey = monkey.Test(boredWorryLevel);
                    targetMonkey.Items.Add(boredWorryLevel);
                }
                monkey.Items.Clear();
            }
            //Console.Clear();
            //foreach (var monkey in Monkey.Monkeys)
            //{
            //    Console.WriteLine(monkey.ToString());
            //}
        }

        var monkeys = Monkey.Monkeys.OrderByDescending(x => x.Inspections).Take(2);
        var monkeyBusiness = monkeys.First().Inspections * monkeys.Last().Inspections;

        return new ValueTask<string>(monkeyBusiness.ToString());
    }

    private void ParseMonkeys()
    {
        Monkey.Monkeys.Clear();
        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (line.StartsWith("Monkey"))
            {
                var parts = line.Split([' ', ':'], StringSplitOptions.RemoveEmptyEntries);

                var monkey = new Monkey()
                {
                    Id = int.Parse(parts[1])
                };
                Monkey.Monkeys.Add(monkey);
            }
        }

        Monkey? currentMonkey = null;
        using var stringReader2 = new StringReader(_input);
        while (stringReader2.ReadLine()?.Trim() is { } line)
        {
            if (line.StartsWith("Monkey"))
            {
                var parts = line.Split([' ', ':'], StringSplitOptions.RemoveEmptyEntries);

                currentMonkey = Monkey.Monkeys.First(x => x.Id == int.Parse(parts[1]));
            }
            else if (line.StartsWith("Starting items"))
            {
                var parts = line[16..].Split([' ', ','], StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToList();

                currentMonkey!.Items = parts;
            }
            else if (line.StartsWith("Operation"))
            {
                currentMonkey!.OperationStr = line[17..];
            }
            else if (line.StartsWith("Test"))
            {
                currentMonkey!.TestStr = line[6..];
            }
            else if (line.StartsWith("If true"))
            {
                currentMonkey!.IfTrueStr = line[9..];
            }
            else if (line.StartsWith("If false"))
            {
                currentMonkey!.IfFalseStr = line[10..];
            }
        }
    }

    public override ValueTask<string> Solve_2()
    {
        ParseMonkeys();

        var superMod = 1L;
        foreach (var testNumber in Monkey.Monkeys.Select(x => x.TestNumber))
        {
            superMod *= testNumber;
        }

        for (int round = 1; round <= 10000; round++)
        {
            foreach (var monkey in Monkey.Monkeys)
            {
                for (var i = 0; i < monkey.Items.Count; i++)
                {
                    var originalWorryLevel = monkey.Items[i];
                    var newWorryLevel = monkey.Operation(originalWorryLevel);
                    var reducedWorryLevle = newWorryLevel % superMod;
                    monkey.Inspections++;
                    var targetMonkey = monkey.Test(reducedWorryLevle);
                    targetMonkey.Items.Add(reducedWorryLevle);
                }
                monkey.Items.Clear();
            }
        }

        var monkeys = Monkey.Monkeys.OrderByDescending(x => x.Inspections).Take(2);
        var monkeyBusiness = monkeys.First().Inspections * monkeys.Last().Inspections;

        return new ValueTask<string>(monkeyBusiness.ToString());
    }

    class Monkey
    {
        public static List<Monkey> Monkeys { get; set; } = new List<Monkey>(8);

        public int Id { get; set; }

        public List<long> Items { get; set; } = [];

        public long Inspections { get; set; }

        private string _operationFirstPart;
        public Func<long, long> OperationFirstPart =>
            (old) =>
            {
                if (_operationFirstPart == "old")
                {
                    return old;
                }
                else if (long.TryParse(_operationFirstPart, out var number))
                {
                    return number;
                }
                throw new NotSupportedException();
            };

        private string _operationOperator;
        public Func<long, long, long> OperationOperator =>
            (first, second) =>
            {
                if (_operationOperator == "*")
                {
                    return first * second;
                }
                else if (_operationOperator == "+")
                {
                    return first + second;
                }
                throw new NotSupportedException();
            };

        private string _operationSecondPart;
        public Func<long, long> OperationSecondPart =>
            (old) =>
            {
                if (_operationSecondPart == "old")
                {
                    return old;
                }
                else if (long.TryParse(_operationSecondPart, out var number))
                {
                    return number;
                }
                throw new NotSupportedException();
            };

        public string OperationStr
        {
            get => string.Join(' ', _operationFirstPart, _operationOperator, _operationSecondPart);
            set
            {
                var parts = value.Split(' ');
                _operationFirstPart = parts[0];
                _operationOperator = parts[1];
                _operationSecondPart = parts[2];
            }
        }

        public Func<long, long> Operation =>
            old => OperationOperator(OperationFirstPart(old), OperationSecondPart(old));

        private string _testNumber;
        public long TestNumber => long.Parse(_testNumber);

        public string TestStr
        {
            get => string.Join(' ', _testOperator, "by", _testNumber);
            set
            {
                var parts = value.Split(' ');
                _testOperator = parts[0];
                _testNumber = parts[2];
            }
        }

        private string _testOperator;
        public Func<long, long, bool> TestOperator =>
            (testValue, byValue) =>
            {
                if (_testOperator == "divisible")
                {
                    return testValue % byValue == 0;
                }
                throw new NotSupportedException();
            };

        private Monkey _ifTrueMonkey;
        public string IfTrueStr
        {
            get => $"If true: throw to monkey {_ifTrueMonkey.Id}";
            set
            {
                var parts = value.Split(' ');
                _ifTrueMonkey = Monkeys[int.Parse(parts[3])];
            }
        }

        private Monkey _ifFalseMonkey;
        public string IfFalseStr
        {
            get => $"If false: throw to monkey {_ifFalseMonkey.Id}";
            set
            {
                var parts = value.Split(' ');
                _ifFalseMonkey = Monkeys[int.Parse(parts[3])];
            }
        }

        public Func<long, Monkey> Test =>
            (testValue) => TestOperator(testValue, TestNumber) ? _ifTrueMonkey : _ifFalseMonkey;

        public override string ToString()
        {
            return $"Monkey {Id}: {string.Join(", ", Items)}";
        }
    }
}
