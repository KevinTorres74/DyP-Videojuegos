using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reloj : MonoBehaviour
{
    // [Tooltip("Tiempo inicial en segundos")]
    public int tiempoInicial;

    // [Tooltip("Escala del tiempo del Reloj")]
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;

    private TMP_Text texto;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoAMostrarEnSegundos = 0f;
    private float escalaDeTiempoAlPausar, escalaDeTiempoInicial;
    // private bool estaPausado = false;
    public GameObject jugador;
    // public GameObject camara;
    public GameObject loseScreen;

    void Start()
    {
        escalaDeTiempoInicial = escalaDeTiempo;
        texto = GetComponent<TMP_Text>();

        tiempoAMostrarEnSegundos = tiempoInicial;
        ActualizarReloj(tiempoInicial);
    }

    void Update()
    {
        tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;
        tiempoAMostrarEnSegundos += tiempoDelFrameConTimeScale;
        // SpriteRenderer sp = jugador.GetComponent<SpriteRenderer>();
        if (jugador != null)
        {
            SpriteRenderer sp = jugador.GetComponent<SpriteRenderer>();
            if (sp != null)
            {
                if (sp.enabled)
                {
                    ActualizarReloj(tiempoAMostrarEnSegundos);
                }
            }
        }
    }

    public void ActualizarReloj(float timepoEnSegundos)
    {
        int minutos = 0;
        int segundos = 0;
        string textoReloj = "";

        if (timepoEnSegundos < 0) timepoEnSegundos = 0;

        minutos = (int)timepoEnSegundos / 60;
        segundos = (int)timepoEnSegundos % 60;

        textoReloj = minutos.ToString("00") + ":" + segundos.ToString("00");

        texto.text = textoReloj;

        if (textoReloj.Equals("00:00"))
        {
            if (jugador != null)
            {
                SpriteRenderer sp = jugador.GetComponent<SpriteRenderer>();
                Movimiento m = jugador.GetComponent<Movimiento>();
                Animator a = jugador.GetComponent<Animator>();
                if (sp != null && m != null && a != null)
                {
                    sp.enabled = false;
                    m.enabled = false;
                    a.enabled = false;
                }
            }
            // jugador.GetComponent<BoxCollider2D>().enabled = false;
            // camara.SetActive(true);
            loseScreen.SetActive(true);
        }
    }    
}
