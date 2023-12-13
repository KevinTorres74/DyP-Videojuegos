using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaida : MonoBehaviour
{
    public GameObject objetoMover;
    // public Transform pInicio;
    public Transform pFinal;
    public float velocidad;
    private Vector3 moverHacia;
    // public bool cayendo;
    // public float fuerzaDeCaída = 0.001f;
    // private Rigidbody2D rb2d;
    private bool cayendo = false;


    void Start()
    {
        cayendo = false;
        moverHacia = pFinal.position;
        // rb2d = GetComponent<Rigidbody2D>();
        // rb2d.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        // objetoMover.transform.position = Vector3.MoveTowards(objetoMover.transform.position, moverHacia, velocidad * Time.deltaTime);
        // if (objetoMover.transform.position == pFinal.position)
        // {
        //     moverHacia = pInicio.position;
        // }
        // if (objetoMover.transform.position == pInicio.position)
        // {
        //     moverHacia = pFinal.position;
        // }
        if (cayendo)
        {
            Caer();
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log("COLISION");
        if (collision.gameObject.tag == "Player" && !cayendo)
        {
            // rb2d.bodyType = RigidbodyType2D.Dynamic;

            // // Aplicar una fuerza hacia abajo para que caiga más rápidamente
            // rb2d.AddForce(Vector2.down * fuerzaDeCaída, ForceMode2D.Impulse);
            cayendo = true;
            // Caer();
            // if (collision.transform.position.y > transform.position.y + 0.1f)
            // {
            //     Caer();
            // }
        }

        if (collision.gameObject.tag == "Player" && gameObject.tag == "Suelo")
        {
                collision.transform.parent = transform;
        }
    }

    public void Caer()
    {
        // Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        // // Obtener las restricciones actuales
        // RigidbodyConstraints2D constraints = rb2d.constraints;

        // // Descongelar la posición en Y
        // constraints &= ~RigidbodyConstraints2D.FreezePositionY;

        // // Aplicar las nuevas restricciones al Rigidbody2D
        // rb2d.constraints = constraints;

        objetoMover.transform.position = Vector3.MoveTowards(objetoMover.transform.position, moverHacia, velocidad * Time.deltaTime);
        if (objetoMover.transform.position == pFinal.position)
        {
            Destroy(gameObject);
            // moverHacia = pInicio.position;
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        // Debug.Log("COLISION");
        if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.parent != null && gameObject.tag == "Suelo")
            {
                collision.transform.parent = null;
            }
        }
        // else if (collision.gameObject.tag == "Picos")
        // {
        //     Debug.Log("COLISION CAIDA");
        //     Destroy(gameObject);
        // }
    }
}
