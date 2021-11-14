using UnityEngine;
using Zenject;
using System.Collections;

namespace GameLogic
{
    public class LoadingCurtain : MonoInstaller
    {
        [SerializeField] private CanvasGroup curtain;
    
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            curtain.alpha = 1;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
    {
        while (curtain.alpha > 0)
        {
            curtain.alpha -= 0.03f;
            yield return new WaitForSeconds(0.03f);
        }        
        gameObject.SetActive(false);
    }
    }
}
