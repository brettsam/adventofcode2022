public class WrappingInt
{
    int _max = 0;
    int _cur = 0;

    public WrappingInt(int cur, int max)
    {
        _cur = cur;
        _max = max;
    }

    public int CurrentValue => _cur;

    public void Increment()
    {
        _cur++;
        if (_cur > _max)
        {
            _cur = 0;
        }
    }

    public void Decrement()
    {
        _cur--;
        if (_cur < 0)
        {
            _cur = _max;
        }
    }
} 