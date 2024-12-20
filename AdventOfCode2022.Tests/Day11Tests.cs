namespace AdventOfCode2022.Tests;

public class Day11Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    Monkey 0:
                      Starting items: 79, 98
                      Operation: new = old * 19
                      Test: divisible by 23
                        If true: throw to monkey 2
                        If false: throw to monkey 3

                    Monkey 1:
                      Starting items: 54, 65, 75, 74
                      Operation: new = old + 6
                      Test: divisible by 19
                        If true: throw to monkey 2
                        If false: throw to monkey 0

                    Monkey 2:
                      Starting items: 79, 60, 97
                      Operation: new = old * old
                      Test: divisible by 13
                        If true: throw to monkey 1
                        If false: throw to monkey 3

                    Monkey 3:
                      Starting items: 74
                      Operation: new = old + 3
                      Test: divisible by 17
                        If true: throw to monkey 0
                        If false: throw to monkey 1
                    """;
        var systemUnderTest = new Day11(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("10605");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    Monkey 0:
                      Starting items: 79, 98
                      Operation: new = old * 19
                      Test: divisible by 23
                        If true: throw to monkey 2
                        If false: throw to monkey 3

                    Monkey 1:
                      Starting items: 54, 65, 75, 74
                      Operation: new = old + 6
                      Test: divisible by 19
                        If true: throw to monkey 2
                        If false: throw to monkey 0

                    Monkey 2:
                      Starting items: 79, 60, 97
                      Operation: new = old * old
                      Test: divisible by 13
                        If true: throw to monkey 1
                        If false: throw to monkey 3

                    Monkey 3:
                      Starting items: 74
                      Operation: new = old + 3
                      Test: divisible by 17
                        If true: throw to monkey 0
                        If false: throw to monkey 1
                    """;
        var systemUnderTest = new Day11(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("2713310158");
    }
}
