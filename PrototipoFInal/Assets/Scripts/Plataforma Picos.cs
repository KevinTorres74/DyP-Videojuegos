using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPicos : MonoBehaviour
{
    public GameObject picos;
    public bool seActivo = false;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !seActivo)
        {
            Invoke("ActivarPicos", 2f);
            seActivo = true;
        }
    }

    private void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !seActivo)
        {
            Invoke("ActivarPicos", 2f);
            seActivo = true;
        }
    }

    public void ActivarPicos()
    {
        picos.SetActive(true);
        Invoke("DesactivarPicos", 1f);
    }

    public void DesactivarPicos()
    {
        picos.SetActive(false);
        seActivo = false;
    }
}
