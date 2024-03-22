using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text coinText;
    public Text gemasText;
    public Text time;
    public int coinsCounter = 0;
    public int gemasCounter = 0;
    public GameObject tiempo;
    public GameObject coins;
    public GameObject gemas;
    public float pasarTiempo;
    public float pasarCoins;
    public float pasarGemas;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Timer.instance.StartStopwatch();
    }

    public void Die()
    {
        Invoke("Lost", 1);
        Timer.instance.StopStopwatch();
    }
    private void Lost()
    {
        pasarTiempo = tiempo.GetComponent<Timer>().currentTime;
        pasarCoins = coins.GetComponent<CoinsCounter>().currentCoins;
        pasarGemas = gemas.GetComponent<GemasCounter>().currentGemas;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Perder", LoadSceneMode.Single);
    }
    public void End()
    {
        Invoke("Win", 0);
        Timer.instance.StopStopwatch();
    }
    private void Win()
    {
        pasarTiempo = tiempo.GetComponent<Timer>().currentTime;
        pasarCoins = coins.GetComponent<CoinsCounter>().currentCoins;
        pasarGemas = gemas.GetComponent<GemasCounter>().currentGemas;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Ganar", LoadSceneMode.Single);
    }
    public void Cerrar()
    {
        Application.Quit();
    }

}