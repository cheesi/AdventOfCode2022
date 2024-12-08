using AdventOfCode2022;

namespace AdventOfCode2022.Tests;

public class Day02Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    A Y
                    B X
                    C Z
                    """;
        var systemUnderTest = new Day02(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("15");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    A Y
                    B X
                    C Z
                    """;
        var systemUnderTest = new Day02(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("12");
    }
}
