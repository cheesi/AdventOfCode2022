using AdventOfCode2022;

namespace AdventOfCode2022.Tests;

public class Day06Tests
{
    [Fact]
    public async Task Part1_1()
    {
        // Arrange
        var input = """
                    mjqjpqmgbljsphdztnvjfqwrcgsmlb
                    """;
        var systemUnderTest = new Day06(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("7");
    }

    [Fact]
    public async Task Part1_2()
    {
        // Arrange
        var input = """
                    bvwbjplbgvbhsrlpgdmjqwftvncz
                    """;
        var systemUnderTest = new Day06(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("5");
    }

    [Fact]
    public async Task Part1_3()
    {
        // Arrange
        var input = """
                    nppdvjthqldpwncqszvftbrmjlhg
                    """;
        var systemUnderTest = new Day06(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("6");
    }

    [Fact]
    public async Task Part1_4()
    {
        // Arrange
        var input = """
                    nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg
                    """;
        var systemUnderTest = new Day06(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("10");
    }

    [Fact]
    public async Task Part1_5()
    {
        // Arrange
        var input = """
                    zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw
                    """;
        var systemUnderTest = new Day06(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("11");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    mjqjpqmgbljsphdztnvjfqwrcgsmlb
                    """;
        var systemUnderTest = new Day06(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("19");
    }
}
