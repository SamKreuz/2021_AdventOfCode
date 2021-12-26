using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    internal class altsol_02
    {
        PartOne(heightmap);
        PartTwo(heightmap);

        void PartOne(int[,] map)
        {
            int xmax = map.GetLength(0);
            int ymax = map.GetLength(1);

            List<int> lowPoints = new();

            for (int y = 0; y < ymax; y++)
            {
                for (int x = 0; x < xmax; x++)
                {
                    int currentNumber = map[x, y];
                    List<(int, int)> proximity = new List<(int, int)> { (0, -1), (-1, 0), (1, 0), (0, 1) };
                    List<int> surrounding = new();
                    foreach (var (p1, p2) in proximity)
                    {
                        try
                        {
                            surrounding.Add(map[x + p1, y + p2]);
                        }
                        catch (IndexOutOfRangeException) { }
                    }
                    if (currentNumber < surrounding.Min())
                        lowPoints.Add(currentNumber);
                }
            }

            BigInteger total = lowPoints.Sum() + (lowPoints.Count);
            Console.WriteLine($"Part One. The total is {total}.");
        }

        void PartTwo(int[,] map)
        {

            int xmax = map.GetLength(0);
            int ymax = map.GetLength(1);

            List<(int p1, int p2)> lowPoints = new();
            for (int y = 0; y < ymax; y++)
            {
                for (int x = 0; x < xmax; x++)
                {
                    int currentNumber = map[x, y];
                    List<(int, int)> proximity = new List<(int, int)> { (0, -1), (-1, 0), (1, 0), (0, 1) };
                    List<int> surrounding = new();
                    foreach (var (p1, p2) in proximity)
                    {
                        try
                        {
                            surrounding.Add(map[x + p1, y + p2]);
                        }
                        catch (IndexOutOfRangeException)
                        { }
                    }
                    if (currentNumber < surrounding.Min())
                    {
                        lowPoints.Add((x, y));
                    }
                }
            }

            List<(int size, (int px, int py))> lowPointSizes = new();
            foreach ((int lpx, int lpy) lp in lowPoints)
            {
                HashSet<(int, int)> done = new();
                List<(int, int)> neighbors = GetValidNeighbors(map, lp);
                List<(int, int)> stack = new();
                foreach ((int, int) lpn in neighbors)
                {
                    if (!done.Contains(lpn))
                        stack.Add(lpn);
                }
                while (stack.Count > 0)
                {
                    (int, int) p = stack.Last();
                    stack.Remove(p);

                    List<(int, int)> newNeighbors = GetValidNeighbors(map, p);
                    foreach ((int, int) neighbor in newNeighbors)
                    {
                        if (!done.Contains(neighbor))
                            stack.Add(neighbor);
                    }
                    done.Add(p);
                }
                lowPointSizes.Add((done.Count, lp));
            }
            lowPointSizes.Sort((s, t) => t.size.CompareTo(s.size));
            int productOfThreeLargest = lowPointSizes[0].size * lowPointSizes[1].size * lowPointSizes[2].size;
            Console.WriteLine($"Part Two.  The product of the three largest basins is {productOfThreeLargest}.");

        }

        List<(int, int)> GetValidNeighbors(int[,] map, (int x, int y) sp)
        {
            List<(int, int)> proximity = new List<(int, int)> { (0, -1), (-1, 0), (1, 0), (0, 1) };
            List<(int, int)> gn = new();
            foreach (var (p1, p2) in proximity)
            {
                try
                {
                    if (map[sp.x + p1, sp.y + p2] < 9)
                        gn.Add((sp.x + p1, sp.y + p2));
                }
                catch (IndexOutOfRangeException) { }
            }
            return gn;
        }
    }
}
