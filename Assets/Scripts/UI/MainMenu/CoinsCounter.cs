using UnityEngine;
using Zenject;
using TMPro;
public class CoinsCounter : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI coinsText;
    public static CoinsCounter Instance;
    private void Awake() 
    {
        Instance = this;
        UpdateText();
    }
    public void AddCoin()
    {
        Profile.Coins++;
        UpdateText();
    }

    private void UpdateText()
    {
        coinsText.text = $"COINS: {Profile.Coins}";
    }
}