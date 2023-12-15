using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
    // Movimiento
    private Rigidbody2D rb2d;
    private float movHor = 0;
    [Header("Movimiento")]
    [SerializeField] private float velMove;
    [SerializeField] private float upForce;
    [SerializeField] private bool jumping;
    [Range(0,0.3f)][SerializeField] private float suavizado;
    Vector3 velocidad = Vector3.zero;
    bool derecha = true;
    public Animator anim;
    public AudioSource musicaNivel;

    // Vida
    public GameObject loseScreen;
    public Image barraVida;
    public float vidaActual;
    public float vidaMaxima;

    // Power ups
    public GameObject inmortal;
    // public GameObject proyectil;
    // public int proyectiles = 0;

    void Start()
    {
        musicaNivel.Play();
        anim = this.GetComponent<Animator>();
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal")*velMove;
        anim.SetBool("jump", jumping);
        if (movHor != 0)
        {
            anim.SetTrigger("run");
            anim.ResetTrigger("idle");
        }
        else
        {
            anim.SetTrigger("idle");
            anim.ResetTrigger("run");
        }

        if (Input.GetButtonDown("Jump") && !jumping)
        {
            rb2d.AddForce(new Vector2(0, upForce));
        }
    }

    private void FixedUpdate()
    {
        Mover(movHor*Time.deltaTime);
    }

    void Mover(float m)
    {
        Vector3 velD = new Vector3(m, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, velD, ref velocidad, suavizado);
        if (m > 0 && !derecha)
        {
            Girar();
        }
        else if (m < 0 && derecha)
        {
            Girar();
        }
    }

    void Girar()
    {
        derecha = !derecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Suelo":
                jumping = false;
                break;

            case "Enemigo":
                if (!inmortal.activeSelf)
                {
                    // if (jumping)
                    // {
                    //     rb2d.AddForce(new Vector2(0, 800.0f));
                    // }
                    // else
                    // {
                    //     rb2d.AddForce(new Vector2(0, 400.0f));
                    // }
                    rb2d.velocity = new Vector2(0, 8.0f);
                    ReducirVida(10.0f);
                }
                break;

            default:
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            jumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Picos":
                if (!inmortal.activeSelf)
                {
                    Vector2 aux = rb2d.velocity;
                    rb2d.velocity = new Vector2(0, 8.0f);
                    ReducirVida(10.0f);
                }
                break;

            case "Enemigo":
                rb2d.velocity = new Vector2(0, 8.0f);
                Destroy(other.gameObject);
                break;

            case "Velocidad":
                Destroy(other.gameObject);
                velMove += 150.0f;
                upForce += 150.0f;
                Invoke("DesactivarPowerVelocidad", 10f);
                break;

            case "Invensibilidad":
                Destroy(other.gameObject);
                inmortal.SetActive(true);
                Invoke("DesactivarPowerInmortal", 10f);
                break;
            
            case "Bloque":
                Destroy(other.gameObject);
                // proyectiles += 1;
                break;

            default:
                break;
        }
    }

    public void ReducirVida(float cantidad)
    {
        if (!inmortal.activeSelf)
        {
            vidaActual -= cantidad;
            barraVida.fillAmount = vidaActual / vidaMaxima;
            if (vidaActual <= 0)
            {
                Morir();
            }
        }
    }

    public void Morir()
    {
        if (musicaNivel != null && musicaNivel.isPlaying)
        {
            musicaNivel.Stop();
        }
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Movimiento>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Animator>().enabled = false;
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        loseScreen.SetActive(true);
    }

    private void DesactivarPowerInmortal()
    {
        if (inmortal.activeSelf)
        {
            inmortal.SetActive(false);
        }
    }

    private void DesactivarPowerVelocidad()
    {
        velMove -= 150.0f;
        upForce -= 150.0f;
    }
}
