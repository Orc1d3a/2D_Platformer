using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private CoinPurse _coinPurse;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        UpdateText(_coinPurse.Coins);
    }

    private void OnEnable()
    {
        _coinPurse.CoinsQuantitiChanged += UpdateText;
    }

    private void OnDisable()
    {
        _coinPurse.CoinsQuantitiChanged -= UpdateText;
    }

    private void UpdateText(int coins)
    {
        _text.text = "Coins: " + coins;
    }
}
