public static class Day7
{
    public static void Part1()
    {
        int total = 0;
        var builder = new DirectoryBuilder();
        foreach (var line in File.ReadAllLines("Day7/input.txt"))
        {
            builder.ParseCommand(line);
        }
        builder.Print();
        var sums = builder.SumFiles();
        var small = sums.Where(p => p.Value <= 100000);
        total = small.Sum(p => p.Value);
       
        Console.WriteLine(total);
    }

    public static void Part2()
    {
        var builder = new DirectoryBuilder();
        foreach (var line in File.ReadAllLines("Day7/input.txt"))
        {
            builder.ParseCommand(line);
        }
        builder.Print();
        var sums = builder.SumFiles();

        int total = 70000000;
        int needed = 30000000;
        int used = sums["//"];
        int avail = total - used;
        int needToDelete = needed - avail;
        Console.WriteLine($"Total space: {total}");
        Console.WriteLine($"Used:        {used}");
        Console.WriteLine($"Available:   {avail}");
        Console.WriteLine($"Needed:      {needed}");
        Console.WriteLine($"Need to del: {needToDelete}");

        KeyValuePair<string, int> dirToDelete = new KeyValuePair<string, int>("", int.MaxValue);

        foreach(var s in sums)
        {
            if (s.Value >= needToDelete && s.Value < dirToDelete.Value)
            {
                dirToDelete = s;
            }
        }

        Console.WriteLine($"Delete {dirToDelete.Key}: {dirToDelete.Value}");
    }

    private class DirectoryBuilder
    {
        public string _mode;
        public FakeDirectory _root = new FakeDirectory("/", null);
        private FakeDirectory _cur;

        public DirectoryBuilder()
        {
            _cur = _root;
        }

        private bool SetCur(FakeDirectory directory, string dirName)
        {
            if (directory.Name == dirName)
            {
                _cur = directory;
                return true;
            }

            foreach(var dir in directory.Directories)
            {
                if (SetCur(dir, dirName))
                {
                    return true;
                }
            }

            return false;
        }

        public void Print()
        {
            PrintDir(_root, string.Empty);
        }

        private void PrintDir(FakeDirectory subDir, string indent)
        {
            Console.WriteLine($"{indent}- {subDir.Name} (dir)");

            foreach(var d in subDir.Directories)
            {
                PrintDir(d, indent + "  ");
            }

            foreach(var f in subDir.Files)
            {
                Console.WriteLine($"{indent}  - {f.Name} (file, size={f.Size})");
            }
        }

        public IDictionary<string, int> SumFiles()
        {
            var sums = new Dictionary<string, int>();
            SumDir(string.Empty, _root, sums);
            return sums;
        }

        private int SumDir(string fullPath, FakeDirectory dir, IDictionary<string, int> sums)
        {
            int subSum = 0;
            var curPath = $"{fullPath}/{dir.Name}";
            foreach(var subDir in dir.Directories)
            {
                subSum += SumDir(curPath, subDir, sums);
            }

            subSum += dir.Files.Select(f => f.Size).Sum();
            sums[curPath] = subSum;
            return subSum;
        }

        public void ParseCommand(string cmd)
        {
            if (cmd == "$ ls")
            {
                _mode = "ls";
                return;
            }

            if (cmd == "$ cd ..")
            {
                _cur = _cur.Parent;
                return;
            }

            if (cmd.StartsWith("$ cd "))
            {
                var setDir = cmd.Substring(5);
                foreach(var subDir in _cur.Directories)
                {
                    if (subDir.Name == setDir)
                    {
                        _cur = subDir;
                        return;
                    }
                }
            }

            if (_mode == "ls")
            {
                if (cmd.StartsWith("dir "))
                {
                    var dirName = cmd.Substring(4);
                    _cur.AddDirectory(dirName, _cur);
                }
                else 
                {
                    var fileAttr = cmd.Split(" ");
                    _cur.AddFile(fileAttr[1], int.Parse(fileAttr[0]));
                }
            }
        }
    }

    private class FakeDirectory
    {
        private IList<FakeDirectory> _directories = new List<FakeDirectory>();
        private IList<FakeFile> _files = new List<FakeFile>();

        public FakeDirectory(string name, FakeDirectory parent)
        {
            Name = name;
            Parent = parent;
        }

        public string Name { get; }
        public FakeDirectory Parent { get; }
        public IEnumerable<FakeDirectory> Directories => _directories;
        public IEnumerable<FakeFile> Files => _files;

        public FakeDirectory AddDirectory(string name, FakeDirectory parent)
        {
            var d = new FakeDirectory(name, parent);
            _directories.Add(d);
            return d;
        }

        public void AddFile(string name, int size)
        {
            _files.Add(new FakeFile(name, size));
        }
    }

    private class FakeFile
    {
        public FakeFile(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public string Name { get; }
        public int Size { get; }
    }
}