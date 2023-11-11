using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDelJugador : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;
    private bool enDialogo = false;


    [Header("Animación")]
    private Animator animator;

    [Header("Puntaje")]
    [SerializeField] private Puntaje puntajeMoneda;
    [SerializeField] private Puntaje puntajeGema;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!enDialogo)
        {
            movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

            animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

            if (Input.GetButtonDown("Jump"))
            {
                salto = true;
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }
      
    }

    public void EstoyConversando()
    {
        enDialogo = true;
        rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        animator.SetBool("enDialogo", enDialogo);
    }

    public void TerminarConversacion()
    {
        enDialogo = false;
        animator.SetBool("enDialogo", enDialogo);
    }


    private void FixedUpdate()
    {
        
            enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
            animator.SetBool("enSuelo", enSuelo);
        
            Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
            salto = false;
        
    }
   
    private void Mover(float mover, bool saltar)
    {
        if (!enDialogo)
        {
            Vector3 velocidadObjetivo = new Vector2(mover, rb2d.velocity.y);
            rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

            if (mover > 0 && !mirandoDerecha)
            {
                Girar();
            }
            else if (mover < 0 && mirandoDerecha)
            {
                Girar();
            }

            if (enSuelo && saltar)
            {
                enSuelo = false;

                rb2d.AddForce(new Vector2(0f, fuerzaDeSalto));
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moneda"))
        {
            puntajeMoneda.SumarPuntos(1);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Gema"))
        {
            puntajeGema.SumarPuntos(1);
            Destroy(collision.gameObject); 
        }
    }
}
