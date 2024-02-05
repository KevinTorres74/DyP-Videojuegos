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

    // Vida
    public GameObject loseScreen;
    public Image barraVida;
    public float vidaActual;
    public float vidaMaxima;

    // Power ups
    public GameObject inmortal;
    public GameObject proyectil;
    public int proyectiles = 0;

    void Start()
    {
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
        if (Input.GetKey("r") && proyectiles > 0)
        {
            GameObject p = Instantiate(proyectil, transform.position, Quaternion.identity);
            p.GetComponent<Proyectil>().direccion = derecha;
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
        if (collision.gameObject.tag == "Suelo")
        {
            jumping = false;
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
                    if (jumping)
                    {
                        rb2d.AddForce(new Vector2(-0, 2*upForce));
                    }
                    else
                    {
                        rb2d.AddForce(new Vector2(-0, upForce));
                    }
                    ReducirVida(10.0f);
                }
                break;

            case "Velocidad":
                Destroy(other.gameObject);
                velMove = 4.0f * velMove;
                Invoke("DesactivarPowerVelocidad", 10f);
                break;

            case "Invensibilidad":
                Destroy(other.gameObject);
                inmortal.SetActive(true);
                Invoke("DesactivarPowerInmortal", 10f);
                break;
            
            case "Destruccion":
                Destroy(other.gameObject);
                proyectiles += 1;
                break;

            default:
                break;
        }
    }

    public void ReducirVida(float cantidad)
    {
        vidaActual -= cantidad;
        barraVida.fillAmount = vidaActual / vidaMaxima;
        if (vidaActual == 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Movimiento>().enabled = false;
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        this.GetComponent<Animator>().enabled = false;
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
        velMove = velMove / 4.0f;
    }
}
