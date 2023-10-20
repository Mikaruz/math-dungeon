using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectarMonedas : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(this.gameObject);
        }
    }
}
