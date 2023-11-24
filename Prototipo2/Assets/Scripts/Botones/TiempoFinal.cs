using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TiempoFinal : MonoBehaviour
{
    public Reloj r;

    void OnEnable()
    {
        Debug.Log("TiempoFinal");
        TMP_Text texto = GetComponent<TMP_Text>();
        texto.text = r.GetTiempo();
    }
}
