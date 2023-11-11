using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogos : MonoBehaviour
{
    [SerializeField] private MovimientoDelJugador movimientoJugador;
    [SerializeField] private GameObject simboloNPC;
    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TMP_Text dialogoTexto;
    [SerializeField, TextArea(4, 6)] private string[] lineasDeDialogo;

    private float tiempoDeTipeo = 0.05f;

    private bool jugadorEnRango;
    private bool empezoDialogo;
    private int lineaIndex;

    void Update()
    {
        if (jugadorEnRango && Input.GetButtonDown("Fire1"))
        {
            if (!empezoDialogo)
            {
                EmpezarDialogo();
            }else if(dialogoTexto.text == lineasDeDialogo[lineaIndex])
            {
                SiguienteLineaDialogo();
            }
            else
            {
                StopAllCoroutines();
                dialogoTexto.text = lineasDeDialogo[lineaIndex];
            }
        }
    }

    private void EmpezarDialogo()
    {
        empezoDialogo = true;
        dialogoPanel.SetActive(true);
        simboloNPC.SetActive(false);
        lineaIndex = 0;
        movimientoJugador.EstoyConversando();
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        dialogoTexto.text = string.Empty;

        foreach (char ch in lineasDeDialogo[lineaIndex])
        {
            dialogoTexto.text += ch;
            yield return new WaitForSeconds(tiempoDeTipeo);
        }
    }

    private void SiguienteLineaDialogo()
    {
        lineaIndex++;

        if(lineaIndex < lineasDeDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            empezoDialogo = false;
            dialogoPanel.SetActive(false);
            simboloNPC.SetActive(true);
            movimientoJugador.TerminarConversacion();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugadorEnRango = true;
            simboloNPC.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugadorEnRango = false;
            simboloNPC.SetActive(false);
        }
    }
}
