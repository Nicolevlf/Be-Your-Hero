using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    [SerializeField] Transform arriba;
    [SerializeField] Transform abajo;
    Transform miTf;
    Transform inicial;
    Transform final;
    SpriteRenderer miSr;
    float velocidad;
    public AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        miTf = GetComponent<Transform>();
        velocidad = 0.2f;
        final = abajo;
        inicial = arriba;
        miSr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        miTf.Translate((final.position - inicial.position) * Time.deltaTime * velocidad);
        if (Vector3.Distance(miTf.position, abajo.position) <= 0.1)
        {
            final = arriba;
            inicial = abajo;
        }
        else if(Vector3.Distance(miTf.position, arriba.position) <= 0.1)
        {
            final = abajo;
            inicial = arriba;
        }
    }
}
