namespace AdventOfCode2022.Tests;

public class Day14Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    498,4 -> 498,6 -> 496,6
                    503,4 -> 502,4 -> 502,9 -> 494,9
                    """;
        var systemUnderTest = new Day14(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("24");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    498,4 -> 498,6 -> 496,6
                    503,4 -> 502,4 -> 502,9 -> 494,9
                    """;
        var systemUnderTest = new Day14(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("93");
    }
}
