using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemas : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("Gema");
            GameManager.Instance.gemasCounter += 1;
            GemasCounter.instance.IncreaseGemas(value);
            Destroy(gameObject);
        }
    }
}
