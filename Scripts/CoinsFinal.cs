using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsFinal : MonoBehaviour
{
    float coins;
    public TMP_Text currentCoinsText;
    // Start is called before the first frame update
    void Start()
    {
        coins = GameObject.Find("GameManager").GetComponent<GameManager>().pasarCoins;
        currentCoinsText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentCoinsText.text = "COINS: " + coins.ToString();
    }
}
