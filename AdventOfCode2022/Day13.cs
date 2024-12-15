using AoCHelper;

namespace AdventOfCode2022;

public class Day13 : BaseDay
{
    private readonly string _input;

    public Day13()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day13(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var packets = new Dictionary<int, (ListOrInteger left, ListOrInteger right)>();

        ListOrInteger? first = null;
        var counter = 1;
        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (line != "")
            {
                if (first is null)
                {
                    first = ParsePacket(line);
                }
                else
                {
                    var second = ParsePacket(line);
                    packets.Add(counter, (first, second));

                    first = null;
                    counter++;
                }
            }
        }

        var indices = packets.Where(packet
                => IsInOrder(packet.Value.left, packet.Value.right)!.Value)
            .Select(packet => packet.Key)
            .ToList();

        return new ValueTask<string>(indices.Sum().ToString());
    }

    private ListOrInteger ParsePacket(string line)
    {
        var parsed = new ListOrInteger();
        parsed.List = [];
        line = line[1..^1];
        var chars = line.ToCharArray();

        if (line.Contains('['))
        {
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '[')
                {
                    // find ]
                    var openBracketsCounter = 0;
                    var closingBracketPosition = -1;
                    for (int j = i + 1; j < chars.Length; j++)
                    {
                        if (chars[j] == '[')
                        {
                            openBracketsCounter++;
                        }
                        else if (chars[j] == ']')
                        {
                            if (openBracketsCounter == 0)
                            {
                                closingBracketPosition = j;
                                break;
                            }
                            else
                            {
                                openBracketsCounter--;
                            }
                        }
                    }

                    closingBracketPosition++;
                    parsed.List.Add(ParsePacket(line[i..closingBracketPosition]));
                    i = closingBracketPosition;
                }
                else if (chars[i] == ',')
                {
                    // continue
                }
                else
                {
                    // find [
                    var bracketPosition = -1;
                    for (int j = i + 1; j < chars.Length; j++)
                    {
                        if (chars[j] == '[' || chars[j] == ']')
                        {
                            bracketPosition = j;
                            break;
                        }
                    }

                    if (bracketPosition > -1)
                    {
                        var numbers = ParseNumbers(line[i..bracketPosition]);
                        parsed.List.AddRange(numbers);
                        i = bracketPosition - 1;
                    }
                    else
                    {
                        var end = line.Length;
                        var numbers = ParseNumbers(line[i..end]);
                        parsed.List.AddRange(numbers);
                        i = end - 1;
                    }
                }
            }
        }
        else
        {
            var numbers = ParseNumbers(line);
            parsed.List.AddRange(numbers);
        }

        return parsed;
    }

    private static IEnumerable<ListOrInteger> ParseNumbers(string line)
    {
        return line
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Select(x => new ListOrInteger()
            {
                Integer = x
            });
    }

    private static bool? IsInOrder(ListOrInteger left, ListOrInteger right)
    {
        if (left.IsInteger && right.IsInteger)
        {
            if (left.Integer < right.Integer)
            {
                return true;
            }
            if (left.Integer > right.Integer)
            {
                return false;
            }
            return null;
        }
        else if (left.IsList && right.IsList)
        {
            for (int i = 0; i < left.List!.Count; i++)
            {
                var leftItem = left.List[i];
                if (right.List!.Count - 1 < i)
                {
                    return false;
                }
                var rightItem = right.List![i];
                var isInOrder = IsInOrder(leftItem, rightItem);
                if (isInOrder.HasValue && isInOrder.Value)
                {
                    return true;
                }
                else if (isInOrder.HasValue && !isInOrder.Value)
                {
                    return false;
                }
            }

            if (left.List.Count < right.List!.Count)
            {
                return true;
            }
        }
        else
        {
            if (left.IsInteger)
            {
                left.List = [new ListOrInteger {
                    Integer = left.Integer
                }];
                left.Integer = null;
            }
            if (right.IsInteger)
            {
                right.List = [new ListOrInteger {
                    Integer = right.Integer
                }];
                right.Integer = null;
            }
            return IsInOrder(left, right);
        }

        return null;
    }

    public override ValueTask<string> Solve_2()
    {
        var packets = new List<ListOrInteger>();
        var dividerPacket2 = ParsePacket("[[2]]");
        var dividerPacket6 = ParsePacket("[[6]]");
        packets.Add(dividerPacket2);
        packets.Add(dividerPacket6);

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (line != "")
            {
                var packet = ParsePacket(line);
                packets.Add(packet);
            }
        }

        packets.Sort(new PacketSorter());

        var indexOfDividerPacket2 = packets.IndexOf(dividerPacket2);
        var indexOfDividerPacket6 = packets.IndexOf(dividerPacket6);

        var decoderKey = (indexOfDividerPacket2 + 1) * (indexOfDividerPacket6 + 1);

        return new ValueTask<string>(decoderKey.ToString());
    }

    class PacketSorter : IComparer<ListOrInteger>
    {
        public int Compare(ListOrInteger? x, ListOrInteger? y)
        {
            var result = IsInOrder(x!, y!);
            if (result.HasValue && result.Value)
            {
                return -1;
            }
            else if (result.HasValue && !result.Value)
            {
                return 1;
            }
            return 0;
        }
    }

    class ListOrInteger
    {
        public int? Integer { get; set; }

        public bool IsInteger => Integer is not null;

        public List<ListOrInteger>? List { get; set; }

        public bool IsList => List is not null;
    }
}
