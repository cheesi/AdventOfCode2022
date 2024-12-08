using AdventOfCode2022;

namespace AdventOfCode2022.Tests;

public class Day03Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    vJrwpWtwJgWrhcsFMMfFFhFp
                    jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                    PmmdzqPrVvPwwTWBwg
                    wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                    ttgJtRGJQctTZtZT
                    CrZsJsPPZsGzwwsLwLmpwMDw
                    """;
        var systemUnderTest = new Day03(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("157");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    vJrwpWtwJgWrhcsFMMfFFhFp
                    jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                    PmmdzqPrVvPwwTWBwg
                    wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                    ttgJtRGJQctTZtZT
                    CrZsJsPPZsGzwwsLwLmpwMDw
                    """;
        var systemUnderTest = new Day03(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("70");
    }
}
