using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DisparadorEnemigo : MonoBehaviour
{
    public Transform origen;
    public Transform disparos;
    public ProyectilEnemigo prefabProyectil;
    public Transform player;
    private ObjectPool<ProyectilEnemigo> proyectilesPool;

    private float tiempoUltimoDisparo;
    public float tiempoEsperaDisparo = 1f;
    private bool puedeDisparar = true;
    public float visDist = 10.0f;

    void Start()
    {
        proyectilesPool = new ObjectPool<ProyectilEnemigo>(() => {
            ProyectilEnemigo proyectil = Instantiate(prefabProyectil, origen.position, origen.rotation);
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
        Vector2 direction = player.position - transform.position;
        if(direction.magnitude < visDist)
        {
            if (puedeDisparar && Random.value < 0.5f)
            {
                Disparar();
                tiempoUltimoDisparo = Time.time;
                puedeDisparar = false;
            }

            // Verificar si ha pasado el tiempo de espera para poder disparar nuevamente
            if (!puedeDisparar && Time.time - tiempoUltimoDisparo >= tiempoEsperaDisparo)
            {
                puedeDisparar = true;
            }
        }
    }

    void Disparar()
    {
        proyectilesPool.Get();
    }

    void DesactivarProyectil(ProyectilEnemigo p)
    {
        proyectilesPool.Release(p);
    }
}
