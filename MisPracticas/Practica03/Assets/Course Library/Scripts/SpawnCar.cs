using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    public GameObject[] spawns = new GameObject[4];
    public GameObject[] cars = new GameObject[4];

    int s, c;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<4; i++)
        {
            s = Random.Range(0, 4);
            c = Random.Range(0, 4);
            Instantiate(cars[c], spawns[s].transform.position, spawns[s].transform.rotation);
        }
        
    }

}
