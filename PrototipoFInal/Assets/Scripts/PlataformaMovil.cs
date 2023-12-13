using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public GameObject objetoMover;
    public Transform pInicio;
    public Transform pFinal;
    public float velocidad;
    private Vector3 moverHacia;

    void Start()
    {
        moverHacia = pFinal.position;
    }

    void Update()
    {
        objetoMover.transform.position = Vector3.MoveTowards(objetoMover.transform.position, moverHacia, velocidad * Time.deltaTime);
        if (objetoMover.transform.position == pFinal.position)
        {
            moverHacia = pInicio.position;
        }
        if (objetoMover.transform.position == pInicio.position)
        {
            moverHacia = pFinal.position;
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        // Debug.Log("COLISION");
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Suelo")
            {
                collision.transform.parent = transform;
            }
            else if (gameObject.tag == "Bloque")
            {
                Movimiento m = collision.gameObject.GetComponent<Movimiento>();
                m.Morir();
            }
        }
        // else if (collision.gameObject.tag == "Picos")
        // {
        //     Debug.Log("COLISION CAIDA");
        //     Destroy(gameObject);
        // }
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