using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;
    private Animator animator;
  
    void Awake()
    {
       slider = GetComponent<Slider>();
       animator = GetComponent<Animator>();
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
        animator.SetTrigger("Golpe");
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
