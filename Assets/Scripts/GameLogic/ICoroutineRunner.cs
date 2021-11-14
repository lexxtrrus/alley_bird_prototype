using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}