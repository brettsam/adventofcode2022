public static class Day2
{
    public static void Part1()
    {
        // rock, paper scissors
        string opp = "ABC";
        string me = "XYZ";

        int total = 0;
        foreach(var line in File.ReadAllLines("Day2/input.txt"))
        {
            char first = line.First();
            char last = line.Last();
            int oi = opp.IndexOf(first);
            int mi = me.IndexOf(last);

            total += mi + 1;
            if (oi == mi)
            {
                total += 3;
                continue;
            }

            if (oi == 0 && mi == 1 ||
                oi == 1 && mi == 2 || 
                oi == 2 && mi == 0)
            {
                total += 6;
                continue;
            }
        }

        Console.WriteLine(total);
    }

    public static void Part2()
    {
         // rock, paper scissors
        string opp = "ABC";

        // lose, draw, win
        string me = "XYZ";

        int total = 0;
        foreach(var line in File.ReadAllLines("Day2/input.txt"))
        {
            char first = line.First();
            char last = line.Last();
            int oi = opp.IndexOf(first);
            int mi = me.IndexOf(last);

            total += mi * 3;
            if (last == 'Y')
            {
                total += oi + 1;
                continue;
            }

            if (last == 'Z')
            {   
                // to win, take opp and add 1
                total += oi++ % 3;
                continue;
            }

            if (last == 'X')
            {
                // to lose, take opp and sub 1
                total += oi-- % 3;
                continue;
            }
        }

        Console.WriteLine(total);
    }
}