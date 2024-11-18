using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBar : MonoBehaviour, IEventSubscriber<ChangeCoinValueEvent>
{
    [SerializeField] private TMP_Text valueCoin;


    public void Subscribe()
    {
        EventBus.RegisterTo(this as IEventSubscriber<ChangeCoinValueEvent>);
    }
    public void Unsubscribe()
    {
        EventBus.UnregisterFrom(this as IEventSubscriber<ChangeCoinValueEvent>);
    }

    public void OnEvent(ChangeCoinValueEvent eventName)
    {
        UpdateTextCoinValue(eventName.NewValueCoin);
    }

    private void UpdateTextCoinValue(int value)
    {
        valueCoin.text = value.ToString();
        Debug.Log("UpdateTextCoinValue");
    }

    private void Start()
    {
        Subscribe();
    }
    private void OnDestroy()
    {
        Unsubscribe();
    }
}
