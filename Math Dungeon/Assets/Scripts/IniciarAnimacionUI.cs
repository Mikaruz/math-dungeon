using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarAnimacionUI : MonoBehaviour
{
    public UISpriteAnimation animacionMoneda;
    public UISpriteAnimation animacionGema;

    void Start()
    {
        // Llama a la funci�n de inicio de la animaci�n cuando comience el juego
        animacionMoneda.Func_PlayUIAnim();
        animacionGema.Func_PlayUIAnim();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
