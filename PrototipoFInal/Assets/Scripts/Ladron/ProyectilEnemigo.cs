using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProyectilEnemigo : MonoBehaviour
{
    public float velMove;
    public float tiempo;
    private Action<ProyectilEnemigo> desactivarP;

    void OnEnable()
    {
        StartCoroutine(Desactivar());
    }

    void Update()
    {
        transform.Translate(Vector2.left*velMove*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // desactivarP(this);
            // Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Movimiento>().ReducirVida(20.0f);
            desactivarP(this);
        }
    }

    public void DesactivarObjeto(Action<ProyectilEnemigo> desA)
    {
        desactivarP = desA;
    }

    IEnumerator Desactivar()
    {
        yield return new WaitForSeconds(tiempo);
        desactivarP(this);
    }
}