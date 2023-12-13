using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonNivel : MonoBehaviour
{
    public void menu()
    {
        Debug.Log("MENU");
        SceneManager.LoadScene(0);
    }

    public void cargarIntro()
    {
        SceneManager.LoadScene(1);
    }

    public void cargarNivel1()
    {
        SceneManager.LoadScene(2);
    }

    public void cargarNivel2()
    {
        Debug.Log("NIVEL 2");
        SceneManager.LoadScene(3);
    }

    public void cargarNivel3()
    {
        SceneManager.LoadScene(4);
    }

    public void cargarNivel4()
    {
        SceneManager.LoadScene(5);
    }

    public void cargarCreditos()
    {
        SceneManager.LoadScene(6);
    }
}
