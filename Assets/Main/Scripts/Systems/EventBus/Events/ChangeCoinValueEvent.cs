
public struct ChangeCoinValueEvent : IEvent
{
    public int NewValueCoin;
    public bool IsShowIncome;
    public int NewIncomeCoinValue;

    public ChangeCoinValueEvent(int newValueCoin, bool isShowIncome = false, int newIncomeCoinValue = 0)
    {
        NewValueCoin = newValueCoin;
        IsShowIncome = isShowIncome;
        NewIncomeCoinValue = newIncomeCoinValue;
    }
}
