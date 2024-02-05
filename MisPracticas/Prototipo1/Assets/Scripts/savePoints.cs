using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NewBehaviourScript : MonoBehaviour
{
    public TMP_Text puntuaje;
    private int puntos;

    private void OnEnable(){
        Debug.Log("Se cargo la data");
        LoadData();
    }

    public void LoadData() {
        if (PlayerPrefs.HasKey("puntuaje"))
        {
            puntuaje.text = PlayerPrefs.GetInt("puntuaje").ToString();
        }else{
            puntuaje.text = "0";
            PlayerPrefs.SetInt("puntuaje", 0);
        }
    }

    public void SaveData() {
        PlayerPrefs.SetInt("puntuaje", puntos);
    }

    public void ResetData(){
        PlayerPrefs.DeleteAll();
    }

    public void setPoints(int points) {
        puntos = points;
    }
}
