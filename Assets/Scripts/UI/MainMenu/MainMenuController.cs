using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic;
using States;
using UnityEngine;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    private EntryApplicationPoint _entry;

    [Inject]
    private void Construct(EntryApplicationPoint entry)
    {
        _entry = entry;
    }

    public void ChangeStateClick()
    {
        _entry.Game.StateMachine.Enter<LoadingSceneState, string, Action>("GameLoopScene",
            () => { _entry.Game.StateMachine.Enter<GameLoopState>();});
    }
}
