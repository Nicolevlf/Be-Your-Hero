using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GemasCounter : MonoBehaviour
{
    Text text;
    public static int GemasAmount;
    public TMP_Text gemasText;
    public int currentGemas = 0;
    public static GemasCounter instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gemasText.text = "GEMAS: " + currentGemas.ToString();
    }

    void update()
    {
        GemasAmount = GameManager.Instance.gemasCounter;
        text.text = GemasAmount.ToString();
    }
    public void IncreaseGemas(int v)
    {
        currentGemas += v;
        gemasText.text = "GEMAS: " + currentGemas.ToString();
    }
}
