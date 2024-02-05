using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coche" || other.gameObject.tag == "ladron" || other.gameObject.tag == "inocente" || other.gameObject.tag == "powerup" || other.gameObject.tag == "powerup-vida")
        {
            Destroy(other.gameObject);
        }
    }
}
