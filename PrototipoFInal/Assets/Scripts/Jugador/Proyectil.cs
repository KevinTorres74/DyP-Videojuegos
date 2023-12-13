using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Proyectil : MonoBehaviour
{
    public float velMove;
    public float tiempo;
    private Action<Proyectil> desactivarP;

    void OnEnable()
    {
        StartCoroutine(Desactivar());
    }

    void Update()
    {
        transform.Translate(Vector2.up*velMove*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            desactivarP(this);
            Destroy(collision.gameObject);
        }
    }

    public void DesactivarObjeto(Action<Proyectil> desA)
    {
        desactivarP = desA;
    }

    IEnumerator Desactivar()
    {
        yield return new WaitForSeconds(tiempo);
        desactivarP(this);
    }
}