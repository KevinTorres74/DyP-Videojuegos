using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public GameObject objetoMover;
    public Transform pInicio;
    public Transform pFinal;
    // public Transform auxJugador;
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

    private void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // auxJugador = collision.transform.parent;
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.parent != null)
            {
                collision.transform.parent = null;
            }
        }
    }
}