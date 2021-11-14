using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic;
using States;
using UnityEngine;
using Zenject;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private EntryApplicationPoint _entry;
    private HeroMovement _heroMovement;

    [Inject]
    private void Construct(EntryApplicationPoint entry, HeroMovement heroMovement)
    {
        _entry = entry;
        _heroMovement = heroMovement;
    }

    private void Awake() 
    {
        _heroMovement.OnHeroDeath += ShowPausePanel;
    }

    private void OnDestroy() 
    {
        _heroMovement.OnHeroDeath -= ShowPausePanel;
    }

    private void ShowPausePanel()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Restart()
    {
        _entry.Game.StateMachine.Enter<LoadingSceneState, string, Action>("GameLoopScene",
            () => { _entry.Game.StateMachine.Enter<GameLoopState>();});
    }

    public void MenuExit()
    {
        _entry.Game.StateMachine.Enter<LoadingSceneState, string, Action>("MainMenuScene",
            () => { _entry.Game.StateMachine.Enter<MainMenuState>();});
    }
}
