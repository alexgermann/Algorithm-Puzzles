#region Test Cases
// Original test case
//    (0, 1, 5),
//    (0, 2, 3),
//    (0, 5, 4),
//    (1, 3, 8),
//    (2, 3, 1),
//    (3, 5, 10),
//    (3, 4, 5)
// Expected: 9
List<Tuple<int, int, int>> inputArray =
[
    new Tuple<int, int, int>(0, 1, 5),
    new Tuple<int, int, int>(0, 2, 3),
    new Tuple<int, int, int>(0, 5, 4),
    new Tuple<int, int, int>(1, 3, 8),
    new Tuple<int, int, int>(2, 3, 1),
    new Tuple<int, int, int>(3, 5, 10),
    new Tuple<int, int, int>(3, 4, 5)
];
TestMinimumMessageTime(inputArray);

// Make 5 reachable faster from source 3 than source 0
// Expected: 14
inputArray = [
    new Tuple<int, int, int>(0, 1, 5),
    new Tuple<int, int, int>(0, 2, 3),
    new Tuple<int, int, int>(0, 5, 20),
    new Tuple<int, int, int>(1, 3, 8),
    new Tuple<int, int, int>(2, 3, 1),
    new Tuple<int, int, int>(3, 5, 10),
    new Tuple<int, int, int>(3, 4, 5),
];
TestMinimumMessageTime(inputArray);

// Generate inputArray with 1000 elements
// Expected: 1000
inputArray = new List<Tuple<int, int, int>>();
for (int i = 0; i < 1000; i++)
{
    inputArray.Add(new Tuple<int, int, int>(i, i + 1, 1));
}
TestMinimumMessageTime(inputArray);




void TestMinimumMessageTime(List<Tuple<int, int, int>> inputArray)
{
    Console.WriteLine("Input: ");
    foreach (var item in inputArray)
    {
        Console.WriteLine($"({item.Item1}, {item.Item2}, {item.Item3})");
    }
    Console.WriteLine($"Output: {GetMinimumMessageTime(inputArray)}");
}

#endregion



int GetMinimumMessageTime(List<Tuple<int, int, int>> inputArray)
{
    // Construct list of edges from input
    var edges = new List<Edge>();
    foreach (var edge in inputArray)
    {
        edges.Add(new Edge { Source = edge.Item1, Destination = edge.Item2, Time = edge.Item3 });
    }

    // Construct dictionary of nodes with times from edges
    var nodes = new Dictionary<int, int>();
    foreach (var edge in edges)
    {
        nodes.TryAdd(edge.Source, int.MaxValue);
        nodes.TryAdd(edge.Destination, int.MaxValue);
    }

    // Start at 0, count it as visited by default
    var currentNode = 0;
    nodes[currentNode] = 0;
    var nextNode = -1;
    void FollowEdgeToEnd(int currentNode, IEnumerable<Edge> currentEdges)
    {
        foreach (var edge in currentEdges)
        {
            var accumulatedTime = nodes[edge.Source];
            if (accumulatedTime + edge.Time < nodes[edge.Destination])
            {
                nodes[edge.Destination] = accumulatedTime + edge.Time;
                accumulatedTime += edge.Time;
                nextNode = edge.Destination;
                FollowEdgeToEnd(nextNode, edges.Where(x => x.Source == nextNode));
            }
        }
    }
    FollowEdgeToEnd(currentNode, edges);

    return nodes.Values.Max();
}



public class Edge
{
    public int Source { get; set; }
    public int Destination { get; set; }
    public int Time { get; set; }
    public string GetEdgeString()
    {
        return $"Edge: ({Source}, {Destination}, {Time})";
    }
}
