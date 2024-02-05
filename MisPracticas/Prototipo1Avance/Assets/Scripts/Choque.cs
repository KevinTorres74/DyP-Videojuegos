using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Choque : MonoBehaviour
{
    public TMP_Text tmpDinero;
    public TMP_Text tmpPerdon;
    public GameObject player;
    public GameObject powerInmortal;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "ladron":
                Destroy(other.gameObject);
                if (int.TryParse(tmpDinero.text, out int dinero))
                {
                    dinero += 10;
                    tmpDinero.text = dinero.ToString();
                }
                break;

            case "inocente":
                Destroy(other.gameObject);
                if (int.TryParse(tmpPerdon.text, out int perdon))
                {
                    if (perdon >= 10)
                    {
                        perdon -= 10;
                    }
                    else if (perdon > 0)
                    {
                        perdon = 0;
                    }
                    tmpPerdon.text = perdon.ToString();
                }
                break;

            case "powerup":
                Destroy(other.gameObject);
                powerInmortal.SetActive(true);
                Invoke("DesactivarPowerInmortal", 10f);
                break;

            case "powerup-vida":
                UpdateMove updm = player.GetComponent<UpdateMove>();
                updm.SubeVida();
                Destroy(other.gameObject);
                break;
            
            default:
                break;
        }
    }

    void DesactivarPowerInmortal()
    {
        powerInmortal.SetActive(false);
    }
}
