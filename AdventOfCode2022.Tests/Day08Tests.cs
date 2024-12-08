namespace AdventOfCode2022.Tests;

public class Day08Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    30373
                    25512
                    65332
                    33549
                    35390
                    """;
        var systemUnderTest = new Day08(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("21");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    30373
                    25512
                    65332
                    33549
                    35390
                    """;
        var systemUnderTest = new Day08(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("8");
    }
}
