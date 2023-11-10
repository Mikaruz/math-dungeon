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

        // Refleja horizontalmente el sprite cuando est� fuera de la pantalla a la izquierda
        if (transform.position.x < -10f) // Ajusta este valor seg�n la posici�n fuera de la pantalla
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
