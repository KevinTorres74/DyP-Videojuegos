using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateMove : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private float salto = 80;
    private float hm;
    private float y = 0;
    public GameObject screen;
    public int dinero;
    public int perdon;
    public TMP_Text tmpDinero;
    public TMP_Text tmpPerdon;
    public Image barraVida;
    public float vidaActual;
    public float vidaMaxima;
    public bool enContacto = false;
    public Image vida;

    // Update is called once per frame
    void Update()
    {
        hm = Input.GetAxis("Horizontal");
        float t = Time.deltaTime;

        this.transform.Translate(t * speed * hm, y, 0);
        // vida.transform.Translate(t * speed * hm * 25, y, 0);
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up*salto);
        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     // if (collision.gameObject.tag == "coche")
    //     // {
    //     //     screen.SetActive(true);
    //     //     this.gameObject.SetActive(false);
    //     // }
    //     if (collision.gameObject.tag == "coche")
    //     {
    //         vidaActual -= 10;
    //         if (vidaActual == 0)
    //         {
    //             screen.SetActive(true);
    //             this.gameObject.SetActive(false);
    //         }
    //         else
    //         {
    //             barraVida.fillAmount = vidaActual / vidaMaxima;
    //         }
    //     }
    // }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(" ->");
        if (collision.gameObject.tag == "coche")
        {
            enContacto = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Debug.Log(" ->");
        if (collision.gameObject.tag == "coche")
        {
            if (enContacto)
            {
                vidaActual -= 10;
                if (vidaActual == 0)
                {
                    screen.SetActive(true);
                    this.gameObject.SetActive(false);
                }
                else
                {
                    barraVida.fillAmount = vidaActual / vidaMaxima;
                    // Debug.Log(" ->" + barraVida.fillAmount.ToString());
                }
                enContacto = false;
            }
        }
    }

    public void SubeVida()
    {
        if (vidaActual + 10 <= vidaMaxima)
        {
            vidaActual += 10; 
        }
        else
        {
            vidaActual = vidaMaxima;
        }
        barraVida.fillAmount = vidaActual / vidaMaxima;
    }
}
