using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    bool timeActive;
    public float currentTime;
    public TMP_Text currentTimeText;
    public static Timer instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }
     
    // Update is called once per frame
    void Update()
    {
        if (timeActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss");
    }
    public void StartStopwatch()
    {
        timeActive = true;

    }
    public void StopStopwatch()
    {
        timeActive = false;
    }

    public void AddTime()
    {
        currentTime -= 15;
    }
}
