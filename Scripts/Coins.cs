using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("Moneda");
            GameManager.Instance.coinsCounter += 1;
            CoinsCounter.instance.IncreaseCoins(value);
            Destroy(gameObject);
        }
    }
}
