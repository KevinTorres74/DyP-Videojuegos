using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogo : MonoBehaviour
{
    public List<GameObject> dialogos;
    public int i = 0;
    public int escena;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (i < dialogos.Count)
            {
                dialogos[i].SetActive(true);
                i ++;
            }
            else
            {
                SceneManager.LoadScene(escena);
            }
        }
    }
}
