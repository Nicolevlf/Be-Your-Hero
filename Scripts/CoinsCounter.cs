using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    Text text;
    public static int CoinAmount;
    public TMP_Text coinText;
    public int currentCoins=0;
    public static CoinsCounter instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    void update()
    {
        CoinAmount= GameManager.Instance.coinsCounter;
        text.text = CoinAmount.ToString();
    }
    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "COINS: " + currentCoins.ToString();
    }
}
