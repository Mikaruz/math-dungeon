using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscenas : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Jugar()
    {
        
        SceneManager.LoadScene(1);

    }

    public void Salir()
    {
        Application.Quit();
    }
}
