public static class Day4
{
    public static void Part1()
    {
        int total = 0;
        foreach(var line in File.ReadAllLines("Day4/input.txt"))
        {
            var ranges = line.Split(",");
            var range1Data = ranges[0].Split("-");
            var range2Data =  ranges[1].Split("-");

            var range1 = new Range(int.Parse(range1Data[0]), int.Parse(range1Data[1]));
            var range2 = new Range(int.Parse(range2Data[0]), int.Parse(range2Data[1]));

            if (range1.Contains(range2) || range2.Contains(range1))
            {
                total++;
            }
        }

        Console.WriteLine(total);
    }

    public static void Part2()
    {
        List<string> groups = new List<string>();

        int total = 0;
        foreach(var line in File.ReadAllLines("Day4/input.txt"))
        {
            var ranges = line.Split(",");
            var range1Data = ranges[0].Split("-");
            var range2Data =  ranges[1].Split("-");

            var range1 = new Range(int.Parse(range1Data[0]), int.Parse(range1Data[1]));
            var range2 = new Range(int.Parse(range2Data[0]), int.Parse(range2Data[1]));

            if (range1.Overlap(range2) || range2.Overlap(range1))
            {
                total++;
            }
        }

        Console.WriteLine(total);
    }
}