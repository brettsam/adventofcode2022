public class SlidingWindow<T> 
{
    IEnumerable<T> _data;

    public SlidingWindow(IEnumerable<T> data)
    {
        _data = data;
    }

    public void Evaluate(int windowSize, Func<IEnumerable<T>, bool> evaluate)
    {
        var count = _data.Count();
        for(int i = 0; i < count - windowSize; i++)
        {
            if (evaluate(_data.Skip(i).Take(windowSize)))
            {
                break;
            }
        }
    }
}