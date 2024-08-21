namespace IssueTrackerApi.Controllers;

public class HitCounter
{
    private int _hitCounter;

    public void Increment()
    {
        _hitCounter++;
    }

    public int GetHitCounter()
    {
        return _hitCounter;
    }
}
