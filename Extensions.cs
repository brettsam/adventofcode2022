public static class Extensions
{
    public static bool Contains(this Range range1, Range range2)
    {
        return range1.Start.Value <= range2.Start.Value && range1.End.Value >= range2.End.Value;  
    }

    public static bool Overlap(this Range range1, Range range2)
    {
        bool r1StartsInR2 = range1.Start.Value >= range2.Start.Value && range1.Start.Value <= range2.End.Value;
        bool r1EndsInR2 = range1.End.Value >= range2.Start.Value && range1.End.Value <= range2.End.Value;

        return r1StartsInR2 || r1EndsInR2;
    }
}