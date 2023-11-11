using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscenas : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void Jugar()
    { 
        SceneManager.LoadScene(2);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Creditos()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
