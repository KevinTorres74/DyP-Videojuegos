using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVe : MonoBehaviour
{

    public GameObject[] spawns = new GameObject[10];
    public GameObject[] cars = new GameObject[6];
    public GameObject[] boxSpawns = new GameObject[2];
    public GameObject[] powerBoxes = new GameObject[2];
    
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int c = Random.Range(0, 6);
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(cars[c], spawns[i].transform.position, spawns[i].transform.rotation);
            }
        }
        if (Random.Range(0, 2) == 0)
        {
            int j = Random.Range(0, 2);
            GameObject spawnedObject = Instantiate(powerBoxes[Random.Range(0, 2)], boxSpawns[j].transform.position, boxSpawns[j].transform.rotation);
            spawnedObject.transform.position += new Vector3(0f, 1f, 0f);
        }
    }
}
