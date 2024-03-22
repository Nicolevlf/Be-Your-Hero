using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mover : MonoBehaviour
{
    public static Mover instance;
    Transform miTf;
    Rigidbody2D miRb;
    SpriteRenderer miSr;
    Animator miAnim;
    [SerializeField] float velocidad;
    [SerializeField] float velocidad2;
    float duration;
    float speed;
    float movimiento;
    [SerializeField] float fuerzasalto;
    [SerializeField] float fuerzaDoblesalto;
    [SerializeField] bool enSuelo;
    bool dobleSalto;
    bool powerSalto;
    GameObject objetos;


    // Start is called before the first frame update
    public void Start()
    {
        miTf = GetComponent<Transform>();
        miRb = GetComponent<Rigidbody2D>();
        miSr = GetComponent<SpriteRenderer>();
        miAnim = GetComponent<Animator>();
        velocidad = 0.01f;
        speed = 0.01f;
        velocidad2 = 0.02f;
        duration = 15;
        fuerzasalto = 1f;
        fuerzaDoblesalto = 2f;
        enSuelo = true;
        dobleSalto = false;
        powerSalto = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1f)
        {
            movimiento = Input.GetAxisRaw("Horizontal");
            if (movimiento != 0)
            {
                SoundManager.PlaySound("");
                miAnim.SetFloat("caminar", 1);
                if (movimiento > 0)
                {
                    miSr.flipX = false;
                }
                else
                {
                    miSr.flipX = true;
                }
            }
            else
            {
                miAnim.SetFloat("caminar", 0);
            }
            miTf.position = new Vector3(miTf.position.x + speed * movimiento, miTf.position.y, miTf.position.z);
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(miTf.position, Vector2.down, 2f, 1 << 8);
        Debug.DrawRay(miTf.position, Vector2.down, Color.green);
        if (hit.collider != null)
        {
            enSuelo = true;
            Debug.Log(hit.collider.gameObject.name);
            miAnim.SetBool("Saltar",false);
        }

        if (Input.GetButton("Jump"))
        {
            SoundManager.PlaySound("");
            if (powerSalto)
            {
                dobleSalto = true;
                if (dobleSalto && enSuelo)
                {
                    miRb.AddForce(Vector2.up * fuerzaDoblesalto, ForceMode2D.Impulse);
                    miAnim.SetBool("Saltar", true);
                    enSuelo = false;
                }
            }
            else if (enSuelo)
            {
                miRb.AddForce(Vector2.up * fuerzasalto, ForceMode2D.Impulse);
                miAnim.SetBool("Saltar", true);
                enSuelo = false;
            }
        }
    }
    public void ActivateSpeed()
    {
        StartCoroutine(SpeedBoostCooldown());
    }
    IEnumerator SpeedBoostCooldown()
    {
        speed = velocidad2;
        yield return new WaitForSeconds(duration);
        speed = velocidad;
    }

    private void dosSaltos()
    {
        powerSalto = false;
    }
    private void correr()
    {
        velocidad = 0.02f;
    }


    private void Die()
    {
        GameManager.Instance.Die();
    }
    private void End()
    {
        GameManager.Instance.End();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Obstaculo"))
        {
            miAnim.SetTrigger("vida");
            Die();
            SoundManager.PlaySound("Electrocuted");
        }
        if (collision.collider.gameObject.CompareTag("Puerta"))
        {
            End();
            Timer.instance.StopStopwatch();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.gameObject.tag == "Coin")
        {
            SoundManager.PlaySound("Moneda");
            Destroy(other.gameObject);
        }*/
        if (other.gameObject.tag == "Gema")
        {
            SoundManager.PlaySound("Gema");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Ropa")
        {
            SoundManager.PlaySound("Ropa");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Reloj")
        {
            SoundManager.PlaySound("Poder");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Rayo")
        {
            SoundManager.PlaySound("Poder");
            Destroy(other.gameObject);
            ActivateSpeed();

        }
        else if (other.gameObject.tag == "DobleSalto")
        {
            SoundManager.PlaySound("Poder");
            Destroy(other.gameObject);
            dobleSalto = true;
            powerSalto = true;
            Invoke("dosSaltos", 15);
        }
    }
}
