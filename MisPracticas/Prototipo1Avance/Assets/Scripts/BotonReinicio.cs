using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonReinicio : MonoBehaviour
{
    public void reiniciarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void regresar()
    {
        SceneManager.LoadScene(0);
    }
}
