using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingEnemy : MonoBehaviour, ITrigger
{
    public void DOReaction(HeroMovement heroMovement)
    {
        heroMovement.StopMovement();
    }
}
