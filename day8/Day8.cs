public static class Day8
{
    private static List<List<int>> _map = new List<List<int>>();

    public static void Part1()
    {
        int total = 0;

        foreach (var line in File.ReadAllLines("Day8/input.txt"))
        {
            var newLine = new List<int>();
            foreach (var c in line)
            {
                newLine.Add(int.Parse(c.ToString()));
            }
            _map.Add(newLine);
        }

        int rows = _map.Count();
        int cols = _map[0].Count();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (!IsHiddenToLeft(r,c))
                {
                    total++;
                    continue;
                }

                if (!IsHiddenToRight(r,c))
                {
                    total++;
                    continue;
                }

                if (!IsHiddenUp(r,c))
                {
                    total++;
                    continue;
                }

                if (!IsHiddenDown(r,c))
                {
                    total++;
                    continue;
                }
            }
        }

        Console.WriteLine(total);
    }

    private static bool IsHiddenUp(int r, int c)
    {
        int cur = _map[r][c];

        for (int p = r - 1; p >= 0; p--)
        {
            var l = _map[p][c];
            if (l >= cur)
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsHiddenToLeft(int r, int c)
    {
        int cur = _map[r][c];

        for (int p = c - 1; p >= 0; p--)
        {
            var l = _map[r][p];
            if (l >= cur)
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsHiddenToRight(int r, int c)
    {
        int cur = _map[r][c];
        int cols = _map[0].Count();

        for (int p = c + 1; p < cols; p++)
        {
            var l = _map[r][p];
            if (l >= cur)
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsHiddenDown(int r, int c)
    {
        int cur = _map[r][c];
        int rows = _map.Count();

        for (int p = r + 1; p < rows; p++)
        {
            var l = _map[p][c];
            if (l >= cur)
            {
                return true;
            }
        }
        return false;
    }

    public static void Part2()
    {
         int total = 0;

        foreach (var line in File.ReadAllLines("Day8/input.txt"))
        {
            var newLine = new List<int>();
            foreach (var c in line)
            {
                newLine.Add(int.Parse(c.ToString()));
            }
            _map.Add(newLine);
        }

        int rows = _map.Count();
        int cols = _map[0].Count();
        int bestView = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                int left = CalculateLeft(r, c);
                int right = CalculateRight(r, c);
                int up = CalculateUp(r, c);
                int down = CalculateDown(r, c);

                var view = left * right * up * down;
                if (view > bestView)
                {
                    bestView = view;
                }
            }
        }

        Console.WriteLine(bestView);
    }

    private static int CalculateUp(int r, int c)
    {
        int cur = _map[r][c];
        int view = 0;

        for (int p = r - 1; p >= 0; p--)
        {
            view++;

            var l = _map[p][c];
            if (l >= cur)
            {
                break;
            }
        }

        return view;
    }

    private static int CalculateLeft(int r, int c)
    {
        int cur = _map[r][c];
        int view = 0;

        for (int p = c - 1; p >= 0; p--)
        {
            view++;

            var l = _map[r][p];
            if (l >= cur)
            {
                break;
            }
        }
        return view;
    }

    private static int CalculateRight(int r, int c)
    {
        int cur = _map[r][c];
        int cols = _map[0].Count();
        int view = 0;

        for (int p = c + 1; p < cols; p++)
        {
            view++;

            var l = _map[r][p];
            if (l >= cur)
            {
                break;
            }
        }
        return view;
    }

    private static int CalculateDown(int r, int c)
    {
        int cur = _map[r][c];
        int rows = _map.Count();
        int view = 0;

        for (int p = r + 1; p < rows; p++)
        {
            view++;

            var l = _map[p][c];
            if (l >= cur)
            {
                break;
            }
        }
        return view;
    }
}