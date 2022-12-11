public static class Day6
{
    public static void Part1()
    {
        int total = 0;

        foreach (var line in File.ReadAllLines("Day6/input.txt"))
        {
            var window = new SlidingWindow<char>(line);
            int iters = 0;
            window.Evaluate(4, s => 
            {
                iters++;
                return s.Distinct().Count() == 4;
            });
            total += iters + 3;
        }

        Console.WriteLine(total);
    }

    public static void Part2()
    {
        int total = 0;

        foreach (var line in File.ReadAllLines("Day6/input.txt"))
        {
            var window = new SlidingWindow<char>(line);
            int iters = 0;
            window.Evaluate(14, s => 
            {
                iters++;
                return s.Distinct().Count() == 14;
            });
            total += iters + 13;
        }

        Console.WriteLine(total);
    }
}