using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladron : MonoBehaviour
{
    public Transform player;
    public Vector3 origen;
    Animator anim;
    State currentState;
    
    void Start()
    {
        origen = transform.position;
        anim = this.GetComponent<Animator>();
        currentState = new Idle(this.gameObject, anim, player, true, origen);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(currentState.name);
        currentState = currentState.Process();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LadronLimite")
        {
            // Debug.Log("aaaaaaaaaa");
            bool derecha = currentState.derecha;
            currentState = new Return(this.gameObject, anim, player, derecha, origen);
        }
    }
}
