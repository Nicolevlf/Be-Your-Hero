using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public static AudioClip moneda, gema, ropa, cable, bolita, laser, electrocuted, poder, salto, caminar;
    static AudioSource audioScr;
    public static SoundManager Instance;
    [SerializeField] Slider volumeSlider;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

        moneda = Resources.Load<AudioClip>("Moneda");
        gema = Resources.Load<AudioClip>("Gema");
        ropa = Resources.Load<AudioClip>("Ropa");
        cable = Resources.Load<AudioClip>("Cable");
        bolita = Resources.Load<AudioClip>("Bolita");
        laser = Resources.Load<AudioClip>("Laser");
        electrocuted = Resources.Load<AudioClip>("Electrocuted");
        poder = Resources.Load<AudioClip>("Poder");
        salto = Resources.Load<AudioClip>("Salto");
        caminar = Resources.Load<AudioClip>("Caminar");

        audioScr = GetComponent<AudioSource>();
    }
    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Moneda":
                audioScr.PlayOneShot(moneda);
                break;
            case "Gema":
                audioScr.PlayOneShot(gema);
                break;
            case "Ropa":
                audioScr.PlayOneShot(ropa);
                break;
            case "Cable":
                audioScr.PlayOneShot(moneda);
                break;
            case "Bolita":
                audioScr.PlayOneShot(bolita);
                break;
            case "Laser":
                audioScr.PlayOneShot(laser);
                break;
            case "Electrocuted":
                audioScr.PlayOneShot(electrocuted);
                break;
            case "Poder":
                audioScr.PlayOneShot(poder);
                break;
            case "Salto":
                audioScr.PlayOneShot(salto);
                break;
            case "Caminar":
                audioScr.PlayOneShot(caminar);
                break;
        }
    }
}
