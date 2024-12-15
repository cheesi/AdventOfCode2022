namespace AdventOfCode2022.Tests;

public class Day13Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    [1,1,3,1,1]
                    [1,1,5,1,1]

                    [[1],[2,3,4]]
                    [[1],4]

                    [9]
                    [[8,7,6]]

                    [[4,4],4,4]
                    [[4,4],4,4,4]

                    [7,7,7,7]
                    [7,7,7]

                    []
                    [3]

                    [[[]]]
                    [[]]

                    [1,[2,[3,[4,[5,6,7]]]],8,9]
                    [1,[2,[3,[4,[5,6,0]]]],8,9]
                    """;
        var systemUnderTest = new Day13(input);

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
                    [1,1,3,1,1]
                    [1,1,5,1,1]
                    
                    [[1],[2,3,4]]
                    [[1],4]
                    
                    [9]
                    [[8,7,6]]
                    
                    [[4,4],4,4]
                    [[4,4],4,4,4]
                    
                    [7,7,7,7]
                    [7,7,7]
                    
                    []
                    [3]
                    
                    [[[]]]
                    [[]]
                    
                    [1,[2,[3,[4,[5,6,7]]]],8,9]
                    [1,[2,[3,[4,[5,6,0]]]],8,9]
                    """;
        var systemUnderTest = new Day13(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("140");
    }
}
