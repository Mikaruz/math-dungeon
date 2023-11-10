using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDelJugador : MonoBehaviour
{

    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private float vidaMaxima;
    [SerializeField] private BarraDeVida barraDeVida;

    

    [Header("Respawn")]
    private Vector3 respawnPoint;

    void Start()
    {
        respawnPoint = transform.position;
        vida = vidaMaxima;
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
                // Acciones para el estado de Game Over
                // Por ejemplo, puedes mostrar un mensaje de Game Over o reiniciar el nivel.
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
        else if (collision.tag == "VidaCorazon" && vida != vidaMaxima)
        {
            vida++;
            Destroy(collision.gameObject);
            barraDeVida.CambiarVidaActual(vida);
        }

    }
}
