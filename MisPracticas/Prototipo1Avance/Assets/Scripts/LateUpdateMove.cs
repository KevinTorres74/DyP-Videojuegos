using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateUpdateMove : MonoBehaviour
{
    
    public float speed;

    void LateUpdate() {
        this.transform.Translate(Time.deltaTime * speed, 0, 0);
    }
}
