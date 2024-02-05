using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMove : MonoBehaviour
{
    public float speed, rotationSpeed;
    private float vm, hm;

    // Update is called once per frame
    void Update()
    {
        vm = Input.GetAxis("Vertical");
        hm = Input.GetAxis("Horizontal");
        this.transform.Translate(0, 0, Time.deltaTime * speed * vm);
        this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * hm);
    }
}