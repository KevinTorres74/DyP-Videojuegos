using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private float velocidad = 4.5f;
    public bool direccion;
    public int dir;

    void Start()
    {
        if (!direccion)
        {
            Vector2 aux = transform.localScale;
            aux.x *= -1;
            transform.localScale = aux;
            dir = -1;
        }
        else
        {
            dir = 1;
        }
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x + (velocidad * Time.deltaTime * dir), transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}