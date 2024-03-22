using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rayo : MonoBehaviour
{
    public static Rayo instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other, int RayoID)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("Poder");
            
            Destroy(gameObject);
            if (RayoID == 1)
            {
                Mover.instance.ActivateSpeed();
            }
        }
    }
}
