namespace AdventOfCode2022.Tests;

public class Day09Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    R 4
                    U 4
                    L 3
                    D 1
                    R 4
                    D 1
                    L 5
                    R 2
                    """;
        var systemUnderTest = new Day09(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("13");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    R 4
                    U 4
                    L 3
                    D 1
                    R 4
                    D 1
                    L 5
                    R 2
                    """;
        var systemUnderTest = new Day09(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("1");
    }


    [Fact]
    public async Task Part2_Big()
    {
        // Arrange
        var input = """
                    R 5
                    U 8
                    L 8
                    D 3
                    R 17
                    D 10
                    L 25
                    U 20
                    """;
        var systemUnderTest = new Day09(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("36");
    }
}
