using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMeshProUGUI.text = "x" + puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}
