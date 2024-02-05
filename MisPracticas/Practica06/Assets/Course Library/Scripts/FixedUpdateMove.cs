using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixed : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        this.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
