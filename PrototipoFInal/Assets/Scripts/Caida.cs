using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Debug.Log("EEEEEEEEEEEEEEEEEEEEEs");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Movimiento>().Morir();
        }
        else if (collision.gameObject.tag == "Suelo" || collision.gameObject.tag == "Movil")
        {
            // Debug.Log("AAAAAAAAAAAAAA");
            Destroy(collision.gameObject);
        }
    }
}
