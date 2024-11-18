using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IGameSystem, IEventSubscriber<PressGetButtonEvent>
{
    [SerializeField] private int valueAddsCoin;
    [SerializeField] private int valueAddsCoinExtra;
    [SerializeField] private Chest playerChest;
    private int coinValue = 0;


    public override void Activate()
    {
        this.gameObject.SetActive(true);
    }
    public void Subscribe()
    {
        EventBus.RegisterTo(this as IEventSubscriber<PressGetButtonEvent>);
    }
    public void Unsubscribe()
    {
        EventBus.UnregisterFrom(this as IEventSubscriber<PressGetButtonEvent>);
    }

    public void OnEvent(PressGetButtonEvent eventName)
    {
        AddCoin();
    }

    private void Start()
    {
        Subscribe();
        coinValue = SaveManager.Instance.MyData.Coins;
        EventBus.RaiseEvent(new ChangeCoinValueEvent(coinValue));
        Debug.Log("Start player");
    }

    private void AddCoin()
    {
        coinValue += valueAddsCoin;
        playerChest.TriggerAnimNormalGetCoin();
        SaveManager.Instance.MyData.Coins = coinValue;
        SaveManager.Instance.Save();
        EventBus.RaiseEvent(new ChangeCoinValueEvent(coinValue,true, valueAddsCoin));
        Debug.Log($"AddCoin = {coinValue}");
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}
