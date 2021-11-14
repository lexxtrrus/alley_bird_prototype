using System;
using System.ComponentModel;
using System.Reflection;
using States;
using UnityEngine;
using Zenject;

namespace GameLogic
{
    public class EntryApplicationPoint : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] public LoadingCurtain _loadingCurtain;
        public Game Game { get; set; }

        private void Awake()
        {
            Game = new Game(this, _loadingCurtain);
            Game.StateMachine.Enter<EntryPointState>();
            DontDestroyOnLoad(this);
        }

        [Inject]
        private void Construct(LoadingCurtain loadingCurtain)
        {
            _loadingCurtain = loadingCurtain;
        }
    }
}