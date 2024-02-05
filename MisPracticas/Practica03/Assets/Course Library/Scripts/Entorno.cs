using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entorno : MonoBehaviour
{
    public float speed = 10;

    public float getSpeed()
    {
        speed += 5;
        return speed;
    }
}
