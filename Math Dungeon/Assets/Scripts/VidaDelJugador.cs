using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDelJugador : MonoBehaviour
{

    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private float vidaTotal;
    [SerializeField] private BarraDeVida barraDeVida;

    [Header("Respawn")]
    private Vector3 respawnPoint;

    void Start()
    {
        respawnPoint = transform.position;
        vida = vidaTotal;
        barraDeVida.InicializarBarraDeVida(vida);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Caida")
        {
            vida--;
            barraDeVida.CambiarVidaActual(vida);

            if (vida <= 0)
            {
                Debug.Log("¡Game Over!");
            }
            else
            {
                transform.position = respawnPoint;
            }
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
        else if (collision.tag == "VidaCorazon" && vida != vidaTotal)
        {
            vida++;
            Destroy(collision.gameObject);
            barraDeVida.CambiarVidaActual(vida);
        }

    }
}
