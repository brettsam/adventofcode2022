public static class Day3
{
    public static void Part1()
    {
        int total = 0;
        foreach(var line in File.ReadAllLines("Day3/input.txt"))
        {
            var len = line.Length;
            var first = line.Substring(0, len /2);
            var second = line.Substring(len / 2);

            var intersection = first.Intersect(second);
            foreach (var c in intersection)
            {
                int index = (int)c % 32;
                
                if (char.IsUpper(c))
                {
                    index += 26;
                }

                total += index;
            }
        }

        Console.WriteLine(total);
    }

    public static void Part2()
    {
        List<string> groups = new List<string>();

        int total = 0;
        foreach(var line in File.ReadAllLines("Day3/input.txt"))
        {
            groups.Add(line);

            if (groups.Count() < 3)
            {
                continue;
            }

            var intersection = groups[0].Intersect(groups[1]).Intersect(groups[2]);
            foreach (var c in intersection)
            {
                int index = (int)c % 32;
                
                if (char.IsUpper(c))
                {
                    index += 26;
                }

                total += index;
            }

            groups.Clear();
        }

        Console.WriteLine(total);
    }
}