using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tracker : MonoBehaviour
{
    public int contador;
    public TMP_Text tmp;
    public TMP_Text tmpDinero;
    public TMP_Text tmpPerdon;
    //public savePoints sp;

    void Start()
    {
        contador = 0;
        tmp.text = "0";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "coche")
        {
            contador++;
            tmp.text = contador.ToString();
            //sp.setPoints(contador);
        }
        else if (other.gameObject.tag == "ladron")
        {
            if (int.TryParse(tmpDinero.text, out int dinero))
            {
                if (dinero >= 10)
                {
                    dinero -= 10;
                }
                else if (dinero > 0)
                {
                    dinero = 0;
                }
                tmpDinero.text = dinero.ToString();
            }
        }
        else if (other.gameObject.tag == "inocente")
        {
            if (int.TryParse(tmpPerdon.text, out int perdon))
            {
                perdon += 10;
                tmpPerdon.text = perdon.ToString();
            }
        }
    }
}
