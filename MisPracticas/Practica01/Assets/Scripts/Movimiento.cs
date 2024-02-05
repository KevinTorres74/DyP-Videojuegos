using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hm = Input.GetAxis("Horizontal"); //Movimiento en Horizontal - 0 1
        float vm = Input.GetAxis("Vertical"); //Movimiento en Vertical - 0 1

        Vector3 mov = new Vector3(hm, 0, vm);

        rb.AddForce(mov * speed);
    }
}
