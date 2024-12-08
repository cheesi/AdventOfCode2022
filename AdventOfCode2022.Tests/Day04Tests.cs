using AdventOfCode2022;

namespace AdventOfCode2022.Tests;

public class Day04Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    2-4,6-8
                    2-3,4-5
                    5-7,7-9
                    2-8,3-7
                    6-6,4-6
                    2-6,4-8
                    """;
        var systemUnderTest = new Day04(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("2");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    2-4,6-8
                    2-3,4-5
                    5-7,7-9
                    2-8,3-7
                    6-6,4-6
                    2-6,4-8
                    """;
        var systemUnderTest = new Day04(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("4");
    }
}
