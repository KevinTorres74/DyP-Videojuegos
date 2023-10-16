using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaImnumidad : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        this.transform.Translate(Time.deltaTime * speed, 0, 0);
    }
}
