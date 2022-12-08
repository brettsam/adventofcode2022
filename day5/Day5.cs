public static class Day5
{
    private static void ParseLine(Stack<char>[] stacks, string line)
    {
        for (int i = 0; i < stacks.Length; i++)
        {
            stacks[i] ??= new Stack<char>();

            var c = line[(i * 4) + 1];
            if (c != ' ')
            {
                stacks[i].Push(c);
            }
        }
    }

    public static void Part1()
    {
        int stackCount = 9;
        Stack<char>[] stacks = new Stack<char>[stackCount];
        bool stacksComplete = false;

        foreach (var line in File.ReadAllLines("Day5/input.txt"))
        {
            if (line.Length < 1)
            {
                continue;
            }

            // done with the initial stack parsing
            if (line[1] == '1')
            {
                stacksComplete = true;

                for (int i = 0; i < stacks.Length; i++)
                {
                    stacks[i] = new Stack<char>(stacks[i]);
                }
                continue;
            }

            if (!stacksComplete)
            {
                ParseLine(stacks, line);
                continue;
            }

            // move 1 from 2 to 1
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int move = int.Parse(parts[1]);
            int from = int.Parse(parts[3]);
            int to = int.Parse(parts[5]);

            for (int m = 0; m < move; m++)
            {
                var c = stacks[from - 1].Pop();
                stacks[to - 1].Push(c);
            }
        }

        string tops = string.Empty;

        for (int i = 0; i < stacks.Length; i++)
        {
            tops += stacks[i].Peek();
        }

        Console.WriteLine(tops);
    }

    public static void Part2()
    {
        int stackCount = 9;
        Stack<char>[] stacks = new Stack<char>[stackCount];
        bool stacksComplete = false;

        foreach (var line in File.ReadAllLines("Day5/input.txt"))
        {
            if (line.Length < 1)
            {
                continue;
            }

            // done with the initial stack parsing
            if (line[1] == '1')
            {
                stacksComplete = true;

                for (int i = 0; i < stacks.Length; i++)
                {
                    stacks[i] = new Stack<char>(stacks[i]);
                }
                continue;
            }

            if (!stacksComplete)
            {
                ParseLine(stacks, line);
                continue;
            }

            // move 1 from 2 to 1
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int move = int.Parse(parts[1]);
            int from = int.Parse(parts[3]);
            int to = int.Parse(parts[5]);

            Stack<char> tempStack = new Stack<char>();
            for (int m = 0; m < move; m++)
            {
                var c = stacks[from - 1].Pop();
                tempStack.Push(c);

                if (m == move - 1)
                {
                    while(tempStack.TryPop(out char tempC))
                    {
                        stacks[to - 1].Push(tempC);
                    }
                }
            }
        }

        string tops = string.Empty;

        for (int i = 0; i < stacks.Length; i++)
        {
            tops += stacks[i].Peek();
        }

        Console.WriteLine(tops);
    }
}