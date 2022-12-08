public static class Day1
{
    public static void Part1()
    {
        int max = 0;
        int cur = 0;
        foreach(var line in File.ReadAllLines("Day1/input.txt"))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (cur > max)
                {
                    max = cur;
                }

                cur = 0;
                continue;
            }

            cur += int.Parse(line);
        }
        Console.WriteLine(max);
    }

    public static void Part2()
    {
        List<int> top3 = new() {0, 0, 0};
        int cur = 0;
        foreach(var line in File.ReadAllLines("Day1/input.txt"))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                top3.Add(cur);
                top3 = top3.OrderDescending().Take(3).ToList();

                cur = 0;
                continue;
            }

            cur += int.Parse(line);
        }
        Console.WriteLine(top3.Sum());
    }
}