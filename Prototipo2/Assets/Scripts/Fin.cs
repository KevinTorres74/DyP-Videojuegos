using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour
{
    public GameObject endScreen;
    public Reloj r;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            r.finNivel = true;
            endScreen.SetActive(true);
        }
    }
}
