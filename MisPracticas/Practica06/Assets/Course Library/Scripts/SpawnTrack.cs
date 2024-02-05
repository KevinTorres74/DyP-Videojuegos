using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrack : MonoBehaviour
{
    public GameObject track;
    public Transform spwan;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag  == "Player")
        {
            Instantiate(track, spwan.position, spwan.rotation);
        }
    }
}
