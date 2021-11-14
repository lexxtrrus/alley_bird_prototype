using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoinTrigger : MonoBehaviour, ITrigger
{
    private CoinsCounter _coinsCounter;

    public void DOReaction(HeroMovement heroMovement)
    {
        CoinsCounter.Instance.AddCoin();
        Destroy(gameObject);
    }
}
