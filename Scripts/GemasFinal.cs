using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemasFinal : MonoBehaviour
{
    float gemas;
    public TMP_Text currentGemasText;
    // Start is called before the first frame update
    void Start()
    {
        gemas = GameObject.Find("GameManager").GetComponent<GameManager>().pasarGemas;
        currentGemasText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentGemasText.text = "GEMAS: " + gemas.ToString();
    }
}
