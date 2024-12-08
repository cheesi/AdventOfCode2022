namespace AdventOfCode2022.Tests;

public class Day07Tests
{
    [Fact]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    $ cd /
                    $ ls
                    dir a
                    14848514 b.txt
                    8504156 c.dat
                    dir d
                    $ cd a
                    $ ls
                    dir e
                    29116 f
                    2557 g
                    62596 h.lst
                    $ cd e
                    $ ls
                    584 i
                    $ cd ..
                    $ cd ..
                    $ cd d
                    $ ls
                    4060174 j
                    8033020 d.log
                    5626152 d.ext
                    7214296 k
                    """;
        var systemUnderTest = new Day07(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        result.Should().Be("95437");
    }

    [Fact]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    $ cd /
                    $ ls
                    dir a
                    14848514 b.txt
                    8504156 c.dat
                    dir d
                    $ cd a
                    $ ls
                    dir e
                    29116 f
                    2557 g
                    62596 h.lst
                    $ cd e
                    $ ls
                    584 i
                    $ cd ..
                    $ cd ..
                    $ cd d
                    $ ls
                    4060174 j
                    8033020 d.log
                    5626152 d.ext
                    7214296 k
                    """;
        var systemUnderTest = new Day07(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        result.Should().Be("24933642");
    }
}
