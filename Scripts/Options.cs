using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject InicioMenu;
    [SerializeField] GameObject OptionsButton;
    [SerializeField] GameObject mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        OptionsMenu.SetActive(false);
        InicioMenu.SetActive(true);
    }

    public void Opciones()
    {
        OptionsMenu.SetActive(true);;
        InicioMenu.SetActive(false);
    }

    public void MainMenu()
    {
        OptionsMenu.SetActive(false);
        InicioMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
