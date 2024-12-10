using AoCHelper;
using System.Drawing;

namespace AdventOfCode2022;

public class Day12 : BaseDay
{
    private readonly string _input;

    public Day12()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day12(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        Node startingNode = null!;
        Node destinationNode = null!;
        var lines = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var map = new Node[lines.Length, lines[0].Length];
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                var node = new Node
                {
                    Name = lines[i][j],
                    Point = new Point(i, j),
                };
                map[i, j] = node;
                if (node.Name == 'S')
                {
                    startingNode = node;
                }
                else if (node.Name == 'E')
                {
                    destinationNode = node;
                }
            }
        }

        MapConnections(lines, map);

        int startToEndCost = Dijkstra(startingNode, destinationNode);

        return new ValueTask<string>(startToEndCost.ToString());
    }

    private static int Dijkstra(Node startingNode, Node destinationNode)
    {
        var queue = new List<Node>
        {
            startingNode
        };
        var startToEndCost = int.MaxValue;
        startingNode.MinCostToStart = 0;

        while (queue.Count > 0)
        {
            queue = queue.OrderBy(x => x.MinCostToStart).ToList();
            var node = queue[0];
            queue.Remove(node);
            foreach (var connectedNode in node.Connections)
            {
                if (connectedNode.Visited)
                {
                    continue;
                }
                if (connectedNode.MinCostToStart is null
                    || node.MinCostToStart + 1 < connectedNode.MinCostToStart && node.MinCostToStart + 1 < startToEndCost)
                {
                    connectedNode.MinCostToStart = node.MinCostToStart + 1;
                    connectedNode.NearestToStart = node;
                    if (!queue.Contains(connectedNode))
                    {
                        queue.Add(connectedNode);
                    }
                }

            }
            node.Visited = true;
            if (node == destinationNode)
            {
                startToEndCost = node.MinCostToStart!.Value;
            }
        }

        return startToEndCost;
    }

    private static void MapConnections(string[] lines, Node[,] map)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                var node = map[i, j];
                if (j - 1 >= 0)
                {
                    var leftNode = map[i, j - 1];
                    if (leftNode.Elevation - node.Elevation <= 1)
                    {
                        node.Connections.Add(leftNode);
                    }
                }
                if (j + 1 < lines[i].Length)
                {
                    var rightNode = map[i, j + 1];
                    if (rightNode.Elevation - node.Elevation <= 1)
                    {
                        node.Connections.Add(rightNode);
                    }
                }
                if (i - 1 >= 0)
                {
                    var upNode = map[i - 1, j];
                    if (upNode.Elevation - node.Elevation <= 1)
                    {
                        node.Connections.Add(upNode);
                    }
                }
                if (i + 1 < lines.Length)
                {
                    var downNode = map[i + 1, j];
                    if (downNode.Elevation - node.Elevation <= 1)
                    {
                        node.Connections.Add(downNode);
                    }
                }
            }
        }
    }

    public override ValueTask<string> Solve_2()
    {
        List<Node> nodes = new List<Node>();
        List<Node> startingNodes = new List<Node>();
        Node destinationNode = null!;
        var lines = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var map = new Node[lines.Length, lines[0].Length];
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                var node = new Node
                {
                    Name = lines[i][j],
                    Point = new Point(i, j),
                };
                map[i, j] = node;
                if (node.Elevation == 'a')
                {
                    startingNodes.Add(node);
                }
                if (node.Name == 'E')
                {
                    destinationNode = node;
                }
                nodes.Add(node);
            }
        }

        MapConnections(lines, map);

        var minStepsRequired = int.MaxValue;
        foreach (var startingNode in startingNodes)
        {
            var steps = Dijkstra(startingNode, destinationNode);
            minStepsRequired = Math.Min(minStepsRequired, steps);
            nodes = ResetNodes(nodes);
        }

        return new ValueTask<string>(minStepsRequired.ToString());
    }

    private static List<Node> ResetNodes(List<Node> nodes)
    {
        foreach (Node node in nodes)
        {
            node.MinCostToStart = null;
            node.NearestToStart = null;
            node.Visited = false;
        }

        return nodes;
    }

    class Node
    {
        public char Name { get; set; }

        public char Elevation
            => Name switch
            {
                'S' => 'a',
                'E' => 'z',
                _ => Name
            };

        public Point Point { get; set; }

        public List<Node> Connections { get; set; } = [];

        public int? MinCostToStart { get; set; }

        public Node? NearestToStart { get; set; }

        public bool Visited { get; set; }
    }
}
