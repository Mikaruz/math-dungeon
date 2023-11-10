using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarAnimacionUI : MonoBehaviour
{
    public UISpriteAnimation animacionMoneda;
    public UISpriteAnimation animacionGema;

    void Start()
    {
        animacionMoneda.Func_PlayUIAnim();
        animacionGema.Func_PlayUIAnim();

    }
}
