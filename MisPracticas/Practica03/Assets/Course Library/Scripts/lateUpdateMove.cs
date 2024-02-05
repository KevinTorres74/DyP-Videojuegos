using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lateUpdateMove : MonoBehaviour
{
    public Entorno ent;

    private void Start()
    {
        ent = GameObject.Find("Entorno").GetComponent<Entorno>();
        speed = ent.getSpeed();
    }
    public float speed;

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.Translate(Time.deltaTime * speed, 0, 0); 
    }
}
