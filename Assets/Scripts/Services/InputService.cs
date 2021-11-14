using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputService : MonoInstaller
{
    public bool isActive = true;
    public delegate void HeroJump();
    public event HeroJump OnJumpPressed;
    private float screenHeightTouchZone;
    private void Awake() 
    {
        screenHeightTouchZone = GetScreenHeightTouchBorder();
    }

    public void DisableInput()
    {
        isActive = false;
    }

    private void Update() 
    {
        if(!isActive || Input.touchCount < 1) return;
        if(Input.GetTouch(0).phase != TouchPhase.Began) return;
        if(Input.GetTouch(0).position.y <= screenHeightTouchZone)
        {
            OnJumpPressed?.Invoke();
        } 
    }

    public float GetScreenHeightTouchBorder()
    {
        return Screen.height * 0.85f;
    }

    public override void InstallBindings()
    {
        BindInputServiceInstance();        
    }

    private void BindInputServiceInstance()
    {
        Container.Bind<InputService>().FromInstance(this).AsSingle().NonLazy();
    }
}
