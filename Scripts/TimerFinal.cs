using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerFinal : MonoBehaviour
{
    public static float tiempo;
    public TMP_Text currentTimeText;
    float minutes = Mathf.Floor(tiempo / 60);
    float seconds = Mathf.RoundToInt(tiempo % 60);
    public float timeValue = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        tiempo = GameObject.Find("GameManager").GetComponent<GameManager>().pasarTiempo;
        currentTimeText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeValue <= 0)
        {
            timeValue += Time.deltaTime;
        }
        else if (timeValue == 60)
        {
            timeValue = 0;
        }

        DisplayTime();

    }
    void DisplayTime()
    {
        currentTimeText.text = "TIME: " + ((int)(tiempo/60)).ToString().PadLeft(2,'0') + ":" + ((int)(tiempo%60)).ToString().PadLeft(2, '0');
    }
    public void Reset()
    {
        currentTimeText.text = "0";
        tiempo = 0;
        tiempo = GameObject.Find("GameManager").GetComponent<GameManager>().pasarTiempo;
    }

}
