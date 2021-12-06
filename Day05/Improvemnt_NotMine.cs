int Day5(string[] input, bool diagonal)
{
    Dictionary<(int, int), int> map = new();

    foreach (var (x1, y1, x2, y2) in ReadLines())
    {
        if (x1 == x2 || y1 == y2 || diagonal)
        {
            MarkLine(x1, y1, x2, y2);
        }
    }

    return map.Values.Count(x => x >= 2);

    void MarkLine(int x1, int y1, int x2, int y2)
    {
        var stepx = x1 == x2 ? 0 : (x1 < x2 ? 1 : -1);
        var endx = x2 + (stepx == 0 ? 1 : stepx);

        var stepy = y1 == y2 ? 0 : (y1 < y2 ? 1 : -1);
        var endy = y2 + (stepy == 0 ? 1 : stepy);

        for (int x = x1, y = y1; x != endx && y != endy; x += stepx, y += stepy)
        {
            var pos = (x, y);
            map.TryGetValue((x, y), out var value);
            map[pos] = value + 1;
        }
    }

    IEnumerable<(int x1, int y1, int x2, int y2)> ReadLines()
    {
        foreach (var line in input)
        {
            var parts = line.Split(" -> ");
            var co1 = parts[0].Split(',');
            var co2 = parts[1].Split(',');
            yield return (co1[0].ToInt(), co1[1].ToInt(), co2[0].ToInt(), co2[1].ToInt());
        }
    }
}