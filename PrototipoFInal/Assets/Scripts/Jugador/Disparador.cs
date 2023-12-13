using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using TMPro;

public class Disparador : MonoBehaviour
{
    public Transform origen;
    public Transform disparos;
    public Proyectil prefabProyectil;
    // public float tiempoDisparo;
    // public float tiempoSigDisparo = 0f;
    private ObjectPool<Proyectil> proyectilesPool;
    public int proyectiles;
    public TMP_Text cantidadP;

    void Start()
    {
        cantidadP.text = "0";
        proyectilesPool = new ObjectPool<Proyectil>(() => {
            Proyectil proyectil = Instantiate(prefabProyectil, origen.position, origen.rotation);
            proyectil.gameObject.transform.parent = disparos.transform;
            proyectil.DesactivarObjeto(DesactivarProyectil);
            return proyectil;
        }, proyectil => {
            proyectil.transform.position = origen.position;
            proyectil.transform.rotation = origen.rotation;
            proyectil.gameObject.SetActive(true);
        }, proyectil => {
            proyectil.gameObject.SetActive(false);
        }, proyectil => {
            Destroy(proyectil.gameObject);
        }, true, 10, 20);
    }

    void Update()
    {
        if (proyectiles > 0 && Input.GetButtonDown("Fire1"))
        {
            Disparar();
            proyectiles -= 1;
            cantidadP.text = proyectiles.ToString();
        }
        // if (tiempoSigDisparo > 0)
        // {
        //     tiempoSigDisparo -= Time.deltaTime;
        // }
        // if (Input.GetKey("r") && tiempoSigDisparo <= 0)
        // {
        //     Disparar();
        //     tiempoSigDisparo = tiempoDisparo;
        // }
    }

    void Disparar()
    {
        proyectilesPool.Get();
    }

    void DesactivarProyectil(Proyectil p)
    {
        proyectilesPool.Release(p);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destruccion")
        {
            Destroy(other.gameObject);
            proyectiles += 1;
            cantidadP.text = proyectiles.ToString();
        }
    }
}
