namespace AdventOfCode2022.Tests;

public class Day12Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    Sabqponm
                    abcryxxl
                    accszExk
                    acctuvwj
                    abdefghi
                    """;
        var systemUnderTest = new Day12(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("31");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    Sabqponm
                    abcryxxl
                    accszExk
                    acctuvwj
                    abdefghi
                    """;
        var systemUnderTest = new Day12(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("29");
    }
}
