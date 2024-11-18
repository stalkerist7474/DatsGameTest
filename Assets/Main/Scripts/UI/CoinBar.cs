using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//обновление значения показателя золота на UI на основе событий
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

    //отображение нового значение золота
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
