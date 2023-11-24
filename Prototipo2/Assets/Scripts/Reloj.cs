using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reloj : MonoBehaviour
{
    public int tiempoInicial;
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;

    private TMP_Text texto;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoAMostrarEnSegundos = 0f;
    private float escalaDeTiempoAlPausar, escalaDeTiempoInicial;
    public GameObject jugador;
    public GameObject loseScreen;

    public bool finNivel = false;

    void Start()
    {
        escalaDeTiempoInicial = escalaDeTiempo;
        texto = GetComponent<TMP_Text>();

        tiempoAMostrarEnSegundos = tiempoInicial;
        ActualizarReloj(tiempoInicial);
    }

    void Update()
    {
        if (!finNivel)
        {
            tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;
            tiempoAMostrarEnSegundos += tiempoDelFrameConTimeScale;
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
            loseScreen.SetActive(true);
        }
    }

    public string GetTiempo()
    {
        return texto.text;
    }
}
