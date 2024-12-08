using AdventOfCode2022;

namespace AdventOfCode2022.Tests;

public class Day01Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    1000
                    2000
                    3000
                    
                    4000
                    
                    5000
                    6000
                    
                    7000
                    8000
                    9000
                    
                    10000
                    """;
        var systemUnderTest = new Day01(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("24000");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    1000
                    2000
                    3000
                    
                    4000
                    
                    5000
                    6000
                    
                    7000
                    8000
                    9000
                    
                    10000
                    """;
        var systemUnderTest = new Day01(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("45000");
    }
}
