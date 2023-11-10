using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveMovimiento : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de vuelo
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Mueve el ave hacia la izquierda
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        // Refleja horizontalmente el sprite cuando está fuera de la pantalla a la izquierda
        if (transform.position.x < -10f) // Ajusta este valor según la posición fuera de la pantalla
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Caida"))
        {
            Destroy(this.gameObject);
        }
    }
}
