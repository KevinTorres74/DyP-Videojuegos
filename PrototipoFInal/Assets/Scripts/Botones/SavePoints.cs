using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SavePoints : MonoBehaviour
{
    public TMP_Text tiempo;
    public TMP_Text tiempo2;
    public TMP_Text tiempo3;
    public TMP_Text tiempo4;
    public int nivel;

    public void OnEnable()
    {
        LoadData();
    }

    public void LoadData()
    {
        string tiempoGuardado = "";
        switch (nivel)
        {
            case 1:
                // if (PlayerPrefs.HasKey("tiempoN1"))
                // {
                //     tiempoGuardado = PlayerPrefs.GetString("tiempoN1");
                // }
                // else
                // {
                //     tiempoGuardado = "00:00";
                // }
                // tiempo.text = MayorTiempo(tiempoGuardado, tiempo.text);
                if (!PlayerPrefs.HasKey("tiempoN1"))
                {
                    PlayerPrefs.SetString("tiempoN1", "00:00");
                    // tiempoGuardado = PlayerPrefs.GetString("tiempoN1");
                }
                break;
            case 2:
                if (PlayerPrefs.HasKey("tiempoN2"))
                {
                    tiempoGuardado = PlayerPrefs.GetString("tiempoN2");
                }
                else
                {
                    tiempoGuardado = "00:00";
                }
                tiempo.text = MayorTiempo(tiempoGuardado, tiempo.text);
                break;
            case 3:
                if (PlayerPrefs.HasKey("tiempoN3"))
                {
                    tiempoGuardado = PlayerPrefs.GetString("tiempoN3");
                }
                else
                {
                    tiempoGuardado = "00:00";
                }
                tiempo.text = MayorTiempo(tiempoGuardado, tiempo.text);
                break;
            case 4:
                if (PlayerPrefs.HasKey("tiempoN4"))
                {
                    tiempoGuardado = PlayerPrefs.GetString("tiempoN4");
                }
                else
                {
                    tiempoGuardado = "00:00";
                }
                tiempo.text = MayorTiempo(tiempoGuardado, tiempo.text);
                break;
            default:
                if (PlayerPrefs.HasKey("tiempoN1"))
                {
                    tiempo.text = PlayerPrefs.GetString("tiempoN1");
                }
                else
                {
                    tiempo.text = "00:00";
                    PlayerPrefs.SetString("tiempoN1", "00:00");
                }

                if (PlayerPrefs.HasKey("tiempoN2"))
                {
                    tiempo2.text = PlayerPrefs.GetString("tiempoN2");
                }
                else
                {
                    tiempo2.text = "00:00";
                    PlayerPrefs.SetString("tiempoN2", "00:00");
                }

                if (PlayerPrefs.HasKey("tiempoN3"))
                {
                    tiempo3.text = PlayerPrefs.GetString("tiempoN3");
                }
                else
                {
                    tiempo3.text = "00:00";
                    PlayerPrefs.SetString("tiempoN3", "00:00");
                }

                if (PlayerPrefs.HasKey("tiempoN4"))
                {
                    tiempo4.text = PlayerPrefs.GetString("tiempoN4");
                }
                else
                {
                    tiempo4.text = "00:00";
                    PlayerPrefs.SetString("tiempoN4", "00:00");
                }
                break;
        }
    }

    public void SaveData()
    {
        switch (nivel)
        {
            case 1:
                String actual1 = PlayerPrefs.GetString("tiempoN1");
                PlayerPrefs.SetString("tiempoN1", MayorTiempo(tiempo.text, actual1));
                break;
            case 2:
                String actual2 = PlayerPrefs.GetString("tiempoN2");
                PlayerPrefs.SetString("tiempoN2", MayorTiempo(tiempo.text, actual2));
                break;
            case 3:
                String actual3 = PlayerPrefs.GetString("tiempoN3");
                PlayerPrefs.SetString("tiempoN3", MayorTiempo(tiempo.text, actual3));
                break;
            case 4:
                String actual4 = PlayerPrefs.GetString("tiempoN4");
                PlayerPrefs.SetString("tiempoN4", MayorTiempo(tiempo.text, actual4));
                break;
            default:
                break;
        }
    }

    public void DelateData()
    {
        PlayerPrefs.SetString("tiempoN1", "00:00");
        PlayerPrefs.SetString("tiempoN2", "00:00");
        PlayerPrefs.SetString("tiempoN3", "00:00");
        PlayerPrefs.SetString("tiempoN4", "00:00");
        LoadData();
    }

    private string MayorTiempo(string tiempo1, string tiempo2)
    {
        TimeSpan t1 = TimeSpan.Parse(tiempo1);
        TimeSpan t2 = TimeSpan.Parse(tiempo2);

        TimeSpan tiempoMasGrande = (t1 > t2) ? t1 : t2;

        return tiempoMasGrande.ToString(@"hh\:mm");
    }
}
