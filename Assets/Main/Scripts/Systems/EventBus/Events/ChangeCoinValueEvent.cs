
public struct ChangeCoinValueEvent : IEvent
{
    public int NewValueCoin;

    public ChangeCoinValueEvent(int newValueCoin)
    {
        NewValueCoin = newValueCoin;
    }
}
