using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float MovimientoHorizontal = 0f;
    [SerializeField] private float Velocidad;
    [Range(0, 0.3f)][SerializeField] private float Suavizado;
    private Vector3 velocidad = Vector3.zero;
    private bool MiraDerecha = true;
    [SerializeField] private float FuerzaSalto;
    [SerializeField] private LayerMask Suelo;
    [SerializeField] private Transform ControladorSuelo;
    [SerializeField] private Vector3 Dimensiones;
    [SerializeField] private bool EnSuelo;
    Animator MiAnim;

    private bool Salto = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        MiAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        MovimientoHorizontal = Input.GetAxisRaw("Horizontal") * Velocidad;
        if (MovimientoHorizontal != 0)
        {
            MiAnim.SetFloat("caminar", 1);
        }
        else
        {
            MiAnim.SetFloat("caminar", 0);
        }
         
        if (Input.GetButtonDown("Jump"))
        {
            rb2D.AddForce(Vector2.up * FuerzaSalto, ForceMode2D.Impulse);
            Salto = true;
            MiAnim.SetBool("Saltar", true);
            EnSuelo = false; 
        }

        

    }

    private void FixedUpdate()
    {
        EnSuelo = Physics2D.OverlapBox(ControladorSuelo.position, Dimensiones, 0f, Suelo<<8);
        Mover(MovimientoHorizontal * Time.fixedDeltaTime, Salto);
        EnSuelo = true; 
        
        if(EnSuelo == true)
        {
            Salto = false;
            MiAnim.SetBool("Saltar", false);
        }
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, Suavizado);

        if (mover > 0 && !MiraDerecha)
        {
            Girar();
        }
        else if (mover < 0 && MiraDerecha)
        {
            Girar();
        }
        if (EnSuelo && saltar)
        {
            EnSuelo = false;
            MiAnim.SetBool("Saltar", true);
            rb2D.AddForce(new Vector2(0f, FuerzaSalto));
        }
 
        void Girar()
        {
            MiraDerecha = !MiraDerecha;
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }

    }
}