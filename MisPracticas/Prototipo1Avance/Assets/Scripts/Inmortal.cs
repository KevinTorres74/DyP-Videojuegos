using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmortal : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coche")
        {
            Destroy(other.gameObject);
        }
    }
}
