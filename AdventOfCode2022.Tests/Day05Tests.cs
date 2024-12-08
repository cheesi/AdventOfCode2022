using AdventOfCode2022;

namespace AdventOfCode2022.Tests;

public class Day05Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                        [D]    
                    [N] [C]    
                    [Z] [M] [P]
                     1   2   3 
                    
                    move 1 from 2 to 1
                    move 3 from 1 to 3
                    move 2 from 2 to 1
                    move 1 from 1 to 2
                    """;
        var systemUnderTest = new Day05(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("CMZ");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                        [D]    
                    [N] [C]    
                    [Z] [M] [P]
                     1   2   3 
                    
                    move 1 from 2 to 1
                    move 3 from 1 to 3
                    move 2 from 2 to 1
                    move 1 from 1 to 2
                    """;
        var systemUnderTest = new Day05(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("MCD");
    }
}
