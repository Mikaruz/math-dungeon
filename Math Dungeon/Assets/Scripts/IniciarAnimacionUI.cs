using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarAnimacionUI : MonoBehaviour
{
    public UISpriteAnimation animacionMoneda;
    public UISpriteAnimation animacionGema;

    void Start()
    {
        // Llama a la función de inicio de la animación cuando comience el juego
        animacionMoneda.Func_PlayUIAnim();
        animacionGema.Func_PlayUIAnim();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
