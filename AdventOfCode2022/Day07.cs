using System.Collections;
using AoCHelper;
using Spectre.Console;

namespace AdventOfCode2022;

public class Day07 : BaseDay
{
    private readonly string _input;

    public Day07()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day07(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        TreeNode? currentNode = null;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (line.StartsWith("$ cd "))
            {
                var targetNode = line[5..];
                if (targetNode is "..")
                {
                    currentNode = currentNode.Parent;
                }
                else
                {
                    var node = new TreeNode()
                    {
                        Name = targetNode,
                        Parent = currentNode,
                        Type = NodeType.Directory
                    };
                    currentNode?.Children.Add(node);
                    currentNode = node;
                }
            }
            else if (line.StartsWith("dir "))
            {

            }
            else if (line.StartsWith("$ ls"))
            {

            }
            else
            {
                var fileEntryParts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var fileSize = int.Parse(fileEntryParts[0]);
                var fileName = fileEntryParts[1];

                var node = new TreeNode()
                {
                    Name = fileName,
                    Parent = currentNode,
                    Type = NodeType.File,
                    Size = fileSize
                };
                currentNode!.Children.Add(node);
            }
        }

        while (currentNode.Parent is not null)
        {
            currentNode = currentNode.Parent;
        }

        long totalSizeOver10000 = 0;
        currentNode.Traverse((node) =>
        {
            if (node.Type == NodeType.Directory)
            {
                var size = node.Size;
                if (size < 100_000)
                {
                    totalSizeOver10000 += node.Size;
                }
            }
        });

        return new ValueTask<string>(totalSizeOver10000.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        TreeNode? currentNode = null;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (line.StartsWith("$ cd "))
            {
                var targetNode = line[5..];
                if (targetNode is "..")
                {
                    currentNode = currentNode.Parent;
                }
                else
                {
                    var node = new TreeNode()
                    {
                        Name = targetNode,
                        Parent = currentNode,
                        Type = NodeType.Directory
                    };
                    currentNode?.Children.Add(node);
                    currentNode = node;
                }
            }
            else if (line.StartsWith("dir "))
            {

            }
            else if (line.StartsWith("$ ls"))
            {

            }
            else
            {
                var fileEntryParts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var fileSize = int.Parse(fileEntryParts[0]);
                var fileName = fileEntryParts[1];

                var node = new TreeNode()
                {
                    Name = fileName,
                    Parent = currentNode,
                    Type = NodeType.File,
                    Size = fileSize
                };
                currentNode!.Children.Add(node);
            }
        }

        while (currentNode.Parent is not null)
        {
            currentNode = currentNode.Parent;
        }

        long diskSpaceNeeded = 30000000 - 21618835;
        long smallestDictionary = long.MaxValue;
        currentNode.Traverse((node) =>
        {
            if (node.Type == NodeType.Directory)
            {
                var size = node.Size;
                if (size >= diskSpaceNeeded)
                {
                    smallestDictionary = Math.Min(smallestDictionary, size);
                }
            }
        });

        return new ValueTask<string>(smallestDictionary.ToString());
    }

    class TreeNode
    {
        public string Name { get; set; }

        public TreeNode? Parent { get; set; }

        public NodeType Type { get; set; }

        private long _size;
        public long Size
        {
            get {
                if (Type == NodeType.File)
                {
                    return _size;
                }
                else
                {
                    return Children.Sum(c => c.Size);
                }
            }
            set {
                if (Type == NodeType.File)
                {
                    _size = value;
                }
            }
        }

        public List<TreeNode> Children { get; set; } = [];

        public void Traverse(Action<TreeNode> action)
        {
            action(this);
            foreach (var child in Children)
                child.Traverse(action);
        }
    }

    enum NodeType
    {
        Directory,
        File
    }
}
